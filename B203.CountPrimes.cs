/**
Description:

Count the number of prime numbers less than a non-negative number, n


Idea: 
The classic method is traverse all positive numbers from 2 to n-1, then use a private method
to check if each number is prime and count the number of prime numbers. But this method
would be TLE because it's two slow. So we need some new algorithm to do the task. 

Reference: 
1, How many primes number less than n?
https://primes.utm.edu/howmany.html
2, Sieve of Eratosthenes
http://en.wikipedia.org/wiki/Sieve_of_Eratosthenes

Here comes this fantastic ancient algorithm to find all prime numbers less than n: Sieve of Eratosthenes
The basic idea quote from Wikipedia is as follow:

To find all the prime numbers less than or equal to a given integer n by Eratosthenes' method:
1, Create a list of consecutive integers from 2 through n: (2, 3, 4, ..., n).
2, Initially, let p equal 2, the first prime number.
3, Starting from p, enumerate its multiples by counting to n in increments of p, and mark them in the list (these will be 2p, 3p, 4p, ... ; the p itself should not be marked).
4, Find the first number greater than p in the list that is not marked. If there was no such number, stop. Otherwise, let p now equal this new number (which is the next prime), and repeat from step 3.

In fact, for each p above, we can start marking new non-prime numbers from p^2 instead of 2p. Because all non-prime numbers
less than p^2 must already been marked by a smaller p. 2p has been marked when p is 2, 3p has been marked when p is 3......


Solution1:
The classic method. To check if n is a prime number, traverse from 2 to sqrt(n), check if n%i is 0.
We need to do the check from 2 to n-1, then for each n, we need to check from 2 to sqrt(n), so the running
time is: O(n^1.5).

Time complexity: O(n*sqrt(n)) = O(n^1.5)  Space: O(1)


Solution2:
Implement Sieve of Eratosthenes Algorithm:
1, create a boolean array named primes with size of n to indicate if each number is prime. 
If primes[i] is false, means i is prime. Otheriwse i is not prime.
2, Use variable count to count the number of prime numbers, initial count as 0.
3, traverse from 2 to n-1 using i, if primes[i] is false, we find a prime, count++. 
And if now i <= sqrt(n), we traverse from i*i to n-1 using j, and for each j, mark primes[j] as true.
4, return count.

Two key points to be noticed:
1, In the outter loop, every time primes[i] is false, we must find a prime numbers. Because i was not marked
by a previous smaller i, so it must be a prime number.
2, When we start to mark new non-prime numbers using current i, we must check if i<=sqrt(n). We will do the marking
process only if i<=sqrt(n). That's because when n is a very large number, then n*n may be larger than the largest int32,
thus will cause an overflow of integer and eventually cause array index out of range. Also if i > sqrt(n), no need to
try the marking process, because i*i is surely larger than n. 

Time Complexity: O(nloglogn)  Space: O(n)


Solution3:
We could do a little improvement based on Solution2. Note in Solution2, we mark all non-prime numbers and use the 
outter loop to count all prime numbers. So for the outter loop, we need to traverse from 2 to n-1. But in fact, we
can count all non-prime numbers when we mark them. Then number of prime = total number - number of non-prime. Thus
we can reduce the times of outter loop. Now the outter loop only traverse from 2 to sqrt(n).

The process:
1, initially count as n-2.
2, traverse from 2 to sqrt(n) using i. 
3, For each i, if primes[i] is false, traverse from i*i to n using j.
4, For each j, if primes[j] is false, we find a new non-prime number, count-- and mark primes[j] as true.
5, return count.

Note:
1, because the in the outter loop i cannot be larger than sqrt(n), so there is no integer overflow to worry about.
2, For the input n, there is at most n-2 prime numbers less than n, because 1 is surely not a prime number. 
So must initial count as n-1.

Time complexity: O(nloglogn)  Space: O(n)
*/

//Solution1: Classic method, but TLE  Time: O(n*sqrt(n)), O(n^1.5) Space: O(1)
public class Solution {
    public int CountPrimes(int n) {
        if(n<=2)
            return 0;
        int count=0;
        for(int i=2;i<n;i++){
            if(IsPrime(i))
                count++;
        }
        return count;
    }
    
    //classic method to check if n is a prime number
    private bool IsPrime(int n){
        for(int i=2;i<Math.Sqrt(n);i++){
            if(n%i==0)
                return false;
        }
        return true;
    }
}


//Solution2: Sieve of Eratosthenes Version#1  Time: O(nloglogn) Space:O(n)
public class Solution {
    public int CountPrimes(int n) {
        if(n<=2)
            return 0;
        bool[] primes = new bool[n]; //false means prime, true means not prime
        int count = 0;
        int limit = (int)Math.Sqrt(n);
        for(int i=2;i<n;i++){ //n times
            if(!primes[i]){
                count++;
                if(i<=limit){ //logn times
                    for(int j=i*i;j<n;j+=i) //loglogn times
                        primes[j]=true;
                }
            }
        }
        return count;
        
    }
}


//Solution3: Sieve of Eratosthenes Version#2 A little bit faster Time:O(nlognlogn) Space:O(n)
public class Solution {
    public int CountPrimes(int n) {
        if(n<=2)
            return 0;
        bool[] primes = new bool[n]; //false means prime, true means not prime
        int count = n-2; //1 is not prime, so at most n-1 prime numbers
        int limit = (int)Math.Sqrt(n);
        for(int i=2;i<=limit;i++){
            if(!primes[i]){
                for(int j=i*i;j<n;j+=i){
                    if(!primes[j])
                        count--;
                    primes[j]=true;
                }
            }
        }
        return count;
        
    }
}
