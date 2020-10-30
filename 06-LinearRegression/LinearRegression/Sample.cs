using Microsoft.ML.Data;

namespace LinearRegression
{
    internal class Sample
    {
        [LoadColumn(0)]
        public float x;
        [LoadColumn(1)]
        public float y;
    }
}