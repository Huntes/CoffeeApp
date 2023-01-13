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
            LabelCount.Text = "Olá, de código backend";
        }

        private int count = 0;
        public int Count { get => count; set { count = value; } }

        private void ButtonClick_Clicked(object sender, EventArgs e)
        {
            Count++;
            LabelCount.Text = $"Você clicou {Count} vez(es)";
        }

        private void ButtonClickLess_Clicked(object sender, EventArgs e)
        {
            Count--;
            LabelCount.Text = $"Você clicou {Count} vez(es)";
        }
    }
}