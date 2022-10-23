using BankApp.Models;
using BankApp.Responses;
using BankApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System;

namespace BankApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KomputerController : ControllerBase
    {
        SqliteConnection? sqlite_conn = null;

        public KomputerController()
        {
            DatabaseTool connection = new();
            sqlite_conn = connection.CreateConnection();
            sqlite_conn.Open();
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            SqliteDataReader sqlite_datareader;
            SqliteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM komputer";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }
            sqlite_conn.Close();
            return new string[] { "value1", "value2", "value3", "value4", "value5" };
        }

        [HttpPost]
        public void OnPost([FromBody] Komputer komputer)
        {
            string q = "INSERT INTO komputer (nazwa, data_ksiegowania, koszt_USD, koszt_PLN, kurs) VALUES ('" 
                + komputer.Nazwa + "','" 
                + komputer.DataKsiegowania + "','"
                + komputer.KosztUSD + "','"
                + komputer.KosztPLN + "','" 
                + komputer.Kurs + "')";
            using var cmd = new SqliteCommand(q, sqlite_conn);

            //cmd.CommandText = "INSERT INTO komputer (nazwa, data_ksiegowania, koszt_USD, koszt_PLN, kurs) VALUES ('kurwa', '2022-04-04', 34, 134, 5)";
            cmd.ExecuteNonQuery();

            //SqliteCommand sqlite_cmd;
            //sqlite_cmd = sqlite_conn.CreateCommand();
            //  sqlite_cmd.CommandText = "INSERT INTO komputer (nazwa, data_ksiegowania, koszt_USD, koszt_PLN, kurs) VALUES (?,?,?,?,?);";
            ////sqlite_cmd.CommandText = "INSERT INTO komputer (nazwa, data_ksiegowania, koszt_USD, koszt_PLN, kurs) VALUES ('kurwa', '2022-04-04', 34, 134, 5)";
            //sqlite_cmd.ExecuteNonQuery();
        }
    }
}
