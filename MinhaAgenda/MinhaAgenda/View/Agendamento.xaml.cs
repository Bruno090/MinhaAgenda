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
    public partial class Agendamento : ContentPage
    {
        public Agendamento()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Agenda agenda_selecionado = new Agenda();

                if (BindingContext != null)
                    agenda_selecionado = BindingContext as Agenda;
              

                string data = Data_agenda.Date.ToString("MM/dd/yyyy");
                string hora = Hora_agendada.Time.ToString();
                string data_hora = data + " " + hora;


                Agenda a = new Agenda
                {
                    Id = agenda_selecionado.Id, 
                    Horario = DateTime.Parse(data_hora),
                    Cliente = txt_cliente.Text,
                    Preco = Convert.ToDouble(txt_preco.Text),
                    Endereco = txt_endereco.Text
                };

                if (a.Id == 0)
                {
                    await App.BancoDados.Insert(a);

                    await DisplayAlert("Deu Certo!", "Agendamento Adicionado", "OK");

                    await Navigation.PopAsync();
                }
                else
                {
                    await App.BancoDados.Update(a);
                    await DisplayAlert("Deu Certo!", "Agendamento  atualizado ", "OK");

                    await Navigation.PopAsync();
                }

            }
            catch(Exception ex) 
            {
                await DisplayAlert("Ops", ex.Message, "OK");    
            }
        }
    }
}