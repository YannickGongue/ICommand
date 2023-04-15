using DoubleClickCommand.Commands;
using DoubleClickCommand.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Input;
using DoubleClickCommand.DbName;
using System.Data;
using DoubleClickCommand.Store;

namespace DoubleClickCommand.ViewModel
{
    public class VMSearchEmail : ViewModelBase
    {
        private SqlCommand sqlcmdManager;
        private SqlConnection sqlconManager;
        private string connectionString;
        private SqlDataReader DataReader;
        private UserStore _userStore;

        private String setEmail;
        private MUser mUser;
        private UserInfos dbName;


        public string SetEmail
        {
            get
            {
                return this.setEmail;
            }

            set
            {
                this.setEmail = value;
                OnPropertyChanged(nameof(this.SetEmail));
            }
        }
        public ICommand OnSearchCommand { get; }

        public VMSearchEmail(UserStore userStore)
        {
            mUser = new MUser();
            _userStore = userStore;
            OnSearchCommand = new SelectedUserCommand(this, _userStore);
        }

      
        public MUser GetUserInfos(string strEmail)
        {
            string strSelectQuery;
            //Connectionstring-Objekt instanzieren.
            sqlconManager = new SqlConnection();

            this.connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //Die Verbindung einer Datenbank festlegen.
            sqlconManager.ConnectionString = connectionString;
            //Sql-command Objekt instanzieren.
            sqlcmdManager = new SqlCommand();
            dbName = new UserInfos();
            //Sql-Command zuweisen.
            sqlcmdManager.Connection = sqlconManager;
            try
            {
                //Verbindung öffnen.
                sqlconManager.Open();
                //sql-Befehle zusammensetzen.
                strSelectQuery = string.Format("SELECT {2},{3} FROM {0} WHERE {1} = @1",
                                                dbName.TBLUser,
                                                dbName.strEmail,
                                                dbName.strId,
                                                dbName.strPassword);
                //Parameters-collection leeren.
                sqlcmdManager.Parameters.Clear();
                // Parameters collection einfügen.
                sqlcmdManager.Parameters.AddWithValue("@1", strEmail);
                //Sql-Abfrage festlegen.
                sqlcmdManager.CommandType = CommandType.Text;
                sqlcmdManager.CommandText = strSelectQuery;

                DataReader = sqlcmdManager.ExecuteReader();

                while (DataReader.Read())
                {
                    mUser.Id = DataReader[dbName.strId].ToString();
                    mUser.Passwort = DataReader[dbName.strPassword].ToString();
                }

                //Die Verbindung schließen.
                sqlconManager.Close();
            }
            catch (Exception ex)
            {
                //Fehlermeldung
                MessageBox.Show(ex.Message.ToString());
            }

            return mUser;
        }

    }
}
