/**
A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).

The robot can only move either down or right at any point in time. 
The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).

How many possible unique paths are there?


Solution:
The total unique paths at grid (r, c) are equal to the sum of total unique paths from grid to
the right (r, c + 1) and the grid below (r + 1, c).
How can this relationship help us solve the problem? We observe that all grids of the
bottom edge and right edge must all have only one unique path to the bottom-right corner. 
Using this as the base case, we can build our way up to our solution at grid (1, 1) 
using the relationship above.

We will use a matrix to store how many unique ways from a specific cell of the matrix.
eg: matrix[i,j] is the number of unique paths from the cell[i,j].

Then matrix[i,j] = matrix[i+1,j] + matrix[i,j+1].

Base case: matrix[m,j] and matrix[i,n] all have only one unique path, so the value of them are 1.

Time complexity: O(mn) 
Space complexity: O(mn)

Special Note: The above solution is equvalient to a Memorized Recursive solution. If we use recursive
solution, the relationship is the same. And in order to avoid duplicate recursive calls, we will use
a matrix to memorize unique paths from each cell. So eventually we will also fill a m*n matrix using
the recursive solution and the time and space complexity is the same.
*/

//Dynamic Programming solution O(mn)
public class Solution {
    public int UniquePaths(int m, int n) {
        int[,] matrix = new int[m,n];
        for(int i=0;i<m;i++) //initiliaze the matrix
            matrix[i,n-1]=1;
        for(int i=0;i<n;i++)
            matrix[m-1,i]=1;
        //fill the matrix cell one by one
        for(int i=m-2;i>=0;i--){
            for(int j=n-2;j>=0;j--){
                matrix[i,j] = matrix[i+1,j]+matrix[i,j+1];
            }
        }
        return matrix[0,0];
    }
}
