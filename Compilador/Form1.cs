using System.ComponentModel;
using System.Data;

namespace Compilador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmAbout = new About();
            frmAbout.Show();
        }

        private void lexicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string codigoFuente;
            codigoFuente = txtBox.Text;
            Lexico analiz = new Lexico(codigoFuente);
            analiz.EjecutarLexico();

            List<Error> listaDeErrores = analiz.listaDeError;

            var listaDeTokens = new BindingList<Token>(analiz.listaDeToken);

            dataGridViewErrores.DataSource = null;
            dataGridViewErrores.DataSource = listaDeErrores;

            dataGridViewTokens.DataSource = null;
            dataGridViewTokens.DataSource = listaDeTokens;


        }
    }
}