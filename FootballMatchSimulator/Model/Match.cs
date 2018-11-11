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
using System.Windows;

namespace FootballMatchSimulator.Model
{
    public class Match : INotifyPropertyChanged
    {
        private int Id { get; set; }
        private int firstTeamId;
        private int secondTeamId;
        private string result;
        private int playerId;

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

        public int FirstTeamId
        {
            get { return firstTeamId; }
            set
            {
                firstTeamId = value;
                OnPropertyChanged("FirstTeamId");
            }
        }

        public void AddMatch(Match match)
        {
            GetConnection();
            //Занесение данных о новом пользователе в БД
            SqlCommand commandInsert = new SqlCommand("Insert into FootballMatch (FirstTeamId, SecondTeamId, Result, PlayerId) values(@FirstTeamId, @SecondTeamId, @Result, @PlayerId)", connection);

            commandInsert.Parameters.AddWithValue("FirstTeamId", match.FirstTeamId);
            commandInsert.Parameters.AddWithValue("SecondTeamId", match.SecondTeamId);
            commandInsert.Parameters.AddWithValue("Result", match.Result); 
            commandInsert.Parameters.AddWithValue("PlayerId", match.PlayerId);
            commandInsert.ExecuteNonQuery();
            CloseConnection();
        }

        public Match GetCurrentMatch(Match match)
        {
            GetConnection();

            SqlCommand selectMatch = new SqlCommand("Select * from FootballMatch where FirstTeamId = @FirstTeamId and SecondTeamId = @SecondTeamId and Result = @Result and PlayerId = @PlayerId", connection);
            selectMatch.Parameters.AddWithValue("FirstTeamId", match.FirstTeamId);
            selectMatch.Parameters.AddWithValue("SecondTeamId", match.SecondTeamId);
            selectMatch.Parameters.AddWithValue("Result", match.Result);
            selectMatch.Parameters.AddWithValue("PlayerId", match.PlayerId);
            SqlDataReader reader = selectMatch.ExecuteReader();
            int id = 0;
            int firstTeamId = 0;
            int secondTeamId = 0;
            string result = string.Empty;
            int playerId = 0;

            while (reader.Read())
            {
                id = Convert.ToInt32(reader["MatchId"]);
                firstTeamId = Convert.ToInt32(reader["FirstTeamId"]);
                secondTeamId = Convert.ToInt32(reader["SecondTeamId"]);
                result = Convert.ToString(reader["Result"]);
                playerId = Convert.ToInt32(reader["PlayerId"]);
            }
            Match footMatch = new Match(id, firstTeamId, secondTeamId, result, playerId);
            reader.Close();
            CloseConnection();
      
            return footMatch;
        }

        public List<string> CreateMatchResults(int _id, List<Team> teams)
        {
            GetConnection();
            SqlCommand selectMatches = new SqlCommand("Select * from FootballMatch where PlayerId = @Id", connection);
            selectMatches.Parameters.AddWithValue("Id", _id);
            SqlDataReader reader = selectMatches.ExecuteReader();
            int id = 0;
            int firstTeamId = 0;
            int secondTeamId = 0;
            string result = string.Empty;
            int playerId = 0;
            List<Match> matches = new List<Match>();
            while (reader.Read())
            {
                id = Convert.ToInt32(reader["MatchId"]);
                firstTeamId = Convert.ToInt32(reader["FirstTeamId"]);
                secondTeamId = Convert.ToInt32(reader["SecondTeamId"]);
                result = Convert.ToString(reader["Result"]);
                playerId = Convert.ToInt32(reader["PlayerId"]);
                Match footMatch = new Match(id, firstTeamId, secondTeamId, result, playerId);
                matches.Add(footMatch);
            }
            CloseConnection();

            List<string> resultArr = new List<string>();
            foreach (Match match in matches)
            {
                string data = string.Format("{0} - {1} {2}", GetTeamNameById(teams,match.FirstTeamId), GetTeamNameById(teams, match.SecondTeamId), match.Result);
                resultArr.Add(data);
            }
            return resultArr;
        }

        private string GetTeamNameById(List<Team> teams, int id)
        {
            return teams.Find(item => item.Id == id).Name;
        }

        public int PlayerId
        {
            get { return playerId; }
            set
            {
                playerId = value;
                OnPropertyChanged("PlayerId");
            }
        }

        public int SecondTeamId
        {
            get { return secondTeamId; }
            set
            {
                secondTeamId = value;
                OnPropertyChanged("SecondTeamId");
            }
        }

        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged("Result");
            }
        }

        public Match() { }

        public Match(int id, int firstTeamId, int secondTeamId, string result, int playerId)
        {
            this.Id = id;
            this.FirstTeamId = firstTeamId;
            this.SecondTeamId = secondTeamId;
            this.Result = result;
            this.PlayerId = playerId;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
