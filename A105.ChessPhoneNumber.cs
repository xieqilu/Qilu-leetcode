using System;
using System.Collections.Generic;
using System.IO;
/**
Basic Idea to Solve this Problem:

I intend to use Recursive method and Dynamic Programming to solve this problem.
The idea is divide the problem from top to bottome. 

Basically, assume N(s,d) is the number of unique, valid phone numbers that 
we can construct starting from number s and has the length of d. 
Then we have N(s,d)=N(s1,d-1)+M(s2,d-1)+...+N(sk,d-1) in which
s1,s2,...,sk represent the number that can be reached by one step from number s.
The base case is when d is equal to 1, then no matter what s is, N(s,d) is equal to 1.
Becasue for each number, we can only get itself as a one digit valid sequence.

And I also use a 2D array to memorize intermediate results and achieve a better time complexity.
The 2D array is actually amatrix. And matrix[s][d] stores the result of N(s,d) from above paragraph. 
The matrix isinitialized with -1 for all cells. So if a cell has the value of -1, 
it means it has not been filled yet.

Then for each recursive call, first I try to look up for the result from the matrix. 
If the required cell has not been filled yet, we then keep call recursively and fill 
the cell. If the required cell has been filled before, we just return the value of the cell.

Time and Space complexity:
By using this method, I can make sure each cell of the martix will be filled only once.
So it has a Linear running time. Suppose we need to contruct a n-digit number sequence
(in this problem, n is equal to 7), the Time Complexity is O(n).
And the Space Complexity is also O(n).
*/

class Solution {
	//Method to calculate number of phone number for "knight" and "bishop"
	public static int CalculateMoves(string piece){
		int[][] matrixKnight = new int[10][]; //matrix for knight
		int[][] matrixBishop = new int[10][]; //matrix for bishop

		//initialize the matrix with value -1
		for (int i = 0; i < matrixBishop.Length; i++) {
			matrixKnight [i] = new int[8]{ -1, -1, -1, -1, -1, -1, -1,-1 };
		}
		for (int i = 0; i < matrixBishop.Length; i++) {
			matrixBishop [i] = new int[8]{ -1, -1, -1, -1, -1, -1, -1,-1 };
		}       
		int count=0;
		if(piece=="knight"){ //calculate for input "Knight"
			//a valid phone number cannot begin with 0 or 1, so start from 2
			for(int i=2;i<10;i++){  
				count+=CalculateMovesKnight(i,7,matrixKnight);
			}
			return count;
		}
		else if(piece=="bishop"){ //calculate for input "bishop"
			for(int i=2;i<10;i++){
				count+=CalculateMovesBishop(i,7,matrixBishop);
			}
			return count;
		}
		else{ //handle invalid input string
			Console.WriteLine("Invalid Input: please input knight or bishop");
			return -1;
		}
	}

	//Recursive method to calculate number of phone numbers for "knight"
	private static int CalculateMovesKnight(int startPos, int num, int[][]matrix){
		//if the cell has been filled before, directly get the value from the cell
		if(matrix[startPos][num]!=-1)  
			return matrix[startPos][num];

		if(num==1){  //Base case: when num is 1, fill the cell with 1.
			matrix[startPos][num]=1;
			return matrix[startPos][num]; 
		}

		int numOfMoves = 0; 

		//fill the matrix cell according to startPos
		switch(startPos){
		case 1:
			numOfMoves= CalculateMovesKnight(6,num-1,matrix)+
				CalculateMovesKnight(8,num-1,matrix);
			matrix[startPos][num]=numOfMoves;
			break;
		case 2:
			numOfMoves= CalculateMovesKnight(7,num-1,matrix)+
				CalculateMovesKnight(9,num-1,matrix);
			matrix[startPos][num]=numOfMoves;
			break;
		case 3:
			numOfMoves= CalculateMovesKnight(4,num-1,matrix)+
				CalculateMovesKnight(8,num-1,matrix);
			matrix[startPos][num]=numOfMoves;
			break;
		case 4:
			numOfMoves= CalculateMovesKnight(0,num-1,matrix)+
				CalculateMovesKnight(9,num-1,matrix)+
				CalculateMovesKnight(3,num-1,matrix);
			matrix[startPos][num]=numOfMoves;
			break;
		case 5:  //from number 5 we cannot reach any other numbers
			numOfMoves=0;
			matrix[startPos][num]=numOfMoves;
			break;
		case 6:
			numOfMoves= CalculateMovesKnight(0,num-1,matrix)+
				CalculateMovesKnight(1,num-1,matrix)+
				CalculateMovesKnight(7,num-1,matrix);
			matrix[startPos][num]=numOfMoves;
			break;
		case 7:
			numOfMoves= CalculateMovesKnight(2,num-1,matrix)+
				CalculateMovesKnight(6,num-1,matrix);
			matrix[startPos][num]=numOfMoves;

			break;
		case 8:
			numOfMoves= CalculateMovesKnight(1,num-1,matrix)+
				CalculateMovesKnight(3,num-1,matrix);
			matrix[startPos][num]=numOfMoves;
			break;
		case 9:
			numOfMoves= CalculateMovesKnight(2,num-1,matrix)+
				CalculateMovesKnight(4,num-1,matrix);
			matrix[startPos][num]=numOfMoves;
			break;
		case 0:
			numOfMoves= CalculateMovesKnight(4,num-1,matrix)+
				CalculateMovesKnight(6,num-1,matrix);
			matrix[startPos][num]=numOfMoves;
			break;

		}
		return matrix[startPos][num]; 
	}

	//Recursive method to calculate number of phone numbers for "bishop"
	private static int CalculateMovesBishop(int startPos, int num,int[][]matrix){
		//if the cell has been filled before, directly get the value from the cell
		if(matrix[startPos][num]!=-1)  
			return matrix[startPos][num]; 

		if(num==1){ //Base case: when num is 1, fill the cell with 1.
			matrix[startPos][num]=1;
			return matrix[startPos][num]; 
		}

		int numOfMoves = 0;

		//fill the matrix cell according to startPos 
		switch(startPos){
		case 1:
			numOfMoves= CalculateMovesBishop(5,num-1,matrix)+
				CalculateMovesBishop(9,num-1,matrix);
			break;
		case 2:
			numOfMoves= CalculateMovesBishop(4,num-1,matrix)+
				CalculateMovesBishop(6,num-1,matrix);
			break;
		case 3:
			numOfMoves= CalculateMovesBishop(5,num-1,matrix)+
				CalculateMovesBishop(7,num-1,matrix);
			break;
		case 4:
			numOfMoves= CalculateMovesBishop(2,num-1,matrix)+
				CalculateMovesBishop(8,num-1,matrix);

			break;
		case 5:
			numOfMoves= CalculateMovesBishop(1,num-1,matrix)+
				CalculateMovesBishop(3,num-1,matrix)+
				CalculateMovesBishop(7,num-1,matrix)+
				CalculateMovesBishop(9,num-1,matrix);
			break;
		case 6:
			numOfMoves= CalculateMovesBishop(2,num-1,matrix)+
				CalculateMovesBishop(8,num-1,matrix);
			break;
		case 7:
			numOfMoves= CalculateMovesBishop(0,num-1,matrix)+
				CalculateMovesBishop(3,num-1,matrix)+
				CalculateMovesBishop(5,num-1,matrix);              
			break;
		case 8:
			numOfMoves= CalculateMovesBishop(4,num-1,matrix)+
				CalculateMovesBishop(6,num-1,matrix);
			break;
		case 9:
			numOfMoves= CalculateMovesBishop(1,num-1,matrix)+
				CalculateMovesBishop(5,num-1,matrix)+
				CalculateMovesBishop(0,num-1,matrix);
			break;
		case 0:
			numOfMoves= CalculateMovesBishop(9,num-1,matrix)+
				CalculateMovesBishop(7,num-1,matrix);
			break;

		}
		return numOfMoves;
	}

	static void Main(String[] args) {
		/* Enter your code here. Your class should be named Solution */
		/* Read from STDIN. Print output to STDOUT */   

		string piece = Console.ReadLine();

		// piece can be "knight" or "bishop"

		int moves = 0;

		// call your algorithm to calculate number of moves...
		moves = CalculateMoves(piece);

		// output moves
		Console.WriteLine(moves);
	}
}
