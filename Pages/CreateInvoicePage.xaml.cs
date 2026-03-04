using fwd_bilvaerksted.ViewModels;

namespace fwd_bilvaerksted.Pages
{
    public partial class CreateInvoicePage : ContentPage
    {
        public CreateInvoicePage(CreateInvoiceViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
