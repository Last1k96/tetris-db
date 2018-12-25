﻿namespace TetrisDb
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.fieldPicture = new System.Windows.Forms.PictureBox();
            this.figurePanel = new System.Windows.Forms.Panel();
            this.nextFigurePicture = new System.Windows.Forms.PictureBox();
            this.buttonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.scoreButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.levelLabel = new System.Windows.Forms.Label();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.linesLabel = new System.Windows.Forms.Label();
            this.levelValue = new System.Windows.Forms.Label();
            this.pointsValue = new System.Windows.Forms.Label();
            this.linesValue = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.scorePanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldPicture)).BeginInit();
            this.figurePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nextFigurePicture)).BeginInit();
            this.buttonsPanel.SuspendLayout();
            this.scorePanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mainPanel.Controls.Add(this.fieldPicture);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.Size = new System.Drawing.Size(340, 640);
            this.mainPanel.TabIndex = 1;
            // 
            // fieldPicture
            // 
            this.fieldPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldPicture.Location = new System.Drawing.Point(20, 20);
            this.fieldPicture.Name = "fieldPicture";
            this.fieldPicture.Size = new System.Drawing.Size(300, 600);
            this.fieldPicture.TabIndex = 0;
            this.fieldPicture.TabStop = false;
            // 
            // figurePanel
            // 
            this.figurePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.figurePanel.Controls.Add(this.nextFigurePicture);
            this.figurePanel.Location = new System.Drawing.Point(3, 3);
            this.figurePanel.Name = "figurePanel";
            this.figurePanel.Size = new System.Drawing.Size(205, 131);
            this.figurePanel.TabIndex = 0;
            // 
            // nextFigurePicture
            // 
            this.nextFigurePicture.Location = new System.Drawing.Point(41, 3);
            this.nextFigurePicture.Name = "nextFigurePicture";
            this.nextFigurePicture.Size = new System.Drawing.Size(120, 120);
            this.nextFigurePicture.TabIndex = 0;
            this.nextFigurePicture.TabStop = false;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonsPanel.Controls.Add(this.scoreButton);
            this.buttonsPanel.Controls.Add(this.pauseButton);
            this.buttonsPanel.Controls.Add(this.startButton);
            this.buttonsPanel.Location = new System.Drawing.Point(3, 250);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Padding = new System.Windows.Forms.Padding(8);
            this.buttonsPanel.Size = new System.Drawing.Size(205, 132);
            this.buttonsPanel.TabIndex = 1;
            // 
            // scoreButton
            // 
            this.scoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreButton.Location = new System.Drawing.Point(11, 11);
            this.scoreButton.Name = "scoreButton";
            this.scoreButton.Size = new System.Drawing.Size(183, 33);
            this.scoreButton.TabIndex = 0;
            this.scoreButton.Text = "Таблица результатов";
            this.scoreButton.UseVisualStyleBackColor = true;
            this.scoreButton.Click += new System.EventHandler(this.scoreButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pauseButton.Location = new System.Drawing.Point(11, 50);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(183, 33);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.Text = "Пауза";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startButton.Location = new System.Drawing.Point(11, 89);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(183, 33);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Новая игра";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.levelLabel.Location = new System.Drawing.Point(7, 32);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(73, 20);
            this.levelLabel.TabIndex = 2;
            this.levelLabel.Text = "Уровень";
            // 
            // pointsLabel
            // 
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pointsLabel.Location = new System.Drawing.Point(7, 52);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(47, 20);
            this.pointsLabel.TabIndex = 3;
            this.pointsLabel.Text = "Очки";
            // 
            // linesLabel
            // 
            this.linesLabel.AutoSize = true;
            this.linesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linesLabel.Location = new System.Drawing.Point(7, 72);
            this.linesLabel.Name = "linesLabel";
            this.linesLabel.Size = new System.Drawing.Size(113, 20);
            this.linesLabel.TabIndex = 4;
            this.linesLabel.Text = "Линий убрано";
            // 
            // levelValue
            // 
            this.levelValue.AutoSize = true;
            this.levelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.levelValue.Location = new System.Drawing.Point(124, 32);
            this.levelValue.Name = "levelValue";
            this.levelValue.Size = new System.Drawing.Size(19, 20);
            this.levelValue.TabIndex = 6;
            this.levelValue.Text = "0";
            // 
            // pointsValue
            // 
            this.pointsValue.AutoSize = true;
            this.pointsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pointsValue.Location = new System.Drawing.Point(124, 52);
            this.pointsValue.Name = "pointsValue";
            this.pointsValue.Size = new System.Drawing.Size(19, 20);
            this.pointsValue.TabIndex = 7;
            this.pointsValue.Text = "0";
            // 
            // linesValue
            // 
            this.linesValue.AutoSize = true;
            this.linesValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linesValue.Location = new System.Drawing.Point(124, 72);
            this.linesValue.Name = "linesValue";
            this.linesValue.Size = new System.Drawing.Size(19, 20);
            this.linesValue.TabIndex = 8;
            this.linesValue.Text = "0";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreLabel.Location = new System.Drawing.Point(82, 12);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(47, 20);
            this.scoreLabel.TabIndex = 10;
            this.scoreLabel.Text = "Счёт";
            // 
            // scorePanel
            // 
            this.scorePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scorePanel.Controls.Add(this.scoreLabel);
            this.scorePanel.Controls.Add(this.levelLabel);
            this.scorePanel.Controls.Add(this.pointsLabel);
            this.scorePanel.Controls.Add(this.linesValue);
            this.scorePanel.Controls.Add(this.linesLabel);
            this.scorePanel.Controls.Add(this.pointsValue);
            this.scorePanel.Controls.Add(this.levelValue);
            this.scorePanel.Location = new System.Drawing.Point(3, 140);
            this.scorePanel.Name = "scorePanel";
            this.scorePanel.Size = new System.Drawing.Size(205, 104);
            this.scorePanel.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.figurePanel);
            this.flowLayoutPanel1.Controls.Add(this.scorePanel);
            this.flowLayoutPanel1.Controls.Add(this.buttonsPanel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(340, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(220, 640);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 400;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 640);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тетрис";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fieldPicture)).EndInit();
            this.figurePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nextFigurePicture)).EndInit();
            this.buttonsPanel.ResumeLayout(false);
            this.scorePanel.ResumeLayout(false);
            this.scorePanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel scorePanel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.Label linesValue;
        private System.Windows.Forms.Label linesLabel;
        private System.Windows.Forms.Label pointsValue;
        private System.Windows.Forms.Label levelValue;
        private System.Windows.Forms.FlowLayoutPanel buttonsPanel;
        private System.Windows.Forms.Button scoreButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Panel figurePanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox fieldPicture;
        private System.Windows.Forms.PictureBox nextFigurePicture;
    }
}
