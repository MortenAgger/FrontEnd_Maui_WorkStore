using fwd_bilvaerksted.ViewModels;

namespace fwd_bilvaerksted.Pages
{
public partial class BookWorkOrder : ContentPage
{
	public BookWorkOrder(WorkOrderViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
}

