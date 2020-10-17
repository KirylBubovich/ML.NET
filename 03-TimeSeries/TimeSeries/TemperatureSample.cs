using Microsoft.ML.Data;
using System;

namespace TimeSeries
{
    internal class TemperatureSample
    {
        [LoadColumn(0)]
        public DateTime Date { get; set; }
        [LoadColumn(1)]
        public float Value { get; set; }
    }
}