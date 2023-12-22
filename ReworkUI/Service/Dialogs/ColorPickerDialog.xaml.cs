using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace ReworkUI.Service.Dialogs
{
    public partial class ColorPickerDialog : Window, INotifyPropertyChanged
    {
        public ColorPickerDialog()
        {
            InitializeComponent();
            DataContext = this;
            _selectedColor.A = 255;
        }

        public SolidColorBrush SelectedColorBrush { get; set; }

        public Color SelectedColor
        {
            get => _selectedColor;
            set
            {
                _selectedColor = value;
                OnPropertyChanged();
                SelectedColorBrush = new SolidColorBrush(_selectedColor);
                OnPropertyChanged(nameof(SelectedColorBrush));
            }
        }

        public bool Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged();
            }
        }

        private Color _selectedColor;

        private bool _selected = false;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Selected = true;
            Close();
        }
    }
}
