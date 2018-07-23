namespace Srednie_spalanie
{
    partial class Form1
    {
        private int margin_X = 5;
        
       
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent(int _liczba_samochodow, Samochod[] _samochody)
        {
            this.label1 = new System.Windows.Forms.Label();
            this.rej1_button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.rej2_button = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1008, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wybierz rodzaj samochodu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rej1_button
            // 
            this.rej1_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rej1_button.AutoSize = true;
            this.rej1_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.rej1_button.Location = new System.Drawing.Point(140, 71);
            this.rej1_button.Name = "rej1_button";
            this.rej1_button.Size = new System.Drawing.Size(310, 37);
            this.rej1_button.TabIndex = 1;
            this.rej1_button.Text = "NAZWA - REJ";
            this.rej1_button.UseVisualStyleBackColor = true;
            this.rej1_button.Click += new System.EventHandler(this.rej1_button_Click);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.button2.Location = new System.Drawing.Point(510, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(310, 37);
            this.button2.TabIndex = 2;
            this.button2.Text = "NAZWA - REJ";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // rej2_button
            // 
            this.rej2_button.AutoSize = true;
            this.rej2_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.rej2_button.Location = new System.Drawing.Point(140, 114);
            this.rej2_button.Name = "rej2_button";
            this.rej2_button.Size = new System.Drawing.Size(310, 37);
            this.rej2_button.TabIndex = 3;
            this.rej2_button.Text = "NAZWA - REJ";
            this.rej2_button.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.button4.Location = new System.Drawing.Point(510, 114);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(310, 37);
            this.button4.TabIndex = 4;
            this.button4.Text = "NAZWA - REJ";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.rej2_button);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.rej1_button);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button rej1_button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button rej2_button;
        private System.Windows.Forms.Button button4;
    }
}

