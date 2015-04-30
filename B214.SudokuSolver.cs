/**
Write a program to solve a Sudoku puzzle by filling the empty cells.

Empty cells are indicated by the character '.'.

You may assume that there will be only one unique solution.


Idea:
This is a classic NP Problem. An NP problem is a problem that can be validated in Polynomial time (O(n^k)), but we don't know
if we can solve it in O(n^k)/Polynomial time. For example, we can validate if a sudoku board is correct in O(n^k) time, but 
we may not be able to solve a sudoku board in O(n^k) time. In fact, most NP problem is supposed to be solved using
some kind of brute-force method, thus the time complexity would be at least exponential time O(2^poly(n)), like: O(2^n).
Specificly, if we use a total brute-force method to solve NP problem, the time complexity would probably be factorial time
O(n!), if we use a better Dynamic Programming method to solve it, the time complexity would be exponential time O(2^n). 
Clearly the exponential time is much faster than factorial time.


Solution1: Brute-Force method
The brute-force method is more simple to code. We will use the solution for Validate Sudoku to check if the current board
is valid or not. The whole process is like a DFS. We start from the first empty cell and try to put number 1 to 9 on it. After
putting a number we validate current board and continue the same process to next empty cell. We continue trying recursively
deeper and deeper until the board is not valid, then we return to the last valid position and try another search path. Once
the board is filled out and it's valid, we find a solution and return.

We will have the followint methods:
validHelper(): check if a row, column or section is valid
isValidSudoku(): check the whole board to see if it's valid
getNextEmpty(): get the next empty cell
solveHelper(): Recursively check all possible paths. Steps in this method:
1, get next empty cell.
2, if there is no next empty cell, return true.
3, Use a for loop to put 1 to 9 on the current empty cell, after putting a number, if the board is valid, continue
to call itself to check the next empty cell. Note if the next try returns false, we need to continue and try another
number for current cell, don't immidieately return false. Only return false after we tried all numbers from 1 to 9 for
the current empty cell.
4, After the for loop, if still not return, that means we cannot put any number on the current empty cell (there is something
wrong on the higher level), so we clear current cell to empty and return false.

Time complexity: factorial time  O(n^2!), n is 9.

Note: this solution is brute-force because every time we put a number on an empty cell, we check the whole board to see if
all cells are valid. This is surely not necessary, because the new added number can only influence a part of the board, and 
before adding the new number the previous board is valid. So we only need to check if this newly added number will conflict
with other existing number on the board.


Solution2: Dynamic Programming
We can modified solution1 to make it much faster. Before trying a new number on the current empty cell, the previous board
must be valid. So after adding the new number, we only need to check if this newly added number is conflict with numbers on
the same row, column and section. In other words, we only check if the row, column and section this newly added number belongs
to is valid or not. If they are valid, the whole board must be valid because the newly added number cannot affect other parts
of the board. We don't need to check the whole board everytime we add a new number, this will make this solution much faster
than solution1.
*/

//Solution1: Brute-Force 
public class Solution {
    //Helper Method to check if a row, column or section is valid
    private boolean validHelper(char[][] board, int sRow, int eRow, int sCol, int eCol){
        boolean[] used = new boolean[10];
        for(int i=sRow; i<=eRow;i++){
            for(int j=sCol;j<=eCol;j++){
                if(board[i][j]=='.')  //if the cell is empty
                    continue;
                if(used[board[i][j]-'0'])  //if the number already used, not valid
                    return false;
                used[board[i][j]-'0']=true; //if the number is not used, set it as used
            }
        }
        return true;
    }
    
    //Method to check if current board is valid by check each row, column, and section
    public boolean isValidSudoku(char[][] board) {
        for(int i=0;i<9;i++){    //check each column
            if(!validHelper(board,i,i,0,8))
                return false;
        }
        
        for(int i=0;i<9;i++){   //check each row
            if(!validHelper(board,0,8,i,i))
                return false;
        }
        
        for(int i=0;i<9;i+=3){ //i and j could be 0,3,6
            for(int j=0;j<9;j+=3){ 
                if(!validHelper(board,i,i+2,j,j+2)) //the end index could be 2,5,8
                    return false;
            }
        }
        return true;
    }
    
    //Get next empty cell on board and return its position
    private int[] getNextEmpty(char[][] board){
        int[] pair = new int[]{-1,-1};
        for(int i=0;i<9;i++){
            for(int j=0;j<9;j++){
                if(board[i][j]=='.'){
                    pair[0] = i;
                    pair[1] = j;
                    return pair;
                }
            }
        }
        return pair;
    }
    
    private boolean solveHelper(char[][] board){
        int[] pair = getNextEmpty(board);
        if(pair[0]==-1)  //if no empty cell on the board
            return true;
        int i = pair[0], j=pair[1];
        for(char num = '1'; num<='9';num++){ //try number 1 to 9 for current cell
            board[i][j] = num;
            if(isValidSudoku(board)){  //after putting a number, first validate board
                if(solveHelper(board))  //then recursively solve other empty cells
                    return true;
            }
        }
        board[i][j] = '.';
        return false;
    }
    
    public void solveSudoku(char[][] board) {
        solveHelper(board);
    }
}


//Solution2: Dynamic Programming
public class Solution {
    //Method to check if the newly added number on cell (x,y) will make the board invalid
    private boolean isValid(char[][] board, int x, int y) {
        //check the row and column that current cell (x,y) belongs to
       for(int i=0;i<9;i++){
            if(i!=x && board[i][y] == board[x][y])
                return false;
            if(i!=y && board[x][i] == board[x][y])
                return false;
       }
       
       //check the section that current cell (x,y) belongs to
       for(int i=3*(x/3);i<3*(x/3+1);i++){
           for(int j=3*(y/3);j<3*(y/3+1);j++){
               if(i!=x && j!=y && board[i][j]==board[x][y])
                    return false;
           }
       }
       return true;
    }
    
    //Get next empty cell on board and return its position
    private int[] getNextEmpty(char[][] board){
        int[] pair = new int[]{-1,-1};
        for(int i=0;i<9;i++){
            for(int j=0;j<9;j++){
                if(board[i][j]=='.'){
                    pair[0] = i;
                    pair[1] = j;
                    return pair;
                }
            }
        }
        return pair;
    }
    
    private boolean solveHelper(char[][] board){
        int[] pair = getNextEmpty(board);
        if(pair[0]==-1)  //if no empty cell on the board
            return true;
        int i = pair[0], j=pair[1];
        for(char num = '1'; num<='9';num++){ //try number 1 to 9 for current cell
            board[i][j] = num;
            if(isValid(board, i, j)){  //after putting a number, first validate board
                if(solveHelper(board))  //then recursively solve other empty cells
                    return true;
            }
        }
        board[i][j] = '.';
        return false;
    }
    
    public void solveSudoku(char[][] board) {
        solveHelper(board);
    }
}
