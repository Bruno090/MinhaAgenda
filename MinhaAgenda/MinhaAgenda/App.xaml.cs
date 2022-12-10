using AppMinhaAgenda.Helper;
using MinhaAgenda.Models;
using MinhaAgenda.View;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MinhaAgenda
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper bancoDados;

        public static SQLiteDatabaseHelper BancoDados
        {
            get
            {
                if(bancoDados == null) 
                {
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Banco_sqLite_agendas.db3");
                    bancoDados = new SQLiteDatabaseHelper(path);
                }
                return bancoDados;
            }
        }
       
        public App()
        {
            InitializeComponent();

            //Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            //MainPage = new NavigationPage(new View.Inicial());

            MainPage = new NavigationPage(new View.MenuSanduiche());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
