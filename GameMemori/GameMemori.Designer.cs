namespace GameMemori
{
    partial class GameMemori
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox grpGameInfo;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTimerTitle;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblPlayerTitle;
        private System.Windows.Forms.Label lblCurrentPlayer;
        private System.Windows.Forms.Label lblScoresTitle;
        private System.Windows.Forms.Label lblScores;
        private System.Windows.Forms.FlowLayoutPanel flpPlayers;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.SplitContainer splitContainer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlTop = new Panel();
            btnReset = new Button();
            lblTitle = new Label();
            pnlGame = new Panel();
            grpGameInfo = new GroupBox();
            flpPlayers = new FlowLayoutPanel();
            lblScores = new Label();
            lblScoresTitle = new Label();
            lblCurrentPlayer = new Label();
            lblPlayerTitle = new Label();
            lblTimer = new Label();
            lblTimerTitle = new Label();
            lblStatus = new Label();
            lblStatusTitle = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            pnlTop.SuspendLayout();
            grpGameInfo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(44, 62, 80);
            pnlTop.Controls.Add(btnReset);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1200, 100);
            pnlTop.TabIndex = 0;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(231, 76, 60);
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(1048, 36);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(100, 25);
            btnReset.TabIndex = 1;
            btnReset.Text = "Сброс";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += BtnReset_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(241, 196, 15);
            lblTitle.Location = new Point(30, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(424, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🎮 Anime Memory Game 🎮";
            // 
            // pnlGame
            // 
            pnlGame.BackColor = Color.FromArgb(236, 240, 241);
            pnlGame.Dock = DockStyle.Fill;
            pnlGame.Location = new Point(0, 100);
            pnlGame.Name = "pnlGame";
            pnlGame.Size = new Size(1200, 500);
            pnlGame.TabIndex = 1;
            // 
            // grpGameInfo
            // 
            grpGameInfo.BackColor = Color.FromArgb(52, 73, 94);
            grpGameInfo.Controls.Add(flpPlayers);
            grpGameInfo.Controls.Add(lblScores);
            grpGameInfo.Controls.Add(lblScoresTitle);
            grpGameInfo.Controls.Add(lblCurrentPlayer);
            grpGameInfo.Controls.Add(lblPlayerTitle);
            grpGameInfo.Controls.Add(lblTimer);
            grpGameInfo.Controls.Add(lblTimerTitle);
            grpGameInfo.Controls.Add(lblStatus);
            grpGameInfo.Controls.Add(lblStatusTitle);
            grpGameInfo.Dock = DockStyle.Bottom;
            grpGameInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpGameInfo.ForeColor = Color.White;
            grpGameInfo.Location = new Point(0, 600);
            grpGameInfo.Name = "grpGameInfo";
            grpGameInfo.Size = new Size(1200, 200);
            grpGameInfo.TabIndex = 2;
            grpGameInfo.TabStop = false;
            grpGameInfo.Text = "Информация об игре";
            // 
            // flpPlayers
            // 
            flpPlayers.Location = new Point(20, 25);
            flpPlayers.Name = "flpPlayers";
            flpPlayers.Size = new Size(550, 165);
            flpPlayers.TabIndex = 9;
            // 
            // lblScores
            // 
            lblScores.AutoSize = true;
            lblScores.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblScores.ForeColor = Color.FromArgb(241, 196, 15);
            lblScores.Location = new Point(950, 90);
            lblScores.Name = "lblScores";
            lblScores.Size = new Size(28, 32);
            lblScores.TabIndex = 7;
            lblScores.Text = "0";
            // 
            // lblScoresTitle
            // 
            lblScoresTitle.AutoSize = true;
            lblScoresTitle.Font = new Font("Segoe UI", 10F);
            lblScoresTitle.Location = new Point(950, 60);
            lblScoresTitle.Name = "lblScoresTitle";
            lblScoresTitle.Size = new Size(55, 23);
            lblScoresTitle.TabIndex = 6;
            lblScoresTitle.Text = "Очки:";
            // 
            // lblCurrentPlayer
            // 
            lblCurrentPlayer.AutoSize = true;
            lblCurrentPlayer.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCurrentPlayer.ForeColor = Color.FromArgb(46, 204, 113);
            lblCurrentPlayer.Location = new Point(750, 90);
            lblCurrentPlayer.Name = "lblCurrentPlayer";
            lblCurrentPlayer.Size = new Size(107, 32);
            lblCurrentPlayer.TabIndex = 5;
            lblCurrentPlayer.Text = "Игрок 1";
            // 
            // lblPlayerTitle
            // 
            lblPlayerTitle.AutoSize = true;
            lblPlayerTitle.Font = new Font("Segoe UI", 10F);
            lblPlayerTitle.Location = new Point(750, 60);
            lblPlayerTitle.Name = "lblPlayerTitle";
            lblPlayerTitle.Size = new Size(60, 23);
            lblPlayerTitle.TabIndex = 4;
            lblPlayerTitle.Text = "Ходит:";
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTimer.ForeColor = Color.FromArgb(241, 196, 15);
            lblTimer.Location = new Point(600, 85);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(99, 37);
            lblTimer.TabIndex = 3;
            lblTimer.Text = "30 сек";
            // 
            // lblTimerTitle
            // 
            lblTimerTitle.AutoSize = true;
            lblTimerTitle.Font = new Font("Segoe UI", 10F);
            lblTimerTitle.Location = new Point(600, 55);
            lblTimerTitle.Name = "lblTimerTitle";
            lblTimerTitle.Size = new Size(84, 23);
            lblTimerTitle.TabIndex = 2;
            lblTimerTitle.Text = "Времени:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(52, 152, 219);
            lblStatus.Location = new Point(20, 150);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(287, 23);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Выберите режим и начните игру";
            // 
            // lblStatusTitle
            // 
            lblStatusTitle.AutoSize = true;
            lblStatusTitle.Font = new Font("Segoe UI", 10F);
            lblStatusTitle.Location = new Point(20, 120);
            lblStatusTitle.Name = "lblStatusTitle";
            lblStatusTitle.Size = new Size(64, 23);
            lblStatusTitle.TabIndex = 0;
            lblStatusTitle.Text = "Статус:";
            // 
            // gameTimer
            // 
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;
            // 
            // GameMemori
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 800);
            Controls.Add(pnlGame);
            Controls.Add(pnlTop);
            Controls.Add(grpGameInfo);
            Name = "GameMemori";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Anime Memory Game";
            WindowState = FormWindowState.Maximized;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            grpGameInfo.ResumeLayout(false);
            grpGameInfo.PerformLayout();
            ResumeLayout(false);
        }
    }
}