using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace ThreadPoolExercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* RESULTS:
             *
             *** EXERCISE 1 (1 iteration in Process) ***
             *
             * Thread Pool Execution
             * Time consumed by ProcessWithThreadPoolMethod: 815520 ticks
             * Thread Execution
             * Time consumed by ProcessWithThreadMethod is : 522055 ticks
             *
             *** EXERCISE 2.1 (100.000 iterations in Process) ***
             *
             * Thread Pool Execution
             * Time consumed by ProcessWithThreadPoolMethod: 202138 ticks
             * Thread Execution
             * Time consumed by ProcessWithThreadMethod is : 626330 ticks
             * 
             *** EXERCISE 2.2 (100.000 * 100.000 iterations in Process) ***
             *
             * Thread Pool Execution
             * Time consumed by ProcessWithThreadPoolMethod: 256228 ticks
             * Thread Execution
             * Time consumed by ProcessWithThreadMethod is : 6345555 ticks
             * 
             * Interesting notes:
             * 
             * 1. Process with threadpool was slower than process with threads in the first exercise, but faster in the second and third.
             * 2. Threadpool only got 50.000 ticks slower from exercise 2.1 to 2.2. Meanwhile, process with threads became more than 10 times slower.
             */

            /* QUESTION:
             * 
             * Does the method Process() need to take an object as an argument? Justify your answer.
             * 
             * Yes, because the method Process() is a called by the threadpool, which requires a method with the signature WaitCallback(object obj).
             * The object is used to pass data to the method called by the threadpool, and even though it is not used in this example, it is still required by the signature as defined in the documentation:
             * https://learn.microsoft.com/en-us/dotnet/api/system.threading.waitcallback?view=net-8.0
             */

            // Create a new stopwatch to record the time taken to execute the methods.
            Stopwatch myWatch = new Stopwatch();
            
            // Record the time taken to execute the ProcessWithThreadMethod method, which simply takes threads from the threadpool.
            Console.WriteLine("Thread Pool Execution");
            myWatch.Start();
            ProcessWithThreadPoolMethod();
            myWatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod: " + myWatch.ElapsedTicks.ToString());
            
            myWatch.Reset();

            // Record the time taken to execute the ProcessWithThreadMethod method, which manually creates threads.
            Console.WriteLine("Thread Execution");
            myWatch.Start();
            ProcessWithThreadMethod();
            myWatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + myWatch.ElapsedTicks.ToString());

            // Wait for user input before closing the console.
            Console.Read();
        }

        // This method is called by the threads created by the different methods for comparison.
        static void Process(object obj)
        {
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 100000; j++)
                {
                    // Do nothing.
                }
            }
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