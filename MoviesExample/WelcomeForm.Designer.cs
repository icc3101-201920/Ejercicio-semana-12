namespace MoviesExample
{
    partial class WelcomeForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.welcomeViewPanel = new System.Windows.Forms.Panel();
            this.tableWelcomePanel = new System.Windows.Forms.TableLayoutPanel();
            this.Title = new System.Windows.Forms.Label();
            this.descriptionTextWelcomeForm = new System.Windows.Forms.Label();
            this.welcomeFormTimer = new System.Windows.Forms.Timer(this.components);
            this.welcomeViewPanel.SuspendLayout();
            this.tableWelcomePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // welcomeViewPanel
            // 
            this.welcomeViewPanel.BackColor = System.Drawing.SystemColors.Window;
            this.welcomeViewPanel.Controls.Add(this.tableWelcomePanel);
            this.welcomeViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welcomeViewPanel.Location = new System.Drawing.Point(0, 0);
            this.welcomeViewPanel.Margin = new System.Windows.Forms.Padding(0);
            this.welcomeViewPanel.Name = "welcomeViewPanel";
            this.welcomeViewPanel.Size = new System.Drawing.Size(344, 321);
            this.welcomeViewPanel.TabIndex = 0;
            // 
            // tableWelcomePanel
            // 
            this.tableWelcomePanel.ColumnCount = 1;
            this.tableWelcomePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableWelcomePanel.Controls.Add(this.Title, 0, 0);
            this.tableWelcomePanel.Controls.Add(this.descriptionTextWelcomeForm, 0, 1);
            this.tableWelcomePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableWelcomePanel.Location = new System.Drawing.Point(0, 0);
            this.tableWelcomePanel.Name = "tableWelcomePanel";
            this.tableWelcomePanel.RowCount = 2;
            this.tableWelcomePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableWelcomePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableWelcomePanel.Size = new System.Drawing.Size(344, 321);
            this.tableWelcomePanel.TabIndex = 3;
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Title.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold);
            this.Title.Location = new System.Drawing.Point(3, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(338, 160);
            this.Title.TabIndex = 4;
            this.Title.Text = "Welcome to Moogle!";
            this.Title.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // descriptionTextWelcomeForm
            // 
            this.descriptionTextWelcomeForm.BackColor = System.Drawing.Color.Transparent;
            this.descriptionTextWelcomeForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionTextWelcomeForm.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextWelcomeForm.Location = new System.Drawing.Point(3, 160);
            this.descriptionTextWelcomeForm.Name = "descriptionTextWelcomeForm";
            this.descriptionTextWelcomeForm.Size = new System.Drawing.Size(338, 161);
            this.descriptionTextWelcomeForm.TabIndex = 5;
            this.descriptionTextWelcomeForm.Text = "The best movie search engine";
            this.descriptionTextWelcomeForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // welcomeFormTimer
            // 
            this.welcomeFormTimer.Enabled = true;
            this.welcomeFormTimer.Interval = 5000;
            this.welcomeFormTimer.Tick += new System.EventHandler(this.WelcomFormTimer_Tick);
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(344, 321);
            this.ControlBox = false;
            this.Controls.Add(this.welcomeViewPanel);
            this.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.Name = "WelcomeForm";
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.welcomeViewPanel.ResumeLayout(false);
            this.tableWelcomePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel welcomeViewPanel;
        private System.Windows.Forms.TableLayoutPanel tableWelcomePanel;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label descriptionTextWelcomeForm;
        private System.Windows.Forms.Timer welcomeFormTimer;
    }
}

