using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppMinhasCompras.Model
{
    public class Produto
    {
        string _nome;
        double _qnt;
        
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nome { 
            get => _nome; 
            set
            {
                if (value == null)
                    throw new Exception("Nome inválido");

                _nome = value;
            } 
        }


        public double Preco { get; set; }

        public double Qnt 
        { 
            get => _qnt; 
            set
            {
                if (value == 0)
                    throw new Exception("Quantidade inválida");

                _qnt = value;
            }
        }


        public double PrecoTotal
        {
            get => Preco * Qnt;
        }
    }
}
