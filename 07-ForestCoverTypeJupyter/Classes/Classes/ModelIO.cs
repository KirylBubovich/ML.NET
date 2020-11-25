using Microsoft.ML.Data;
using System;

namespace Classes
{
    public class ModelInput
    {
        [ColumnName("Id"), LoadColumn(0)]
        public float Id { get; set; }


        [ColumnName("Elevation"), LoadColumn(1)]
        public float Elevation { get; set; }


        [ColumnName("Aspect"), LoadColumn(2)]
        public float Aspect { get; set; }


        [ColumnName("Slope"), LoadColumn(3)]
        public float Slope { get; set; }


        [ColumnName("Horizontal_Distance_To_Hydrology"), LoadColumn(4)]
        public float Horizontal_Distance_To_Hydrology { get; set; }


        [ColumnName("Vertical_Distance_To_Hydrology"), LoadColumn(5)]
        public float Vertical_Distance_To_Hydrology { get; set; }


        [ColumnName("Horizontal_Distance_To_Roadways"), LoadColumn(6)]
        public float Horizontal_Distance_To_Roadways { get; set; }


        [ColumnName("Hillshade_9am"), LoadColumn(7)]
        public float Hillshade_9am { get; set; }


        [ColumnName("Hillshade_Noon"), LoadColumn(8)]
        public float Hillshade_Noon { get; set; }


        [ColumnName("Hillshade_3pm"), LoadColumn(9)]
        public float Hillshade_3pm { get; set; }


        [ColumnName("Horizontal_Distance_To_Fire_Points"), LoadColumn(10)]
        public float Horizontal_Distance_To_Fire_Points { get; set; }


        [ColumnName("Wilderness_Area1"), LoadColumn(11)]
        public float Wilderness_Area1 { get; set; }


        [ColumnName("Wilderness_Area2"), LoadColumn(12)]
        public float Wilderness_Area2 { get; set; }


        [ColumnName("Wilderness_Area3"), LoadColumn(13)]
        public float Wilderness_Area3 { get; set; }


        [ColumnName("Wilderness_Area4"), LoadColumn(14)]
        public float Wilderness_Area4 { get; set; }


        [ColumnName("Soil_Type1"), LoadColumn(15)]
        public float Soil_Type1 { get; set; }


        [ColumnName("Soil_Type2"), LoadColumn(16)]
        public float Soil_Type2 { get; set; }


        [ColumnName("Soil_Type3"), LoadColumn(17)]
        public float Soil_Type3 { get; set; }


        [ColumnName("Soil_Type4"), LoadColumn(18)]
        public float Soil_Type4 { get; set; }


        [ColumnName("Soil_Type5"), LoadColumn(19)]
        public float Soil_Type5 { get; set; }


        [ColumnName("Soil_Type6"), LoadColumn(20)]
        public float Soil_Type6 { get; set; }


        [ColumnName("Soil_Type7"), LoadColumn(21)]
        public float Soil_Type7 { get; set; }


        [ColumnName("Soil_Type8"), LoadColumn(22)]
        public float Soil_Type8 { get; set; }


        [ColumnName("Soil_Type9"), LoadColumn(23)]
        public float Soil_Type9 { get; set; }


        [ColumnName("Soil_Type10"), LoadColumn(24)]
        public float Soil_Type10 { get; set; }


        [ColumnName("Soil_Type11"), LoadColumn(25)]
        public float Soil_Type11 { get; set; }


        [ColumnName("Soil_Type12"), LoadColumn(26)]
        public float Soil_Type12 { get; set; }


        [ColumnName("Soil_Type13"), LoadColumn(27)]
        public float Soil_Type13 { get; set; }


        [ColumnName("Soil_Type14"), LoadColumn(28)]
        public float Soil_Type14 { get; set; }


        [ColumnName("Soil_Type15"), LoadColumn(29)]
        public float Soil_Type15 { get; set; }


        [ColumnName("Soil_Type16"), LoadColumn(30)]
        public float Soil_Type16 { get; set; }


        [ColumnName("Soil_Type17"), LoadColumn(31)]
        public float Soil_Type17 { get; set; }


        [ColumnName("Soil_Type18"), LoadColumn(32)]
        public float Soil_Type18 { get; set; }


        [ColumnName("Soil_Type19"), LoadColumn(33)]
        public float Soil_Type19 { get; set; }


        [ColumnName("Soil_Type20"), LoadColumn(34)]
        public float Soil_Type20 { get; set; }


        [ColumnName("Soil_Type21"), LoadColumn(35)]
        public float Soil_Type21 { get; set; }


        [ColumnName("Soil_Type22"), LoadColumn(36)]
        public float Soil_Type22 { get; set; }


        [ColumnName("Soil_Type23"), LoadColumn(37)]
        public float Soil_Type23 { get; set; }


        [ColumnName("Soil_Type24"), LoadColumn(38)]
        public float Soil_Type24 { get; set; }


        [ColumnName("Soil_Type25"), LoadColumn(39)]
        public float Soil_Type25 { get; set; }


        [ColumnName("Soil_Type26"), LoadColumn(40)]
        public float Soil_Type26 { get; set; }


        [ColumnName("Soil_Type27"), LoadColumn(41)]
        public float Soil_Type27 { get; set; }


        [ColumnName("Soil_Type28"), LoadColumn(42)]
        public float Soil_Type28 { get; set; }


        [ColumnName("Soil_Type29"), LoadColumn(43)]
        public float Soil_Type29 { get; set; }


        [ColumnName("Soil_Type30"), LoadColumn(44)]
        public float Soil_Type30 { get; set; }


        [ColumnName("Soil_Type31"), LoadColumn(45)]
        public float Soil_Type31 { get; set; }


        [ColumnName("Soil_Type32"), LoadColumn(46)]
        public float Soil_Type32 { get; set; }


        [ColumnName("Soil_Type33"), LoadColumn(47)]
        public float Soil_Type33 { get; set; }


        [ColumnName("Soil_Type34"), LoadColumn(48)]
        public float Soil_Type34 { get; set; }


        [ColumnName("Soil_Type35"), LoadColumn(49)]
        public float Soil_Type35 { get; set; }


        [ColumnName("Soil_Type36"), LoadColumn(50)]
        public float Soil_Type36 { get; set; }


        [ColumnName("Soil_Type37"), LoadColumn(51)]
        public float Soil_Type37 { get; set; }


        [ColumnName("Soil_Type38"), LoadColumn(52)]
        public float Soil_Type38 { get; set; }


        [ColumnName("Soil_Type39"), LoadColumn(53)]
        public float Soil_Type39 { get; set; }


        [ColumnName("Soil_Type40"), LoadColumn(54)]
        public float Soil_Type40 { get; set; }


        [ColumnName("Cover_Type"), LoadColumn(55)]
        public string Cover_Type { get; set; }

        public ModelInput(ModelInputTest mit)
        {
            Id = mit.Id;
            Elevation = mit.Elevation;
            Aspect = mit.Aspect;
            Slope = mit.Slope;
            Horizontal_Distance_To_Hydrology = mit.Horizontal_Distance_To_Hydrology;
            Vertical_Distance_To_Hydrology = mit.Vertical_Distance_To_Hydrology;
            Horizontal_Distance_To_Roadways = mit.Horizontal_Distance_To_Roadways;
            Hillshade_9am = mit.Hillshade_9am;
            Hillshade_Noon = mit.Hillshade_Noon;
            Hillshade_3pm = mit.Hillshade_3pm;
            Horizontal_Distance_To_Fire_Points = mit.Horizontal_Distance_To_Fire_Points;
            Wilderness_Area1 = mit.Wilderness_Area1;
            Wilderness_Area2 = mit.Wilderness_Area2;
            Wilderness_Area3 = mit.Wilderness_Area3;
            Wilderness_Area4 = mit.Wilderness_Area4;
            Soil_Type1 = mit.Soil_Type1;
            Soil_Type2 = mit.Soil_Type2;
            Soil_Type3 = mit.Soil_Type3;
            Soil_Type4 = mit.Soil_Type4;
            Soil_Type5 = mit.Soil_Type5;
            Soil_Type6 = mit.Soil_Type6;
            Soil_Type7 = mit.Soil_Type7;
            Soil_Type8 = mit.Soil_Type8;
            Soil_Type9 = mit.Soil_Type9;
            Soil_Type10 = mit.Soil_Type10;
            Soil_Type11 = mit.Soil_Type11;
            Soil_Type12 = mit.Soil_Type12;
            Soil_Type13 = mit.Soil_Type13;
            Soil_Type14 = mit.Soil_Type14;
            Soil_Type15 = mit.Soil_Type15;
            Soil_Type16 = mit.Soil_Type16;
            Soil_Type17 = mit.Soil_Type17;
            Soil_Type18 = mit.Soil_Type18;
            Soil_Type19 = mit.Soil_Type19;
            Soil_Type20 = mit.Soil_Type20;
            Soil_Type21 = mit.Soil_Type21;
            Soil_Type22 = mit.Soil_Type22;
            Soil_Type23 = mit.Soil_Type23;
            Soil_Type24 = mit.Soil_Type24;
            Soil_Type25 = mit.Soil_Type25;
            Soil_Type26 = mit.Soil_Type26;
            Soil_Type27 = mit.Soil_Type27;
            Soil_Type28 = mit.Soil_Type28;
            Soil_Type29 = mit.Soil_Type29;
            Soil_Type30 = mit.Soil_Type30;
            Soil_Type31 = mit.Soil_Type31;
            Soil_Type32 = mit.Soil_Type32;
            Soil_Type33 = mit.Soil_Type33;
            Soil_Type34 = mit.Soil_Type34;
            Soil_Type35 = mit.Soil_Type35;
            Soil_Type36 = mit.Soil_Type36;
            Soil_Type37 = mit.Soil_Type37;
            Soil_Type38 = mit.Soil_Type38;
            Soil_Type39 = mit.Soil_Type39;
            Soil_Type40 = mit.Soil_Type40;
        }

        public ModelInput() { }
    }

    public class ModelOutput
    {
        [ColumnName("PredictedLabel")]
        public String Prediction { get; set; }
        public float[] Score { get; set; }
    }

    public class ModelInputTest
    {
        [ColumnName("Id"), LoadColumn(0)]
        public float Id { get; set; }


        [ColumnName("Elevation"), LoadColumn(1)]
        public float Elevation { get; set; }


        [ColumnName("Aspect"), LoadColumn(2)]
        public float Aspect { get; set; }


        [ColumnName("Slope"), LoadColumn(3)]
        public float Slope { get; set; }


        [ColumnName("Horizontal_Distance_To_Hydrology"), LoadColumn(4)]
        public float Horizontal_Distance_To_Hydrology { get; set; }


        [ColumnName("Vertical_Distance_To_Hydrology"), LoadColumn(5)]
        public float Vertical_Distance_To_Hydrology { get; set; }


        [ColumnName("Horizontal_Distance_To_Roadways"), LoadColumn(6)]
        public float Horizontal_Distance_To_Roadways { get; set; }


        [ColumnName("Hillshade_9am"), LoadColumn(7)]
        public float Hillshade_9am { get; set; }


        [ColumnName("Hillshade_Noon"), LoadColumn(8)]
        public float Hillshade_Noon { get; set; }


        [ColumnName("Hillshade_3pm"), LoadColumn(9)]
        public float Hillshade_3pm { get; set; }


        [ColumnName("Horizontal_Distance_To_Fire_Points"), LoadColumn(10)]
        public float Horizontal_Distance_To_Fire_Points { get; set; }


        [ColumnName("Wilderness_Area1"), LoadColumn(11)]
        public float Wilderness_Area1 { get; set; }


        [ColumnName("Wilderness_Area2"), LoadColumn(12)]
        public float Wilderness_Area2 { get; set; }


        [ColumnName("Wilderness_Area3"), LoadColumn(13)]
        public float Wilderness_Area3 { get; set; }


        [ColumnName("Wilderness_Area4"), LoadColumn(14)]
        public float Wilderness_Area4 { get; set; }


        [ColumnName("Soil_Type1"), LoadColumn(15)]
        public float Soil_Type1 { get; set; }


        [ColumnName("Soil_Type2"), LoadColumn(16)]
        public float Soil_Type2 { get; set; }


        [ColumnName("Soil_Type3"), LoadColumn(17)]
        public float Soil_Type3 { get; set; }


        [ColumnName("Soil_Type4"), LoadColumn(18)]
        public float Soil_Type4 { get; set; }


        [ColumnName("Soil_Type5"), LoadColumn(19)]
        public float Soil_Type5 { get; set; }


        [ColumnName("Soil_Type6"), LoadColumn(20)]
        public float Soil_Type6 { get; set; }


        [ColumnName("Soil_Type7"), LoadColumn(21)]
        public float Soil_Type7 { get; set; }


        [ColumnName("Soil_Type8"), LoadColumn(22)]
        public float Soil_Type8 { get; set; }


        [ColumnName("Soil_Type9"), LoadColumn(23)]
        public float Soil_Type9 { get; set; }


        [ColumnName("Soil_Type10"), LoadColumn(24)]
        public float Soil_Type10 { get; set; }


        [ColumnName("Soil_Type11"), LoadColumn(25)]
        public float Soil_Type11 { get; set; }


        [ColumnName("Soil_Type12"), LoadColumn(26)]
        public float Soil_Type12 { get; set; }


        [ColumnName("Soil_Type13"), LoadColumn(27)]
        public float Soil_Type13 { get; set; }


        [ColumnName("Soil_Type14"), LoadColumn(28)]
        public float Soil_Type14 { get; set; }


        [ColumnName("Soil_Type15"), LoadColumn(29)]
        public float Soil_Type15 { get; set; }


        [ColumnName("Soil_Type16"), LoadColumn(30)]
        public float Soil_Type16 { get; set; }


        [ColumnName("Soil_Type17"), LoadColumn(31)]
        public float Soil_Type17 { get; set; }


        [ColumnName("Soil_Type18"), LoadColumn(32)]
        public float Soil_Type18 { get; set; }


        [ColumnName("Soil_Type19"), LoadColumn(33)]
        public float Soil_Type19 { get; set; }


        [ColumnName("Soil_Type20"), LoadColumn(34)]
        public float Soil_Type20 { get; set; }


        [ColumnName("Soil_Type21"), LoadColumn(35)]
        public float Soil_Type21 { get; set; }


        [ColumnName("Soil_Type22"), LoadColumn(36)]
        public float Soil_Type22 { get; set; }


        [ColumnName("Soil_Type23"), LoadColumn(37)]
        public float Soil_Type23 { get; set; }


        [ColumnName("Soil_Type24"), LoadColumn(38)]
        public float Soil_Type24 { get; set; }


        [ColumnName("Soil_Type25"), LoadColumn(39)]
        public float Soil_Type25 { get; set; }


        [ColumnName("Soil_Type26"), LoadColumn(40)]
        public float Soil_Type26 { get; set; }


        [ColumnName("Soil_Type27"), LoadColumn(41)]
        public float Soil_Type27 { get; set; }


        [ColumnName("Soil_Type28"), LoadColumn(42)]
        public float Soil_Type28 { get; set; }


        [ColumnName("Soil_Type29"), LoadColumn(43)]
        public float Soil_Type29 { get; set; }


        [ColumnName("Soil_Type30"), LoadColumn(44)]
        public float Soil_Type30 { get; set; }


        [ColumnName("Soil_Type31"), LoadColumn(45)]
        public float Soil_Type31 { get; set; }


        [ColumnName("Soil_Type32"), LoadColumn(46)]
        public float Soil_Type32 { get; set; }


        [ColumnName("Soil_Type33"), LoadColumn(47)]
        public float Soil_Type33 { get; set; }


        [ColumnName("Soil_Type34"), LoadColumn(48)]
        public float Soil_Type34 { get; set; }


        [ColumnName("Soil_Type35"), LoadColumn(49)]
        public float Soil_Type35 { get; set; }


        [ColumnName("Soil_Type36"), LoadColumn(50)]
        public float Soil_Type36 { get; set; }


        [ColumnName("Soil_Type37"), LoadColumn(51)]
        public float Soil_Type37 { get; set; }


        [ColumnName("Soil_Type38"), LoadColumn(52)]
        public float Soil_Type38 { get; set; }


        [ColumnName("Soil_Type39"), LoadColumn(53)]
        public float Soil_Type39 { get; set; }


        [ColumnName("Soil_Type40"), LoadColumn(54)]
        public float Soil_Type40 { get; set; }
    }

}
