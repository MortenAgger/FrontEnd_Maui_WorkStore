using fwd_bilvaerksted.Data;
using fwd_bilvaerksted.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace fwd_bilvaerksted.ViewModels
{
    public partial class CreateInvoiceViewModel : ObservableObject
    {
        private readonly Database _database;

        [ObservableProperty] private string workOrderIdText = "";
        [ObservableProperty] private string mechanicName = "";
        [ObservableProperty] private string materialsDescription = "";
        [ObservableProperty] private string materialsPriceText = "";
        [ObservableProperty] private string hoursText = "";
        [ObservableProperty] private string hourlyRateText = "400";

        public CreateInvoiceViewModel(Database database)
        {
            _database = database;
        }

        [RelayCommand]
        private async Task SaveInvoice()
        {
            if (!int.TryParse(WorkOrderIdText, out var workOrderId)) return;
            double.TryParse(MaterialsPriceText?.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var materialsPrice);
            double.TryParse(HoursText?.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var hours);
            double.TryParse(HourlyRateText?.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var hourlyRate);
            if (hourlyRate == 0) hourlyRate = 400;
            var invoice = new Invoice
            {
                WorkOrderId = workOrderId,
                MechanicName = MechanicName,
                MaterialsDescription = MaterialsDescription,
                MaterialsPrice = materialsPrice,
                Hours = hours,
                HourlyRate = hourlyRate
            };
            await _database.AddInvoice(invoice);
            await Shell.Current.GoToAsync("..");
        }
    }
}
