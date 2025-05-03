using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DylanDeSouzaQuoteAppPart1
{
    public partial class Favourites : ContentPage
    {
        Model model;

        public Favourites(Model model)
        {
            InitializeComponent();
            this.model = model;
            BindingContext = model;
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "Back") Navigation.PopAsync();
        }

        void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}