/**
Given a binary tree, find its maximum depth.
The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
*/

/**
 * Definition for binary tree
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */
 /**
  * Solution1:
  * This is an classic recursive question,
  * maxDepth(root) = Math.max(maxDepth(root.left)+1, 
  *                         maxDepth(root.right)+1)
  * Base case: when root==null, return 0;
  * 
  * Solution2:
  * We can also use Iterative BFS to solve this problem.
  * The max Depth of a BT is actually the number of level the BT has.
  * So use a queue to do classic iterative BFS, when finish a level
  * we increment the int level. After the BFS, return level
  * */
  
  public class Solution1 { //recursive DFS
    public int MaxDepth(TreeNode root) {
        if(root==null) return 0;
        return Math.Max(MaxDepth(root.left)+1, MaxDepth(root.right)+1);
    }
}

public class Solution2 {
    //Iterative BFS
    private void Swap<T>(ref T a, ref T b){ //Generic Swap method
        T temp = a;
        a = b;
        b = temp;
    }
    public int MaxDepth(TreeNode root) {
        if(root==null) return 0;
        Queue<TreeNode> currentLevel = new Queue<TreeNode>();
        Queue<TreeNode> nextLevel = new Queue<TreeNode>();
        int maxLevel = 0;
        currentLevel.Enqueue(root);
        while(currentLevel.Count!=0){
            TreeNode curr = currentLevel.Dequeue();
            if(curr.left!=null) nextLevel.Enqueue(curr.left);
            if(curr.right!=null) nextLevel.Enqueue(curr.right);
            if(currentLevel.Count==0){
                Swap(ref currentLevel, ref nextLevel);
                maxLevel++;
            }
        }
        return maxLevel;
    }
}
