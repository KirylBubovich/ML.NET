    using Microsoft.ML;
    using Microsoft.ML.Transforms.TimeSeries;
    using System;
using System.Linq;

namespace TimeSeries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MLContext();
            var samples = context.Data.LoadFromTextFile<TemperatureSample>("daily-minimum-temperatures-in-me.csv",
                hasHeader: true, separatorChar: ',');
            var pipeline = context.Forecasting.ForecastBySsa(
                "Values",
                nameof(TemperatureSample.Value),
                windowSize: 365 * 2,
                seriesLength: 365*4,
                trainSize: 365*4 + 1,
                horizon: 365
            );
            var model = pipeline.Fit(samples);
            var engine = model.CreateTimeSeriesEngine<TemperatureSample, TemperatureForecast>(context);
            var forecast = engine.Predict();
            foreach (var item in forecast.Values)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
