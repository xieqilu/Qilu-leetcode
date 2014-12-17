public class Finder
{
static int MAX;
public static int getAmpTree(TreeNode root)
{
  if(root == null) 
    return 0;
  FindDfs(root, root.x, root.x);
  return MAX;
}

public static void FindDfs(TreeNode root, int min, int max){
  if(root = null)
    return;
  min = Math.min(min, root.x);
  max = Math.max(max, root.x);
  if(root.l == null && root.r == null)
    Max = Math.max(Max, max-min);
  FindDfs(root.l, min, max);
  FindDfs(root.r, min, max);
}
}
