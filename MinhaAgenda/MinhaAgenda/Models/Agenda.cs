using SQLite;
using System;

namespace MinhaAgenda.Models
{
    public class Agenda
    {
        string _nome;

        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public DateTime Horario { get; set; }

        public string Cliente
        {
            get => _nome;
            set
            {
                if (value == null)
                    throw new Exception("Cliente Inválido");

                _nome = value;
            }
        }
        

        
        public double Preco { get; set; }

        public string Endereco {get;set;}
     
    }
}