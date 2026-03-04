using fwd_bilvaerksted.ViewModels;

namespace fwd_bilvaerksted
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
