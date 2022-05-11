using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoCarro
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtPlaca.Text == "")
            {
                MessageBox.Show("O campo placa está vazio!");
                return;
            }
            Carro cli = new Carro();

            cli.Placa = txtPlaca.Text;
            cli.Modelo = txtModelo.Text;
            cli.Marca = txtMarca.Text;
            cli.Dono = txtDono.Text;
            cli.Ano = int.Parse(mtbAno.Text);
            cli.DataCompra = dtpDataCompra.Value;

            cli.Registrar();
            MessageBox.Show("Cadastro realizado com sucesso!");
            Zerar();

        }
        private void Zerar()
        {
            txtPlaca.Text = "";
            txtModelo.Text = "";
            txtMarca.Text = "";
            txtDono.Text = "";
            mtbAno.Text = "";
            dtpDataCompra.Value = new DateTime(2000,01,01);
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            if (txtPlaca.Text == "")
            {
                MessageBox.Show("O campo nome está vazio!");
                return;
            }
            bool ok = false;
            string placa = txtPlaca.Text;
            Carro cli = new Carro();

            ok = cli.Procurar(placa);

            if (ok)
            {

                txtModelo.Text = cli.Modelo;
                txtMarca.Text = cli.Marca;
                txtDono.Text = cli.Dono;
                mtbAno.Text = cli.Ano.ToString();
                dtpDataCompra.Value = cli.DataCompra;
            }
            else
            {
                MessageBox.Show("Registro não encontrado!");
                Zerar();
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            Carro cli = new Carro();
            txtLista.Text = cli.Listar();
            
            
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
