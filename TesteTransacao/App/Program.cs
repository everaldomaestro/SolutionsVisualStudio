using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new Model();

            Teste t1 = new Teste() { Nome = "Everaldo", Idade = 31 };
            Teste t2 = new Teste() { Nome = "Ana", Idade = 27 };


            ctx.Teste.Add(t1);
            ctx.Teste.Add(t2);

            ctx.SaveChanges();

            var dados = from t in ctx.Teste
                        select t;

            foreach (var l in dados)
            {
                Console.WriteLine("{0} - {1}", l.Nome, l.Idade);
            }
            Console.ReadKey();
        }
    }
}
