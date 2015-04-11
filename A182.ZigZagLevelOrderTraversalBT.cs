/**
Given a binary tree, return the zigzag level order traversal of its nodes' values. 
(ie, from left to right, then right to left for the next level and alternate between).

For example:
Given binary tree {3,9,20,#,#,15,7},
    3
   / \
  9  20
    /  \
   15   7
return its zigzag level order traversal as:
[
  [3],
  [20,9],
  [15,7]
]


Idea:
This problem is very similiar to Level Order Traversal of Binary Tree. The only difference is that 
for ith level, if i is odd number, traverse from right to left, if i is even number, traverse from
left to right. The key point is to maintain the correct traverse order for each level.

Solution1: 
Using additional traversal of result List

We can use the same method as Binary Tree Level Order Traversal, after getting the result. We traverse
the result list and for the ith list, if i is odd number, we just reverse this list. The main method is
excatly the same, we just add an additional traversal of the result list to reverse some elements.

Time: O(n)  Space: O(n)

Solution2: 
Using a flag to control the adding position of TreeNode value.

The overall method is the same as Binary Tree Level Order Traversal, the only difference is we need to 
control the adding position of TreeNode value. In detail, for the ith level (i is zero-based), if i is
even number, append TreeNode value at the end of list; if i is odd number, insert TreeNode value at the
head of list (using List.Add() and List.Insert()). Thus we can control the order for each level.

But there is a significant drawback of this method: List.Insert() has a running time of O(n^2), because
if we want to insert an element at the head of List, we need to shift all other elements. Instead, 
List.Add() has a running time of O(n) (although if we add beyond current capacity, it's O(n)).

So the time complexity is O(n^2) thus this method is not a good option.

Time: O(n)  Space: O(n^2)

Solution3: 
Using two Stacks and a flag to control traverse order for each level.

This is a very tricky method. We can use two stacks to do the BFS. The way we use two stacks is excatly the 
same as using two queues to do the BFS (Note we cannot use one stack to do any BFS). And we also need a flag
to control the traverse order for each level. In detail, for a current poped TreeNode, if the flag is true,
we firstly try to push its left child, then its right child; Otherwise, firstly try to push its right child,
then its left child. And if current stack is empty, swap it with next stack and reverse flag.
If we push child from left to right, we will get the traversal order from right to left for this level, and
Vice versa (Stack is LIFO). 

Note here the difference of Stack and Queue is totally presented. Because Stack is LIFO, we can keep pushing 
element into it and maintain the reverse poped order. Thus we can change the traverse order for each level.
Buf if we use two queues, we cannot do that, because the Enqueue order and Dequeue order is always the same.

For this method, we don't need to do extra traversal for result list, so it's supposed to be the best method.

Time: O(n)  Space:O(n)
*/

/**
 * Definition for binary tree
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

//Solution1: My Solution Time: O(n)  Space:O(n)
public class Solution {
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) { //Time: O(n)  Space: O(n)
        IList<IList<int>> result = new List<IList<int>>();
        if(root==null) return result;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        int current=1, next=0;
        queue.Enqueue(root);
        IList<int> temp = new List<int>();
        while(queue.Count!=0){
            TreeNode curr = queue.Dequeue();
            //List.Add() is O(1), if add beyond current capacity,it's O(n)
            //But List.Insert() is always O(n) because of shifting elements
            temp.Add(curr.val); 
            current--;
            if(curr.left!=null){
                queue.Enqueue(curr.left);
                next++;
            }
            if(curr.right!=null){
                queue.Enqueue(curr.right);
                next++;
            }
            if(current==0){
                result.Add(temp);
                temp = new List<int>();
                current=next;
                next=0;
            }
        }
        for(int i=0;i<result.Count;i++){ //O(n)
            if(i%2==1)
                Reverse(result[i]);
        }
        return result;
    }
    
    private void Reverse(IList<int> list){
        int start=0, end=list.Count-1;
        while(start<end){
            int temp = list[start];
            list[start]=list[end];
            list[end] = temp;
            start++;
            end--;
        }
    }
}

//Solution2: Using List.Insert(), Time: O(n^2) Space: O(n)
public class Solution {
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) { //Time: O(n^2)  Space: O(n)
        IList<IList<int>> result = new List<IList<int>>();
        if(root==null) return result;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        int current=1, next=0;
        bool isLeft = true;
        queue.Enqueue(root);
        IList<int> temp = new List<int>();
        while(queue.Count!=0){
            TreeNode curr = queue.Dequeue();
            //List.Add() is O(1), if add beyond current capacity,it's O(n)
            //But List.Insert is always O(n) because of shifting elements
            if(isLeft)
                temp.Add(curr.val); 
            else
                temp.Insert(0, curr.val); //O(n)
            current--;
            if(curr.left!=null){
                queue.Enqueue(curr.left);
                next++;
            }
            if(curr.right!=null){
                queue.Enqueue(curr.right);
                next++;
            }
            if(current==0){
                result.Add(temp);
                isLeft = !isLeft;
                temp = new List<int>();
                current=next;
                next=0;
            }
        }
        return result;
    }
}

//Solution3: Using Two Stacks, Best solution. Time: O(n)  Space: O(n)
public class Solution {
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) { //Time: O(n)  Space: O(n)
        IList<IList<int>> result = new List<IList<int>>();
        if(root==null) return result;
        Stack<TreeNode> current = new Stack<TreeNode>();
        Stack<TreeNode> next = new Stack<TreeNode>();
        IList<int> temp = new List<int>();
        bool isLeft = true;
        current.Push(root);
        while(current.Count!=0){
            TreeNode curr = current.Pop();
            temp.Add(curr.val);
            if(isLeft){
                if(curr.left!=null)
                    next.Push(curr.left);
                if(curr.right!=null)
                    next.Push(curr.right);
            }
            else{
                if(curr.right!=null)
                    next.Push(curr.right);
                if(curr.left!=null)
                    next.Push(curr.left);
            }
            if(current.Count==0){
                result.Add(temp);
                temp = new List<int>();
                Swap(ref current, ref next);
                isLeft=!isLeft;
            }
        }
        return result;
    }
    //swap two references of type T
    private void Swap<T> (ref T t1, ref T t2){
        T temp = t1;
        t1 = t2;
        t2 = temp;
    } 
}
