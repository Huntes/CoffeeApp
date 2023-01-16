using CoffeeApp.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CoffeeApp.ViewModels
{
    public class CounterViewModel : ViewModelBase
    {
        public CounterViewModel()
        {
            IncreaseCount = new Command(OnIncrease);
            DecreaseCount = new Command(async() => { await OnDecrease(); });
            Title = "Coffe Counter";
        }

        public ICommand IncreaseCount { get; }
        public ICommand DecreaseCount { get; set; }

        int count = 0;
        string countDisplay = "Clique aqui";

        public string CountDisplay
        {
            get => countDisplay;
            set => SetProperty(ref countDisplay, value);
        }

        void OnIncrease()
        {
            count++;
            CountDisplay = $"Você clicou {count} vez(es)";
        }

        async Task OnDecrease()
        {
            if (count == 0)
            {
                await Application.Current.MainPage.DisplayAlert("", "O número de vezes clicado não pode ser menor que 0", "OK");
            }
            else
            {
                count--;
                CountDisplay = $"Você clicou {count} vez(es)";
            }
        }
    }
}
