using FootballMatchSimulator.Command;
using FootballMatchSimulator.Model;
using FootballMatchSimulator.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FootballMatchSimulator.ViewModel
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        private Player player;
        private string password;
        private string name;
        private List<string> matches;
        private List<Team> teams;

        private Team selectedFirstTeam;
        private Team selectedSecondTeam;

        private Match currentMatch;
        
        private string win;

        private List<Footballer> footballersToUpdate;

        //=============================
        //Game Play

        private RelayCommand startPlayGame;
        public RelayCommand StartPlayGame
        {
            get
            {
                return startPlayGame ??
                    (startPlayGame = new RelayCommand(obj =>
                    {
                        Team team = new Team();
                        Teams = team.GetAllTeams();
                        MatchSett matchSett = new MatchSett(this);
                        matchSett.Show();
                        Application.Current.Windows[2].Close();
                    }));
            }
        }

        private RelayCommand simulateGame;
        public RelayCommand SimulateGame
        {
            get
            {
                return simulateGame ??
                    (simulateGame = new RelayCommand(obj =>
                    {
                        if (SelectedFirstTeam != null && SelectedSecondTeam != null)
                        {
                            string result = GenerateResult();
                            FootballersToUpdate = PlayersToUpdate(result);
                            UpdateFootballers(FootballersToUpdate);
                            CurrentMatch = new Match(135, SelectedFirstTeam.Id, SelectedSecondTeam.Id, result, Player.Id);
                            CurrentMatch.AddMatch(CurrentMatch);
                            CurrentMatch = CurrentMatch.GetCurrentMatch(CurrentMatch);
                            MatchRes matchRes = new MatchRes(this);
                            matchRes.Show();
                            Application.Current.Windows[2].Close();
                        }
                    }));
            }
        }

        private RelayCommand saveGame;
        public RelayCommand SaveGame
        {
            get
            {
                return saveGame ??
                    (saveGame = new RelayCommand(obj =>
                    {
                        Match match = new Match();
                        Team team = new Team();
                        Teams = team.GetAllTeams();
                        Matches = match.CreateMatchResults(Player.Id, Teams);
                        PersonalArea personalArea = new PersonalArea(this);
                        personalArea.Show();
                        Application.Current.Windows[2].Close();
                    }));
            }
        }

        private void UpdateFootballers(List<Footballer> footballers)
        {
            foreach(Footballer footballer in footballers)
            {
                footballer.ProgressValue += 1;
                footballer.UpdateRate(1, footballer.Id);
            }
        }

        private List<Footballer> PlayersToUpdate(string result)
        {
            string[] arr = result.Split(':');
            int firstRes = Convert.ToInt32(arr[0]);
            int secondRes = Convert.ToInt32(arr[1]);
            List<Footballer> footballersToUpdate = new List<Footballer>();
            if (firstRes > 0)
            {
                for (int i = 0; i < firstRes; i++)
                {
                    Footballer footballer = SelectedFirstTeam.Footballers[Randomize(11)];
                    footballersToUpdate.Add(footballer);
                }
            }
            if(secondRes > 0)
            {
                for (int i = 0; i < secondRes; i++)
                {
                    Footballer footballer = SelectedSecondTeam.Footballers[Randomize(11)];
                    footballersToUpdate.Add(footballer);
                }
            }

            return footballersToUpdate;
        }

        private string GenerateResult()
        {
            string result ="";
            string[] winResults = new[] { "2:1", "2:0", "1:0", };
            string[] loseResults = new[] { "1:2", "0:2", "0:1" };
            string[] drawResults = new[] { "0:0", "1:1", "2:2" };
          
            if (SelectedFirstTeam.Rate > SelectedSecondTeam.Rate)
            {
                Win = "Win";
                int randomNumb = Randomize(3);
                Player.NumberOfWins += 1;
                Player.UpdateNumberOfWins(Player);
                result = winResults[randomNumb];
            } else if(SelectedFirstTeam.Rate < SelectedSecondTeam.Rate)
            {
                Win = "Lose";
                int randomNumb = Randomize(3);
                result = loseResults[randomNumb];
            } else
            {
                Win = "Draw";
                int randomNumb = Randomize(3);
                result = drawResults[randomNumb];
            }
            return result;
        }

        private int Randomize(int numb)
        {
            return new Random().Next(numb);
        }

        //=========================================================
        //Login/SignUp

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        if (Name != null && Password != null)
                        {
                            Match match = new Match();
                            Player = new Player(135135, Name, Password, 0);
                            Player.AddPlayer(Player);
                            Player = Player.GetCurrentPlayer(Player);
                            Team team = new Team();
                            Teams = team.GetAllTeams();
                            Matches = match.CreateMatchResults(Player.Id, Teams);
                            PersonalArea personalArea = new PersonalArea(this);
                            personalArea.Show();
                            Application.Current.Windows[2].Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid data");
                        }
                    }));
            }
        }

        private RelayCommand checkCommand;
        public RelayCommand CheckCommand
        {
            get
            {
                return checkCommand ??
                    (checkCommand = new RelayCommand(obj =>
                    {
                        if (Name != null && Password != null)
                        {
                            Player = new Player(135135, Name, Password, 0);
                            bool exist = Player.CheckPlayer(Player);
                            if (exist)
                            {
                                Player = Player.GetCurrentPlayer(Player);
                            }
                            else
                            {
                                Player = null;
                            }
                            if (Player != null)
                            {
                                Match match = new Match();
                                Team team = new Team();
                                Teams = team.GetAllTeams();
                                Matches = match.CreateMatchResults(Player.Id, Teams);
                                PersonalArea personalArea = new PersonalArea(this);
                                personalArea.Show();
                                Application.Current.Windows[2].Close();
                            }
                            else
                            {
                                MessageBox.Show("Invalid data");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid data");
                        }
                    }));
            }
        }


        //===============================
        //Properties


        public List<Footballer> FootballersToUpdate
        {
            get { return footballersToUpdate; }
            set
            {
                footballersToUpdate = value;
                OnPropertyChanged("FootballersToUpdate");
            }
        }


        public string Win
        {
            get { return win; }
            set
            {
                win = value;
                OnPropertyChanged("Win");
            }
        }

        public Match CurrentMatch
        {
            get { return currentMatch; }
            set
            {
                currentMatch = value;
                OnPropertyChanged("CurrentMatch");
            }
        }

        public Team SelectedFirstTeam
        {
            get { return selectedFirstTeam; }
            set
            {
                selectedFirstTeam = value;
                OnPropertyChanged("SelectedFirstTeam");
            }
        }

        public Team SelectedSecondTeam
        {
            get { return selectedSecondTeam; }
            set
            {
                selectedSecondTeam = value;
                OnPropertyChanged("SelectedSecondTeam");
            }
        }

        public List<Team> Teams
        {
            get { return teams; }
            set
            {
                teams = value;
                OnPropertyChanged("Teams");
            }
        }

        public List<string> Matches
        {
            get { return matches; }
            set
            {
                matches = value;
                OnPropertyChanged("Matches");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public Player Player
        {
            get { return player; }
            set
            {
                player = value;
                OnPropertyChanged("Player");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
