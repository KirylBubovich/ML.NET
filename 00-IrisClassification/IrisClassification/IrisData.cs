using Microsoft.ML.Data;

namespace IrisClassification
{
    class IrisData
    {
        [LoadColumn(0)]
        public float SepalLength;

        [LoadColumn(1)]
        public float SepalWidth;

        [LoadColumn(2)]
        public float PetalLength;

        [LoadColumn(3)]
        public float PetalWidth;

        [LoadColumn(4)]
        public string Label;

        public void SetProperty(string property, float value)
        {
            switch (property)
            {
                case "SepalLength":
                    SepalLength = value;
                    break;
                case "SepalWidth":
                    SepalWidth = value;
                    break;
                case "PetalLength":
                    PetalLength = value;
                    break;
                case "PetalWidth":
                    PetalWidth = value;
                    break;
            }
        }
    }

    public class LabelPrediction
    {
        [ColumnName("PredictedLabel")]
        public uint PredictedLabelId;
    }
}
