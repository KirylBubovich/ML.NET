using Microsoft.ML.Data;

namespace Titanic
{
    internal class ModelInputTest
    {
        [ColumnName("PassengerId"), LoadColumn(0)]
        public float PassengerId { get; set; }


        [ColumnName("Pclass"), LoadColumn(1)]
        public float Pclass { get; set; }


        [ColumnName("Name"), LoadColumn(2)]
        public string Name { get; set; }


        [ColumnName("Sex"), LoadColumn(3)]
        public string Sex { get; set; }


        [ColumnName("Age"), LoadColumn(4)]
        public float Age { get; set; }


        [ColumnName("SibSp"), LoadColumn(5)]
        public float SibSp { get; set; }


        [ColumnName("Parch"), LoadColumn(6)]
        public float Parch { get; set; }


        [ColumnName("Ticket"), LoadColumn(7)]
        public string Ticket { get; set; }


        [ColumnName("Fare"), LoadColumn(8)]
        public float Fare { get; set; }


        [ColumnName("Cabin"), LoadColumn(9)]
        public string Cabin { get; set; }


        [ColumnName("Embarked"), LoadColumn(10)]
        public string Embarked { get; set; }
    }
}