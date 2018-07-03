using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSU.Base.Services
{
    public class AccountService
    {
        public Task<string> AuthenticateAsync(string email, string password)
        {
            return Task<string>.Factory.StartNew(() =>
            {
                MySqlConnection myConnection = new MySqlConnection("Server=localhost;Database=msu;User Id=ilija;Password=admin;");
                myConnection.Open();

                //string query = "SELECT * FROM studenti WHERE elektronska_posta = '" + email + "'";

                string rtn = "authenticate_student";

                //Create Command
                MySqlCommand cmd = new MySqlCommand(rtn, myConnection); //query
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", email);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<string> cityList = new List<string>();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    cityList.Add(dataReader["ime"].ToString());
                    //list[0].Add(dataReader["id"] + "");
                    //list[1].Add(dataReader["name"] + "");
                    //list[2].Add(dataReader["age"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //ViewBag.Info = "ServerVersion: " + myConnection.ServerVersion + "\nState: " + myConnection.State.ToString();

                //close Connection
                myConnection.Close();

                return cityList[0].ToString();
            });
            throw new NotImplementedException();
        }
    }
}
