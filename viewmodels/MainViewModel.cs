using fwd_bilvaerksted.Data;
using fwd_bilvaerksted.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;

namespace fwd_bilvaerksted.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly Database _database;
        public MainViewModel()
        {
            _database = new Database();

        }
        [ObservableProperty]
        private string text = "Placeholder tekst"; // Nu skal den kaldes med "Text", grundet [ObservableProperty]

        [RelayCommand]
        private async Task MyFunction1() // Kaldes i .xaml filen ved at skrive "MyFunction1Command"
        {
            var newModel = new BaseModel
            {
                MyProp = "Jeg er tekst fra en BaseModel i databasen :D"
            };
            await _database.AddModel(newModel);

            var bm = await _database.GetModel(newModel.Id);
            if (bm == null)
                Text = "Funktion 1: BaseModel ikke hentet";
            else
                Text ="Funktion 1: " +  bm.MyProp;
            Debug.WriteLine("Function 1 kørte"); // Kan findes i debug konsole når programmet startes med f5
        }
        [RelayCommand]
        private async Task MyFunction2() // Kaldes i .xaml filen ved at skrive "MyFunction2Command"
        {
            var bm = await _database.GetModel(0);
            if (bm == null)
                Text = "Funktion 2: BaseModel ikke hentet. Findes intet på id = -1 ;(";
            else
                Text = "Funktion 2: " +  bm.MyProp;
            Debug.WriteLine("Funktion 2 kørte"); // Kan findes i debug konsole når programmet startes med f5
        }

        [RelayCommand]
        private async Task MyFunction3() // Kaldes i .xaml filen ved at skrive "MyFunction3Command"
        {
            bool del = false;
            var models = await _database.GetModels();
            foreach(var m in models)
            {
                await _database.DeleteModel(m);
                if(!del)
                    del = true;
            }

            if (!del)
                Text = "Intet fra databasen blev fjernet";
            else
                Text = "Du slettede modellerne!";
            Debug.WriteLine("Function 3 kørte"); // Kan findes i debug konsole når programmet startes med f5
        }
    }
}
