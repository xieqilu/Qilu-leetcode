/**
 * Merge k sorted linked lists and return it as one sorted list. 
 * Analyze and describe its complexity.
 * 
 * Solution 1:
 * We alreadly know how to merge two sorted lists, so we can use
 * this method to merge k sorted lists. The process is like merge
 * sort, each time we merge two lists together and eventually we 
 * will merge k lists together.
 * 
 * One thing to note is that we need to first merge the first and 
 * the last lists, then the second and the second last lists, and so on.
 * 
 * After we merge two lists together, we put the new merged list at
 * the position of the first original list. For example: if we merge
 * lists[0] and lists[7] (totally 8 lists), we put the new merged list
 * at lists[0].
 * 
 * By using this Divide and Conquer approach, we can reduce the time 
 * complexity.
 * 
 * 利用分治的思想把合并k个链表分成两个合并k/2个链表的任务，一直划分，知道任务中只剩一个链表或者两个链表。可以很简单的用递归来实现。因此算法复杂度为T(k) = 2T(k/2) + O(nk),很简单可以推导得到算法复杂度为O（nklogk）
递归的代码就不贴了。下面是非递归的代码非递归的思想是（以四个链表为例）：             
1、3合并，合并结果放到1的位置
2、4合并，合并结果放到2的位置
再把1、2合并（相当于原来的13 和 24合并）
 * 
 * 
 * Time Complexity: O(nklogk)
 * T(K) = 2T(k/2) +O(nk) -> O(nklogk)
 * We can analyze the time complexity in this way:
 * If the list has k elements and we need to use merge sort to sort them,
 * the time comlexity is O(klogk). But in this case, each element is actually
 * a Linked List with n nodes, so each operation will have O(n) steps. Then
 * the overall time complexity is O(nklogk).
 * 
 * Space Complexity: Constant space, O(1)
 * 
 * 
 * Solution 2:
 * Use a Min Heap (Priority Queue in java) to solve the problem.
 * Create a Min Heap with size of k, then put all head nodes
 * of the k lists into the Min Heap. Then each time we remove the
 * head node of the heap (which is also the current minimum node in
 * the heap) and append it to the new list. Then add the nexst node of
 * the removed node into the Min Heap (the Heap will automatically heapify).
 * Then we repeat the above process for n*k times to get the new sorted list.
 * 
 * Note: C# doesn't have a Min Heap class so the second solution will only
 * be implemented in Java.
 * 
 * Time Complexity: O(nklok)
 * We need to visit each node for exactly once. So totally we need to add n*k
 * nodes to the Min Heap, and each add operation will take O(logk) time. So 
 * the total time complexity is O(nklogk).
 * 
 * Space Complexity: O(k)
 * We need to keep a Min Heap that has k elements.
 * 
 * 
 * 
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */

//Solution 1: Merge Sort Solution
public class Solution {
    //Method to merge two sorted lists
    private ListNode MergeTwoLists(ListNode l1, ListNode l2) {
         if(l1==null||l2==null){
            if(l1 ==null) return l2;
            if(l2 ==null) return l1;
        }
        ListNode newHead,p,p1,p2;
        if(l1.val < l2.val){
            newHead = l1;
             p1 = l1.next;
             p2 = l2;
        }
        else{
            newHead = l2;
             p1 = l1;
             p2 = l2.next;
        }
           
         p = newHead;
        while(p1!=null && p2!=null){
            if(p1.val < p2.val){
                p.next = p1;
                p1 = p1.next;
            }
            else{
                p.next = p2;
                p2 = p2.next;
            }
            p=p.next;
        }
        //no need to use the while loop, directly append p1 or p2 to p
        //because rest nodes of p1 or p2 are already sorted
        if(p1!=null) p.next=p1;
        if(p2!=null) p.next=p2;
        return newHead;
    }
    
    //Iterative approach for Merge Sort O(nlogn)
    public ListNode MergeKLists(List<ListNode> lists) {
        int last = lists.Count-1;
        if(last<0) return null; //handle edge case: lists is empty
        while(last>0){
            int cur = 0;
            while(cur<last){
                lists[cur]= MergeTwoLists(lists[cur],lists[last]);
                cur++;
                last--;
            }
        }
        return lists[0];
        
    }
}
