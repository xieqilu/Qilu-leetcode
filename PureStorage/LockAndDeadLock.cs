/**
The lock keyword marks a statement block as a critical section by obtaining the mutual-exclusion lock for a given object, 
executing a statement, and then releasing the lock. The following example includes a lock statement.
*/

//Simple example for using Lock
  class Account
    {
        decimal balance;
        private Object thisLock = new Object();

        public void Withdraw(decimal amount)
        {
            lock (thisLock)
            {
                if (amount > balance)
                {
                    throw new Exception("Insufficient funds");
                }
                balance -= amount;
            }
        }
    }

/**
The lock keyword ensures that one thread does not enter a critical section of code while another thread is in the critical section.
If another thread tries to enter a locked code, it will wait, block, until the object is released.

The lock keyword calls Enter at the start of the block and Exit at the end of the block. 
A ThreadInterruptedException is thrown if Interrupt interrupts a thread that is waiting to enter a lock statement.

In general, avoid locking on a public type, or instances beyond your code's control. T
he common constructs lock (this), lock (typeof (MyType)), and lock ("myLock") violate this guideline:

lock (this) is a problem if the instance can be accessed publicly.
lock (typeof (MyType)) is a problem if MyType is publicly accessible.
lock("myLock") is a problem because any other code in the process using the same string, will share the same lock.

Best practice is to define a private object to lock on, 
or a private static object variable to protect data common to all instances.
You can't use the await keyword in the body of a lock statement.
*/

/**
The following sample uses threads and lock.
As long as the lock statement is present, the statement block is a critical section 
and balance will never become a negative number.

Why the balance will never become a negative number?
Because by using the lock, the statments in the lock (withdrawl money) is a critical section. If one thread is executing the 
withdrawl statement, other threads have to wait until the lock is released. So the withdrawl action become atomic action which
means mutiple threads cannot withdrawl money at the same time. Thus, in the withdrawl statment we make sure the balance will
never become negative.

BUT, if mutiple threads can withdrawl at the same time, suppose thread A want to get a amount money and thread B want to get b
amount money. And the current balance is c amount money. Both a and b are less than c. So thread A and thread B will both do the
withdrawl action. Then if a+b is greater than c, after thread A and thread B both withdrawl at the same time, the balance is 
negative. 
*/

//Solution using lock to ensure balance will never be negative
// using System.Threading; 

    class Account
    {
        private Object thisLock = new Object();
        int balance;

        Random r = new Random();

        public Account(int initial)
        {
            balance = initial;
        }

        int Withdraw(int amount)
        {

            // This condition never is true unless the lock statement 
            // is commented out. 
            if (balance < 0)
            {
                throw new Exception("Negative Balance");
            }

            // Comment out the next line to see the effect of leaving out  
            // the lock keyword. 
            lock (thisLock)
            {
                if (balance >= amount)
                {
                    Console.WriteLine("Balance before Withdrawal :  " + balance);
                    Console.WriteLine("Amount to Withdraw        : -" + amount);
                    balance = balance - amount;
                    Console.WriteLine("Balance after Withdrawal  :  " + balance);
                    return amount;
                }
                else
                {
                    return 0; // transaction rejected
                }
            }
        }

        public void DoTransactions()
        {
            for (int i = 0; i < 100; i++)
            {
                Withdraw(r.Next(1, 100));
            }
        }
    }

    class Test
    {
        static void Main()
        {
            Thread[] threads = new Thread[10];
            Account acc = new Account(1000);
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ThreadStart(acc.DoTransactions));
                threads[i] = t;
            }
            for (int i = 0; i < 10; i++)
            {
                threads[i].Start();
            }
        }
    }


/**
Introduction

A deadlock is a situation where an application locks up because two or more activities are waiting for each other to finish. 
This occurs in multithreading software where a shared resource is locked by one thread and another thread is waiting to access it
and something occurs so that the thread holding the locked item is waiting for the other thread to execute.

First, it's important to understand what a deadlock among threads is and the conditions that lead to one. 
Many OS course textbooks will cite the four conditions necessary for a deadlock to occur:

1, A limited number of a particular resource. In the case of a monitor in C# (what you use when you employ the lock keyword), 
this limited number is one, since a monitor is a mutual-exclusion lock (meaning only one thread can own a monitor at a time).

2, The ability to hold one resource and request another. 
In C#, this is akin to locking on one object and then locking on another before releasing the first lock, for example:
lock(a)
   {
     lock(b)
         {
            ....
          }
   }

3, No preemption capability. In C#, this means that one thread can't force another thread to release a lock.

4, A circular wait condition. This means that there is a cycle of threads, 
each of which is waiting for the next to release a resource before it can continue.

If any one of these conditions is not met, deadlock is not possible. We can avoid all four condition by the followings:

The first condition is inherent to what a monitor is, so if you're using monitors, this one is set in stone.
The second condition could be avoided by ensuring that you only ever lock one object at a time, 
but that's frequently not a feasible requirement in a large software project.
The third condition could possibly be avoided in the Microsoft.NET Framework 
by aborting or interrupting the thread holding the resource your thread requires, 
but a) that would require knowing which thread owned the resource, 
and b) that's an inherently dangerous operation .

To further illustrate how a deadlock might occur, imagine the following sequence of events:

Thread 1 acquires lock A.
Thread 2 acquires lock B.
Thread 1 attempts to acquire lock B, but it is already held by Thread 2 and thus Thread 1 blocks until B is released.
Thread 2 attempts to acquire lock A, but it is held by Thread 1 and thus Thread 2 blocks until A is released.
At this point, both threads are blocked and will never wake up. The following C# code demonstrates this situation.
*/

//Simple example for deadlock
object lockA = new object();
object lockB = new object(); 
        Thread 1 void t1() 
        { 
            lock (lockA) 
            { 
                lock (lockB)
                { 
                    /* ... */
                } 
            } 
        } 
        Thread 2 void t2() 
        { 
            lock (lockB)
            { 
                lock (lockA)
                   { 
                    /* ... */
                   } 
            } 
        }

//A complete code that cause DeadLock
using System;
using System.Threading;
namespace deadlockincsharp
{
public class Akshay
    {
        static readonly object firstLock = new object();
        static readonly object secondLock = new object();
        static void ThreadJob()
        {
            Console.WriteLine("\t\t\t\tLocking firstLock");
            lock (firstLock)
            {
                Console.WriteLine("\t\t\t\tLocked firstLock");
                // Wait until we're fairly sure the first thread
                // has grabbed secondLock
                Thread.Sleep(1000);
                Console.WriteLine("\t\t\t\tLocking secondLock");
                lock (secondLock)
                {
                    Console.WriteLine("\t\t\t\tLocked secondLock");
                }
                Console.WriteLine("\t\t\t\tReleased secondLock");
            }
            Console.WriteLine("\t\t\t\tReleased firstLock");
        }
        static void Main()
        {
            new Thread(new ThreadStart(ThreadJob)).Start();
            // Wait until we're fairly sure the other thread
            // has grabbed firstLock
            Thread.Sleep(500);
            Console.WriteLine("Locking secondLock");
            lock (secondLock)
            {
                Console.WriteLine("Locked secondLock");
                Console.WriteLine("Locking firstLock");
                lock (firstLock)
                {
                    Console.WriteLine("Locked firstLock");
                }
                Console.WriteLine("Released firstLock");
            }
            Console.WriteLine("Released secondLock");
            Console.Read();
        }       
    }
}

/**
Output:
Time limit exceeded	time: 5 memory: 28912 signal:9
				Locking firstLock
				Locked firstLock
Locking secondLock
Locked secondLock
Locking firstLock
				Locking secondLock

As we can see, the program is terminated because Time Limit Exceeded. And both objects are trying to lock a resouce that is owned
by the other.
*/

