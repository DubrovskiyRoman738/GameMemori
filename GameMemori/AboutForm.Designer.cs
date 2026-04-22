namespace GameMemori
{
    partial class AboutForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.Label lblGameModes;
        private System.Windows.Forms.Label lblThemes;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlBackground = new Panel();
            btnOk = new Button();
            btnClose = new Button();
            lblThemes = new Label();
            lblGameModes = new Label();
            lblCredits = new Label();
            lblDescription = new Label();
            lblVersion = new Label();
            lblTitle = new Label();
            pnlBackground.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBackground
            // 
            pnlBackground.BackColor = Color.FromArgb(44, 62, 80);
            pnlBackground.Controls.Add(btnOk);
            pnlBackground.Controls.Add(btnClose);
            pnlBackground.Controls.Add(lblThemes);
            pnlBackground.Controls.Add(lblGameModes);
            pnlBackground.Controls.Add(lblCredits);
            pnlBackground.Controls.Add(lblDescription);
            pnlBackground.Controls.Add(lblVersion);
            pnlBackground.Controls.Add(lblTitle);
            pnlBackground.Dock = DockStyle.Fill;
            pnlBackground.Location = new Point(0, 0);
            pnlBackground.Name = "pnlBackground";
            pnlBackground.Size = new Size(600, 500);
            pnlBackground.TabIndex = 0;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(46, 204, 113);
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(167, 251);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 35);
            btnOk.TabIndex = 9;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += BtnOk_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(231, 76, 60);
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(350, 251);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 35);
            btnClose.TabIndex = 8;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // 
            // lblThemes
            // 
            lblThemes.AutoSize = true;
            lblThemes.Font = new Font("Segoe UI", 8F);
            lblThemes.ForeColor = Color.FromArgb(241, 196, 15);
            lblThemes.Location = new Point(50, 180);
            lblThemes.Name = "lblThemes";
            lblThemes.Size = new Size(306, 19);
            lblThemes.TabIndex = 6;
            lblThemes.Text = "Тематические вселенные: One Piece | JoJo | Mix";
            lblThemes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGameModes
            // 
            lblGameModes.AutoSize = true;
            lblGameModes.Font = new Font("Segoe UI", 8F);
            lblGameModes.ForeColor = Color.FromArgb(241, 196, 15);
            lblGameModes.Location = new Point(50, 145);
            lblGameModes.Name = "lblGameModes";
            lblGameModes.Size = new Size(455, 19);
            lblGameModes.TabIndex = 5;
            lblGameModes.Text = "Режимы: Соло | 1vs1 | 1vs1vs1vs1 |  Размеры: 2x2 | 2x4 | 4x4 | 4x8 | 8x8";
            lblGameModes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCredits
            // 
            lblCredits.AutoSize = true;
            lblCredits.Font = new Font("Segoe UI", 9F);
            lblCredits.ForeColor = Color.FromArgb(52, 152, 219);
            lblCredits.Location = new Point(30, 455);
            lblCredits.Name = "lblCredits";
            lblCredits.Size = new Size(237, 20);
            lblCredits.TabIndex = 4;
            lblCredits.Text = "Разработчик: Дубровский Роман";
            lblCredits.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 9F);
            lblDescription.ForeColor = Color.White;
            lblDescription.Location = new Point(50, 110);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(493, 20);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Классическая игра на память с персонажами из популярных аниме. \r\n";
            lblDescription.TextAlign = ContentAlignment.MiddleCenter;
            lblDescription.Click += lblDescription_Click;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Segoe UI", 9F);
            lblVersion.ForeColor = Color.FromArgb(189, 195, 199);
            lblVersion.Location = new Point(491, 455);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(82, 20);
            lblVersion.TabIndex = 2;
            lblVersion.Text = "Версия 1.0";
            lblVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(241, 196, 15);
            lblTitle.Location = new Point(64, 28);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(483, 46);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "🎮 Anime Memory Game 🎮";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // AboutForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(600, 500);
            Controls.Add(pnlBackground);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Об игре";
            pnlBackground.ResumeLayout(false);
            pnlBackground.PerformLayout();
            ResumeLayout(false);
        }
    }
}