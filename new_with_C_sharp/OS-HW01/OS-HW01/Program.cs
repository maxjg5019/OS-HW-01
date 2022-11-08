using System;
using System.Diagnostics;
using System.Threading;


namespace OS_HW01
{
    class Program
    {
		
        static void Main(string[] args)
        {
            double[,] A = new double[500, 800];
            double[,] B = new double[800, 500];
            double[,] C = new double[500, 500];

			// create A
			for (int i = 0; i < 500; i++)			
				for (int j = 0; j < 800; j++)
				{
                    A[i,j] = 6.6 * (i + 1) - 3.3 * (j + 1);
				}			

			// create B
			for (int i = 0; i < 800; i++)			
				for (int j = 0; j < 500; j++)
				{
					B[i,j] = 100 + 2.2 * (i + 1) - 5.5 * (j + 1);
				}			

			// create C
			for (int i = 0; i < 500; i++)			
				for (int j = 0; j < 500; j++)
				{
					C[i,j] = 0;
				}			

			// for-loops
			double Start1 = Stopwatch.GetTimestamp();
			for (int i = 0; i < 500; i++)			
				for (int j = 0; j < 500; j++)				
					for (int k = 0; k < 800; k++)
					{
						C[i,j] += A[i,k] * B[k,j];
					}				
			
			double Stop1 = Stopwatch.GetTimestamp();
			Console.WriteLine("Using for-loops = " + (Stop1 - Start1)/100000 + "ms\n");

			//Multithread 50
			double Start2 = Stopwatch.GetTimestamp();

			Thread [] threads_50 = new Thread[50];
			int rows_50 = 500 / 50;

			for (int i = 0; i < 50; i++)
			{
				var start = new int();
                start = (rows_50 * i);
                var end = new int();
                end = ((rows_50 * i) + rows_50);
                //Console.WriteLine($"{ rows_50 * i},{(rows_50 * i) + rows_50}" );
                threads_50[i] = new Thread(() => MutiThread_50(A, B, C, start, end));
				threads_50[i].Start();
			}

			for (int i = 0; i < 50; i++)
				threads_50[i].Join();

			double Stop2 = Stopwatch.GetTimestamp();
			Console.WriteLine("Using Multithread 50 = " + (Stop2 - Start2) / 100000 + "ms\n");

			//Multithread 10
			double Start3 = Stopwatch.GetTimestamp();

			Thread [] threads_10 = new Thread[10];
			int rows_10 = 500 / 10;

            for (int i = 0; i < 10; i++)
            {
				var start = new int();
				start = (rows_10 * i);
				var end = new int();
				end = ((rows_10 * i) + rows_10);
				//Console.WriteLine($"{ rows_10 * i},{(rows_10 * i) + rows_10}");
				threads_10[i] = new Thread(() => MutiThread_10(A, B, C, start, end));
                threads_10[i].Start();
            }
            for (int i = 0; i < 10; i++)
                threads_10[i].Join();

            double Stop3 = Stopwatch.GetTimestamp();
            Console.WriteLine("Using Multithread 10 = " + (Stop3 - Start3) / 100000 + "ms\n");

        }
		private static void MutiThread_10(double[,] a, double[,] b, double[,] c, int Startplace, int Endplace)
		{
            //Console.WriteLine($"{ Startplace},{Endplace}");
            for (int i = Startplace; i < Endplace; i++)
                for (int j = 0; j < 500; j++)
                    for (int k = 0; k < 800; k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
        }
		private static void MutiThread_50(double[,] a, double[,] b, double[,] c, int Startplace, int Endplace)
		{
			//Console.WriteLine($"{ Startplace},{Endplace}");
            for (int i = Startplace; i < Endplace; i++)
                for (int j = 0; j < 500; j++)
                    for (int k = 0; k < 800; k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
        }
	}
}

