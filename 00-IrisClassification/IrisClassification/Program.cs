using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using XPlot.Plotly;

namespace IrisClassification
{
    class Program
    {
        static readonly string _dataPath = "Assets\\iris.csv";
        static void Main()
        {
            var mlContext = new MLContext(seed: 0);
            IDataView dataView = mlContext.Data.LoadFromTextFile<IrisData>(
                _dataPath, hasHeader: false, separatorChar: ','
                );
            dataView = mlContext.Data.ShuffleRows(dataView, seed: 42);
            var ttSet = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
            string featuresColumnName = "Features";
            var pipeline = mlContext.Transforms
                .Concatenate(featuresColumnName, "SepalLength", "SepalWidth", "PetalLength", "PetalWidth")
                .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "Label",
                inputColumnName: "Label"))
                                  .AppendCacheCheckpoint(mlContext)
                .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy(labelColumnName: "Label",
                featureColumnName: featuresColumnName));
            var model = pipeline.Fit(ttSet.TrainSet);
            var predictions = model.Transform(ttSet.TrainSet);
            var metrics = mlContext.MulticlassClassification.Evaluate(predictions);
            var predictor = mlContext.Model.CreatePredictionEngine<IrisData, LabelPrediction>(model);
            Console.WriteLine($"Macro accuracy: {metrics.MacroAccuracy}\n\n");
            int mistakesCount = 0;
            foreach (var item in ttSet.TestSet.Preview(150).RowView)
            {
                var sample = new IrisData();
                foreach (var property in item.Values)
                {
                    if (property.Key != "Label")
                    {
                        Console.Write(property + " ");
                        sample.SetProperty(property.Key, (float)property.Value);
                    }
                }
                var prediction = predictor.Predict(sample);
                Console.WriteLine("\nReal label:" + item.Values[^1].Value);
                string predictedLabel = prediction.PredictedLabelId == 1 ? "Versicolor" :
                    prediction.PredictedLabelId == 2 ? "Setosa" : "Virginica";
                Console.WriteLine($"Predicted label: {predictedLabel}\n");
                mistakesCount += predictedLabel == item.Values[^1].Value.ToString() ? 0 : 1;
            }
            Console.WriteLine($"Mistakes: {mistakesCount}");
            Console.ReadKey();
        }
    }
}
