using SQLite;
using CommunityToolkit.Mvvm.ComponentModel;

namespace fwd_bilvaerksted.Models
{
    public partial class BaseModel : ObservableObject
    {
        [ObservableProperty]
        [property: PrimaryKey]
        [property: AutoIncrement]
        private int id;

        [ObservableProperty]
        private string myProp;
    }
}
