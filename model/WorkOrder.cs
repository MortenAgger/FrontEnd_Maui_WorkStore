using SQLite;
using CommunityToolkit.Mvvm.ComponentModel;

namespace fwd_bilvaerksted.Models
{
    public partial class WorkOrder : ObservableObject
    {
        [ObservableProperty]
        [property: PrimaryKey]
        [property: AutoIncrement]
        private int id;

        [ObservableProperty]
        private string myProp;

        [ObservableProperty] private string name = "";
        [ObservableProperty] private string address = "";
        [ObservableProperty] private string brand = "";
        [ObservableProperty] private string model = "";
        [ObservableProperty] private string regNumber = "";
        [ObservableProperty] private DateTime timeOfDelivery;
        [ObservableProperty] private string jobDescription = "";
    }
}
