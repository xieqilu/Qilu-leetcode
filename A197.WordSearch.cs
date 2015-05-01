/**
Given a 2D board and a word, find if the word exists in the grid.

The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once.

For example,
Given board =

[
  ["ABCE"],
  ["SFCS"],
  ["ADEE"]
]
word = "ABCCED", -> returns true,
word = "SEE", -> returns true,
word = "ABCB", -> returns false.


Idea:
这道题很容易感觉出来是图的题目，其实本质上还是做深度优先搜索。基本思路就是从某一个元素出发，往上下左右深度搜索是否有相等于word的字符串。这里注意每次从一个元素出发时要重置访问标记（也就是说虽然单次搜索字符不能重复使用，但是每次从一个新的元素出发，字符还是重新可以用的）。深度优先搜索的算法就不再重复解释了，不了解的朋友可以看看wiki - 深度优先搜索。我们知道一次搜索的复杂度是O(E+V)，E是边的数量，V是顶点数量，在这个问题中他们都是O(m*n)量级的（因为一个顶点有固定上下左右四条边）。加上我们对每个顶点都要做一次搜索，所以总的时间复杂度最坏是O(m^2*n^2)，空间上就是要用一个数组来记录访问情况，所以是O(m*n)

Time complexity: O(n^2*m^2)  Space complexity: O(m*n)

Solution:
Use dfs to start from each cell on board, and search to four directions. Note that after one complete search, we need to
remark all cells in visited as false, because all cells can be used for the next search. We can do this in the dfs method 
after recursive calls.

Follow-Up: If we can search to eight directions, just change the recursive call to eight directions.
*/

public class Solution {
    public bool Exist(char[,] board, string word) {
        if(word.Length==0 || word==null)
            return true;
        int m = board.GetLength(0), n = board.GetLength(1);
        if(board==null || m==0 || n==0)
            return false;
        bool[,] visited = new bool[m,n];
        for(int i=0;i<m;i++){
            for(int j=0;j<n;j++){
                if(dfs(board, word, 0, i, j, visited))
                    return true;
            }
        }
        return false;
    }
    
    private bool dfs(char[,] board, string word, int index, int i, int j, bool[,] visited){
        if(index==word.Length)
            return true;
        if(i<0||j<0||i>board.GetLength(0)-1||j>board.GetLength(1)-1||visited[i,j]||board[i,j]!=word[index])
            return false;
        visited[i,j] = true;
        bool res = dfs(board, word, index+1, i+1, j, visited)
            || dfs(board, word, index+1, i-1, j, visited)
            || dfs(board, word, index+1, i, j+1, visited)
            || dfs(board, word, index+1, i, j-1, visited);
        visited[i,j] = false;
        return res;
    }
}
