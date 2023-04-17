/*
* C# Program to Create Thread Pools
*/
using System;
using System.Threading;
class ThreadPoolDemo
{
    // Each method outputs 3 times
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

    static void MainIgnore()
    {
        ThreadPoolDemo tpd = new ThreadPoolDemo();

        for (int i = 0; i < 2; i++) // Create 4 tasks total, 2 at a time.
                                    // These tasks are executed in an order determined by the CPU at runtime based on available resources.
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.task1)); // (new WaitCallback(tpd.task1)) and simply (tpd.task1) are equivalent
                                                                       // and compile to the same byte code.

            ThreadPool.QueueUserWorkItem(tpd.task2);
        }

        Console.Read();
    }
}