using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FootballMatchSimulator.Model
{
    public class Team : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string name;
        public int rate;
        public List<Footballer> Footballers { get; set; }

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

        public List<Team> GetAllTeams()
        {
            GetConnection();
            
            SqlCommand selectAll = new SqlCommand("Select * from Team", connection);
            SqlDataReader reader = selectAll.ExecuteReader();
            int id = 0;
            string name = string.Empty;
            int rate = 0;
            List<Footballer> footballers;
            List<Team> teams = new List<Team>();

            while (reader.Read())
            {
                id = Convert.ToInt32(reader["TeamId"]);
                name = Convert.ToString(reader["TeamName"]);
                rate = Convert.ToInt32(reader["Rate"]);
                footballers = GetAllTeamFootballers(id);
                Team team = new Team(id, name, rate, footballers);
                teams.Add(team);
            }

            reader.Close();
            CloseConnection();

            return teams;
        }

        public List<Footballer> GetAllTeamFootballers(int _id)
        {
            GetConnection();

            SqlCommand selectAll = new SqlCommand("Select * from Footballer where TeamId = @Id", connection);
            selectAll.Parameters.AddWithValue("Id", _id);
            SqlDataReader reader = selectAll.ExecuteReader();
            int id = 0;
            string name = string.Empty;
            string pos = string.Empty;
            int rate = 0;
            int teamId = 0;
            List<Footballer> footballers = new List<Footballer>();

            while (reader.Read())
            {
                id = Convert.ToInt32(reader["FootballerId"]);
                name = Convert.ToString(reader["FootballerName"]);
                pos = Convert.ToString(reader["Position"]);
                rate = Convert.ToInt32(reader["Rate"]);
                teamId = Convert.ToInt32(reader["TeamId"]);
                Footballer footballer = new Footballer(id, name, pos, rate, teamId);
                footballers.Add(footballer);
            }

            reader.Close();
            CloseConnection();

            return footballers;
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

        public int Rate
        {
            get { return rate; }
            set
            {
                rate = value;
                OnPropertyChanged("Rate");
            }
        }

        public Team()
        {

        }

        public Team(string name, int rate)
        {
            this.Name = name;
            this.Rate = rate;
        }

        public Team(int id, string name, int rate, List<Footballer> footballers)
        {
            this.Id = id;
            this.Name = name;
            this.Rate = rate;
            this.Footballers = footballers;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
