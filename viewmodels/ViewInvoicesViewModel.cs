using fwd_bilvaerksted.Data;
using fwd_bilvaerksted.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace fwd_bilvaerksted.ViewModels
{
    public partial class ViewInvoicesViewModel : ObservableObject
    {
        private readonly Database _database;

        [ObservableProperty] private string searchText = "";
        [ObservableProperty] private ObservableCollection<Invoice> invoices = new();
        [ObservableProperty] private ObservableCollection<Invoice> filteredInvoices = new();

        public ViewInvoicesViewModel(Database database)
        {
            _database = database;
        }

        [RelayCommand]
        private async Task LoadInvoices()
        {
            var list = await _database.GetInvoices();
            Invoices.Clear();
            foreach (var i in list)
                Invoices.Add(i);
            ApplyFilter();
        }

        partial void OnSearchTextChanged(string value)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            FilteredInvoices.Clear();
            var text = (SearchText ?? "").ToLower();
            foreach (var inv in Invoices)
            {
                if (string.IsNullOrEmpty(text) ||
                    (inv.MechanicName?.ToLower().Contains(text) == true) ||
                    inv.WorkOrderId.ToString().Contains(text) || inv.Id.ToString().Contains(text))
                    FilteredInvoices.Add(inv);
            }
        }
    }
}
