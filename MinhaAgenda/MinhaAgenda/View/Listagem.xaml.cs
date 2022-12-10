using System.Collections.ObjectModel;
using MinhaAgenda.Models;
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
    public partial class Listagem : ContentPage
    {

        ObservableCollection<Agenda> Lista_Agenda = new ObservableCollection<Agenda>();
       
        public Listagem()
        {
            InitializeComponent();

            

            lst_agenda.ItemsSource = Lista_Agenda;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Agendamento());
        }

        protected override void OnAppearing()
        {
            if(Lista_Agenda.Count == 0)
            {
                Task.Run(async () =>
                {
                    List<Agenda> temp = await App.BancoDados.GetAll();
                    foreach (Agenda a in temp)
                    {
                        Lista_Agenda.Add(a);
                    }
                });
            }
        }

        private void lst_produtos_Refreshing(object sender, EventArgs e)
        {
 
            Lista_Agenda.Clear();
            Task.Run(async () =>
            {
                List<Agenda> temp = await App.BancoDados.GetAll();

                foreach (Agenda a in temp)
                {
                    Lista_Agenda.Add(a);
                }
            });

            ref_carregando.IsRefreshing = false;
        }
        private void lst_agenda_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Agenda Agenda_selecionada = e.SelectedItem as Agenda;

            Navigation.PushAsync(new Agendamento
            {
                BindingContext = Agenda_selecionada
            });
        }

        private async void MenuItem_Clicked_remover(object sender, EventArgs e)
        {
            MenuItem disparador = sender as MenuItem;

            Agenda agenda_selecionado = (Agenda)disparador.BindingContext;

            string mensagem = "Remover" + agenda_selecionado.Cliente + "da agenda? ";

            bool confirmacao = await DisplayAlert("Tem Certeza?", mensagem, "sim", "não");

            if (confirmacao)
            {
                await App.BancoDados.Delete(agenda_selecionado.Id);
                Lista_Agenda.Remove(agenda_selecionado);
            }
        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string q = e.NewTextValue;

            Lista_Agenda.Clear();

            Task.Run(async () =>
            {
                List<Agenda> temp = await App.BancoDados.Search(q);

                foreach (Agenda a in temp)
                {
                    Lista_Agenda.Add(a);
                }
            });
        }
    }
}