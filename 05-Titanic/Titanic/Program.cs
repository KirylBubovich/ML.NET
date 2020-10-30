using Microsoft.ML;
using Microsoft.ML.Trainers.LightGbm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Titanic
{
    class Program
    {
        static void Main()
        {
            string path = "train.csv";
            var context = new MLContext();
            var samples = context.Data.LoadFromTextFile<ModelInput>(path, hasHeader: true, separatorChar: ',', trimWhitespace: true, allowQuoting: true);
            samples.Preview(5).RowView.ToList().ForEach(item =>
                {
                    item.Values.ToList().ForEach(prop => Console.Write(prop.Value + ", "));
                    Console.WriteLine();
                }
            );
            var ttset = context.Data.TrainTestSplit(samples, testFraction: 0.1);
            var dataProcessPipeline = context.Transforms.Conversion.ConvertType("Survived", "Survived", Microsoft.ML.Data.DataKind.Boolean)
                                      .Append(context.Transforms.Categorical.OneHotEncoding(new[]
                                      { new InputOutputColumnPair("Sex", "Sex"), new InputOutputColumnPair("Embarked", "Embarked") }))
                                      .Append(context.Transforms.Categorical.OneHotHashEncoding(new[]
                                      { new InputOutputColumnPair("Cabin", "Cabin")}))
                                      .Append(context.Transforms.Text.FeaturizeText("Name", "Name"))
                                      .Append(context.Transforms.Text.FeaturizeText("Ticket", "Ticket"))
                                      .Append(context.Transforms.Concatenate("Features", new[]
                                      { "Sex", "Embarked", "Cabin", "Name",
                                          "Pclass", "Age", "SibSp", "Parch", "Fare", "Ticket" }));
            var trainerFT = context.BinaryClassification.Trainers.FastTree("Survived", "Features");
            var trainerLG = context.BinaryClassification.Trainers.LightGbm(
                new LightGbmBinaryTrainer.Options()
                {
                    NumberOfIterations = 100,
                    NumberOfLeaves = 28,
                    LabelColumnName = "Survived",
                    FeatureColumnName = "Features",
                    LearningRate = 0.2,
                    MinimumExampleCountPerLeaf = 10,
                    Booster = new GradientBooster.Options() { L2Regularization = 1, L1Regularization = 1 },
                    UseCategoricalSplit = true,
                    HandleMissingValue = true,
                    UseZeroAsMissingValue = false,
                    MinimumExampleCountPerGroup = 200,
                    MaximumCategoricalSplitPointCount = 64,
                    CategoricalSmoothing = 10,
                    L2CategoricalRegularization = 0.5
                });
            var trainerLR = context.BinaryClassification.Trainers.SdcaLogisticRegression("Survived", "Features");
            var trainerGam = context.BinaryClassification.Trainers.Gam("Survived", "Features");
            var trainerLbfLR = context.BinaryClassification.Trainers.LbfgsLogisticRegression("Survived", "Features");

            var trainingPipelineFT = dataProcessPipeline.Append(trainerFT);
            var trainingPipelineLG = dataProcessPipeline.Append(trainerLG);
            var trainingPipelineLR = dataProcessPipeline.Append(trainerLR);
            var trainingPipelineGam = dataProcessPipeline.Append(trainerGam);
            var trainingPipelineLbfLR = dataProcessPipeline.Append(trainerLbfLR);
            var modelFT = trainingPipelineFT.Fit(samples);
            var modelLG = trainingPipelineLG.Fit(samples);
            var modelLR = trainingPipelineLR.Fit(samples);
            var modelGam = trainingPipelineGam.Fit(samples);
            var modelLbfLR = trainingPipelineLbfLR.Fit(samples);
            Console.WriteLine("Training has finished!");
            int size = 5;
            IDataView[] tmp = new IDataView[size];
            tmp[0] = modelFT.Transform(samples);
            tmp[1] = modelLG.Transform(samples);
            tmp[2] = modelLR.Transform(samples);
            tmp[3] = modelGam.Transform(samples);
            tmp[4] = modelLbfLR.Transform(samples);
            for (int i = 0; i < size; ++i)
            {
                var metrics = context.BinaryClassification.Evaluate(tmp[i], "Survived");
                Console.WriteLine($"Model {i}:");
                Console.WriteLine("Accuracy: " + metrics.Accuracy);
                Console.WriteLine("F1 score: " + metrics.F1Score);
                Console.WriteLine("AUC ROC: " + metrics.AreaUnderRocCurve);
                Console.WriteLine("Log Loss: " + metrics.LogLoss);
            }
            PredictionEngine<ModelInput, ModelOutput>[] engines = new PredictionEngine<ModelInput, ModelOutput>[size];
            engines[0] = context.Model.CreatePredictionEngine<ModelInput, ModelOutput>(modelFT);
            engines[1] = context.Model.CreatePredictionEngine<ModelInput, ModelOutput>(modelLG);
            engines[2] = context.Model.CreatePredictionEngine<ModelInput, ModelOutput>(modelLR);
            engines[3] = context.Model.CreatePredictionEngine<ModelInput, ModelOutput>(modelGam);
            engines[4] = context.Model.CreatePredictionEngine<ModelInput, ModelOutput>(modelLbfLR);
            path = "test.csv";
            var test = context.Data.LoadFromTextFile<ModelInputTest>(path, hasHeader: true, separatorChar: ',', trimWhitespace: true, allowQuoting: true);
            var testData = test.Preview(int.MaxValue);
            var predictions = new Dictionary<int, bool>();
            foreach (var item in testData.RowView)
            {
                var sample = new ModelInput
                {
                    PassengerId = Convert.ToSingle(item.Values[0].Value),
                    Pclass = Convert.ToSingle(item.Values[1].Value),
                    Name = Convert.ToString(item.Values[2].Value),
                    Sex = Convert.ToString(item.Values[3].Value),
                    Age = Convert.ToSingle(item.Values[4].Value),
                    SibSp = Convert.ToSingle(item.Values[5].Value),
                    Parch = Convert.ToSingle(item.Values[6].Value),
                    Ticket = Convert.ToString(item.Values[7].Value),
                    Fare = Convert.ToSingle(item.Values[8].Value),
                    Cabin = Convert.ToString(item.Values[9].Value),
                    Embarked = Convert.ToString(item.Values[10].Value),
                };
                int[] res = new int[2];
                for (int i = 0; i < size; ++i)
                {
                    var result = engines[i].Predict(sample);
                    res[result.Prediction ? 1 : 0]++;
                }
                predictions.Add(Convert.ToInt32(item.Values[0].Value), res[1] > res[0]);
            }
            path = "achifal.csv";
            File.WriteAllText(path, "PassengerId,Survived\n");
            File.AppendAllLines(path, predictions.Select(keyval => keyval.Key.ToString() + "," + (keyval.Value ? "1" : "0")));
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
