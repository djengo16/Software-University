// ConsoleApplication33.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
// Example program
#include <iostream>
#include <string>
using namespace std;
int main()
{
	int P[10];
	int a = 0;
	for (int a = 0; a < 10; a++)
	{
		cout << "Den" << " " << (a + 1) << "!" << endl;
		cin >> P[a];
		if (cin.fail()) {
			cout << "Wrong format" << endl;
			return 1;
		}
	}
	int maxBr = 0; int *A = P;
	for (int a = 0; a < 10; a++)
		if (A[a] + A[a + 1] + A[a + 2] > maxBr)
			maxBr = A[a] + A[a + 1] + A[a + 2];
	cout << "Max prez 3 posledovatelni dni" << maxBr << endl;
	int Avg = 0;
	for (int a = 0; a < 10; a++) {

		Avg += P[a];
	}
		cout << "sreden broy = " << ((float)Avg / 10) << endl;
	for (a=1;a<10;a+=2)
		if (P[a] > P[a - 1]) {
			cout << "data:" << a + 1 << ".IX.2019" << endl;

		}
	return 0;
}