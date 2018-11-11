using FootballMatchSimulator.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace FootballMatchSimulator.UI
{
    /// <summary>
    /// Логика взаимодействия для MatchRes.xaml
    /// </summary>
    public partial class MatchRes : Window
    {
        public MatchRes(PlayerViewModel vm)
        {
            InitializeComponent();
            string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "Img/football.jpg");
            Background = new ImageBrush(new BitmapImage(new Uri(path)));
            path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "Img/icons/minimize.png");
            cutDownBtn.Background = new ImageBrush(new BitmapImage(new Uri(path)));
            path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "Img/icons/close.png");
            powerBtn.Background = new ImageBrush(new BitmapImage(new Uri(path)));
            DataContext = vm;
        }

        private void powerBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void cutDownBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
