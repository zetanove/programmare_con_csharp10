/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 13: gestione di task
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1=Task.Factory.StartNew(() => Console.WriteLine("Hello tasks"));
            
            Task task2=Task.Run(()=>Console.WriteLine("Hello tasks 2"));
            Console.WriteLine(task2.IsCompleted);
            task2.Wait();
            Console.WriteLine("task2 completed");

            Task task3 = new Task(()=>Operation(1000));
         
            task3.Start();

            Task longTask=Task.Run( ()=>{
                Console.WriteLine("Start task...");
                Thread.Sleep(3000);
                Console.WriteLine("End task");
            });
            longTask.Wait(2000);
            Console.WriteLine("after wait..." );

            Task longTask2 = Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Thread.Sleep(100);
                    }
                },
                TaskCreationOptions.LongRunning);

            List<Task> tasks = new List<Task>();
            for (int i = 1; i <= 5; i++)
            {
                int number = i;
                tasks.Add(Task.Run(() =>
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            Console.WriteLine("{0} {1}", number, new string('.', j));
                            Thread.Sleep(500);
                        }
                    })
                );
            }
            
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("all tasks completed"); 
            
            //results
            Task<string> tsr = Task<string>.Run(() =>
            {
                return DownloadHtml("http://www.microsoft.com");
            });
            string str = tsr.Result;


            //continuation
            Task ts = Task.Run(() => Operation(1000)).ContinueWith((task) => Operation(2000));
            ts.Wait();

            Task taskRitardato = Task.Delay(5000).ContinueWith( task=> Operation(1000));

            Task<string> webtask = Task<string>.Run(() =>
            {
                return DownloadHtml("http://www.microsoft.com");
            });
            Task<int> taskVocali = webtask.ContinueWith<int>(downloadTask =>
                {
                    int count=0;
                    string vocali="aeiou";
                    string result=downloadTask.Result;
                    foreach(char ch in result)
                    {
                        if(vocali.IndexOf(ch)>-1)
                            count++;
                    }
                    return count;
                });
            Console.WriteLine(taskVocali.Result);

            Task[] taskArray = new Task[2];
            taskArray[0]=new Task(()=> Operation(1000));
            taskArray[1] = new Task(() => Operation(2000));
            taskArray[0].Start();
            taskArray[1].Start();
            Task taskCont = Task.Factory.ContinueWhenAll(taskArray, (tasksPrecedenti) => Console.WriteLine("{0} Tasks completati", tasksPrecedenti.Count()));
            taskCont.Wait();

            taskArray[0] = new Task(() => Operation(1000));
            taskArray[1] = new Task(() => Operation(2000));
            taskArray[0].Start();
            taskArray[1].Start();
            Task<string> taskCont2 = Task.Factory.ContinueWhenAny<string>(taskArray, taskPrec => "uno dei task è terminato");
            Console.WriteLine(taskCont2.Result);

            Task[] task3Array = new Task[3] { new Task(() => Operation(1000)), new Task(() => Operation(3000)), new Task(() => Operation(2000)) };
            foreach (var tsk in task3Array)
                tsk.Start();
            Task all3=Task.WhenAll(task3Array);
            all3.Wait();
            Console.WriteLine("task3Array completed");

            Task<int> taskDiv = Task.Run<int>(() => Dividi(1, 0));
            try
            {
                int risultato = taskDiv.Result;
            }
            catch(AggregateException aggrEx)
            {
                if (taskDiv.IsFaulted)
                {
                    Console.WriteLine("il task è fallito");
                    Console.WriteLine(taskDiv.Exception.ToString());
                }
                else Console.WriteLine(aggrEx.InnerException.ToString());
            }


            var cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task taskCancellable = Task.Run(() =>
            {
                token.ThrowIfCancellationRequested();

                for(int i=0;i<50;i++){
                    Thread.Sleep(100);
                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                    }
                }
            }, token);

            try
            {
                cancelTokenSource.CancelAfter(1000);
                taskCancellable.Wait();
            }
            catch (AggregateException aggrEx)
            {
                if (taskCancellable.IsCanceled && taskCancellable.Status == TaskStatus.Canceled)
                {
                    Console.WriteLine(aggrEx.InnerException.ToString());
                }
            }


            Console.ReadLine();
        }


        public static int Dividi(int x, int y)
        {
            return x / y;
        }

        public static  void Operation(int time)
        {
            Console.WriteLine("Start operation at {0}", DateTime.Now);
            Thread.Sleep(time);
            Console.WriteLine("End operation at {0}", DateTime.Now);
        }

        public static string DownloadHtml(string url)
        {
            WebClient wc=new WebClient();
            return wc.DownloadString(url);
        }
    }
}
