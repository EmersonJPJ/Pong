using NAudio.Wave;
using System.IO;
using Timer = System.Windows.Forms.Timer;

namespace Pong_en_C_
{
    public partial class Form1 : Form
    {

        int arriba;
        int abajo;
        int derecha;
        int izquierda;
        double aumento = 2; 
        int velocidadx = 2;
        int velocidady = 2;
        int jugador1 = 0;
        int cpu = 0;
        private bool puedeReproducirSonido = true;
        // Si es true, el jugador controla el palo derecho, si es false, lo controla la CPU
        private bool controlJugadorDerecho;  



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Preguntar al usuario al inicio si quiere controlar el palo derecho
            preguntarControlPaloDerecho();  

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Solo mover el palo derecho si el jugador lo controla
            if (controlJugadorDerecho)  
            {
                if (e.KeyCode == Keys.W)
                {
                    paloDer.Top -= 35;  
                }
                if (e.KeyCode == Keys.S)
                {
                    paloDer.Top += 35;  
                }
            }
        }


        private void preguntarControlPaloDerecho()
        {
            DialogResult resultado = MessageBox.Show("¿Quieres controlar el palo derecho?", "Control del Palo Derecho", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                controlJugadorDerecho = true;  // El jugador controla el palo derecho
            }
            else
            {
                controlJugadorDerecho = false;  // La CPU controla el palo derecho
            }

            // Iniciar el juego después de que el usuario haya respondido
            reiniciar();
        }


        private void moverPaloCPU()
        {
            // Solo mueve el palo si no lo está controlando el jugador
            if (!controlJugadorDerecho)  
            {
                // La CPU sigue la bola con un pequeño retraso
                //Va aumentando la velocidad de la cpu conforme el jugador sume puntos
                int velocidadCPU = 6 + (jugador1 / 3);
                int centroPaloDer = paloDer.Top + (paloDer.Height / 2);
                int centroBola = bola.Top + (bola.Height / 2);

                if (centroPaloDer < centroBola)
                {
                    paloDer.Top += velocidadCPU;
                }
                else if (centroPaloDer > centroBola)
                {
                    paloDer.Top -= velocidadCPU;
                }

                // Limites del formulario
                if (paloDer.Top < 0)
                {
                    paloDer.Top = 0;
                }
                if (paloDer.Top + paloDer.Height > this.ClientSize.Height)
                {
                    paloDer.Top = this.ClientSize.Height - paloDer.Height;
                }
            }
        }



        private void mostrarPuntaje(int jugador, int cpu)
        {
            lblJugador.Text = jugador.ToString();
            lblCPU.Text = cpu.ToString();

            // Hacer que el texto parpadee
            lblJugador.ForeColor = Color.Blue;
            lblCPU.ForeColor = Color.Yellow;

            Timer timer = new Timer();
            timer.Interval = 500; // Cambiar color cada medio segundo
            timer.Tick += (sender, e) =>
            {
                lblJugador.ForeColor = Color.OrangeRed;
                lblCPU.ForeColor = Color.OrangeRed;
                timer.Stop();
            };
            timer.Start();
        }


        private void reproducirMP3(string nombreArchivo)
        {
            if (!puedeReproducirSonido)
                return;

            string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
            string rutaProyecto = Directory.GetParent(rutaBase).Parent.Parent.Parent.FullName;
            string rutaCompleta = Path.Combine(rutaProyecto, "media", nombreArchivo);

            if (File.Exists(rutaCompleta))
            {
                var reader = new AudioFileReader(rutaCompleta);
                var output = new WaveOutEvent();
                output.Init(reader);
                output.Play();
                puedeReproducirSonido = false;

                // Un delay de 5 segundos para evitar que se reproduzcan sonidos muy seguidos
                Timer timer = new Timer();
                timer.Interval = 500; // 500 ms delay
                timer.Tick += (sender, e) =>
                {
                    puedeReproducirSonido = true;
                    timer.Stop();
                };
                timer.Start();
            }
            else
            {
                MessageBox.Show("Archivo de sonido no encontrado: " + rutaCompleta);
            }
        }






        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //Movimiento del palo izquierdo con el mouse
            paloIzq.Top = e.Y;
        }

        private void colision()
        {

            //Hitbox de los palos
            int paloIzqArriba = paloIzq.Top;
            int paloIzqAbajo = paloIzq.Top + paloIzq.Height;
            int paloIzqIzquierda = paloIzq.Left;
            int paloIzqDerecha = paloIzq.Left + paloIzq.Width;

            int paloDerArriba = paloDer.Top;
            int paloDerAbajo = paloDer.Top + paloDer.Height;
            int paloDerIzquierda = paloDer.Left;
            int paloDerDerecha = paloDer.Left + paloDer.Width;

            //Hitbox de la bola
            int bolaArriba = bola.Top;
            int bolaAbajo = bola.Top + bola.Height;
            int bolaIzquierda = bola.Left;
            int bolaDerecha = bola.Left + bola.Width;

            //Colision palo con la bola
            //Palo izquierdo
            if (bolaDerecha >= paloDerIzquierda && bolaArriba <= paloDerAbajo && bolaAbajo >= paloDerArriba)
            {
                reproducirMP3("rebote.mp3");
                aumento += 0.3;
                velocidadx = (int)(aumento * -1);
            }
            //Palo derecho
            if (bolaIzquierda <= paloIzqDerecha && bolaArriba <= paloIzqAbajo && bolaAbajo >= paloIzqArriba)
            {
                reproducirMP3("rebote.mp3");
                aumento += 0.3;
                velocidadx = (int)aumento;
            }



            bola.Top += velocidady;
            bola.Left += velocidadx;
            arriba = 0;
            izquierda = 0;
            abajo = this.Size.Height - bola.Height - 40;
            derecha = this.Size.Width - bola.Width - 20;

            //Colision con las paredes

            if (bola.Top <= arriba)
            {
                aumento += 0.3;
                velocidady = (int)aumento;
            }
            if (bola.Top >= abajo)
            {
                aumento += 0.3;
                velocidady = (int)(aumento * -1);
            }
            if (bola.Left <= izquierda)
            {
                timer1.Enabled = false;
                MessageBox.Show("Punto para la CPU");
                cpu++;
                mostrarPuntaje(jugador1, cpu);
                reiniciar();
            }
            if (bola.Left >= derecha)
            {
                timer1.Enabled = false;
                MessageBox.Show("Punto para el jugador 1");
                jugador1++;
                mostrarPuntaje(jugador1, cpu);
                reiniciar();
            }

        }

        public void reiniciar()
        {
            bola.Top = 200;
            bola.Left = 400;
            velocidadx = 3;
            velocidady = 3;
            lblJugador.Text = jugador1.ToString();
            lblCPU.Text = cpu.ToString();
            aumento = 2;

            // Dirección aleatoria para la bola
            Random random = new Random();
            int direccionX = random.Next(0, 2) == 0 ? -1 : 1;
            int direccionY = random.Next(0, 2) == 0 ? -1 : 1;

            velocidadx = 2 * direccionX;
            velocidady = 2 * direccionY;
            MessageBox.Show("Presiona OK para continuar");
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            colision();
            moverPaloCPU();

        }
    }
}
