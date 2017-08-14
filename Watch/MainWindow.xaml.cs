using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Watch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer minuteschanged = null;
        public MainWindow()
        {
            InitializeComponent();
             minuteschanged = new Timer();
            minuteschanged.Enabled = true;
            minuteschanged.Interval = 60;
            minuteschanged.Elapsed += Minuteschanged_Elapsed;
           
        }

        private void Minuteschanged_Elapsed(object sender, ElapsedEventArgs e)
        {
            minuteschanged.Enabled = false;
            string timeH =  DateTime.Now.Hour.ToString();
            string timeM = DateTime.Now.Minute.ToString();

            

            string filelocH1 = @"C:\Users\ady8\Desktop\digits\";
            string filelocH2 = filelocH1;
            string filelocM1 = filelocH1;
            string filelocM2 = filelocH1;

            if (timeH.Length == 2 )
            {
                if (timeM.Length == 2)
                {
                    filelocM1 = filelocM1 + timeM[0].ToString() + ".png";
                    filelocM2 = filelocM2 + timeM[1].ToString() + ".png";
                    filelocH1 = filelocH1 + timeH[0].ToString() + ".png";
                    filelocH2 = filelocH2 + timeH[1].ToString() + ".png";
                }
                else
                    {
                    filelocM1 = filelocM1 + "0.png";
                    filelocM2 = filelocM2 + timeM[0].ToString() + ".png";
                    filelocH1 = filelocH1 + timeH[0].ToString() + ".png";
                    filelocH2 = filelocH2 + timeH[1].ToString() + ".png";
                    }
            }
            else
            {
                if (timeM.Length == 2)
                {
                    filelocM1 = filelocM1 + timeM[0].ToString() + ".png";
                    filelocM2 = filelocM2 + timeM[1].ToString() + ".png";
                    filelocH1 = filelocH1  + "0.png";
                    filelocH2 = filelocH2 + timeH[0].ToString() + ".png";
                }
                else
                {
                    filelocM1 = filelocM1 + "0.png";
                    filelocM2 = filelocM2 + timeM[0].ToString() + ".png";
                    filelocH1 = filelocH1 + "0.png";
                    filelocH2 = filelocH2 + timeH[0].ToString() + ".png";
                }
            }
            
            
            customStack.Dispatcher.Invoke(new Action(() => doit(filelocM2,filelocM1,filelocH2,filelocH1)));
            //customStack.Dispatcher.Invoke(new Action(() => customStack.Children.Add(new Image() { Margin = new Thickness(49, 0, 98, 0),  Height = 100, Width = 49, Source = new BitmapImage(new Uri(filelocH2)) })));
            //customStack.Dispatcher.Invoke(new Action(() => customStack.Children.Add(new Image() { Margin = new Thickness(98, 0, 95, 0), Height = 100, Width = 49, Source = new BitmapImage(new Uri(@"C:\Users\ady8\Desktop\digits\sep.png")) })));

            //customStack.Dispatcher.Invoke(new Action(() => customStack.Children.Add(new Image() { Margin = new Thickness(95, 0, 46, 0),  Height = 100, Width = 49, Source = new BitmapImage(new Uri(filelocM1)) })));
            //customStack.Dispatcher.Invoke(new Action(() => customStack.Children.Add(new Image() { Margin = new Thickness(147, 0, 0, 0),  Height = 100, Width = 49, Source = new BitmapImage(new Uri(filelocM2)) })));

        }

        private void doit(string m2 , string m1 , string h2 , string h1)
        {
            customStack.Children.Add(new Image() { Margin = new Thickness(0, 0, 147, 0), Height = 100, Width = 49, Source = new BitmapImage(new Uri(h1)) });
            customStack.Children.Add(new Image() { Margin = new Thickness(49, 0, 98, 0), Height = 100, Width = 49, Source = new BitmapImage(new Uri(h2)) });
            customStack.Children.Add(new Image() { Margin = new Thickness(95, 0, 46, 0), Height = 100, Width = 49, Source = new BitmapImage(new Uri(m1)) });
            customStack.Children.Add(new Image() { Margin = new Thickness(147, 0, 0, 0), Height = 100, Width = 49, Source = new BitmapImage(new Uri(m2)) });
        }
    }
}
