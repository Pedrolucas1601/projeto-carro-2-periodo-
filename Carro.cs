using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoCarro
{
    class Carro
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Dono { get; set; }
        public int Ano { get; set; }
        public DateTime DataCompra { get; set; }

        public void Registrar()
        {
            StreamWriter gravar = new StreamWriter("Carro.txt", true);
            gravar.WriteLine($"{Placa};{Modelo};{Marca};{Dono};{Ano};{DataCompra}");
            gravar.Close();

        }
        public bool Procurar(string placa)
        {
            string linha = "", placaCLI = "";
            bool ok = false;
            StreamReader ler = new StreamReader("Carro.txt");

            while(!ler.EndOfStream)
            {
                linha = ler.ReadLine();
                string[] item = linha.Split(';');

                placaCLI = item[0];
              

                if (placa.ToUpper().Trim() == placaCLI.ToUpper().Trim())
                {
                    Modelo = item[1];
                    Marca = item[2];
                    Dono = item[3];
                    Ano = int.Parse(item[4]);
                    DataCompra = DateTime.Parse(item[5]);
                    ok = true;
                    break;
                }


            }
            ler.Close();
            return ok;


        }
        public string Listar()
        {
            string linha = "", linhaLista = "";

            StreamReader ler = new StreamReader("Carro.txt");

            while (!ler.EndOfStream)
            {
                linha = ler.ReadLine();
                string[] item = linha.Split(';');
                Modelo = item[1];
                linhaLista = linhaLista + " | " + Modelo;
            }
            ler.Close();

            return linhaLista;
        }
    }
}
