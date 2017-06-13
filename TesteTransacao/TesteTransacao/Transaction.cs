using System;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace TesteTransacao
{
    class Transaction
    {
        //Data Source = SERVER,PORT; 
        //Initial Catalog = BD;
        //User Id = USER; 
        //Password=PASS;";
        //String de conexão com o banco
        private string SQLStringCon = @"Data Source = x,x; Initial Catalog = x; User Id = x; Password = x;";
        private static SqlConnection SQLCon;
        private static SqlTransaction SQLTran;
        private static SqlCommand SQLCmd;

        private string MySQLStringCon = "";
        private static MySqlConnection MySQLCon;
        private static MySqlTransaction MySQLTran;
        private static MySqlCommand MySQLCmd;

        public void TransacaoSQL(string[] cmds)
        {
            using (SQLCon = new SqlConnection())
            {
                SQLCon.ConnectionString = SQLStringCon;
                SQLCon.Open();
                SQLTran = SQLCon.BeginTransaction();

                try
                {
                    foreach (string cmdTxt in cmds)
                    {
                        SQLCmd = SQLCon.CreateCommand();
                        SQLCmd.CommandText = cmdTxt;
                        SQLCmd.Transaction = SQLTran;
                        SQLCmd.ExecuteNonQuery();      
                    }
                    SQLTran.Commit();
                }
                catch (SqlException ex)
                {
                    SQLTran.Rollback();
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    SQLCon.Close();
                }
            }
        }

        public void TransacaoMySQL(string[] cmds)
        {
            using (SQLCon = new SqlConnection())
            {
                SQLCon.ConnectionString = SQLStringCon;
                SQLCon.Open();
                SQLTran = SQLCon.BeginTransaction();

                try
                {
                    foreach (string cmdTxt in cmds)
                    {
                        SQLCmd = SQLCon.CreateCommand();
                        SQLCmd.CommandText = cmdTxt;
                        SQLCmd.Transaction = SQLTran;
                        SQLCmd.ExecuteNonQuery();
                    }
                    SQLTran.Commit();
                }
                catch (SqlException ex)
                {
                    SQLTran.Rollback();
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    SQLCon.Close();
                }
            }
        }
    }
}
