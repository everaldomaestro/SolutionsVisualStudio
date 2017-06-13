namespace TesteTransacao
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                Transaction tr = new Transaction();
                string[] cmds = new string[2];

                cmds[0] = "insert into Teste (Nome, Idade) values ('TESTE',19)";
                cmds[1] = "insert into Teste (Nome, Idade) values (19,NULL)";

                tr.TransacaoSQL(cmds);
            }
        }
    }
}