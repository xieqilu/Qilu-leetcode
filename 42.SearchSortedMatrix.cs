//Write an efficient algorithm that searches for a value in an n x m table (two-dimensional array).
//This table is sorted along the rows and columns — that is,
//
//Table[i][j] ≤ Table[i][j + 1], 
//Table[i][j] ≤ Table[i + 1][j]

//Binary Search for each rows(columns):  O(nlogn)
//not a good idea

//Step-wise Linear Search:  O(n), best solution!

//C#: 2D array, GetUpperBound(0) => get the largest row index
//				GetUpperBound(1) => get the largest column index


using System;
using System.Collections.Generic;
using System.Collections;

namespace SearchSortedMatrix
{
	class Finder
	{
		//Step-wise Linear Search, Time: O(n), O(m+n) if m rows and n colmuns
		public static bool MatrixContains(int[,] matrix, int t)
		{
			int n = matrix.GetUpperBound (0); //largest row index
			int m = matrix.GetUpperBound (1); //largest column index

			if (t > matrix [n,m] || t < matrix [0, 0]) //if t is not in the boundries of matrix
				return false;

			int row = 0;
			int col = m;

			while (row <= n && col >= 0) {
				if (matrix [row, col] == t)
					return true;
				else if (matrix [row, col] > t)
					col--;
				else          //matrix[row, col]>t
					row++;
			}
			return false;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			int[,] matrix = new int[6,5] {
				{1,4,7,11,15},
				{2,5,8,12,19},
				{3,6,9,16,22},
				{10,13,14,17,24},
				{18,21,23,26,30},
				{20,25,27,29,34}
			};

			Console.WriteLine (matrix.GetUpperBound (0)); //row is from 0 to 5, so here the value printed is 5
			Console.WriteLine (matrix.GetUpperBound (1)); //column is from 0 to 4, so here the value printe is 4
			Console.WriteLine (Finder.MatrixContains (matrix, 90));
			Console.WriteLine (Finder.MatrixContains (matrix, 27));
		}
	}
}
