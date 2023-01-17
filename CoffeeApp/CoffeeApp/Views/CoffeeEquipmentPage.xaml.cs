using CoffeeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeeEquipmentPage : ContentPage
    {
        public CoffeeEquipmentPage()
        {
            InitializeComponent();
        }

        //private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    //Convertendo o item selecionado na model Coffee
        //    var coffee = ((ListView)sender).SelectedItem as Coffee;
        //    if (coffee == null)
        //        return;

        //    await DisplayAlert("Café Selecionado", coffee.Name, "OK");
        //}

        //private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    //Deseleciona o elemento automaticamente
        //    ((ListView)sender).SelectedItem = null;
        //}

        //private async void MenuItem_Clicked(object sender, EventArgs e)
        //{
        //    var coffee = ((MenuItem)sender).BindingContext as Coffee;
        //    if (coffee == null)
        //        return;

        //    await DisplayAlert("Café Favorito", coffee.Name, "OK");
        //}
    }
}