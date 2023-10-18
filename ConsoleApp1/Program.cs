using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static volatile List<int> s = new List<int>();
        static void Main(string[] args)
        {
            //var qq = new QSystem.Collections.Concurrent.ConcurrentQueue<int>();
            //var isempty = qq.IsEmpty;
            //foreach(var oo in Enumerable.Range(0, 10).ToList())
            //{
            //    qq.Enqueue(oo);
            //}
            //isempty = qq.IsEmpty;
            try
            {
                _ = Task.Run(() =>
                {
                    SpinWait spin = new SpinWait();
                    while (true)
                    {

                        spin.SpinOnce();
                        s.Add(1);
                    }
                });
            }
            catch(Exception ex) 
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }


            try
            {
                _ = Task.Run(() =>
                {
                    SpinWait spin = new SpinWait();
                    while (true)
                    {
                        spin.SpinOnce();
                        if (s.Count >0)
                        {
                            s.RemoveAt(0);
                        }
                        
                    }
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }
    }

    
}
