using System;
using System.Diagnostics;
using System.Threading;


namespace OS_HW01
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] A = new double[50, 80];
            double[,] B = new double[80, 50];
            double[,] C = new double[50, 50];

			// create A
			for (int Ai = 0; Ai < 50; Ai++)
			{
				for (int Aj = 0; Aj < 80; Aj++)
				{
                    A[Ai,Aj] = 6.6 * (Ai + 1) - 3.3 * (Aj + 1);
				}
			}

			// create B
			for (int Bi = 0; Bi < 80; Bi++)
			{
				for (int Bj = 0; Bj < 50; Bj++)
				{
					B[Bi,Bj] = 100 + 2.2 * (Bi + 1) - 5.5 * (Bj + 1);
				}
			}

			// create C
			for (int Ci = 0; Ci < 50; Ci++)
			{
				for (int Cj = 0; Cj < 50; Cj++)
				{
					C[Ci,Cj] = 0;
				}
			}

			// for-loops
			double Start1 = Stopwatch.GetTimestamp();
			for (int i = 0; i < 50; i++)
			{
				for (int j = 0; j < 50; j++)
				{
					for (int k = 0; k < 80; k++)
					{
						C[i,j] += A[i,k] * B[k,j];
					}
				}
			}
			double Stop1 = Stopwatch.GetTimestamp();
			Console.WriteLine("Using for-loops = " + (Stop1 - Start1)/1000 + "ms\n");

			//Multithread 50
			double Start2 = Stopwatch.GetTimestamp();
			Run(A, B, C, 50);

			double Stop2 = Stopwatch.GetTimestamp();
			Console.WriteLine("Using Multithread 50 = " + (Stop2 - Start2) / 1000 + "ms\n");

			//Multithread 10
			double Start3 = Stopwatch.GetTimestamp();
			Run(A, B, C, 10);

			double Stop3 = Stopwatch.GetTimestamp();
			Console.WriteLine("Using Multithread 10 = " + (Stop3 - Start3) / 1000 + "ms\n");
		}
		static void Run(double[,]a, double[,]b, double[,]c, int threads_count)
		{
			Thread[] threads = new Thread[threads_count];
			int C_rows = c.Length / threads_count;

			for(int i = 0; i < threads_count; i++)
            {
				int current = C_rows;


            }
		}
	}
}

