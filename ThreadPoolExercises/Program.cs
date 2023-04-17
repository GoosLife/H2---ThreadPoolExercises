using System.Diagnostics;
using System.Threading;

namespace ThreadPoolExercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch myWatch = new Stopwatch();
            Console.WriteLine("Thread Pool Execution");
        }

        static void Process()
        {
        }

        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }

        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }
    }
}