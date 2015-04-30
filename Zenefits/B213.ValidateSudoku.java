/**
Determine if a Sudoku is valid, Sudoku Rules reference:
http://sudoku.com.au/TheRules.aspx

Details of rules:
1,The sudoku board is a 9x9 board, each cell can be filled with number from 0 to 9.
2,Each column must have the numbers 1-9 occuring just once.
3,Each row must have the numbers 1-9 occuring just once.
4,And the numbers 1-9 must occur just once in each of the 9 sub-boxes of the grid.

The Sudoku board could be partially filled, where empty cells are filled with the character '.'.
Note:
A valid Sudoku board (partially filled) is not necessarily solvable. Only the filled cells need to be validated.


Idea:
This problem is a Brute-Force problem. We will ignore all empty cell on the sudoku board and only test the cell that
has a number. The approach is very straightforward, we check each row, column and section to see if there is any duplicate number on it. If there is any duplicate number, return false.


Solution:
To make to code more elegant and simple, we use a private method which can check each row, column and section.
The method will take five arguments: the borad, the start and end index of row, the start and end index of column.
And in the method, we use a bool array with length of 10 to serve like a dictionary, if a number already appeared,
array[number-'0'] is true. Then we traverse each cell within the start and end index of row and column, ignore the
empty cell and check if there is any duplicate.

To check each column, set start and end index of row from 0 to 8.
To check each row, set start and end index of column from 0 to 8.
To check section, set all the four index arguments accordingly to cover all 9 sections on board.

Time complexity: O(n^2), n=9.
Suppose the board is nxn size, then there are totally n^2 cells. And each cell will be visited 3 times because
it belongs to a row, a column and a section. So running time is O(3*n^2).

Space: O(1)  only use a bool array with length of 10.
*/


public class Solution {
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
    
}
