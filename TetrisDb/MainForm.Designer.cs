using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TetrisDb
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private IContainer components = null;

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
            this.components = new Container();
            this.mainPanel = new Panel();
            this.fieldPicture = new PictureBox();
            this.figurePanel = new Panel();
            this.nextFigurePicture = new PictureBox();
            this.buttonsPanel = new FlowLayoutPanel();
            this.scoreButton = new Button();
            this.pauseButton = new Button();
            this.startButton = new Button();
            this.levelLabel = new Label();
            this.pointsLabel = new Label();
            this.linesLabel = new Label();
            this.levelValue = new Label();
            this.pointsValue = new Label();
            this.linesValue = new Label();
            this.scoreLabel = new Label();
            this.scorePanel = new Panel();
            this.flowLayoutPanel1 = new FlowLayoutPanel();
            this.gameTimer = new Timer(this.components);
            this.mainPanel.SuspendLayout();
            ((ISupportInitialize)(this.fieldPicture)).BeginInit();
            this.figurePanel.SuspendLayout();
            ((ISupportInitialize)(this.nextFigurePicture)).BeginInit();
            this.buttonsPanel.SuspendLayout();
            this.scorePanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = SystemColors.ControlDark;
            this.mainPanel.Controls.Add(this.fieldPicture);
            this.mainPanel.Dock = DockStyle.Fill;
            this.mainPanel.Location = new Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new Padding(20);
            this.mainPanel.Size = new Size(340, 640);
            this.mainPanel.TabIndex = 1;
            // 
            // fieldPicture
            // 
            this.fieldPicture.Dock = DockStyle.Fill;
            this.fieldPicture.Location = new Point(20, 20);
            this.fieldPicture.Name = "fieldPicture";
            this.fieldPicture.Size = new Size(300, 600);
            this.fieldPicture.TabIndex = 0;
            this.fieldPicture.TabStop = false;
            // 
            // figurePanel
            // 
            this.figurePanel.BorderStyle = BorderStyle.FixedSingle;
            this.figurePanel.Controls.Add(this.nextFigurePicture);
            this.figurePanel.Location = new Point(3, 3);
            this.figurePanel.Name = "figurePanel";
            this.figurePanel.Size = new Size(205, 131);
            this.figurePanel.TabIndex = 0;
            // 
            // nextFigurePicture
            // 
            this.nextFigurePicture.Location = new Point(41, 3);
            this.nextFigurePicture.Name = "nextFigurePicture";
            this.nextFigurePicture.Size = new Size(120, 120);
            this.nextFigurePicture.TabIndex = 0;
            this.nextFigurePicture.TabStop = false;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.BorderStyle = BorderStyle.FixedSingle;
            this.buttonsPanel.Controls.Add(this.scoreButton);
            this.buttonsPanel.Controls.Add(this.pauseButton);
            this.buttonsPanel.Controls.Add(this.startButton);
            this.buttonsPanel.Location = new Point(3, 250);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Padding = new Padding(8);
            this.buttonsPanel.Size = new Size(205, 132);
            this.buttonsPanel.TabIndex = 1;
            // 
            // scoreButton
            // 
            this.scoreButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.scoreButton.Location = new Point(11, 11);
            this.scoreButton.Name = "scoreButton";
            this.scoreButton.Size = new Size(183, 33);
            this.scoreButton.TabIndex = 0;
            this.scoreButton.Text = "Таблица результатов";
            this.scoreButton.UseVisualStyleBackColor = true;
            this.scoreButton.Click += new EventHandler(this.scoreButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.pauseButton.Location = new Point(11, 50);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new Size(183, 33);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.Text = "Пауза";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new EventHandler(this.pauseButton_Click);
            // 
            // startButton
            // 
            this.startButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.startButton.Location = new Point(11, 89);
            this.startButton.Name = "startButton";
            this.startButton.Size = new Size(183, 33);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Новая игра";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new EventHandler(this.startButton_Click);
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.levelLabel.Location = new Point(7, 32);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new Size(73, 20);
            this.levelLabel.TabIndex = 2;
            this.levelLabel.Text = "Уровень";
            // 
            // pointsLabel
            // 
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.pointsLabel.Location = new Point(7, 52);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new Size(47, 20);
            this.pointsLabel.TabIndex = 3;
            this.pointsLabel.Text = "Очки";
            // 
            // linesLabel
            // 
            this.linesLabel.AutoSize = true;
            this.linesLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.linesLabel.Location = new Point(7, 72);
            this.linesLabel.Name = "linesLabel";
            this.linesLabel.Size = new Size(113, 20);
            this.linesLabel.TabIndex = 4;
            this.linesLabel.Text = "Линий убрано";
            // 
            // levelValue
            // 
            this.levelValue.AutoSize = true;
            this.levelValue.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            this.levelValue.Location = new Point(124, 32);
            this.levelValue.Name = "levelValue";
            this.levelValue.Size = new Size(19, 20);
            this.levelValue.TabIndex = 6;
            this.levelValue.Text = "0";
            // 
            // pointsValue
            // 
            this.pointsValue.AutoSize = true;
            this.pointsValue.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            this.pointsValue.Location = new Point(124, 52);
            this.pointsValue.Name = "pointsValue";
            this.pointsValue.Size = new Size(19, 20);
            this.pointsValue.TabIndex = 7;
            this.pointsValue.Text = "0";
            // 
            // linesValue
            // 
            this.linesValue.AutoSize = true;
            this.linesValue.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            this.linesValue.Location = new Point(124, 72);
            this.linesValue.Name = "linesValue";
            this.linesValue.Size = new Size(19, 20);
            this.linesValue.TabIndex = 8;
            this.linesValue.Text = "0";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.scoreLabel.Location = new Point(82, 12);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new Size(47, 20);
            this.scoreLabel.TabIndex = 10;
            this.scoreLabel.Text = "Счёт";
            // 
            // scorePanel
            // 
            this.scorePanel.BorderStyle = BorderStyle.FixedSingle;
            this.scorePanel.Controls.Add(this.scoreLabel);
            this.scorePanel.Controls.Add(this.levelLabel);
            this.scorePanel.Controls.Add(this.pointsLabel);
            this.scorePanel.Controls.Add(this.linesValue);
            this.scorePanel.Controls.Add(this.linesLabel);
            this.scorePanel.Controls.Add(this.pointsValue);
            this.scorePanel.Controls.Add(this.levelValue);
            this.scorePanel.Location = new Point(3, 140);
            this.scorePanel.Name = "scorePanel";
            this.scorePanel.Size = new Size(205, 104);
            this.scorePanel.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.figurePanel);
            this.flowLayoutPanel1.Controls.Add(this.scorePanel);
            this.flowLayoutPanel1.Controls.Add(this.buttonsPanel);
            this.flowLayoutPanel1.Dock = DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new Point(340, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new Size(220, 640);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 400;
            this.gameTimer.Tick += new EventHandler(this.gameTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(560, 640);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Тетрис";
            this.Load += new EventHandler(this.MainForm_Load);
            this.KeyDown += new KeyEventHandler(this.MainForm_KeyDown);
            this.Leave += new EventHandler(this.MainForm_Leave);
            this.mainPanel.ResumeLayout(false);
            ((ISupportInitialize)(this.fieldPicture)).EndInit();
            this.figurePanel.ResumeLayout(false);
            ((ISupportInitialize)(this.nextFigurePicture)).EndInit();
            this.buttonsPanel.ResumeLayout(false);
            this.scorePanel.ResumeLayout(false);
            this.scorePanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel scorePanel;
        private Label scoreLabel;
        private Label levelLabel;
        private Label pointsLabel;
        private Label linesValue;
        private Label linesLabel;
        private Label pointsValue;
        private Label levelValue;
        private FlowLayoutPanel buttonsPanel;
        private Button scoreButton;
        private Button pauseButton;
        private Button startButton;
        private Panel figurePanel;
        private Panel mainPanel;
        private FlowLayoutPanel flowLayoutPanel1;
        private Timer gameTimer;
        private PictureBox fieldPicture;
        private PictureBox nextFigurePicture;
    }
}

