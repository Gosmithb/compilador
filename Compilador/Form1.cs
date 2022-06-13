namespace Compilador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void analizar_btn_Click(object sender, EventArgs e)
        {
            string codigoFuente;
            codigoFuente = txtBox.Text;
            Lexico analiz = new Lexico(codigoFuente);
            analiz.EjecutarLexico();
        }
    }
}