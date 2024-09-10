namespace Examination_System;

internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            App.Run(args);
            Console.WriteLine("[1]Exit\t [2]Retest");
            int x=int.Parse(Console.ReadLine());
            if(x==1)
            {
                break; 
            } 
        }
    }
}