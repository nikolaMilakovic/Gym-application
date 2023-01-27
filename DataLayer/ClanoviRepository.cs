using Shared;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ClanoviRepository
    {
        public List<Clanovi> GetAllMember()
        {
            List<Clanovi> listaClanova = new List<Clanovi>();
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = "SELECT * FROM CLANOVI";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Clanovi c = new Clanovi();
                    c.id_clana = dataReader.GetInt32(0);
                    c.ime = dataReader.GetString(1);
                    c.prezime = dataReader.GetString(2);
                    c.broj_telefona = dataReader.GetString(3);
                    c.datum_uclanjenja = dataReader.GetString(4);


                    listaClanova.Add(c);
                }

            }
            return listaClanova;
        }
        public int InsertMember(Clanovi c)
        {

            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = string.Format("INSERT INTO CLANOVI " +
                    "VALUES('{0}','{1}', '{2}', '{3}')", c.ime, c.prezime, c.broj_telefona, c.datum_uclanjenja);

                return command.ExecuteNonQuery();

            }

        }
        public int UpdateMember(Clanovi c)
        {

            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = string.Format("UPDATE CLANOVI SET Ime='{0}', Prezime='{1}', Broj_telefona='{2}', datum_uclanjenja='{3}' " +
                    "WHERE id={4}", c.ime, c.prezime, c.broj_telefona, c.datum_uclanjenja, c.id_clana);
                

                return command.ExecuteNonQuery();

            }

        }
        public int DeleteMember(Clanovi c)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                {
                    sqlConnection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlConnection;
                    command.CommandText = string.Format("DELETE FROM CLANOVI WHERE id = {0}", c.id_clana);

                    return command.ExecuteNonQuery();
                }
            }


        }
    }
}
