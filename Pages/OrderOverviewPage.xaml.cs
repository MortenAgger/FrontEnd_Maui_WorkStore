using fwd_bilvaerksted.ViewModels;

namespace fwd_bilvaerksted.Pages
{
    public partial class OrderOverviewPage : ContentPage
    {
        public OrderOverviewPage(OrderOverviewViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is OrderOverviewViewModel vm)
                _ = vm.LoadOrdersCommand.ExecuteAsync(null);
        }
    }
}
