#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>

double A [50][80];
double B [80][50];
double C [50][50];

int main () 
{
	int i, j;
	double sum;

	for (i = 1; i <= 50 ; i++)
	{
		for (j = 1; j < 80 ; j++)
		{
			A[i][j] = 6.6 * i - 3.3 * j;

			B[j][i] = 100 + 2.2 * i - 5.5 * j;

			C[i][j] = A [i][j] * B[j][i];
		}
		printf("test");
	}
}