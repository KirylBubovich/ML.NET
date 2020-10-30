using Microsoft.ML.Data;

namespace LinearRegression
{
    internal class Prediction
    {
        [ColumnName("Score")]
        public float y;
    }
}