using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MinhaAgenda.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicial : ContentPage
    {
        public Inicial()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Button_Clicked_Login(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Listagem());
        }

        private void Button_Clicked_Registro(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }

       
    }
}