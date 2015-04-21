using System;
using System.Linq;

namespace Solution {
    class Solution {
        //find number of positions to put new marble
        static int GetNumOfMarble(bool[,] board, int size){ 
            int[,] X = new int[size,2]; 
            int[,] Y = new int[size,2]; 
            
            for(int i=0;i<size;i++){
                int maxY=-1, minY=size, maxX=-1, minX=size;
                for(int j=0;j<size;j++){
                    if(board[i,j]==true){
                        maxY=Math.Max(maxY,j);
                        minY=Math.Min(minY,j);
                    }
                    if(board[j,i]==true){
                        maxX=Math.Max(maxX,j);
                        minX=Math.Min(minX,j);
                    }
                }
                X[i,0]=minY;
                X[i,1]=maxY;
                Y[i,0]=minX;
                Y[i,1]=maxX;
            }
            int res = 0;
            for(int i=0;i<size;i++){
                if(X[i,0]==size || X[i,0]==X[i,1])
                    continue;
                for(int j=X[i,0]+1;j<X[i,1];j++){
                    if(Y[j,0]==size || Y[j,0]==Y[j,1])
                        continue;
                    if(i>=Y[j,0]&&i<=Y[j,1]&&board[i,j]!=true)
                        res++;
                }
            }
            return res;           
        }
        //Parse STDIN
        static int[] ParseInput(string line){
            string[] input = line.Split();
            int[] nums = input.Select(y=>int.Parse(y)).ToArray();
            return nums;
        }
        
        static void Main(string[] args) {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */
            int[] firstLine = ParseInput(Console.ReadLine());
            int size = firstLine[0], numMarble = firstLine[1];
            bool[,] board = new bool[size,size];
            for(int i=0;i<numMarble;i++){
                int[] position = ParseInput(Console.ReadLine());
                board[position[0],position[1]] = true; //true means this position has marble
            }
            Console.WriteLine(GetNumOfMarble(board, size));
        }
    }
