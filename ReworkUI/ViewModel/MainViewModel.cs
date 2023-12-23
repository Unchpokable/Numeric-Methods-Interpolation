using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Lab4;
using Microsoft.Win32;
using OxyPlot;
using OxyPlot.Legends;
using ReworkUI.Core;
using ReworkUI.Locale;
using ReworkUI.Model;

namespace ReworkUI.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            PlotBackground = new SolidColorBrush(Colors.Transparent);
            _processor = new FunctionProcessor();
            _processor.Finished += OnProcessorCompletedAction;

            ProcessingModes = Interpolations.Select(x => (object)x).ToList();
            SelectedProcessingMode = InterpolationType.Lagrange;

            SwapProcessingModes = new RelayCommand(SwapAvailableModes);

            ProcessFunction = new RelayCommand(ExecuteFunctionProcessing);

            PerformDirectCalculation = new RelayCommand(PerformDirectCalculateInternal);

            LoadDataFromFile = new RelayCommand(LoadDataFromFileInternal);

            SelectPlotBackground = new RelayCommand(SelectPlotBackgroundColor);

            ApproximationFunctionStep = 0.01f;
            _processor.Step = ApproximationFunctionStep;

            InputErrorLabelVisible = Visibility.Collapsed;
        }

        public IEnumerable<InterpolationType> Interpolations => Enum.GetValues(typeof(InterpolationType)).Cast<InterpolationType>();

        public IEnumerable<SmoothingType> Smoothings => Enum.GetValues(typeof(SmoothingType)).Cast<SmoothingType>();

        public RelayCommand SwapProcessingModes { get; set; }
        public RelayCommand PerformDirectCalculation { get; set; }
        public RelayCommand ProcessFunction { get; set; }
        public RelayCommand SelectPlotBackground { get; set; }

        public RelayCommand LoadDataFromFile { get; set; }

        public object SelectedProcessingMode
        {
            get => _selectedProcessingMode;
            set
            {
                _selectedProcessingMode = value;
                OnPropertyChanged();
            }
        }

        public List<object> ProcessingModes
        {
            get => _processingModes;
            set
            {
                _processingModes = value;
                OnPropertyChanged();
            }
        }

        public Brush PlotBackground
        {
            get => _plotBackground;
            set
            {
                _plotBackground = value;
                OnPropertyChanged();
            }
        }

        public PlotModel Model
        {
            get => _plot;
            set
            {
                _plot = value;
                OnPropertyChanged();
            }
        }

        public string RawInputX
        {
            get => _rawInputX;
            set
            {
                _rawInputX = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public string RawInputY
        {
            get => _rawInputY;
            set
            {
                _rawInputY = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public float DirectCalculateInput
        {
            get => _directCalculateInput;
            set
            {
                _directCalculateInput = value;
                OnPropertyChanged();
            }
        }

        public float DirectCalculateOutput
        {
            get => _directCalculateOutput;
            set
            {
                _directCalculateOutput = value;
                OnPropertyChanged();
            }
        }

        public Visibility InputErrorLabelVisible
        {
            get => _inputErrorLabelVisible;
            set
            {
                _inputErrorLabelVisible = value;
                OnPropertyChanged();
            }
        }

        public float ApproximationFunctionStep
        {
            get => _approximationFunctionStep;
            set
            {
                _approximationFunctionStep = value;
                ValidateInput();
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Steps => new ObservableCollection<string>(_processor.Steps);

        private FunctionProcessor _processor;

        private Visibility _inputErrorLabelVisible;

        private Brush _plotBackground;
        private PlotModel _plot;

        private string _rawInputX;
        private string _rawInputY;

        private float _directCalculateInput;
        private float _directCalculateOutput;

        private List<object> _processingModes;
        private object _selectedProcessingMode;

        private List<float> _inputDataX;
        private List<float> _inputDataY;
        private float _approximationFunctionStep;


        private void OnProcessorCompletedAction(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(Steps));
        }

        private void SwapAvailableModes(object argument)
        {
            if (!(argument is ProcessingType type))
                return;

            switch (type)
            {
                case ProcessingType.Interpolation:
                    ProcessingModes = Interpolations.Select(x => (object)x).ToList();
                    SelectedProcessingMode = InterpolationType.Lagrange;
                    break;
                case ProcessingType.Smoothing:
                    ProcessingModes = Smoothings.Select(x => (object)x).ToList();
                    SelectedProcessingMode = SmoothingType.NonLinearLeastSquares;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ExecuteFunctionProcessing(object parameter)
        {
            if (!ValidateInput())
                return;

            var selectedProcessingMode = _selectedProcessingMode;

            _processor.Steps.Clear();
            _processor.Step = ApproximationFunctionStep;
            if (selectedProcessingMode == null)
            {
                _processor.Steps.Add("Невозможно выполнить - не выбран алгоритм аппроксимации");
                OnPropertyChanged(nameof(Steps));
                return;
            }

            _processor.AssignControlPoints(MergeControlPoints());


            PlotModel data = new PlotModel();

            if (Enum.TryParse(selectedProcessingMode.ToString(), true, out InterpolationType interpolation))
            {
                data = _processor.InterpolateRange(interpolation);
            }

            else if (Enum.TryParse(selectedProcessingMode.ToString(), true, out SmoothingType smoothing))
            {
                data = _processor.SmoothRange(smoothing);
            }

            data.Title = ProcessingModesTranslation.TranslateProcessingMode(_selectedProcessingMode);


            var textColorBytes = ArgsFromHex("#FFC3C3C3");
            var textColor = OxyColor.FromArgb(textColorBytes.Item1, textColorBytes.Item2, textColorBytes.Item3, textColorBytes.Item4);
            data.TextColor = textColor;
            data.PlotAreaBorderColor = textColor;
            data.SelectionColor = textColor;
            data.DefaultFont = "Tahoma";
            data.DefaultFontSize = 16;

            data.Legends.Add(new Legend() { LegendPlacement = LegendPlacement.Outside, LegendFontSize = 18, LegendPosition = LegendPosition.TopLeft });
            data.Legends.Add(new Legend() { LegendPlacement = LegendPlacement.Outside, LegendFontSize = 18, LegendPosition = LegendPosition.TopLeft });

            Model = data;
        }

        private bool ValidateInput()
        {
            var xs = RawInputX?.Trim().Split(' ') ?? Array.Empty<string>();
            var ys = RawInputY?.Trim().Split(' ') ?? Array.Empty<string>();

            try
            {
                _inputDataX = xs.Select(float.Parse).ToList();
                _inputDataY = ys.Select(float.Parse).ToList();

                if (_inputDataX.Count != _inputDataY.Count)
                {
                    InputErrorLabelVisible = Visibility.Visible;
                    return false;
                }
                else
                {
                    InputErrorLabelVisible = Visibility.Collapsed;
                    return true;
                }
            }
            catch (FormatException)
            {
                InputErrorLabelVisible = Visibility.Visible;
                return false;
            }
        }

        private Vector2[] MergeControlPoints()
        {
            if (_inputDataX.Count != _inputDataY.Count)
                return null;

            var result = new Vector2[_inputDataX.Count];

            for (var i = 0; i < _inputDataX.Count; i++)
            {
                result[i] = new Vector2(_inputDataX[i], _inputDataY[i]);
            }

            return result;
        }

        private void PerformDirectCalculateInternal(object o)
        {
            var x = DirectCalculateInput;

            Func<float, float> interpolator = f => f;

            if (Enum.TryParse(SelectedProcessingMode.ToString(), true, out InterpolationType interpolation))
            {
                switch (interpolation)
                {
                    case InterpolationType.Lagrange:
                        interpolator = Interpolation.OfLagrange(MergeControlPoints());
                        break;
                    case InterpolationType.Newton:
                        interpolator = Interpolation.OfNewton(MergeControlPoints());
                        break;
                    case InterpolationType.CubicSpline:
                        interpolator = Interpolation.CubicSpline(MergeControlPoints());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(interpolation), interpolation, null);
                }
            }

            else if (Enum.TryParse(SelectedProcessingMode.ToString(), true, out SmoothingType smoothing))
            {
                switch (smoothing)
                {
                    case SmoothingType.NonLinearLeastSquares:
                        interpolator = Smoothing.NonLinearLeastSquares(MergeControlPoints());
                        break;
                    case SmoothingType.LinearLeastSquares:
                        interpolator = Smoothing.LinearLeastSquares(MergeControlPoints());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(smoothing), smoothing, null);
                }
            }

            DirectCalculateOutput = interpolator?.Invoke(x) ?? float.NaN;
        }

        private (byte, byte, byte, byte) ArgsFromHex(string hex)
        {
            if (hex.StartsWith("#"))
                hex = hex.Substring(1);

            if (hex.Length != 8)
                throw new ArgumentException("Incorrect hex color representation", nameof(hex));

            byte alpha = Convert.ToByte(hex.Substring(0, 2), 16);
            byte red = Convert.ToByte(hex.Substring(2, 2), 16);
            byte green = Convert.ToByte(hex.Substring(4, 2), 16);
            byte blue = Convert.ToByte(hex.Substring(6, 2), 16);

            return (alpha, red, green, blue);
        }

        private void LoadDataFromFileInternal(object o)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    string[] lines = File.ReadAllLines(filePath);

                    float[] arrayX = ParseStringToFloatArray(lines[0]);
                    float[] arrayY = ParseStringToFloatArray(lines[1]);

                    RawInputX = lines[0];
                    RawInputY = lines[1];

                    _inputDataX = arrayX.ToList();
                    _inputDataY = arrayY.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private float[] ParseStringToFloatArray(string input)
        {
            var stringNumbers = input.Split(' ');

            var result = new float[stringNumbers.Length];

            for (var i = 0; i < stringNumbers.Length; i++)
            {
                if (float.TryParse(stringNumbers[i], out float number))
                {
                    result[i] = number;
                }
                else
                {
                    MessageBox.Show($"Error parsing value \"{stringNumbers[i]}\" at line {input}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }

            return result;
        }

        private void SelectPlotBackgroundColor(object o)
        {
            var dialog = new Service.Dialogs.ColorPickerDialog(((SolidColorBrush)PlotBackground).Color);
            dialog.ShowDialog();

            if (dialog.Selected)
            {
                PlotBackground = new SolidColorBrush(dialog.SelectedColor);
            }
        }
    }
}
