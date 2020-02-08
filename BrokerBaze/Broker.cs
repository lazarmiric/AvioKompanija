using AvioKompanija;
using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerBaze
{
    public class Broker
    {
        private SqlConnection connection;
        private SqlTransaction transaction;
        public Broker()
        {
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BazaAvioKompanija;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public void OtvoriKonekciju()
        {
            connection.Open();
        }
        public void ZatvoriKonekciju()
        {
            connection.Close();
        }
        public void PokreniTransakciju()
        {
            transaction = connection.BeginTransaction();
        }
        public void Commit()
        {
            transaction.Commit();
        }
        public void Rollback()
        {
            transaction.Rollback();
        }  

        public bool izmeniSa(IDomenskiObjekat objekat)
        {
           
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"UPDATE {objekat.Table} SET {objekat.Uslov()} {objekat.SearchWhere()}";
            return command.ExecuteNonQuery() == 1;
        }

        public bool sacuvaj(IDomenskiObjekat objekat)
        {           
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"INSERT INTO {objekat.Table} VALUES({objekat.InsertValues})";
            return command.ExecuteNonQuery() == 1;

        }

        public List<IDomenskiObjekat> Pronadji(IDomenskiObjekat objekat)
        {
            
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"{objekat.Get} {objekat.FullTable} {objekat.Join} {objekat.SearchId}";
            SqlDataReader reader = command.ExecuteReader();
            return objekat.GetReaderResult(reader);

        }

        public bool Otkazi(IDomenskiObjekat objekat)
        {

            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"Update {objekat.Table} {objekat.UpdateValues} {objekat.ColumnId}";        
            return command.ExecuteNonQuery() == 1;   
                              
               
        }

 
        public List<IDomenskiObjekat> vratiListu(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"{objekat.Get} {objekat.FullTable} {objekat.Join}";
            SqlDataReader reader = command.ExecuteReader();
            return objekat.GetReaderResult(reader);



        }

        public List<IDomenskiObjekat> vratiBez(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"{objekat.Get} {objekat.Table} {objekat.Join}";
            SqlDataReader reader = command.ExecuteReader();
            return objekat.GetReaderResult(reader);
        }




    }
}
