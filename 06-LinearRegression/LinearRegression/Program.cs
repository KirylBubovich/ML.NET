using Microsoft.ML;
using System;
using System.IO;
using System.Linq;

namespace LinearRegression
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "train.csv";
            var context = new MLContext();
            var trainSamples = context.Data.LoadFromTextFile<Sample>(path, hasHeader:true, separatorChar:',');
            path = "test.csv";
            var testSamples = context.Data.LoadFromTextFile<Sample>(path, hasHeader: true, separatorChar: ',');
            var pipeline = context.Transforms.CopyColumns("Label", "y").Append(
                context.Transforms.Concatenate("Features", new[] { "x" }).Append(
                context.Regression.Trainers.FastForest()
                ));
            var model = pipeline.Fit(trainSamples);
            var engine = context.Model.CreatePredictionEngine<Sample, Prediction>(model);
            var predictions = model.Transform(trainSamples);
            var metrics = context.Regression.Evaluate(predictions, "Label", "Score");
            Console.WriteLine("Rsquared: " + metrics.RSquared);
            Console.WriteLine("Loss function: " + metrics.LossFunction);
            Console.WriteLine("Mean absolute error: " + metrics.MeanAbsoluteError);
            foreach (var item in testSamples.Preview().RowView)
            {
                var tmp = engine.Predict(new Sample() { x = Convert.ToSingle(item.Values[0].Value) });
                Console.WriteLine(item.Values[0].Value + " " + tmp.y);
                Console.WriteLine(item.Values[0].Value + " " + item.Values[1].Value);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
