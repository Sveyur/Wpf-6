using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        class WeatherControl : DependencyObject
        {
            public static readonly DependencyProperty TemperatureProperty;          
            private string directionWind;
            private int speedWind;
            private int precipitation;
            public WeatherControl(int temperature, string directionWind, int speedWind, int precipitation)
            {
                this.Temperature = temperature;
                this.Precipitation = precipitation;
                this.DirectionWind = directionWind;
                this.SpeedWind = speedWind;
            }
            static WeatherControl()
            {
                TemperatureProperty = DependencyProperty.Register(
                    nameof(Temperature), 
                    typeof(int), 
                    typeof(WeatherControl),
                    new FrameworkPropertyMetadata(0,
                    FrameworkPropertyMetadataOptions.Journal,null,
                    new CoerceValueCallback(CoerceTemperature)),
                    new ValidateValueCallback(ValidateTeTemperature));                                
            }
            private static object CoerceTemperature(DependencyObject d, object baseValue)
            {
                int v = (int)baseValue;
                if (v >= -50 && v <= 50)
                    return v;
                else
                    return 0;
            }
            private static bool ValidateTeTemperature(object value)
            {
                int v = (int) value;
                if (v >= -50 && v <= 50)
                    return true;
                else
                    return false;
            }

            public int Temperature
            {
                get => (int)GetValue(TemperatureProperty);
                set => SetValue(TemperatureProperty, value);
            }
            public string DirectionWind
            {
                get => directionWind;
                set => directionWind = value;
            }
            public int SpeedWind
            {
                get
                {
                    return speedWind;
                }
                set
                {
                    if (value > 0 && value < 67)
                    {
                        speedWind = value;
                    }
                    else
                    {
                        speedWind = 0;
                    }
                }
            }
            public int Precipitation
            {
                get
                {
                    return precipitation;
                }
                set
                {
                    if (value >= 0 && value <= 3)
                    {
                        precipitation = value;
                    }
                    else
                    {
                        precipitation = 0;
                    }
                }




            }
        }
    }

}