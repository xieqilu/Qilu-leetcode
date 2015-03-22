/**
Given preorder and inorder traversal of a tree, construct the binary tree.

Note:
You may assume that duplicates do not exist in the tree.


Idea: 
This is not an easy problem which requires some careful thinking.
Pre-Order: root->left->right
In-Order: left->root->right
Basically we can use Pre-Order array to find the root of the tree (first element), then we 
can find the index of this element in In-Order array. Using the index, we can divide both
Pre-Order array and In-Order array into two parts, one for the left subtree and the other
for right subtree. Then we can call the recursive method to get root.left and root.right.

Below is a good example of this problem:

Inorder sequence: D B E A F C
Preorder sequence: A B D E C F

In a Preorder sequence, leftmost element is the root of the tree. So we know ‘A’ is root for given sequences. By searching ‘A’ in Inorder sequence, we can find out all elements on left side of ‘A’ are in left subtree and elements on right are in right subtree. So we know below structure now.

                 A
               /   \
             /       \
           D B E     F C
We recursively follow above steps and get the following tree.

         A
       /   \
     /       \
    B         C
   / \        /
 /     \    /
D       E  F



Solution1: Recursive and HashMap  
From the above idea, we know that for each node, we need to search the element in the In-Order array. The searching 
would take O(n) time thus the overall running time would be O(n^2). To reduce the running time, we can first build
a HashMap that map the element of In-Order array to its index. Then the searching time will be O(1) and the overall
running time would be O(n).

Then after building the map. we can do the recursive call. The arguments we need for the recursive call are：
Two arrays: int[] preorder, int[] inorder
left and right index that set the range of elements in two arrays: int preL, preR, inL, inR
And the map: HashMap<Integer, Integer> map

Base case: when preL>preR, there is no more element to create node, return null.

So in each recursive call, the steps are:
1, Check base case.
2, create current root with preorder[preL] (root mus be the first element in current preorder range)
3, get the index of current root in inorder (index=map.get(preorder[preL]))
4, get number of elements that will be used to build left subtree of current root. (numLeft = index-inL)
5, Recursive get root.left and root.right.
root.left arguments: preL=preL+1, preR=preL+1+numLeft, inL = inL, inR=index-1
root.right arguments: preL=preL+1+numLeft, preR= preR, inL = index+1, inR=inR

Time: O(n)  Space: O(n)


Solution2: better and simpler recursive, avoid unnessary arguments
In the solution1, we can find that there are some arguments that are useless in the recursive method.
For example, the inorder array is never used because we use the map to find an element's index. So we 
can avoid unnessary arguments to make the recursive call simple. The only arguments we need are:
1, preorder array: to find the current root
2, preL: to ger current root
3, preR: use preL and preR to check the base case
4, inL: get the number of elements that will be used for left subtree of current root
5, map: get index of current root

Time: O(n)  Space: O(n)
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

//Solution1: Recursive and HashMap  Time: O(n)  Space: O(n)
public class Solution {
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        Dictionary<int,int> map = new Dictionary<int,int>();
        for(int i=0;i<inorder.Length;i++){
            map.Add(inorder[i],i);
        }
        return BuildTreeHelper(preorder, inorder, 0, preorder.Length-1, 0, inorder.Length-1,map);
    }
    
    private TreeNode BuildTreeHelper(int[] preorder, int[] inorder, int preL, int preR, int inL, int inR, 
                                      Dicitionary<int,int> map)
    {
        if(preL>preR) return null; //base case
        TreeNode root = new TreeNode(preorder[preL]); //create new TreeNode with current root element
        int index = map[preorder[preL]]; //the index of root.val in inorder array
        int numLeft = index-inL; //number of nodes at the left subtree of current root
        root.left= BuildTreeHelper(preorder, inorder, preL+1, preL+numLeft, inL, index-1, map);
        root.right = BuildTreeHelper(preorder, inorder, preL+1+numLeft, preR, index+1, inR, map);
        return root;
    }
}


//Solution2: better and simpler recursive, avoid unnecessary arguments   Time:O(n)  Space:O(n)
public class Solution {
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        //build map for fast look-up for element's index of inorder array
        Dictionary<int,int> map = new Dictionary<int,int>();
        for(int i=0;i<inorder.Length;i++){
            map.Add(inorder[i],i);
        }
        return BuildTreeHelper(preorder, 0, preorder.Length-1, 0, map);
    }
    
    private TreeNode buildTreeHelper(int[] preorder,int preL, int preR, int inL,Dictionary<int,int> map)
    {
        if(preL>preR) return null;//base case
        TreeNode root = new TreeNode(preorder[preL]); //create current root node
        int index = map[preorder[preL]]; //the index of root.val in inorder array
        int numLeft = index-inL; //number of nodes at the left subtree of current root
        root.left=BuildTreeHelper(preorder, preL+1, preL+numLeft, inL,map);
        root.right = BuildTreeHelper(preorder, preL+1+numLeft, preR, index+1,map);
        return root;
    }
}
