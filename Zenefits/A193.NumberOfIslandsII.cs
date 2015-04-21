/**
Given a 2d grid map of '1's (land) and '0's (water), return a list/array containing the size of each island. 
An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
You may assume all four edges of the grid are all surrounded by water.

Example#1:
11000
11001
00001
Answer: [4,2]
The above matrix contains two islands, one has four lands, the other has 2 lands.

Example#2:
101
010
101
Answer: [1,1,1,1,1]
The above matrix contains five islands, each has only one land.


Idea:
This problem is very similiar to the original number of islands problem. The only difference
is we need to caculate the size of each island. So for each island, use a variable size to count
its size, pass the reference of size to the recursive DFS method. If we find an adjecent cell that
is '1', increment size before recrusively call DFS method. Thus after all the recursive calls, size
will store the size of current island.


Solution:
1, Use a List<int> to store results.
2, traverse the matrix, if current cell is '1', create int size=0 and pass the reference of it to
DFS method. After the calling DFS method, add size to result List.
3, In the DFS method:
If the current cell is '1', increment size, then mark current cell as '0' and recursively call DFS
method for all four adjecent cells.

Time complexity: O(n*m)
*/


using System;
using System.Collections.Generic;

public class Test
{
	public static List<int> FindIsland(char[][] grid){
		    List<int> res = new List<int>();
		    int r = grid.Length;
        if(r==0) return res; //edge case
        int c = grid[0].Length;
        if(c==0) return res; //edge case
        
        for(int i=0;i<r;i++){
            for(int j=0;j<c;j++){
                if(grid[i][j]=='1'){
                	int size=0; //number of lands in current island.
                    DFS(grid,i,j,ref size);
                    res.Add(size);
                }
            }
        }
        return res;
	}
	
	private static void DFS(char[][] grid, int i, int j, ref int size){
		    int r = grid.Length;
        int c = grid[0].Length;
        //Base Case to stop recursion
        if(i<0 || j<0 || i>r-1 || j>c-1)
            return;
        if(grid[i][j]=='1'){ //visit all adjecent cells around '1' and mark '1' as '0'
        	  size++;
            grid[i][j]='0';
            DFS(grid, i+1,j,ref size);
            DFS(grid, i-1,j,ref size);
            DFS(grid, i, j+1,ref size);
            DFS(grid, i, j-1,ref size);
        }
	}
	
	public static void Main()
	{
		int num = int.Parse(Console.ReadLine());
		for(int i=0;i<num;i++){
			string[] input = Console.ReadLine().Split(new char[]{' '});
			int n = int.Parse(input[0]); //number of columns
			char[][] grid = new char[n][];
			for(int j=0;j<n;j++){
				grid[j] = input[j+1].ToCharArray();
			}
			List<int> res = FindIsland(grid);
			foreach(int c in res)
				Console.Write(c+" ");
			Console.WriteLine(" ");
		}
	}
}
