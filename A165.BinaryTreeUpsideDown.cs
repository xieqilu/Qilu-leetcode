/**
Given a binary tree where all the right nodes are either leaf nodes with a sibling 
(a left node that shares the same parent node) or empty, 
flip it upside down and turn it into a tree where the original right nodes turned into left leaf nodes.
Return the new root.

For example:
Given a binary tree {1,2,3,4,5},
    1
   / \
  2   3
 / \
4   5
return the root of the binary tree [4,5,2,#,#,3,1].
   4
  / \
 5   2
    / \
   3   1  



Idea: 
Observe the example then we can find the rules for this problem is pretty simple.
In the original tree, for each current node, we need to do the following:
current.left = parent.right (parent is the parent node of current node)
current.right = parent
We can solve this problem iterativly without using any extra space.


Solution:
The key point is we need to know what information are required for each iterative pass:
1, curr: current node for this pass
2, parent: the parent node of curr
3, parentRight: the original right child of parent (parent.right has been modified in the last pass)

Then for each pass, we need to modify curr.left and curr.right and also update all required information
for the next pass. The steps are:
1, store original left child of curr before modifing curr.left (TreeNode left=curr.left)
2, set curr.left to parentRight
3, update parentRight to curr.right for the next pass (curr will become parent for the next pass)
4, set curr.right to parent
5, update parent to curr
6, update curr to left

Special Note:
The sequence of above operations is very important:
1, we must store curr.left before modifing it so that we can update curr correctly later
2, we must update parentRight to curr.right before modifing curr.right so that parentRight 
would be correct for the next pass.

Also the condition of while loop is curr!=null, after the loop, curr is null and we must return parent.
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

//Solution: Iterative  
public class Solution {
    public TreeNode UpsideDownBinaryTree(TreeNode root) {
        if(root==null) return null;
        TreeNode curr = root, parent=null, parentRight=null; //initial values
        while(curr!=null){
            TreeNode left = curr.left; //store curr.left before modifiing it
            curr.left = parentRight;
            parentRight = curr.right; //store curr.right before modifing it
            curr.right = parent;
            parent = curr; //update parent to curr
            curr=left; //update curr to left
        }
        return parent;
    }
}
