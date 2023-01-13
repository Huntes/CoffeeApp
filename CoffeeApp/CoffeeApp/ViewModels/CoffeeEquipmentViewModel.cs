using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CoffeeApp.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase
    {
        public CoffeeEquipmentViewModel()
        {
            IncreaseCount = new Command(OnIncrease);
            DecreaseCount = new Command(OnDecrease);
            CallServerCommand = new Command(async () => { await CallServer(); });
            Coffee = new ObservableRangeCollection<string>();
            Title = "Coffee Equipment";
        }

        public ObservableRangeCollection<string> Coffee { get; }

        public ICommand CallServerCommand { get; }
        public ICommand IncreaseCount { get; }
        public ICommand DecreaseCount { get; set; }

        int count = 0;
        string countDisplay = "Clique aqui";

        public string CountDisplay
        {
            get => countDisplay;
            set => SetProperty(ref countDisplay, value);
        }

        async Task CallServer()
        {
            Coffee.Add(string.Empty);
        }

        void OnIncrease()
        {
            count++;
            CountDisplay = $"Você clicou {count} vez(es)";
        }

        void OnDecrease()
        {
            count--;
            CountDisplay = $"Você clicou {count} vez(es)";
        }
    }
}
