using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CoffeeApp.ViewModels
{
    public class CoffeeEquipmentViewModel : BindableObject
    {
        public CoffeeEquipmentViewModel()
        {
            IncreaseCount = new Command(OnIncrease);
            DecreaseCount = new Command(OnDecrease);
        }

        public ICommand IncreaseCount { get; }
        public ICommand DecreaseCount { get; set; }

        int count = 0;
        string countDisplay = "Clique aqui";

        public string CountDisplay
        {
            get => countDisplay;
            set
            {
                if (value == countDisplay)
                    return;

                countDisplay = value;

                //Parametro de property change é pego automaticamente, pois está dentro da propriedade
                OnPropertyChanged();
            }
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
