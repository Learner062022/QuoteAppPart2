using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DylanDeSouzaQuoteAppPart1
{
    public partial class MainPage : ContentPage
    {
        Model model = new();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = model;
        }
        

        void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "Add Quote") model.AddQuote();
            else if (button.Text == "Get Random Quote") model.FetchRandomQuote();
        }
    }
}
