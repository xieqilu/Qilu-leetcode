/**
Given an array with n objects colored red, white or blue, sort them so that objects of the same color are adjacent,
with the colors in the order red, white and blue.

Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.

Note:
You are not suppose to use the library's sort function for this problem.

click to show follow up.

Follow up:
A rather straight forward solution is a two-pass algorithm using counting sort.
First, iterate the array counting number of 0's, 1's, and 2's, 
then overwrite array with total number of 0's, then 1's and followed by 2's.

Could you come up with an one-pass algorithm using only constant space?


Idea:
This is a typical problem about counting sort. Counting sort is a very important linear time sorting algorithm.
Overall there are two approaches:

1, first iteration of A to count number of each elements in A. Then use second iteration to overwrite A using
the number of each elements.

2, Use two pointers starting from the head and end of A. Then iterate A, for each element, if it's 0, swap it
with A[headPointer] and increment headPointer, if it's 2, swap it with A[endPointer] and decrement endPointer. 


Solution1: Two Iteration
Use three variables to store the number of 0,1,2 in A. Then iterate A for the second time to overwrite A using 
the three variables.


Solution2: Two Iteration  more flexible  Time: O(n)  Space: O(1)
This is the classic method to do counting sort. Use an extra array count to store the number of 0,1,2 in A.
The index of array count is 0,1,2 and the value is the number of index that appears in A. In other words, 
count[0] will store the number of 0 in A. Then iterate A and build values of count.

Then we will use count to overwrite A. Note to overwrite A, for each element in A, we need three informations:
the element itself, the number of the element, and the starting position for the element in A. Use count we can
get the first two information, but we still don't know the starting position. So we will use an integer to keep
track of the starting position. Initially int start=0. Then after filling element i to A, we update start as
start+=count[i].


Solution3: One Iteration  Time: O(n)  Space: O(1)
We can also use two pointers to solve this problem. The task of this problem is actually pushing all 0s in A to
the head and all 2s in A to the end. So we can use redPos starting from the head and bluePos starting from the end.
(redPos=0, bluePos=A.Length-1). Then iterate A, if A[i]==0, swap it with A[redPos] and increment redPos and i. Else
if A[i]==2, swap it with A[bluePos] and decrement bluePos. Else (A[i]==1) just increment i. In the process, all the
positions before redPos and after bluePos have already been swapped.

The condition of while loop is i<bluePos+1, becuase all positions after bluePos have been swapped already, we don't
need to check them again.

Special Note: in the loop, when A[i]==2, after swapping we do not increment i. Because after swapping the current A[i]
is swapped from the end of A, if we increment i, then we will skip the current A[i] without handling it. But when 
A[i]==0, after swapping we must increment i. Because the current A[i] is swapped from the head of A and it must be
already visited before by i. So we don't need to handle it again thus must increment i.
*/

//Solution1: Two Iteration  Time: O(n)  Space:O(1)
public class Solution {
    public void SortColors(int[] A) {
       int red = 0, white = 0, blue = 0;
			//scan arr and caculate occurence of three colors
			for (int i = 0; i < A.Length; i++) {
				switch (A[i]) {
				case 0:
					red++;
					break;
				case 1:
					white++;
					break;
				case 2:
					blue++;
					break;
				}
			}
				
			//overwrite the arrar according to occurence
			for (int i = 0; i < A.Length; i++) {
				if (red > 0) {
					A[i] = 0;
					red--;
				} else if (white > 0) {
					A [i] = 1;
					white--;
				} else
					A [i] = 2;

			}

    }
}

//Solution2: Two Iteration  more flexible   Time:O(n)  Space:O(1)
public class Solution {
    public void SortColors(int[] A) {
        int[] count = new int[3]; //use array to store number of appearence for differern colors
        //first iteration to caculate number of appearence and store the information to count
        foreach(int i in A){
            count[i]++;
        }
        int start=0; //starting index for each color
        for(int i=0;i<count.Length;i++){ //second iteration to overwrite array A
            for(int j=0;j<count[i];j++)
                A[j+start]=i;
            start+=count[i];
        }
    }
}


//Solution3: One Iteration  Time:O(n)  Space:O(1)
public class Solution {
    public void SortColors(int[] A) {
       int redPos = 0, bluePos =A.Length-1;
       int i=0;
       while(i<bluePos+1){
           if(A[i]==0){
               Swap(ref A[i],ref A[redPos]);
               redPos++;
               i++;
           }
           else if(A[i]==2){
               Swap(ref A[i],ref A[bluePos]);
               bluePos--; 
               //Here after swapping, don't increment i, because i now pointes to the element swapped 
               //from the end of A, if i++, then we will skip current A[i] and cannot handle it
           }
           else
                i++;
       }
    }
    
    private void Swap(ref int a, ref int b){
        int temp = a;
        a = b;
        b = temp;
    }
}
