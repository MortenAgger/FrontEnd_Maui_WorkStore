using fwd_bilvaerksted.ViewModels;

namespace fwd_bilvaerksted.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
