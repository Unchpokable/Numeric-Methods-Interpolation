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
    public partial class PolynomInterpForm : Form
    {
        public PolynomInterpForm(Form parent = null)
        {
            _parent = parent;
            InitializeComponent();
            _validationTimer = new System.Timers.Timer();
            _validationTimer.Interval = 1000; 
            _validationTimer.AutoReset = false;
            _validationTimer.Elapsed += ValidationTimerElapsed;
            InterpolationSelect.DataSource = Enum.GetValues(typeof(InterpolationType));
            InterpolationStepInput.Text = _interpolationStep.ToString(CultureInfo.InvariantCulture);
            ToolTipProvider.SetToolTip(ShouldRestrictArgRange_CheckBox, "Если включен, ввод значения, выходящего за границы диапазона, заданного опорными точками, будет считаться ошибкой");
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
        private float _interpolationStep = 1e-1f;
        private Vector2[] _controlPoints;
        private Form _parent;

        private void button1_Click(object sender, EventArgs e)
        {
            ValidateInput();
            TempValuesList.Items.Clear();
            if (!string.IsNullOrEmpty(InterpolationStepInput.Text))
            {
                if (!float.TryParse(InterpolationStepInput.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out _interpolationStep))
                {
                    InterpolationStepInput.BackColor = Color.LightCoral;
                    ErrProvider.SetError(InterpolationStepInput, "Неверное значение - не число");
                    return;
                }
                else
                {
                    InterpolationStepInput.BackColor = System.Drawing.SystemColors.Window;
                    ErrProvider.SetError(InterpolationStepInput, "");
                }
            }

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
                var interp_x = interpolator.Invoke(x);
                lineSeries.Points.Add(new DataPoint(x, interp_x));
                TempValuesList.Items.Add($"x = {x}, <interp>__P(x) = {interp_x}");
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

            _controlPoints = Utils.Merge(xValues.Select(x => float.Parse(x, CultureInfo.InvariantCulture)).ToArray(),
                yValues.Select(y => float.Parse(y, CultureInfo.InvariantCulture)).ToArray());
        }

        private bool IsValidInput(string value)
        {
            // Проверка наличия только цифр и точки
            return value.All(c => char.IsDigit(c) || c == '.' || c == '-');
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

                    Vector2[] result = Utils.Merge(xs, ys);
                    lockInputTextbox.Checked = true;
                    _controlPoints = result;
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
                if (!float.TryParse(tokens[i], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out values[i]))
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
                case InterpolationType.CubicSpline:
                    return Interpolation.CubicSpline(args);
                default:
                    return null;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _parent?.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ErrProvider.SetError(CustomXInput, "");
            ErrProvider.SetError(sender as Control, "");
            CustomYOut.Clear();
            if (_controlPoints == null || _controlPoints.Length == 0)
            {
                ErrProvider.SetError(sender as Control, "Контрольные точки не заданы, действие невозможно");
                return;
            }

            ErrProvider.SetError(CustomXInput, !float.TryParse(CustomXInput.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out float x) ? "Не число!" : "");

            if (ShouldRestrictArgRange_CheckBox.Checked)
            {
                _controlPoints = _controlPoints.OrderBy(p => p.X).ToArray();
                if (x < _controlPoints[0].X || x > _controlPoints[_controlPoints.Length - 1].X)
                {
                    ErrProvider.SetError(CustomXInput, "Значение должно находится в заданном диапазоне опорных точек!");
                    return;
                }
            }

            var y = GetInterpolationByType(
                (InterpolationType)Enum.Parse(typeof(InterpolationType), InterpolationSelect.SelectedValue.ToString()),
                _controlPoints).Invoke(x);

            CustomYOut.Text = y.ToString(CultureInfo.InvariantCulture);
        }
    }
}
