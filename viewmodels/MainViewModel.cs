using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace fwd_bilvaerksted.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task BookNewOrder()
        {
            await Shell.Current.GoToAsync("BookWorkOrder");
        }

        [RelayCommand]
        private async Task GoToOrderOverview()
        {
            await Shell.Current.GoToAsync("OrderOverview");
        }

        [RelayCommand]
        private async Task GoToCreateInvoice()
        {
            await Shell.Current.GoToAsync("CreateInvoice");
        }

        [RelayCommand]
        private async Task GoToViewInvoices()
        {
            await Shell.Current.GoToAsync("ViewInvoices");
        }
    }
}
