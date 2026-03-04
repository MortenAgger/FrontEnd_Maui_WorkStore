using SQLite;
using CommunityToolkit.Mvvm.ComponentModel;

namespace fwd_bilvaerksted.Models
{
    public partial class Invoice : ObservableObject
    {
        [ObservableProperty]
        [property: PrimaryKey]
        [property: AutoIncrement]
        private int id;

        [ObservableProperty] private int workOrderId;
        [ObservableProperty] private string mechanicName = "";
        [ObservableProperty] private string materialsDescription = "";
        [ObservableProperty] private double materialsPrice;
        [ObservableProperty] private double hours;
        [ObservableProperty] private double hourlyRate;

        [Ignore]
        public double Total => MaterialsPrice + (Hours * HourlyRate);
    }
}
