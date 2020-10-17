using Microsoft.ML;
using Microsoft.ML.Vision;
using System;
using System.IO;
using System.Linq;

namespace ImageClassification
{
    class Program
    {
        static void Main()
        {
            var folder = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "Assets");
            var filePaths = Directory.GetFiles(folder, "*", SearchOption.AllDirectories);
            var images = filePaths.Select(item => new ImageData
            {
                Path = item,
                Label = Directory.GetParent(item).Name
            });
            var context = new MLContext();
            var samples = context.Data.LoadFromEnumerable(images);
            var estimator = context.Transforms.Conversion.MapValueToKey("LabelKey", "Label",
                keyOrdinality: Microsoft.ML.Transforms.ValueToKeyMappingEstimator.KeyOrdinality.ByValue);
            var pipelineAddImage = estimator
                .Append(context.Transforms.LoadRawImageBytes("Image", folder, "Path"));
            var samplesWithKeyAndImage = pipelineAddImage
                .Fit(samples)
                .Transform(samples);
            samplesWithKeyAndImage.Preview().RowView.ToList().ForEach(item=>Console.WriteLine($"{item.Values[0]}\n{item.Values[1]}\n{item.Values[2]}\n"));
            var options = new ImageClassificationTrainer.Options
            {
                Arch = ImageClassificationTrainer.Architecture.ResnetV250,
                Epoch = 100,
                BatchSize = 20,
                LearningRate = 0.05f,
                LabelColumnName = "LabelKey",
                FeatureColumnName = "Image",
                ValidationSet = samplesWithKeyAndImage
            };
            var pipeline = context.MulticlassClassification.Trainers.ImageClassification(options)
                .Append(context.Transforms.Conversion.MapKeyToValue("PredictedLabel"));
            var model = pipeline.Fit(samplesWithKeyAndImage);
            var engine = context.Model.CreatePredictionEngine<ImageDataUp, Prediction>(model);
            var folderTest = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "Test");
            var filePathsTest = Directory.GetFiles(folderTest, "*");
            var test = filePathsTest.Select(item => new ImageDataUp
            {
                Path = item,
                Image = File.ReadAllBytes(item)
            });
            Console.WriteLine("\n\n");
            foreach (var item in test)
            {
                Prediction prediction = new Prediction();
                engine.Predict(item, ref prediction);
                Console.WriteLine("Path: " + item.Path);
                Console.WriteLine("Label: " + prediction.PredictedLabel);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
