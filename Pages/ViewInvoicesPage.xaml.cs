using fwd_bilvaerksted.ViewModels;

namespace fwd_bilvaerksted.Pages
{
    public partial class ViewInvoicesPage : ContentPage
    {
        public ViewInvoicesPage(ViewInvoicesViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is ViewInvoicesViewModel vm)
                _ = vm.LoadInvoicesCommand.ExecuteAsync(null);
        }
    }
}
