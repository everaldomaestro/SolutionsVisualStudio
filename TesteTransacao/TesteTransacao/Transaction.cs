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
            @"Data Source = xxxxxx,xxxxxx; 
            Initial Catalog = xxxxxx;
            User Id = xxxxxx;
            Password = xxxxxx;";
        //@"Data Source = SERVER,PORT; 
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
                        Console.WriteLine(cmd.CommandText);
                        cmd.Transaction = tran;
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Comando executado com sucesso!");
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
