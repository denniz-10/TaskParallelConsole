using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            var relogio = new Stopwatch();
            relogio.Start();
            CozinharMacarrao();
            RefogarMolho();
            relogio.Stop();
            Console.WriteLine($"tempo: {relogio.ElapsedMilliseconds / 1000.0} \n");

            Console.WriteLine("Tarefa paralela\n");
            relogio.Reset();
            relogio.Restart();
            Parallel.Invoke(() => CozinharMacarrao(),
            () => RefogarMolho());
            relogio.Stop();
            Console.WriteLine($"tempo: {relogio.ElapsedMilliseconds / 1000.0}");

        }

        static void CozinharMacarrao()
        {
            Console.WriteLine("Cozinhando macarrao");
            Thread.Sleep(1000);
            Console.WriteLine("macarrao ja esta cozido");
            Console.WriteLine();
        }

        static void RefogarMolho()
        {
            Console.WriteLine("Refogando molho");
            Thread.Sleep(2000);
            Console.WriteLine("Molho ja esta refogado");
            Console.WriteLine();
        }
    }
}
