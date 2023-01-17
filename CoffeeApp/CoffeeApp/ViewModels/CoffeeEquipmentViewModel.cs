using CoffeeApp.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CoffeeApp.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; } = new ObservableRangeCollection<Coffee>();
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; set; }

        public CoffeeEquipmentViewModel()
        {
            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();

            LoadMore();

            //var tiposCafe = Coffee.GroupBy(c => c.Roaster).Select(g => g.First().Roaster).ToList();
            //foreach (var tipo in tiposCafe)
            //{
            //    CoffeeGroups.Add(new Grouping<string, Coffee>(tipo, Coffee.Where(c => c.Roaster == tipo)));
            //}

            RefreshCommandAsync = new Command(async () => { await Refresh(); });
            FavoriteCommandAsync = new Command<Coffee>(async (coffee) => { await Favorite(coffee); });
            LoadMoreCommandAsync = new Command(LoadMore);
        }

        public ICommand RefreshCommandAsync { get; }
        public ICommand FavoriteCommandAsync { get; }
        public ICommand LoadMoreCommandAsync { get; }

        Coffee previouslySelected;
        Coffee selectedCoffee;

        public Coffee SelectedCoffee
        {
            get => selectedCoffee;
            set
            {
                if(value != null)
                {
                    Application.Current.MainPage.DisplayAlert("Café Selecionado", value.Name, "OK");
                    previouslySelected = value;
                    value = null;
                }

                selectedCoffee = value;
                OnPropertyChanged();
            }
        }

        async Task Favorite(Coffee coffee)
        {
            if (coffee == null)
                return;
            await Application.Current.MainPage.DisplayAlert("Favorito", coffee.Name, "OK");
        }

        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            Coffee.Clear();
            LoadMore();
            IsBusy = false;
        }

        void LoadMore()
        {
            if (Coffee.Count >= 20)
                return;

            var image = "https://www.oswaldocruz.com/site/images/artigos/pesquisa_cafe_coracao.jpg";

            Coffee.Add(new Coffee { Roaster = "Robusta", Name = "Conilon", Image = image });
            Coffee.Add(new Coffee { Roaster = "Robusta", Name = "Bourbon", Image = image });
            Coffee.Add(new Coffee { Roaster = "Arábica", Name = "Catuaí", Image = image });
            Coffee.Add(new Coffee { Roaster = "Arábica", Name = "Novo Mundo", Image = image });
            Coffee.Add(new Coffee { Roaster = "Arábica", Name = "Caturra", Image = image });
            Coffee.Add(new Coffee { Roaster = "Arábica", Name = "Acaiá", Image = image });

            CoffeeGroups.Clear();

            var tiposCafe = Coffee.GroupBy(c => c.Roaster).Select(g => g.First().Roaster).ToList();
            foreach (var tipo in tiposCafe)
            {
                CoffeeGroups.Add(new Grouping<string, Coffee>(tipo, Coffee.Where(c => c.Roaster == tipo)));
            }
        }

        void DelayLoadMore()
        {
            if (Coffee.Count <= 10)
                return;

            LoadMore();
        }

        void InitializeCoffeList()
        {
            var image = "https://www.oswaldocruz.com/site/images/artigos/pesquisa_cafe_coracao.jpg";

            Coffee.Add(new Coffee { Roaster = "Robusta", Name = "Conilon", Image = image });
            Coffee.Add(new Coffee { Roaster = "Arábica", Name = "Bourbon", Image = image });
            Coffee.Add(new Coffee { Roaster = "Arábica", Name = "Catuaí", Image = image });
            Coffee.Add(new Coffee { Roaster = "Arábica", Name = "Novo Mundo", Image = image });
            Coffee.Add(new Coffee { Roaster = "Arábica", Name = "Caturra", Image = image });
            Coffee.Add(new Coffee { Roaster = "Arábica", Name = "Acaiá", Image = image });
        }
    }
}
