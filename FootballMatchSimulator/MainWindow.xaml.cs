using FootballMatchSimulator.UI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FootballMatchSimulator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Window> wins;
        public MainWindow()
        {
            InitializeComponent();
            string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "Img/icons/minimize.png");
            cutDownBtn.Background = new ImageBrush(new BitmapImage(new Uri(path)));
            path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "Img/icons/close.png");
            powerBtn.Background = new ImageBrush(new BitmapImage(new Uri(path)));
            wins = new List<Window>() { new LogIn(), new MatchRes(), new MatchSett()
            , new PersonalArea(), new SignUp()};
            ShowWins(wins);
        }

        private void ShowWins(List<Window> list)
        {
            foreach(Window win in list)
            {
                win.Show();
            }
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
