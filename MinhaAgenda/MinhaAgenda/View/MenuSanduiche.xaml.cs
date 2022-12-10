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
    public partial class MenuSanduiche : MasterDetailPage
    {
        public MenuSanduiche()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            Detail = new NavigationPage( new Listagem());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_agendamento(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Agendamento());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {

        }
    }
}