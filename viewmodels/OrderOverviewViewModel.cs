using fwd_bilvaerksted.Data;
using fwd_bilvaerksted.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace fwd_bilvaerksted.ViewModels
{
    public partial class OrderOverviewViewModel : ObservableObject
    {
        private readonly Database _database;

        [ObservableProperty] private DateTime selectedDate = DateTime.Today;
        [ObservableProperty] private ObservableCollection<WorkOrder> orders = new();

        public OrderOverviewViewModel(Database database)
        {
            _database = database;
        }

        [RelayCommand]
        private async Task LoadOrders()
        {
            var list = await _database.GetWorkOrdersByDate(SelectedDate);
            Orders.Clear();
            foreach (var o in list)
                Orders.Add(o);
        }

        partial void OnSelectedDateChanged(DateTime value)
        {
            _ = LoadOrders();
        }
    }
}
