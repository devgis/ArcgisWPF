using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ESRI.ArcGIS.Client;

namespace ArcgisWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            //nav.Map = mainMap;
            //sline.Map = mainMap;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var symbol=new ESRI.ArcGIS.Client.Symbols.PictureMarkerSymbol();
            symbol.Width = 20;
            symbol.Height = 20;
            //symbol.Source = new BitmapImage(new Uri("http://pnga.mypng.cn/2227/7-email.png.1.png", UriKind.Absolute));
            symbol.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "//p.png"));
            var randrom = new Random();
            var layer = mainMap.Layers["myLayer"] as GraphicsLayer;
            for (int i = 0; i < 100; i++)
            {
                var geo = new ESRI.ArcGIS.Client.Geometry.MapPoint();
                geo.X = randrom.Next(0,9999999);//103+randrom.NextDouble();
                geo.Y = randrom.Next(0,9999999);//34 + randrom.NextDouble();
                geo.SpatialReference = mainMap.SpatialReference;
                var graphic = new ESRI.ArcGIS.Client.Graphic();
                graphic.Geometry = geo;
                graphic.Symbol = symbol;
                //GraphicsLayer ID="myLayer"
                layer.Graphics.Add(graphic);
                
            }
            
            
        }
    }
}
