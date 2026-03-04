using fwd_bilvaerksted.Data;
using fwd_bilvaerksted.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace fwd_bilvaerksted.ViewModels
{
    public partial class WorkOrderViewModel : ObservableObject
    {
        private readonly Database _database;

        [ObservableProperty] private string name = "";
        [ObservableProperty] private string address = "";
        [ObservableProperty] private string brand = "";
        [ObservableProperty] private string model = "";
        [ObservableProperty] private string regNumber = "";
        [ObservableProperty] private DateTime selectedDate = DateTime.Today;
        [ObservableProperty] private TimeSpan selectedTime = new TimeSpan(8, 0, 0);
        [ObservableProperty] private string jobDescription = "";

        public WorkOrderViewModel(Database database)
        {
            _database = database;
        }

        [RelayCommand]
        private async Task SaveOrder()
        {
            var timeOfDelivery = SelectedDate.Add(SelectedTime);
            var order = new WorkOrder
            {
                Name = Name,
                Address = Address,
                Brand = Brand,
                Model = Model,
                RegNumber = RegNumber,
                TimeOfDelivery = timeOfDelivery,
                JobDescription = JobDescription
            };
            await _database.AddModel(order);
            await Shell.Current.GoToAsync("..");
        }
    }
}
