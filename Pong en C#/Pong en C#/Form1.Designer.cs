namespace Pong_en_C_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            paloIzq = new Button();
            paloDer = new Button();
            bola = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            label2 = new Label();
            lblJugador = new Label();
            lblCPU = new Label();
            ((System.ComponentModel.ISupportInitialize)bola).BeginInit();
            SuspendLayout();
            // 
            // paloIzq
            // 
            paloIzq.BackColor = Color.White;
            paloIzq.Location = new Point(35, 146);
            paloIzq.Name = "paloIzq";
            paloIzq.Size = new Size(20, 100);
            paloIzq.TabIndex = 0;
            paloIzq.TabStop = false;
            paloIzq.UseVisualStyleBackColor = false;
            // 
            // paloDer
            // 
            paloDer.BackColor = Color.White;
            paloDer.Location = new Point(750, 146);
            paloDer.Name = "paloDer";
            paloDer.Size = new Size(20, 100);
            paloDer.TabIndex = 1;
            paloDer.TabStop = false;
            paloDer.UseVisualStyleBackColor = false;
            // 
            // bola
            // 
            bola.Image = (Image)resources.GetObject("bola.Image");
            bola.Location = new Point(370, 194);
            bola.Name = "bola";
            bola.Size = new Size(20, 20);
            bola.SizeMode = PictureBoxSizeMode.StretchImage;
            bola.TabIndex = 2;
            bola.TabStop = false;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Cursor = Cursors.No;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(229, 9);
            label1.Name = "label1";
            label1.Size = new Size(82, 23);
            label1.TabIndex = 3;
            label1.Text = "Jugador:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(429, 9);
            label2.Name = "label2";
            label2.Size = new Size(48, 23);
            label2.TabIndex = 4;
            label2.Text = "CPU:";
            // 
            // lblJugador
            // 
            lblJugador.AutoSize = true;
            lblJugador.BackColor = Color.Transparent;
            lblJugador.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJugador.ForeColor = Color.White;
            lblJugador.Location = new Point(308, 9);
            lblJugador.Name = "lblJugador";
            lblJugador.Size = new Size(20, 23);
            lblJugador.TabIndex = 5;
            lblJugador.Text = "0";
            // 
            // lblCPU
            // 
            lblCPU.AutoSize = true;
            lblCPU.BackColor = Color.Transparent;
            lblCPU.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCPU.ForeColor = Color.White;
            lblCPU.Location = new Point(473, 9);
            lblCPU.Name = "lblCPU";
            lblCPU.Size = new Size(20, 23);
            lblCPU.TabIndex = 6;
            lblCPU.Text = "0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 450);
            Controls.Add(lblCPU);
            Controls.Add(lblJugador);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(bola);
            Controls.Add(paloDer);
            Controls.Add(paloIzq);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pong";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            MouseMove += Form1_MouseMove;
            ((System.ComponentModel.ISupportInitialize)bola).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button paloIzq;
        private Button paloDer;
        private PictureBox bola;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private Label label2;
        private Label lblJugador;
        private Label lblCPU;
    }
}
