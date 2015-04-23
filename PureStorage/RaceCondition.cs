/**
Introduction

A race condition occurs when two or more threads are able to access shared data and they try to change it at the same time. 
Because the thread scheduling algorithm can swap between threads at any point, 
we cannot know the order at which the threads will attempt to access the shared data. 
Therefore, the result of the change in data is dependent on the thread scheduling algorithm, 
i.e. both threads are 'racing' to access/change the data. The reason for having more race conditions among threads 
than processes is that threads can share their memory while a process can not.

For example Let's say we have two threads, T1 and T2, where both are accessing a shared variable x.
They first read data from the variable and then try to write data on the variable simultaneously.  
They would race to find which of these threads can write the value last to the variable.  
In this case, the last written value would be saved.

As another example, we can have these two threads, T1 and T2, trying opposite operations on this variable.  
Let thread T1 increase the value of the variable and the thread T2 decrease the value of the variable at the same point of time.
What is the result?  The value remains unchanged.

Race Conditions
Consider the example shown below. We have a variable result and there are 3 threads trying to write a unique value to it.
*/

//Example for simple race condition
using System;
using System.Threading;

    class Test
    {
        int result = 0;
        void Work1() { result = 1; }
        void Work2() { result = 2; }
        void Work3() { result = 3; }
        static void Main(string[] args)
        {
            Test t = new Test();
            Thread worker1 = new Thread(t.Work1);
            Thread worker2 = new Thread(t.Work2);
            Thread worker3 = new Thread(t.Work3);
            worker1.Start();
            worker2.Start();
            worker3.Start();
            Console.WriteLine(t.result);
            Console.Read();
        }
    }
/**
output : Looking at the code it might seem that the result at the end will be 3. 
But if you try executing the code you will find out that it is not always true. 
The result might be 1, 2 ,3 or even 0 (The main thread executed first and print 0)

The reason for this is that the operating system decides which thread gets executed first. 
And the order in which we start the threads is not all that important. 
So thread that is given least priority by the operating system gets executed last.
*/

/**
The Solution

C# provide number of ways to avoid race conditions depending on the type of application you are writing. 
But the most common method that works in any condition is using Wait Handles and Signaling. 
In the above example we will try to ensure that the first thread is the last one that writes value to result variable.

The process is quite simple let all threads are started at the same time. 
But the first thread is forced to wait till second and third thread signal that they are done.

Similarly the main thread is forced to wait till the first thread completes. 
This ensures that the  Console.WriteLine() is not called before the other threads finish their work.
*/

//Example to avoid Race Condition using Wait Handles and Signaling.
using System;
using System.Threading;

    class Test
    {
        int result = 0;
        //declare AutoResetEvent for each thread, initially false
        AutoResetEvent event1 = new AutoResetEvent(false);
        AutoResetEvent event2 = new AutoResetEvent(false);
        AutoResetEvent event3 = new AutoResetEvent(false);
        void Work1()
        {
        	//call static method WaitAll to wait for event2 and event3
            WaitHandle.WaitAll(new WaitHandle[] { event2, event3 });
            result = 1;
            event1.Set(); //set event1 to true
        }
        void Work2() { result = 2; event2.Set(); } //set event2 and event3
        void Work3() { result = 3; event3.Set(); }
        static void Main(string[] args)
        {
            Test t = new Test();
            Thread worker1 = new Thread(t.Work1);
            Thread worker2 = new Thread(t.Work2);
            Thread worker3 = new Thread(t.Work3);
            WaitHandle[] waitHandles = new WaitHandle[] { t.event2, t.event3 };
            worker1.Start();
            worker2.Start();
            worker3.Start(); 
            //call static method WaitAny to wait for event1
            WaitHandle.WaitAny(new WaitHandle[] { t.event1 });
            Console.WriteLine(t.result);
        }
    }

/**
To implement this we need to declare AutoResetEvent for each thread (except the main one). 
Whenever a thread finishes execution it signals its respective AutoResetEvent by calling Set(). 
The first thread waits for both second and third thread to signal and then starts execution.

Similarly the main thread waits for the first thread to signal before it prints the value. 
This method will always ensure that the final result is 1.
*/
