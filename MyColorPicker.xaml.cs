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

namespace Gusev_ITMO_WPF_Lab17
{
    /// <summary>
    /// Логика взаимодействия для MyColorPicker.xaml
    /// </summary>
    public partial class MyColorPicker : UserControl
    {
        public static DependencyProperty MyColorProperty;
        public static DependencyProperty MyRedProperty;
        public static DependencyProperty MyGreenProperty;
        public static DependencyProperty MyBlueProperty;
        public static readonly RoutedEvent ColorChangedEvent;

        static MyColorPicker()
        {
            MyColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(MyColorPicker),
                new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));

            MyRedProperty = DependencyProperty.Register("Red", typeof(byte), typeof(MyColorPicker),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

            MyGreenProperty = DependencyProperty.Register("Green", typeof(byte), typeof(MyColorPicker),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

            MyBlueProperty = DependencyProperty.Register("Blue", typeof(byte), typeof(MyColorPicker),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

            ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<Color>), typeof(MyColorPicker));
        }

        public Color MyColor
        {
            get { return (Color)GetValue(MyColorProperty); }
            set { SetValue(MyColorProperty, value); }
        }

        public byte MyRed
        {
            get { return (byte)GetValue(MyRedProperty); }
            set { SetValue(MyRedProperty, value); }
        }

        public byte MyGreen
        {
            get { return (byte)GetValue(MyGreenProperty); }
            set { SetValue(MyGreenProperty, value); }
        }

        public byte MyBlue
        {
            get { return (byte)GetValue(MyBlueProperty); }
            set { SetValue(MyBlueProperty, value); }
        }

        private static void OnColorRGBChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MyColorPicker colorPicker = (MyColorPicker) d;
            Color color = colorPicker.MyColor;

            if (e.Property == MyRedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == MyGreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == MyBlueProperty)
                color.B = (byte)e.NewValue;

            colorPicker.MyColor = color;

        }

        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            MyColorPicker colorpicker = (MyColorPicker)d;
            colorpicker.MyRed = newColor.R;
            colorpicker.MyGreen = newColor.G;
            colorpicker.MyBlue = newColor.B;
        }

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        public MyColorPicker()
        {
            InitializeComponent();
        }
    }
}
