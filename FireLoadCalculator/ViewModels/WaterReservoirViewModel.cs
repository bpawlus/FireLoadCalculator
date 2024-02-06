using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireLoadCalculator.ViewModels
{
    public partial class WaterReservoirViewModel : ObservableObject
    {
        [ObservableProperty]
        public string totalFireLoadDensity;
        [ObservableProperty]
        public string totalArea;
        [ObservableProperty]
        public string externalWater;

        [ObservableProperty]
        public string waterRequired;
        [ObservableProperty]
        public string missingWater;
        [ObservableProperty]
        public string fireTime;
        [ObservableProperty]
        public string fireWaterTankCapacity;

        private double? waterRequiredAsDecimal;
        private double? missingWaterAsDecimal;
        private double? fireTimeAsDecimal;
        private double? fireWaterTankCapacityAsDecimal;

        public WaterReservoirViewModel()
        {
            totalFireLoadDensity = string.Empty;
            totalArea = string.Empty;
            externalWater = string.Empty;
        }

        public async Task SetInternalData(bool useInternal)
        {
            if(useInternal)
            {
                TotalArea = (await Constants.Room_DB.GetItemsTotalArea()).ToString();
                TotalFireLoadDensity = await Constants.RoomMaterial_DB.GetFireLoadDensityAllRooms();
            }
            else
            {
                TotalArea = Constants.TotalAreaCache;
                TotalFireLoadDensity = Constants.TotalFireLoadDensityCache;
            }
        }

        private void UpdateWaterRequired()
        {
            try
            {
                var totalAreaDouble = Double.Parse(TotalArea);
                var totalFireLoadDensityDouble = Double.Parse(TotalFireLoadDensity);

                waterRequiredAsDecimal = Constants.ExcelReader.GetWaterSupplyEfficiency(totalAreaDouble, totalFireLoadDensityDouble);
                WaterRequired = String.Format("{0:0.##}", waterRequiredAsDecimal);
            }
            catch
            {
                waterRequiredAsDecimal = null;
                WaterRequired = Resources.Strings.AppResources.WaterReservoirField4Error;
            }
        }

        private void UpdateMissingWater()
        {
            try
            {
                var waterRequireDouble = (double)waterRequiredAsDecimal;
                var externalWaterDouble = Double.Parse(ExternalWater);

                var difference = externalWaterDouble - waterRequireDouble;
                MissingWater = difference < 0 ? String.Format("{0:0.##}", -difference) : Resources.Strings.AppResources.WaterReservoirField5NoNeed;
                missingWaterAsDecimal = difference < 0 ? -difference : 0;
            }
            catch
            {
                MissingWater = Resources.Strings.AppResources.WaterReservoirField4Error;
                missingWaterAsDecimal = null;
            }
        }

        private void UpdateFireTime()
        {
            try
            {
                var totalFireLoadDensityDouble = Double.Parse(TotalFireLoadDensity);

                var fireTimeDouble = Constants.ExcelReader.GetFireTime(totalFireLoadDensityDouble);
                if (fireTimeDouble != -1)
                {
                    var hours = Math.Floor(fireTimeDouble);
                    var mins = (fireTimeDouble - hours) * 60;

                    mins = Math.Round(mins / 5.0) * 5;
                    if (mins == 60)
                    {
                        mins = 0;
                        hours++;
                    }

                    FireTime = String.Concat(hours, "h ", mins, "m");
                    fireTimeAsDecimal = fireTimeDouble;
                }
                else
                {
                    FireTime = ">8h";
                    fireTimeAsDecimal = fireTimeDouble;
                }
            }
            catch
            {
                FireTime = Resources.Strings.AppResources.WaterReservoirField4Error;
                fireTimeAsDecimal = null;
            }
        }

        private void UpdateFireWaterTankCapacity()
        {
            try
            {
                var missingWaterDouble = (double)missingWaterAsDecimal;
                if (missingWaterDouble == 0)
                {
                    fireWaterTankCapacityAsDecimal = 0;
                    FireWaterTankCapacity = Resources.Strings.AppResources.WaterReservoirField5NoNeed;
                    return;
                }

                var fireTimeSecondsDouble = (double)fireTimeAsDecimal * 3600;
                if (fireTimeSecondsDouble > 0)
                {
                    fireWaterTankCapacityAsDecimal = missingWaterDouble * fireTimeSecondsDouble / 1000;
                    FireWaterTankCapacity = String.Format("{0:0.##}", fireWaterTankCapacityAsDecimal);
                }
                else
                {
                    fireWaterTankCapacityAsDecimal = -1;
                    FireWaterTankCapacity = Resources.Strings.AppResources.WaterReservoirField7VeryHigh;
                }
            }
            catch
            {
                fireWaterTankCapacityAsDecimal = null;
                FireWaterTankCapacity = Resources.Strings.AppResources.WaterReservoirField4Error;
            }
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch (e.PropertyName)
            {
                case nameof(TotalArea):
                    UpdateWaterRequired();

                    UpdateMissingWater();

                    UpdateFireWaterTankCapacity();
                    break;
                case nameof(TotalFireLoadDensity):
                    UpdateWaterRequired();

                    UpdateMissingWater();

                    UpdateFireTime();

                    UpdateFireWaterTankCapacity();
                    break;
                case nameof(ExternalWater):
                    UpdateMissingWater();

                    UpdateMissingWater();

                    UpdateFireWaterTankCapacity();
                    break;
            }

        }
    }
}
