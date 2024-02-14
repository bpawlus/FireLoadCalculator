using FastExcel;
using SQLitePCL;
using System.Diagnostics;
using static SQLite.TableMapping;


namespace FireLoadCalculator.Data
{
    public class ExcelReader
    {
        public ExcelReader() {
        }

        public int GetWaterSupplyEfficiency(double fireZoneArea, double fireLoadDensity)
        {
            using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(new FileInfo(Constants.ExcelPath)))
            {
                var sheetWaterSupply = fastExcel.Read(1);
                var rows = sheetWaterSupply.Rows.ToArray();

                FastExcel.Cell[] valuesMinFireZoneCells = rows[1].Cells.ToArray().Skip(1).Take(rows[1].Cells.Count() - 1).ToArray();
                List<FastExcel.Cell> valuesMinFireLoadDensityCells = new List<FastExcel.Cell> { rows[2].Cells.ToArray()[1] };
                for (int i = 3; i < rows.Count(); i++)
                    valuesMinFireLoadDensityCells.Add(rows[i].Cells.ToArray()[1]);

                var valuesMinFireZone = Array.ConvertAll<FastExcel.Cell, int>(valuesMinFireZoneCells, (o) => Int32.Parse((string)o.Value));
                var valuesMinFireLoadDensity = Array.ConvertAll<FastExcel.Cell, int>(valuesMinFireLoadDensityCells.ToArray(), (o) => Int32.Parse((string)o.Value));


                int fireZoneIndex = 0;
                for (int i = 0; i < valuesMinFireZone.Length - 1; i++)
                {
                    if (fireZoneArea < valuesMinFireZone[i + 1]) break;
                    fireZoneIndex++;
                }

                int fireLoadDensityIndex = 0;
                for (int j = 0; j < valuesMinFireLoadDensity.Length - 1; j++)
                {
                    if (fireLoadDensity < valuesMinFireLoadDensity[j + 1]) break;
                    fireLoadDensityIndex++;
                }

                int column = fireZoneIndex;
                int row = fireLoadDensityIndex;

                return Int32.Parse((string)rows[2+row].Cells.ToArray()[2+column].Value);
            }

            return 0;
        }

        public double GetFireTime(double fireLoadDensity)
        {
            using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(new FileInfo(Constants.ExcelPath)))
            {
                var sheetFireTime = fastExcel.Read(2);
                var rows = sheetFireTime.Rows.ToArray();

                List<double> valuesFireLoadDensity = new List<double>();
                List<double> valuesDurationOfFire = new List<double>();
                for (int i = 1; i < rows.Count()-1; i++)
                {
                    valuesFireLoadDensity.Add(Double.Parse((string)rows[i].Cells.ToArray()[0].Value));
                    valuesDurationOfFire.Add(Double.Parse((string)rows[i].Cells.ToArray()[1].Value));
                }

                for (int i = 0; i < valuesFireLoadDensity.Count - 1; i++)
                {
                    if (fireLoadDensity < valuesFireLoadDensity[i + 1])
                    {
                        var prev = valuesFireLoadDensity[i];
                        var next = valuesFireLoadDensity[i + 1];
                        var tonext = next - fireLoadDensity;

                        var range = next - prev;
                        var addToHour = (1 - (tonext / range));

                        var hour = valuesDurationOfFire[i];
                        return hour + addToHour;
                    }
                }
            }
            return -1;
        }
    }
}
