/**
As an example, I will use a regular LIFO stack data structure implemented as a linked list. 
Here is a regular Stack data structure without the concurrency in place.
*/

//Example: Non-Concurrent Stack
public class StackL
 {
     internal class Node
     {
         internal T _item;
         internal Node _next;
         public Node(T item, Node next) { _item = item; _next = next; }
     }
 
     private Node _head = null;
     private long _size = 0;
 
     public StackL()
     {
         _head = new Node(default(T), _head);
     }
 
     public bool IsEmpty()
     {
         return _size == 0 ? true : false;
     }
 
     public long CurrentSize()
     {
         return _size;
     }
 
     public void Push(T item)
     {
         _head = new Node(item,_head);
         _size++;
     }
 
     public T Pop()
     {
         if(_head._next == null)
             throw new IndexOutOfRangeException("Stack is empty");
 
         T item = _head._item;
         _head = _head._next;
         _size--;
         return item;
     }
 }
 
 /**
 The possibility for the concurrency for a Stack data structure is somehow limited due to 
 a single Head node that will be used to achieve both “push” and “pop” operations. 
 But there are still few possibilities that we can use that are worth mentioning. 
 Below is the simplest implementation of concurrent Stack.
 */
 
 //Simple Concurrent Stack
 public class ConcurrentStackL
 {
     object _objLock;
 
     internal class Node
     {
         internal T _item; 
         internal Node _next;
         public Node(T item, Node next) { _item = item; _next = next; }
     }
 
     private Node _head = null;
     private bool _isEmpty;
 
     public ConcurrentStackL()
     {
         _head = new Node(default(T), _head);
         _objLock = new object();
         _isEmpty = true;
     }
 
     public bool IsEmpty()
     {
         bool val;
         lock (_objLock)
         {
             val = _isEmpty;
         }
         return val;
     }
 
 
     public void Push(T item)
     {
         lock (_objLock)
         {
             _head = new Node(item, _head);
             if (!_isEmpty)
                 _isEmpty = false;
         }
     }
 
     public T Pop()
     {
         T item;
         lock (_objLock)
         {
             if (_head._next == null)
                 throw new IndexOutOfRangeException("Stack is empty");
 
              item = _head._item;
             _head = _head._next;
 
             if (_head._next == null)
                 _isEmpty = true;
         }
          
         return item;
     }
 }
 
/**
The implementation of this algorithm is fairy trivial. 
The only thing that we are doing here is simply surrounded “push” and “pop” operations with the critical region. 
Of course, this simple approach guarantees safety in the concurrent environment, 
and it should be used when there are no other options; however, the scalability for this scenario is still questionable. 
Generally speaking the above implementation is somewhat similar to this:

StackL stackl = new StackL();
         Object syncObj = new Object();
         lock (syncObj)
         {
             stack.Push(1);
         }
         int result = 0;
         lock (syncObj)
         {
             result = stack.Pop();
         }
*/

/**
n comparison with the previous implementation, non-blocking approach for the Stack data structure might make a little more sense.
The reason is simple: by using Interlocked operation we can almost entirely avoid locking.
*/

//Non-Locking Concurrent Stack
public class ConcurrentNoBlockStackL
 {
     internal class Node
     {
         internal T _item; 
         internal Node _next;
         public Node() { }
         public Node(T item, Node next) { _item = item; _next = next; }
     }
 
     private volatile Node _head = null;
 
     public ConcurrentNoBlockStackL()
     {
         _head = new Node(default(T), _head);
     }
 
     public void Push(T item)
     {
         Node nodeNew = new Node();
         nodeNew._item = item;
 
         Node tmp;
         do{
             tmp = _head;
             nodeNew._next = tmp;
         } while (Interlocked.CompareExchange(ref _head,nodeNew,tmp) != tmp);
     }
 
     public T Pop()
     {
         Node ret;
 
         do{
             ret = _head;
             if(ret._next == null)
                 throw new IndexOutOfRangeException("Stack is empty");
 
         } while (Interlocked.CompareExchange(ref _head, ret._next, ret) != ret);
         return ret._item;
     }
 }
 
 /**
 In this code, we are using CompareExchage operation to swap the head Node with the newly created node atomically. 
 We also have defined head value as volatile to prevent possible reordering which might take place in the “Push” operation. 
 It is recommended to use volatile variable for the store in the Interlocked operations. 
 However, it is not strictly necessary as Interlocked operations prevent instruction reordering on the hardware layer. 
 (Volatile type works on compiler level)
 Note also that we are using “while” loop here to make sure the head node has not being changed by other thread 
 while we are trying to make an update.
 
 Volatile:
 The volatile keyword indicates that a field might be modified by multiple threads that are executing at the same time. 
 Fields that are declared volatile are not subject to compiler optimizations that assume access by a single thread. 
 This ensures that the most up-to-date value is present in the field at all times.
 The volatile modifier is usually used for a field that is accessed by multiple threads without using the lock statement 
 to serialize access.
 */
