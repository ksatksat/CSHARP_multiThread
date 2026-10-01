using System;
using System.Threading.Tasks;
using System.Threading;
namespace MultiThreading{
    class Program{
        static void Main(string[] args){
            /*threads = an execution part of program
            we can use multiple threads to perform
            different tasks of our program 
            at the same time. Current thread
            running is "main" thread 
            using System.Threading;
            */
            #region SingleThreadWorking
            Thread mainThread = Thread.CurrentThread;
            mainThread.Name = "Hooray It Is My First Thread";

            //Main and single thread working
            /*expected output: 
            Hooray It Is My First Thread
 ___ Timer #1 : 10 seconds
 ___ Timer #1 : 9 seconds
 ___ Timer #1 : 8 seconds
 ___ Timer #1 : 7 seconds
 ___ Timer #1 : 6 seconds
 ___ Timer #1 : 5 seconds
 ___ Timer #1 : 4 seconds
 ___ Timer #1 : 3 seconds
 ___ Timer #1 : 2 seconds
 ___ Timer #1 : 1 seconds
 ___ Timer #1 : 0 seconds
 ___ Timer #1 is complete!
 *** Timer #2 : 0 seconds
 *** Timer #2 : 1 seconds
 *** Timer #2 : 2 seconds
 *** Timer #2 : 3 seconds
 *** Timer #2 : 4 seconds
 *** Timer #2 : 5 seconds
 *** Timer #2 : 6 seconds
 *** Timer #2 : 7 seconds
 *** Timer #2 : 8 seconds
 *** Timer #2 : 9 seconds
 *** Timer #2 : 10 seconds
 *** Timer #2 is complete!
Main thread is complete!
            */
            //CountByUsingMainThread(mainThread);
            #endregion SingleThreadWorking
            #region MultipleThreadsWorking
            Thread thread_countDown = new Thread(CountDown);
            Thread thread_countUp = new Thread(CountUp);

            thread_countDown.Start();
            thread_countUp.Start();
            /*expected output:
             ___ Timer #1 : 10 seconds
 *** Timer #2 : 0 seconds
 *** Timer #2 : 1 seconds
 ___ Timer #1 : 9 seconds
 ___ Timer #1 : 8 seconds
 *** Timer #2 : 2 seconds
 ___ Timer #1 : 7 seconds
 *** Timer #2 : 3 seconds
 ___ Timer #1 : 6 seconds
 *** Timer #2 : 4 seconds
 ___ Timer #1 : 5 seconds
 *** Timer #2 : 5 seconds
 ___ Timer #1 : 4 seconds
 *** Timer #2 : 6 seconds
 ___ Timer #1 : 3 seconds
 *** Timer #2 : 7 seconds
 ___ Timer #1 : 2 seconds
 *** Timer #2 : 8 seconds
 ___ Timer #1 : 1 seconds
 *** Timer #2 : 9 seconds
 ___ Timer #1 : 0 seconds
 *** Timer #2 : 10 seconds
 ___ Timer #1 is complete!
 *** Timer #2 is complete!
            */
            #endregion MultipleThreadsWorking
            Console.ReadLine();
        }
        static void CountByUsingMainThread(Thread mainThread){
            Console.WriteLine(mainThread.Name);
            CountDown();
            CountUp();
            Console.WriteLine("Main thread is complete!");
        }
        public static void CountDown()
        {
            for(int i = 10; i >= 0; i--){
                Console.WriteLine($" ___ Timer #1 : {i} seconds");
                Thread.Sleep(1000);
            }
            Console.WriteLine(" ___ Timer #1 is complete!");
        }
        public static void CountUp()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($" *** Timer #2 : {i} seconds");
                Thread.Sleep(1000);
            }
            Console.WriteLine(" *** Timer #2 is complete!");
        }
    }
}