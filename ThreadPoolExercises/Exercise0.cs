/*
* C# Program to Create Thread Pools
*/
using System;
using System.Threading;

/// <summary>
/// Class used to demonstrate the use and parallel execution of thread pools by writing to the console.
/// </summary>
class ThreadPoolDemo
{
    // Each call outputs 3 times
    public void task1(object obj)
    {
        for (int i = 0; i <= 2; i++)
        {
            Console.WriteLine("Task 1 is being executed");
        }
    }

    public void task2(object obj)
    {
        for (int i = 0; i <= 2; i++)
        {
            Console.WriteLine("Task 2 is being executed");
        }
    }

    // The main method from Exercise 0
    static void MainIgnore()
    {
        ThreadPoolDemo tpd = new ThreadPoolDemo();

        // Create 2 threads in the thread pool and execute their tasks in parallel. 
        for (int i = 0; i < 2; i++)
        {
            // (new WaitCallback(tpd.task1)) and simply (tpd.task1) are equivalent and compile to the same byte code.
            ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.task1));
            ThreadPool.QueueUserWorkItem(tpd.task2);
        }

        Console.Read();
    }
}