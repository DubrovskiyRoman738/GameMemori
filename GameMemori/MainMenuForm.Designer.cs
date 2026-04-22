namespace GameMemori
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Timer timerAnimation;
        private System.Windows.Forms.Label lblSubtitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlBackground = new Panel();
            btnAbout = new Button();
            btnExit = new Button();
            lblSubtitle = new Label();
            btnStart = new Button();
            lblTitle = new Label();
            timerAnimation = new System.Windows.Forms.Timer(components);
            pnlBackground.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBackground
            // 
            pnlBackground.BackColor = Color.FromArgb(44, 62, 80);
            pnlBackground.BackgroundImageLayout = ImageLayout.Stretch;
            pnlBackground.Controls.Add(btnAbout);
            pnlBackground.Controls.Add(btnExit);
            pnlBackground.Controls.Add(lblSubtitle);
            pnlBackground.Controls.Add(btnStart);
            pnlBackground.Controls.Add(lblTitle);
            pnlBackground.Dock = DockStyle.Fill;
            pnlBackground.Location = new Point(0, 0);
            pnlBackground.Name = "pnlBackground";
            pnlBackground.Size = new Size(900, 600);
            pnlBackground.TabIndex = 0;
            // 
            // btnAbout
            // 
            btnAbout.BackColor = Color.FromArgb(52, 152, 219);
            btnAbout.FlatAppearance.BorderSize = 0;
            btnAbout.FlatStyle = FlatStyle.Flat;
            btnAbout.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAbout.ForeColor = Color.White;
            btnAbout.Location = new Point(340, 302);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(201, 44);
            btnAbout.TabIndex = 1;
            btnAbout.Text = "ℹ️ Об игре";
            btnAbout.UseVisualStyleBackColor = false;
            btnAbout.Click += BtnAbout_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(231, 76, 60);
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(370, 383);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(140, 40);
            btnExit.TabIndex = 2;
            btnExit.Text = "🚪 Выход";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += BtnExit_Click;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            lblSubtitle.ForeColor = Color.FromArgb(189, 195, 199);
            lblSubtitle.Location = new Point(328, 142);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(225, 28);
            lblSubtitle.TabIndex = 3;
            lblSubtitle.Text = "Проверь свою память!\r\n";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            lblSubtitle.Click += lblSubtitle_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(46, 204, 113);
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(300, 214);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(300, 50);
            btnStart.TabIndex = 0;
            btnStart.Text = "🎮 Начать игру";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += BtnStart_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(241, 196, 15);
            lblTitle.Location = new Point(0, 37);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(903, 81);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🎮 ANIME MEMORY GAME 🎮";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timerAnimation
            // 
            timerAnimation.Enabled = true;
            timerAnimation.Interval = 50;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(pnlBackground);
            Name = "MainMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Anime Memory Game - Главное меню";
            pnlBackground.ResumeLayout(false);
            pnlBackground.PerformLayout();
            ResumeLayout(false);
        }
    }
}