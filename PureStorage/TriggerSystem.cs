/**
题目大意是这样的。有一个系统，里面会有一些任务，如果trigger函数没有被执行过呢，
那么这些任务就存起来；如果trigger函数已经执行过了呢，就马上执行。
另外，trigger函数执行的时候，也需要将之前存起来的任务执行掉。

Solution:

系统从简单到复杂一步步深化：
1）单线程、顺序不需要保证
    用一个boolean变量记录是否执行过trigger就好了。可以用一个queue来存没有马上执行的任务。
2）多线程、顺序不需要保证. 
    把涉及到boolean变量取值、赋值的部分上锁。如果直接就写对了，
    面试官会写几个别的上锁的可能性让你来判断是否达到了同样的效果（有些对，有些错）
3）多线程、顺序需要保证
    这里比较麻烦一点。最直接的做法是把trigger里面整个释放过程加锁。
    但这样太笨重了。在面试官的引导下，找到了另外一种加锁的方式：
    把改变boolean值放在最后，把判断queue是否为空的代码上锁，
    这样其他的任务还能在trigger执行的时候把任务加到最后。
*/

//Solution1: 单线程，顺序不需保证
using System;
using System.Threading;
using System.Collections.Generic;

class Test{
	private static bool flag;
	private static Queue<int> tasks = new Queue<int>();
	
	public static void Main(){
		for(int i=0;i<3;i++)
			DoTask(i);
		Trigger();
		for(int i=4;i<6;i++)
			DoTask(i);
	}
	
	public static void Trigger(){
		flag = true;
		Console.WriteLine("Done Trigger!");
		foreach(int v in tasks)
			Console.WriteLine(v);
	}
	
	public static void DoTask(int val){
		if(flag)
			Console.WriteLine("do task: "+val);
		else
			tasks.Enqueue(val);
	}
	
}

//Solution2  多线程，顺序不需保证
using System;
using System.Threading;
using System.Collections.Generic;

class Test{
	private static bool flag;
	private static Queue<int> tasks = new Queue<int>();
	private static object thisLock = new object();
	
	public static void Main(){
		Thread t1 = new Thread(Test.run1);
		Thread t2 = new Thread(Test.run2);
		Thread t3 = new Thread(Test.Trigger);
		t1.Start();
		t2.Start();
		t3.Start();
	}
	
	public static void Trigger(){
		lock(thisLock){ //lock when wirte flag
			flag = true;
		}
		Console.WriteLine("Done Trigger!");
		foreach(int v in tasks)
			Console.WriteLine("do task: "+v);
	}
	
	public static void DoTask(int val){
		lock(thisLock){ //lock when get value from flag
			if(flag)
				Console.WriteLine("do task: "+val);
			else
				tasks.Enqueue(val);
		}
	}
	
	public static void run1(){
		for(int i=4;i<6;i++)
			DoTask(i);
	}
	
	public static void run2(){
		for(int i=0;i<3;i++)
			DoTask(i);
	}
}

//Solution3: 多线程，顺序需要保证
/**
题目大意是这样的。有一个系统，里面会有一些任务，如果trigger函数没有被执行过呢，
那么这些任务就存起来；如果trigger函数已经执行过了呢，就马上执行。
另外，trigger函数执行的时候，也需要将之前存起来的任务执行掉。

Solution:

系统从简单到复杂一步步深化：
3）多线程、顺序需要保证
    这里比较麻烦一点。最直接的做法是把trigger里面整个释放过程加锁。
    但这样太笨重了。在面试官的引导下，找到了另外一种加锁的方式：
    把改变boolean值放在最后，把判断queue是否为空的代码上锁，
    这样其他的任务还能在trigger执行的时候把任务加到最后。
*/

/**
Final Solution:
RegisterCallBack(CallBack cb):
1, Lock(), then check flag, if flage is true, unlock() and cb.run().
2, If flag is false, push cb to queue, then unlock().

EventFired():
1, Use a while loop to repeatedly check if queue is empty, before check queue.Count, lock().
2, If queue is not empty, unlock(), then pop cb from queue and run it.
3. If queue is empty, firstly set flag = true, then unlock() and break.

Key points:
1, we must lock the process of checking and setting flag, thus no two threads can visit flag at the same time. That means,
when a thread is checking flage, no other threads can change flag. And also when a thread is changing flag, no other theads
can check the flag, they must wait until flage is changed successfully.

2, To insure the order of CallBack is the same, we must also lock the process of checking q.Count and pushing CallBack into 
q. That means, if a thread is checking q.Count, no other threads can push CallBack to the queue. But after checking q.Count,
we can unlock(), so when one thread is running a Callback poped from q, other threads can still add new CallBack to q. And we
will check the q.Count again, so it doenn's affect the order. When one thread is pushing CallBack into q, no other threads can
check q.Count, they must wait until the CallBack is pushed into q.

3, In fact, in order to make the order correct. When one thread is checking q.Count, no other threads can check the flage. They
can check the flag only when:
1, the q is not empty, thus in this pass we won't change flag.
2, the q is empty, after we change the flag.
*/


//最终版本：use lock() and unlock() method to solve this problem
using System;
using System.Collectiosn.Generic;
using System.Threading;

// To execute C#, please define "static void Main" on a class
// named Solution.

Event myEvent;

class Callback {
    void run() {
        myEvent.registerCallback(...)
    }
}

void lock(object);
void unlock(object);

class Event {
    private bool flag;
    private Queue<Callback> q = new Queue<Callback>();
    private static object thisLock = new object();
    void registerCallback(Callback cb) {
       lock(thisLock)
        if (flag) {
            unlock(thisLock);
            cb.run();
       } else {
           q.Enqueue(cb);
       }
        unlock(thisLock)
    }

    void eventFired() {
        lock(thisLock)
        //if(q.Count!=0)
        
        unlock(thisLock)
        while(true){
            lock(thisLock)
            if(q.Count!=0){
                unlock(thisLock)
                q.Dequeue().run();
            }
            else{                
                flag=true;
                unlock(thisLock);
                break;
            }
        }
    }
}

//Test process:
register(A)
register(B)
register(C)
-eventFired()
    A.run()
    B.run()
register(D)
    C.run()
    D.run()
