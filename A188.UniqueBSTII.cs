/**
Given n, generate all structurally unique BST's (binary search trees) that store values 1...n.

For example,
Given n = 3, your program should return all 5 unique BST's shown below.

   1         3     3      2      1
    \       /     /      / \      \
     3     2     1      1   3      2
    /     /       \                 \
   2     1         2                 3
   

Idea:
This time we will get all possible trees instead of the number of possible trees. 
Given number n, we will have n nodes. And each node could be the root, so we select each node as
the root, then the other n-1 nodes will be divided into two parts: nodes for left subtree and 
nodes for right subtrees. Then we call recursive method to get all possible left/right subtrees using
left/right nodes and append each pair of left and right subtrees to the current root.

Suppose the number of possible left and right subtrees are m and n, then the total number of combination
is m*n. So for the current root, there are totally m*n possible trees.

Note for this problem, we will call recursive method in the loop to get all possible left and right subtrees
for a current root. This trick is very important and useful and can be applied to many similiar problems.


Solution: Recursive
The recursive method GetAllTrees(int start, int end) will return a List containing all possible trees from
the range (start,end). For example, if start=3, end=5, then the method will return all possible tress we can
construct using nodes 3,4, and 5. 

Detailed steps in the method:
1, create a List to store all possible tress in the range (start,end).
2, Base case#1: if start>end, that means no node is available to build trees, so we add null to List and return.
3, Base case#2: if start==end, means only one node is available, so we add new TreeNode(start) to list and return.
4, Use a loop traversing each node between (start,end) and select it as current root.
5, Suppose i is current root, call recursive method on (start, i-1) to get all possible left trees.
   And call recursive method on (i+1,end) to get all possible right trees.
6, Use two nested loops to pair each left tree and each right tree. And append all combination of left and right
   subtrees to the root. (In each pass, create a new TreeNode root using number i).
7, Return List as result.

Then in the primary public method, just call GetAllTrees(1,n) to get all possible trees using number 1 to number n.

Time Complexity: O(n^3) (because of the three level nested loops)
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
public class Solution {
    public IList<TreeNode> GenerateTrees(int n) {
        return GetAllTrees(1,n);
    }
    
    //get all possible trees from the range (start,end) 
    private IList<TreeNode> GetAllTrees(int start, int end){
        IList<TreeNode> trees = new List<TreeNode>();
        //base case: if no node available, cannot build any tree, so add null
        if(start>end){ 
            trees.Add(null);
            return trees;
        }
        //base case: if only one node available, can only build one tree with this node
        if(start==end){
            trees.Add(new TreeNode(start));
            return trees;
        }
        //Use each node from start to end as root
        for(int i=start;i<=end;i++){
            IList<TreeNode> leftTrees = GetAllTrees(start, i-1); //all possible left trees
            IList<TreeNode> rightTrees = GetAllTrees(i+1, end); //all possible right trees
            for(int j=0;j<leftTrees.Count;j++){
                for(int k=0;k<rightTrees.Count;k++){
                    TreeNode root = new TreeNode(i); //current root
                    root.left = leftTrees[j]; //append left and right subtree to root
                    root.right = rightTrees[k];
                    trees.Add(root);
                }
            }
        }
        return trees;
    }
}
