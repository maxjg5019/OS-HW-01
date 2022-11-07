#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>
#include <time.h>

double A[50][80];
double B[80][50];
double C[50][50];

int main()
{
	// init A

	int Ai, Aj;
	for (Ai = 0; Ai < 50; Ai++)
	{
		for (Aj = 0; Aj < 80; Aj++)
		{
			A[Ai][Aj] = 6.6 * (Ai + 1) - 3.3 * (Aj + 1);
		}
	}
	// init B

	int Bi, Bj;

	for (Bi = 0; Bi < 80; Bi++)
	{
		for (Bj = 0; Bj < 50; Bj++)
		{
			B[Bi][Bj] = 100 + 2.2 * (Bi + 1) - 5.5 * (Bj + 1);
		}
	}
	// init C

	int Ci, Cj;

	for (Ci = 0; Ci < 50; Ci++)
	{
		for (Cj = 0; Cj < 50; Cj++)
		{
			C[Ci][Cj] = 0;
		}
	}
	int i, j, k;

	// for-loops

	clock_t START, END;
	START = clock();
	for (i = 0; i < 50; i++)
	{
		for (j = 0; j < 50; j++)
		{
			for (k = 0; k < 80; k++)  
			{
				C[i][j] += A[i][k] * B[k][j];
			}
		}
	}
	END = clock();
	printf("for-loop = %lf ms\n",(double) (END - START) / CLOCKS_PER_SEC);

	//Multithread 50

	pthread_t T50 ;
	clock_t START50, END50;
	int count_50 = 50;
	START50 = clock();
	pthread_create(&T50, NULL, Multithread_50_matrix, &count_50);

	END50 = clock();
	printf("Multithread 50 = %lf ms\n", (double)(END50 - START50) / CLOCKS_PER_SEC);

	//Multithread 10

	pthread_t T10;
	clock_t START10, END10;
	int count_10 = 10;
	START10 = clock();
	pthread_create(&T10,NULL, Multithread_10_matrix, &count_10);

	END10 = clock();
	printf("Multithread 10 = %lf ms\n", (double)(END10 - START10) / CLOCKS_PER_SEC);
	
}

void *Multithread_50_matrix(double A[50][80],double B[80][50], double C) 
{

}

void *Multithread_10_matrix (double A[50][80], double B[80][50], double C)
{

}