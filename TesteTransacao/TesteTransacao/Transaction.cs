using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace TesteTransacao
{
    class Transaction
    {
        //String de conexão com o banco
        private string StringCon =
            @"Data Source = TI,1433;
            Initial Catalog = TesteTransacao;
            User Id = sa;
            Password = abc.123;";
        //Data Source = SERVER,PORT; 
        //Initial Catalog = BD;
        //User Id = USER; 
        //Password=PASS;";

        private static SqlConnection con;
        private static SqlTransaction tran;


        //private SqlCommand cmd2 = con.CreateCommand();

        public void transacao(string[] cmds)
        {
            using (con = new SqlConnection())
            {
                SqlCommand cmd = con.CreateCommand();
                con.ConnectionString = StringCon;
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    foreach (string cmdTxt in cmds)
                    {
                        cmd.CommandText = cmdTxt;
                        cmd.Transaction = tran;
                        cmd.ExecuteNonQuery();      
                    }
                    tran.Commit();
                }
                catch (SqlException ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }


    }
}
