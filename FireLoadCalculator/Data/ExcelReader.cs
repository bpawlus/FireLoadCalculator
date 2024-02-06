using IronXL;

namespace FireLoadCalculator.Data
{
    public class ExcelReader
    {
        WorkBook workbook;
        WorkSheet sheetWaterSupply;
        WorkSheet sheetFireTime;

        public ExcelReader() {
            workbook = WorkBook.Load(Constants.ExcelPath);

            sheetWaterSupply = workbook.WorkSheets[0];
            sheetFireTime = workbook.WorkSheets[1];


            return;
        }

        public int GetWaterSupplyEfficiency(double fireZoneArea, double fireLoadDensity)
        {
            var valuesMinFireZone = sheetWaterSupply["C2:I2"].ToArray();
            var valuesMinFireLoadDensity = sheetWaterSupply["B3:B8"].ToArray();

            int fireZoneIndex = 0;
            for (int i = 0; i < valuesMinFireZone.Length-1; i++)
            {
                if (fireZoneArea < valuesMinFireZone[i+1].IntValue) break;
                fireZoneIndex++;
            }

            int fireLoadDensityIndex = 0;
            for (int j = 0; j < valuesMinFireLoadDensity.Length-1; j++)
            {
                if (fireLoadDensity < valuesMinFireLoadDensity[j+1].IntValue) break;
                fireLoadDensityIndex++;
            }

            char column = (char)(67 + fireZoneIndex);
            string row = (fireLoadDensityIndex + 3).ToString();

            return sheetWaterSupply[string.Concat(column, row)].IntValue;
        }

        public double GetFireTime(double fireLoadDensity)
        {
            var valuesFireLoadDensity = sheetFireTime["A2:A10"].ToArray();
            var valuesDurationOfFire = sheetFireTime["B2:B10"].ToArray();


            for (int i = 0; i < valuesFireLoadDensity.Length - 1; i++)
            {
                if (fireLoadDensity < valuesFireLoadDensity[i + 1].IntValue)
                {
                    var prev = valuesFireLoadDensity[i].DoubleValue;
                    var next = valuesFireLoadDensity[i + 1].DoubleValue;
                    var tonext = next - fireLoadDensity;

                    var range = next - prev;
                    var addToHour = (1 - (tonext / range));

                    var hour = valuesDurationOfFire[i].IntValue;
                    return hour + addToHour;
                }
            }

            return -1;
        }
    }
}
