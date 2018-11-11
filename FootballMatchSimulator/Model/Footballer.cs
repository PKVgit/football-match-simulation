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
    public class Footballer: INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string name;
        private string pos;
        private int rate;
        private int teamId;
        private int progressValue;

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

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int TeamId
        {
            get { return teamId; }
            set
            {
                teamId = value;
                OnPropertyChanged("TeamId");
            }
        }

        public string Pos
        {
            get { return pos; }
            set
            {
                pos = value;
                OnPropertyChanged("Position");
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

        public int ProgressValue
        {
            get { return progressValue; }
            set
            {
                progressValue = value;
                OnPropertyChanged("ProgressValue");
            }
        }

        public Footballer()
        {

        }

        public Footballer(int id, string name, string pos, int rate, int teamId)
        {
            this.Id = id;
            this.Name = name;
            this.Pos = pos;
            this.Rate = rate;
            this.TeamId = teamId;
        }

        public void UpdateRate(int amount, int id)
        {
            this.Rate += amount;
            GetConnection();
            SqlCommand writeRate = new SqlCommand("Update Footballer set Rate = @Rate where FootballerId = @Id", connection);
            writeRate.Parameters.AddWithValue("Rate", this.Rate);
            writeRate.Parameters.AddWithValue("Id", id);
            writeRate.ExecuteNonQuery();
            CloseConnection();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
