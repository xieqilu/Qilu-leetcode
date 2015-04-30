/**
Follow up for "Unique Paths":

Now consider if some obstacles are added to the grids. How many unique paths would there be?

An obstacle and empty space is marked as 1 and 0 respectively in the grid.

For example,
There is one obstacle in the middle of a 3x3 grid as illustrated below.

[
  [0,0,0],
  [0,1,0],
  [0,0,0]
]
The total number of unique paths is 2.

Note: m and n will be at most 100.


Solution: 
This problem is very similiar to the original Unique Paths problem. 
The primary logic is the same, we will still use a matrix DP[m,n] to store the number of unique paths
from each cell of the original matrix. 
But this time there are obstacles in the original matrix and a valid path cannot pass any obstacle.
Thus we have two special cases to handle as follows:

1, When initializing the base row and column (DP[0,n] and DP[m,0]), when a cell has obstacle, the number
of paths from it should be 0. In addition, if any previous cell at the same row or column has obstacle,
the number of paths from the current cell should also be 0 (because we cannot pass obstacle).
How do we acheieve the above results? The steps are as follows:

1.1, First initialize DP[0,0]. If obstacleGrid[0,0] has obstacle, DP[0,0]=0. Otherwise, DP[0,0]=1.
1.2, Then initialize DP[0,n], the idea is if obstacleGrid[0,n] has obstacle, DP[0,n] must be 0.
Otherwise, let DP[0,n]=DP[0,n-1]. The second part is very important, it enables us to pass the influence
of obstacle alone the row. In other words, if any previous cell of DP[0,n] is 0, then DP[0,n] must be 0.
1.3, Initialize DP[m,0] using the same method as step 1.2.

2, When constructing the DP matrix after initializing the base row and column, if the current cell doesn't
have obstacle, DP[i,j]=DP[i-1,j]+DP[i,j-1]. Otherwise, DP[i,j]==0.

Time: O(m*n)   Space: O(m*n)

Special Note:
In C#, when we have a MultiArray like a matrix A[m,n], we can use the method GetLength(int i) to get the
length of any dimision of the MultiArray.
For example: 
If we have a matrix A[m,n], A.GenLength(0) returns the length of first dimision, which is m. (totally m rows)
A.GetLength(1) returns the length of second dimision, which is n. (totally n columns)
*/

//Solution: Dynamic Programming  
public class Solution {
    public int UniquePathsWithObstacles(int[,] obstacleGrid) {
        if(obstacleGrid==null||obstacleGrid.GetLength(0)==0) //edge case
            return 0;
        int m = obstacleGrid.GetLength(0); //get length of first dimision  O(1)
        int n = obstacleGrid.GetLength(1); //get length of second dimision O(1)
        int[,] DP = new int[m,n];
        DP[0,0] = obstacleGrid[0,0]==0? 1:0; //first set DP[0,0]
        //initialize base columns and rows for DP matrix
        for(int i=1;i<n;i++)
            DP[0,i] = obstacleGrid[0,i]==1? 0:DP[0,i-1];
        for(int i=1;i<m;i++)
            DP[i,0] = obstacleGrid[i,0]==1? 0:DP[i-1,0];
            
        for(int i=1;i<m;i++){
            for(int j=1;j<n;j++){
                if(obstacleGrid[i,j]==1)
                    DP[i,j]=0;
                else
                    DP[i,j]=DP[i,j-1]+DP[i-1,j];
            }
        }
        return DP[m-1,n-1];
    }
}
