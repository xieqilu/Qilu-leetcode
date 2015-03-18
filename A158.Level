/**
Problem 1:
Given a binary tree, return the level order traversal of its nodes' values. 
(ie, from left to right, level by level).

For example:
Given binary tree {3,9,20,#,#,15,7},
    3
   / \
  9  20
    /  \
   15   7
return its level order traversal as:
[
  [3],
  [9,20],
  [15,7]
]

Solution:
The method is the same as Print Binary Tree By Level Order. Here we only implements the one queue solution.
Notice that after iterating a certain level, set the list currentLevel to a new List<int>();


Problem 2:
Given a binary tree, return the bottom-up level order traversal of its nodes' values. 
(ie, from left to right, level by level from leaf to root).

For example:
Given binary tree {3,9,20,#,#,15,7},
    3
   / \
  9  20
    /  \
   15   7
return its bottom-up level order traversal as:
[
  [15,7],
  [9,20],
  [3]
]


Solution:
This problem is very similiar to problem1. The only difference is the order of level order
traversal. In problem1 the order is top-down, in this problem the order is bottom-up.
The method is almost the same, only difference is that we will add the list of each level to
the head of the result List. 

In C#, we can just use List.Insert(index i, object e) to do this.
i is the insertion index to insert e.
Each time after iterating a specific level, we add the currentLevel list by res.insert(0,currentLevel)

In Java, it's even simpler, the add method of ArrayList can take two arguments to insert an object
to a specific index. So we can easily use ArrayList.add(0, objec e) to insert e to the head of ArrayList.
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
 
//Solution for Problem1: Top-down level order traversal
public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root) {
        IList<IList<int>> res = new List<IList<int>>();
        if(root==null) return res;
        Queue<TreeNode> q = new Queue<TreeNode>();
        int currentNodes=1, nextNodes=0;
        IList<int> currentLevel = new List<int>();
        q.Enqueue(root);
        while(q.Count!=0){
            TreeNode curr = q.Dequeue();
            currentNodes--;
            currentLevel.Add(curr.val);
            if(curr.left!=null){
                q.Enqueue(curr.left);
                nextNodes++;
            }
            if(curr.right!=null){
                q.Enqueue(curr.right);
                nextNodes++;
            }
            if(currentNodes==0){
                currentNodes=nextNodes;
                nextNodes=0;
                res.Add(currentLevel);
                currentLevel = new List<int>();
            }
        }
        return res;
    }
}


//Solution for Problem2: Bottome-up level order traversal
public class Solution {
    public IList<IList<int>> LevelOrderBottom(TreeNode root) {
        IList<IList<int>> res = new List<IList<int>>();
        if(root==null) return res;
        Queue<TreeNode> q = new Queue<TreeNode>();
        int currentNodes=1, nextNodes=0;
        IList<int> currentLevel = new List<int>();
        q.Enqueue(root);
        while(q.Count!=0){
            TreeNode curr = q.Dequeue();
            currentNodes--;
            currentLevel.Add(curr.val);
            if(curr.left!=null){
                q.Enqueue(curr.left);
                nextNodes++;
            }
            if(curr.right!=null){
                q.Enqueue(curr.right);
                nextNodes++;
            }
            if(currentNodes==0){
                currentNodes=nextNodes;
                nextNodes=0;
                res.Insert(0, currentLevel);
                currentLevel = new List<int>();
            }
        }
        return res;
    }
}
