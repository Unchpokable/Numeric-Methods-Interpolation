namespace Lab4
{
    partial class Form1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lockInputTextbox = new System.Windows.Forms.CheckBox();
            this.loadFromFileButton = new System.Windows.Forms.Button();
            this.YInputTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.XInputTextbox = new System.Windows.Forms.TextBox();
            this.RenderButton = new System.Windows.Forms.Button();
            this.PlotView = new OxyPlot.WindowsForms.PlotView();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.InterpolationSelect = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.InterpolationSelect);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.RenderButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PlotView);
            this.splitContainer1.Size = new System.Drawing.Size(1427, 826);
            this.splitContainer1.SplitterDistance = 474;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lockInputTextbox);
            this.groupBox1.Controls.Add(this.loadFromFileButton);
            this.groupBox1.Controls.Add(this.YInputTextbox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.XInputTextbox);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 402);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные";
            // 
            // lockInputTextbox
            // 
            this.lockInputTextbox.AutoSize = true;
            this.lockInputTextbox.Location = new System.Drawing.Point(6, 124);
            this.lockInputTextbox.Name = "lockInputTextbox";
            this.lockInputTextbox.Size = new System.Drawing.Size(104, 17);
            this.lockInputTextbox.TabIndex = 5;
            this.lockInputTextbox.Text = "Заблокировать";
            this.lockInputTextbox.UseVisualStyleBackColor = true;
            this.lockInputTextbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // loadFromFileButton
            // 
            this.loadFromFileButton.Location = new System.Drawing.Point(10, 373);
            this.loadFromFileButton.Name = "loadFromFileButton";
            this.loadFromFileButton.Size = new System.Drawing.Size(431, 23);
            this.loadFromFileButton.TabIndex = 4;
            this.loadFromFileButton.Text = "Загрузить из файла";
            this.loadFromFileButton.UseVisualStyleBackColor = true;
            this.loadFromFileButton.Click += new System.EventHandler(this.loadFromFileButton_Click);
            // 
            // YInputTextbox
            // 
            this.YInputTextbox.Location = new System.Drawing.Point(6, 97);
            this.YInputTextbox.Name = "YInputTextbox";
            this.YInputTextbox.Size = new System.Drawing.Size(402, 20);
            this.YInputTextbox.TabIndex = 3;
            this.YInputTextbox.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Значения Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Значения X";
            // 
            // XInputTextbox
            // 
            this.XInputTextbox.Location = new System.Drawing.Point(6, 43);
            this.XInputTextbox.Name = "XInputTextbox";
            this.XInputTextbox.Size = new System.Drawing.Size(402, 20);
            this.XInputTextbox.TabIndex = 0;
            this.XInputTextbox.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // RenderButton
            // 
            this.RenderButton.Location = new System.Drawing.Point(13, 791);
            this.RenderButton.Name = "RenderButton";
            this.RenderButton.Size = new System.Drawing.Size(448, 23);
            this.RenderButton.TabIndex = 0;
            this.RenderButton.Text = "Построить";
            this.RenderButton.UseVisualStyleBackColor = true;
            this.RenderButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // PlotView
            // 
            this.PlotView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlotView.Location = new System.Drawing.Point(0, 0);
            this.PlotView.Name = "PlotView";
            this.PlotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.PlotView.Size = new System.Drawing.Size(949, 826);
            this.PlotView.TabIndex = 0;
            this.PlotView.Text = "plotView1";
            this.PlotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.PlotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.PlotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // InterpolationSelect
            // 
            this.InterpolationSelect.FormattingEnabled = true;
            this.InterpolationSelect.Location = new System.Drawing.Point(13, 466);
            this.InterpolationSelect.Name = "InterpolationSelect";
            this.InterpolationSelect.Size = new System.Drawing.Size(448, 21);
            this.InterpolationSelect.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 447);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Метод Интерполяции";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 826);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Interpolation";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private OxyPlot.WindowsForms.PlotView PlotView;
        private System.Windows.Forms.Button RenderButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox XInputTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox YInputTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loadFromFileButton;
        private System.Windows.Forms.CheckBox lockInputTextbox;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox InterpolationSelect;
    }
}

