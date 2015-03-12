/**
Given a non-negative number represented as an array of digits, plus one to the number.

The digits are stored such that the most significant digit is at the head of the list.


Solution:
This is a very simple Math Problem. Just do it using regular approach.
The only trick is we only need to plus one to the input number, so if all digits of the input
number are 9, we need to add an additional digit at the head of input number. And in this case,
we do not need to do any loop, we can directly create a new int array with the length of digits.Length+1,
and set the first digit of new array as 1 then return the new array. (all elements of the new array have
the default value as 0)

Notice only when all digits of input number are 9 then we avoid using loop. Otherwise, we will need a for
loop from end to start to modify the input number. In detail, each time we add 1 to digits[i], if the sum
is less than 10, we set digits[i] to sum and directly break the loop and return digits. 
If the sum is 10, we set digits[i] to 0 and continue the loop.
*/
public class Solution {
    public int[] PlusOne(int[] digits) {
        if(IsAllNine(digits)){ //if all digits are 9, no need to do loop
            int[] newDigits = new int[digits.Length+1];
            newDigits[0]=1;
            return newDigits;
        }
        for(int i=digits.Length-1;i>=0;i--){ //otherwise, need the loop
            int temp = 1+digits[i];
            if(temp<10){ //if temp<10, no need to do any more caculation
                digits[i]=temp;
                return digits;
            } 
            else
                digits[i]=0;
        }
        return digits;
    }
    
    private bool IsAllNine(int[] digits){
        foreach(int i in digits){
            if(i!=9) return false;
        }   
        return true;
    }
}
