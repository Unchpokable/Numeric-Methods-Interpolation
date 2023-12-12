namespace Lab4
{
    partial class PolynomInterpForm
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
            this.TempValuesList = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CustomYOut = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ShouldRestrictArgRange_CheckBox = new System.Windows.Forms.CheckBox();
            this.CustomXInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SmoothingSelect = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.smoothingCheck = new System.Windows.Forms.RadioButton();
            this.interpolationCheck = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.InterpolationSelect = new System.Windows.Forms.ComboBox();
            this.InterpolationStepInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            this.ToolTipProvider = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.TempValuesList);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.RenderButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PlotView);
            this.splitContainer1.Size = new System.Drawing.Size(1427, 826);
            this.splitContainer1.SplitterDistance = 472;
            this.splitContainer1.TabIndex = 0;
            // 
            // TempValuesList
            // 
            this.TempValuesList.FormattingEnabled = true;
            this.TempValuesList.Location = new System.Drawing.Point(15, 405);
            this.TempValuesList.Name = "TempValuesList";
            this.TempValuesList.Size = new System.Drawing.Size(445, 212);
            this.TempValuesList.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.CustomYOut);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.ShouldRestrictArgRange_CheckBox);
            this.groupBox3.Controls.Add(this.CustomXInput);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 660);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(448, 154);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Рассчёт значения";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(432, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Выполнить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // CustomYOut
            // 
            this.CustomYOut.Location = new System.Drawing.Point(10, 95);
            this.CustomYOut.Name = "CustomYOut";
            this.CustomYOut.ReadOnly = true;
            this.CustomYOut.Size = new System.Drawing.Size(432, 20);
            this.CustomYOut.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(312, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Рассчётное значение аппроксимационной функции в точке:";
            // 
            // ShouldRestrictArgRange_CheckBox
            // 
            this.ShouldRestrictArgRange_CheckBox.AutoSize = true;
            this.ShouldRestrictArgRange_CheckBox.Location = new System.Drawing.Point(10, 49);
            this.ShouldRestrictArgRange_CheckBox.Name = "ShouldRestrictArgRange_CheckBox";
            this.ShouldRestrictArgRange_CheckBox.Size = new System.Drawing.Size(227, 17);
            this.ShouldRestrictArgRange_CheckBox.TabIndex = 2;
            this.ShouldRestrictArgRange_CheckBox.Text = "Ограничить диапазоном опорных точек";
            this.ShouldRestrictArgRange_CheckBox.UseVisualStyleBackColor = true;
            // 
            // CustomXInput
            // 
            this.CustomXInput.Location = new System.Drawing.Point(81, 23);
            this.CustomXInput.Name = "CustomXInput";
            this.CustomXInput.Size = new System.Drawing.Size(361, 20);
            this.CustomXInput.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Значение X:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SmoothingSelect);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.smoothingCheck);
            this.groupBox2.Controls.Add(this.interpolationCheck);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.InterpolationSelect);
            this.groupBox2.Controls.Add(this.InterpolationStepInput);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 181);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры";
            // 
            // SmoothingSelect
            // 
            this.SmoothingSelect.FormattingEnabled = true;
            this.SmoothingSelect.Location = new System.Drawing.Point(128, 101);
            this.SmoothingSelect.Name = "SmoothingSelect";
            this.SmoothingSelect.Size = new System.Drawing.Size(314, 21);
            this.SmoothingSelect.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Метод Сглаживания:";
            // 
            // smoothingCheck
            // 
            this.smoothingCheck.AutoSize = true;
            this.smoothingCheck.Location = new System.Drawing.Point(9, 84);
            this.smoothingCheck.Name = "smoothingCheck";
            this.smoothingCheck.Size = new System.Drawing.Size(93, 17);
            this.smoothingCheck.TabIndex = 8;
            this.smoothingCheck.TabStop = true;
            this.smoothingCheck.Text = "Сглаживание";
            this.smoothingCheck.UseVisualStyleBackColor = true;
            this.smoothingCheck.CheckedChanged += new System.EventHandler(this.AlgorithmChanged);
            // 
            // interpolationCheck
            // 
            this.interpolationCheck.AutoSize = true;
            this.interpolationCheck.Location = new System.Drawing.Point(9, 20);
            this.interpolationCheck.Name = "interpolationCheck";
            this.interpolationCheck.Size = new System.Drawing.Size(98, 17);
            this.interpolationCheck.TabIndex = 7;
            this.interpolationCheck.TabStop = true;
            this.interpolationCheck.Text = "Интерполяция";
            this.interpolationCheck.UseVisualStyleBackColor = true;
            this.interpolationCheck.CheckedChanged += new System.EventHandler(this.AlgorithmChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Метод Интерполяции";
            // 
            // InterpolationSelect
            // 
            this.InterpolationSelect.FormattingEnabled = true;
            this.InterpolationSelect.Location = new System.Drawing.Point(128, 37);
            this.InterpolationSelect.Name = "InterpolationSelect";
            this.InterpolationSelect.Size = new System.Drawing.Size(314, 21);
            this.InterpolationSelect.TabIndex = 2;
            // 
            // InterpolationStepInput
            // 
            this.InterpolationStepInput.Location = new System.Drawing.Point(194, 155);
            this.InterpolationStepInput.Name = "InterpolationStepInput";
            this.InterpolationStepInput.Size = new System.Drawing.Size(248, 20);
            this.InterpolationStepInput.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Шаг аппроксимирующей функции:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Промежуточные значения:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lockInputTextbox);
            this.groupBox1.Controls.Add(this.loadFromFileButton);
            this.groupBox1.Controls.Add(this.YInputTextbox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.XInputTextbox);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 185);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные";
            // 
            // lockInputTextbox
            // 
            this.lockInputTextbox.AutoSize = true;
            this.lockInputTextbox.Location = new System.Drawing.Point(10, 124);
            this.lockInputTextbox.Name = "lockInputTextbox";
            this.lockInputTextbox.Size = new System.Drawing.Size(104, 17);
            this.lockInputTextbox.TabIndex = 5;
            this.lockInputTextbox.Text = "Заблокировать";
            this.lockInputTextbox.UseVisualStyleBackColor = true;
            this.lockInputTextbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // loadFromFileButton
            // 
            this.loadFromFileButton.Location = new System.Drawing.Point(10, 147);
            this.loadFromFileButton.Name = "loadFromFileButton";
            this.loadFromFileButton.Size = new System.Drawing.Size(432, 23);
            this.loadFromFileButton.TabIndex = 4;
            this.loadFromFileButton.Text = "Загрузить из файла";
            this.loadFromFileButton.UseVisualStyleBackColor = true;
            this.loadFromFileButton.Click += new System.EventHandler(this.loadFromFileButton_Click);
            // 
            // YInputTextbox
            // 
            this.YInputTextbox.Location = new System.Drawing.Point(10, 97);
            this.YInputTextbox.Name = "YInputTextbox";
            this.YInputTextbox.Size = new System.Drawing.Size(432, 20);
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
            this.XInputTextbox.Location = new System.Drawing.Point(10, 40);
            this.XInputTextbox.Name = "XInputTextbox";
            this.XInputTextbox.Size = new System.Drawing.Size(432, 20);
            this.XInputTextbox.TabIndex = 0;
            this.XInputTextbox.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // RenderButton
            // 
            this.RenderButton.Location = new System.Drawing.Point(12, 630);
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
            this.PlotView.Size = new System.Drawing.Size(951, 826);
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
            // PolynomInterpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 826);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PolynomInterpForm";
            this.Text = "Interpolation";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox InterpolationStepInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox CustomYOut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox ShouldRestrictArgRange_CheckBox;
        private System.Windows.Forms.TextBox CustomXInput;
        private System.Windows.Forms.ToolTip ToolTipProvider;
        private System.Windows.Forms.ListBox TempValuesList;
        private System.Windows.Forms.RadioButton smoothingCheck;
        private System.Windows.Forms.RadioButton interpolationCheck;
        private System.Windows.Forms.ComboBox SmoothingSelect;
        private System.Windows.Forms.Label label8;
    }
}

