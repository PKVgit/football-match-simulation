using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

namespace FootballMatchSimulator.Model
{
    public class Player : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string name;
        public string password;
        public int numberOfWins;
        public List<Match> matches;

        SqlConnection connection;
        string connectionString;

        private void GetConnection()
        {
            //Подключение к БД
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        private void CloseConnection()
        {
            //Закрытие подключения к БД
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public void UpdateNumberOfWins(Player player)
        {
            GetConnection();
            SqlCommand writeRate = new SqlCommand("Update Player set NumberOfWins = @NumberOfWins where PlayerId = @Id", connection);
            writeRate.Parameters.AddWithValue("NumberOfWins", player.NumberOfWins);
            writeRate.Parameters.AddWithValue("Id", player.Id);
            writeRate.ExecuteNonQuery();
            CloseConnection();
        }

        public void AddPlayer(Player player)
        {
            GetConnection();
            //Занесение данных о новом пользователе в БД
            SqlCommand commandInsert = new SqlCommand("Insert into Player (PlayerName, PlayerPassword, NumberOfWins) values(@Login, @Password, @NumberOfWins)", connection);

            commandInsert.Parameters.AddWithValue("Login", player.Name);
            commandInsert.Parameters.AddWithValue("Password", player.Password);
            commandInsert.Parameters.AddWithValue("NumberOfWins", player.NumberOfWins);
            commandInsert.ExecuteNonQuery();
            CloseConnection();
        }

        public Player GetCurrentPlayer(Player player)
        {
            GetConnection();
            //Занесение данных о новом пользователе в БД
            SqlCommand selectAll = new SqlCommand("Select * from Player where PlayerName = @PlayerName and PlayerPassword = @PlayerPassword", connection);
            selectAll.Parameters.AddWithValue("PlayerName", player.Name);
            selectAll.Parameters.AddWithValue("PlayerPassword", player.Password);
            SqlDataReader reader = selectAll.ExecuteReader();
            int id = 0;
            string name = string.Empty;
            string password = string.Empty;
            int numberOfWins = 0;

            while (reader.Read())
            {
                id = Convert.ToInt32(reader["PlayerId"]);
                name = Convert.ToString(reader["PlayerName"]);
                password = Convert.ToString(reader["PlayerPassword"]);
                numberOfWins = Convert.ToInt32(reader["NumberOfWins"]);
            }

            Player user = new Player(id, name, password, numberOfWins);
            reader.Close();
            CloseConnection();

            return user;
        }

        public bool CheckPlayer(Player player)
        {
            Player user = GetCurrentPlayer(player);
            if (user.Name.Length > 0) return true;
            return false;
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

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public int NumberOfWins
        {
            get { return numberOfWins; }
            set
            {
                numberOfWins = value;
                OnPropertyChanged("NumberOfWins");
            }
        }

        public List<Match> Matches
        {
            get { return matches; }
            set
            {
                matches = value;
                OnPropertyChanged("Matches");
            }
        }

        public Player() { }

        public Player(int id, string name, string password, int numberOfWins)
        {
            Matches = new List<Match>()
            {
                new Match(0, 2, 2, "2:1", Id)
            };
            this.Id = id;
            this.Name = name;
            this.Password = password;
            this.NumberOfWins = numberOfWins;
        }

       public void AddMatch(Match match)
       {
            Matches.Add(match);
       }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
