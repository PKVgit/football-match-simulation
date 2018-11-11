using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FootballMatchSimulator.ViewModel;
using FootballMatchSimulator.Model;

namespace FootballMatchSimulator.UI
{
    /// <summary>
    /// Логика взаимодействия для MatchSett.xaml
    /// </summary>
    public partial class MatchSett : Window
    {
        PlayerViewModel pvm;
        public MatchSett(PlayerViewModel vm)
        {
            InitializeComponent();
            string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "Img/football.jpg");
            Background = new ImageBrush(new BitmapImage(new Uri(path)));
            path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "Img/icons/minimize.png");
            cutDownBtn.Background = new ImageBrush(new BitmapImage(new Uri(path)));
            path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "Img/icons/close.png");
            powerBtn.Background = new ImageBrush(new BitmapImage(new Uri(path)));
            DataContext = vm;
            pvm = vm;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Team team = (Team) FirstTeamList.SelectedItem;
            pvm.SelectedFirstTeam = team;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Team team = (Team)SecondTeamList.SelectedItem;
            pvm.SelectedSecondTeam = team;
        }
    }
}
