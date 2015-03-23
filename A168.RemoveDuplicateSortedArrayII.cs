/**
Follow up for "Remove Duplicates":
What if duplicates are allowed at most twice?

For example,
Given sorted array A = [1,1,1,2,2,3],

Your function should return length = 5, and A is now [1,1,2,2,3].


Idea:
The method is very similiar to the original Remove Duplicates problem. Since in this problem duplicates are
allowed at most twice. It's obvious that we need an Integer (or a bool) to keep track of the number of appearence
of A[prev], so that we know when to discard duplicates. Also in the iteration if A[i]!=A[prev] and A[prev] 
appears more than twice, set A[prev+1]=A[prev] and increment prev twice, then set A[prev]=A[i].


Solution:
Detailed steps:
1, Edge case: if length of A is less than 3, return A.Length
2, set prev=0, count=1.
3, Iterate A from the second element:
3.1, if A[i]==A[prev], increment count
3.2, if A[i]!=A[prev], check count, if count>=2, set A[prev+1]=A[prev] and increment prev. Then increment prev
and set A[prev]=A[i], then set count=1. (because A[i] appears once now)
4, After iteration, also need to check count, if count>=2, set A[prev+1]=A[prev] and return prev+2. 
Otherwise, return prev+1.


Special Note:
1, Every time if A[i]!=A[prev] and count>=2 we need to set A[prev+1]=A[prev]. That's because the current A[prev]
could be shifted from the later part of A and is not necessarily equal to A[prev+1]. And we need to keep two 
A[prev] in the result so must set A[prev+1]=A[prev].

2, After the iteration, we must check count for last prev to make sure the result is correct.
*/


//Solution: Two pointers and a flag variable
public class Solution {
    public int RemoveDuplicates(int[] A) {
        if(A.Length<3) return A.Length;
        int prev=0;
        int count=1; //keep track of the number of appearence of A[prev]
        for(int i=1;i<A.Length;i++){
            if(A[i]!=A[prev]){
                if(count>=2){ //if A[prev] appears more than twice
                    A[prev+1]=A[prev];
                    prev++; //increment for one extra time
                }
                prev++;
                A[prev]=A[i];
                count=1;
            }
            else
                count++;
        }
        if(count>=2){ //if last A[prev] appears more than twice
            A[prev+1]=A[prev];
            return prev+2;
        }
        return prev+1;
    }
}
