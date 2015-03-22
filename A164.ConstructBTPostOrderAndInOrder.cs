/**
Given inorder and postorder traversal of a tree, construct the binary tree.

Note:
You may assume that duplicates do not exist in the tree.


Idea:
The idea is pretty the same with building BT using Pre-Order and In-Order array.
Post-Order: left->right->root
In-Order: left->root->right
Basically we can use postorder array to find the root element of the tree (last element). Then
we can find the index of current root in inorder array. Using the index, we can divide both postorder
and inorder array into two parts, one for the left subtree of current root and the other for the right
subtree of current root. Then we can call the recurisve method to get root.left and root.right.


Solution1:
The solution is almost the same with building BT using Pre-Order and In-Order array. The only difference
are:
1, In postorder array, the last element is the current root. So we will use postorder[poR] to get the 
current array. 

2, In postorder array, the first numLeft elements are for the left subtree, all the rest elements except for
the root element are for the right subtree.
root.left: poL = poL, poR=poL+numLeft-1, inL=inL, inR=index-1
root.right: poL= poL+numLeft, poR=poR-1, inL=index+1, inR=inR

Time: O(n)  Space: O(n)


Solution2:
We can also avoid some unnessary arguments to make the recursive call simpler. The arguments we need are:
1, postrder array: to find the current root
2, poL: use poL and poR to check the base case
3, poR: to find the current root
4, inL: get the number of elements that will be used for left subtree of current root
5, map: get index of current root
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


//Solution1: Recursive and HashMap   Time:O(n)  Space:O(n)
public class Solution {
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        Dictionary<int,int> map = new Dictionary<int,int>();
        for(int i=0;i<inorder.Length;i++){
            map.Add(inorder[i],i);
        }
        return BuildTreeHelper(postorder, inorder, 0, postorder.Length-1, 0, inorder.Length-1,map);
    }
    
    private TreeNode BuildTreeHelper(int[] postorder, int[] inorder, int poL, int poR, int inL, int inR, 
                                Dictionary<int,int> map)
    {
        if(poL>poR) return null;
        TreeNode root = new TreeNode(postorder[poR]);
        int index = map[postorder[poR]];
        int numLeft = index-inL;
        root.left = BuildTreeHelper(postorder,inorder,poL,poL+numLeft-1, inL, index-1, map);
        root.right = BuildTreeHelper(postorder,inorder,poL+numLeft, poR-1, index+1, inR, map);
        return root;
    }
}


//Solution2: better and simpler recursive, avoid unnessary arguments  Time: O(n)  Space: O(n)
public class Solution {
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        Dictionary<int,int> map = new Dictionary<int,int>();
        for(int i=0;i<inorder.Length;i++){
            map.Add(inorder[i],i);
        }
        return BuildTreeHelper(postorder, 0, postorder.Length-1, 0,map);
    }
    
    private TreeNode BuildTreeHelper(int[] postorder, int poL, int poR, int inL, 
                                Dictionary<int,int> map)
    {
        if(poL>poR) return null;
        TreeNode root = new TreeNode(postorder[poR]);
        int index = map[postorder[poR]];
        int numLeft = index-inL;
        root.left = BuildTreeHelper(postorder,poL,poL+numLeft-1, inL, map);
        root.right = BuildTreeHelper(postorder,poL+numLeft, poR-1, index+1, map);
        return root;
    }
}
