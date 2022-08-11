namespace ControlMultaTransito
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            lblFecha.Text = DateTime.Today.Date.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString(); 

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //capturando datos

            string placa = txtPlaca.Text;
            double velocidad = double.Parse(txtVelcidad.Text);
            DateTime fecha = DateTime.Parse(lblFecha.Text);
            DateTime hora = DateTime.Parse(lblHora.Text);

            //procesando
            double multa = 0;
            if (velocidad <= 0)
                multa = 0;

            else if (velocidad < 70 && velocidad <= 90)
                multa = 120;

            else if (velocidad > 90 && velocidad <= 100)
                multa = 240;
            else if (velocidad > 100)
                multa = 350;

            //imprimiendo resultados
            ListViewItem fila = new ListViewItem(placa);
            fila.SubItems.Add(lblFecha.Text);
            fila.SubItems.Add(lblHora.Text);
            fila.SubItems.Add(velocidad.ToString("0.00"));
            fila.SubItems.Add(multa.ToString("C"));
            lvlMulat.Items.Add(fila);


        }
        ListViewItem Item;
        private void lvlMulat_MouseClick(object sender, MouseEventArgs e)
        {
            Item=lvlMulat.GetItemAt(e.X, e.Y);

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Item != null)
            {
                lvlMulat.Items.Remove(Item);
                MessageBox.Show("la multa ha sido eliminida correctamente");
            }
            else
            {
                MessageBox.Show("debe selecccionar una multa de la lista");
            
            }

        }

        private void txtVelcidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r= MessageBox.Show("Estas seguro de que quieres salir",
                "control de pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
                this.Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}