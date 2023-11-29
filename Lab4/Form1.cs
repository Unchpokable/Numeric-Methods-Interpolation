using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _validationTimer = new System.Timers.Timer();
            _validationTimer.Interval = 1000; 
            _validationTimer.AutoReset = false;
            _validationTimer.Elapsed += ValidationTimerElapsed;
            InterpolationSelect.DataSource = Enum.GetValues(typeof(InterpolationType));
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            _validationTimer.Stop();
            _validationTimer.Start();

            _lastTouchedTextbox = (TextBox)sender;
        }

        private void ValidationTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Invoke((MethodInvoker)ValidateInput);
        }

        private System.Timers.Timer _validationTimer;
        private TextBox _lastTouchedTextbox;
        private float _interpolationStep = 1e-3f;
        private Vector2[] _controlPoints;

        private void button1_Click(object sender, EventArgs e)
        {
            ValidateInput();

            if (_controlPoints == null || _controlPoints.Length == 0) { return; }

            var interpolator = GetInterpolationByType((InterpolationType)Enum.Parse(typeof(InterpolationType), InterpolationSelect.SelectedValue.ToString()), _controlPoints);

            var model = new PlotModel { Title = "Интерполяция функции в заданных значениях" };

            var scatterSeries = new ScatterSeries() { MarkerType = MarkerType.Circle };

            foreach (var pt in _controlPoints)
            {
                scatterSeries.Points.Add(new ScatterPoint(pt.X, pt.Y));
            }

            var lineSeries = new LineSeries { Color = OxyColors.Blue };


            var minx = _controlPoints.Select(x => x.X).Min();
            var maxx = _controlPoints.Select(x => x.X).Max();

            for (var x = minx; x <= maxx; x += _interpolationStep)
            {
                lineSeries.Points.Add(new DataPoint(x, interpolator.Invoke(x)));
            }

            model.Series.Add(scatterSeries);
            model.Series.Add(lineSeries);

            PlotView.Model = model;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            XInputTextbox.Enabled = !(sender as CheckBox)?.Checked ?? true;
            YInputTextbox.Enabled = !(sender as CheckBox)?.Checked ?? true;
        }

        private void ValidateInput()
        {
            if (string.IsNullOrEmpty(XInputTextbox.Text) || string.IsNullOrEmpty(YInputTextbox.Text))
            {
                RenderButton.Enabled = false;
                return;
            }
            
            // Получаем введенные значения
            string[] xValues = XInputTextbox.Text.Split(' ');
            string[] yValues = YInputTextbox.Text.Split(' ');

            // Проверка наличия недопустимых символов
            if (xValues.Any(value => !IsValidInput(value)) || yValues.Any(value => !IsValidInput(value)))
            {
                ErrProvider.SetError(_lastTouchedTextbox, "Неверный ввод - допустимы только символы [0-9] и точка \".\"");
                _lastTouchedTextbox.BackColor = System.Drawing.Color.LightCoral;
                RenderButton.Enabled = false;
                return;
            }

            // Проверка на совпадение количества введенных чисел
            if (xValues.Length != yValues.Length)
            {
                ErrProvider.SetError(_lastTouchedTextbox, "Неверный ввод - кол-во введенных чисел должно быть одинаковым");
                _lastTouchedTextbox.BackColor = System.Drawing.Color.LightCoral;
                RenderButton.Enabled = false;
                return;
            }

            RenderButton.Enabled = true;
            ErrProvider.SetError(XInputTextbox, "");
            ErrProvider.SetError(YInputTextbox, "");

            // Сброс цвета при успешной валидации
            XInputTextbox.BackColor = System.Drawing.SystemColors.Window;
            YInputTextbox.BackColor = System.Drawing.SystemColors.Window;

            _controlPoints = Merge(xValues.Select(x => float.Parse(x, CultureInfo.InvariantCulture)).ToArray(),
                yValues.Select(y => float.Parse(y, CultureInfo.InvariantCulture)).ToArray());
        }

        private bool IsValidInput(string value)
        {
            // Проверка наличия только цифр и точки
            return value.All(c => char.IsDigit(c) || c == '.' || c == '-');
        }

        private Vector2[] Merge(float[] xs, float[] ys)
        {
            if (xs.Length != ys.Length)
                throw new ArgumentException("Unmatched sizes of argument arrays");

            var result = new Vector2[xs.Length];

            for (int i = 0; i < xs.Length; i++)
            {
                result[i] = new Vector2(xs[i], ys[i]);
            }

            return result;
        }

        private void loadFromFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
            openFileDialog.Title = "Select a Text File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string[] lines = File.ReadAllLines(filePath);

                    if (lines.Length != 2)
                    {
                        MessageBox.Show("File should contain exactly two lines.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    float[] xs = ValidateAndParseLine(lines[0]);
                    float[] ys = ValidateAndParseLine(lines[1]);

                    if (xs == null || ys == null)
                    {
                        MessageBox.Show("Invalid data format in the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    XInputTextbox.Text = lines[0];
                    YInputTextbox.Text = lines[1];

                    Vector2[] result = Merge(xs, ys);
                    lockInputTextbox.Checked = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private float[] ValidateAndParseLine(string line)
        {
            string[] tokens = line.Split(' ');

            float[] values = new float[tokens.Length];

            for (int i = 0; i < tokens.Length; i++)
            {
                if (!float.TryParse(tokens[i], out values[i]))
                {
                    return null; // Возвращаем null в случае ошибки парсинга
                }
            }

            return values;
        }

        private Func<float, float> GetInterpolationByType(InterpolationType type, Vector2[] args)
        {
            switch (type)
            {
                case InterpolationType.Lagrange:
                    return Interpolation.OfLagrange(args);
                case InterpolationType.Newton:
                    return Interpolation.OfNewton(args);
                default:
                    return null;
            }
        }
    }
}
