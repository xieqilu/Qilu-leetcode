/**
Given numRows, generate the first numRows of Pascal's triangle.

For example, given numRows = 5,
Return

[
     [1],
    [1,1],
   [1,2,1],
  [1,3,3,1],
 [1,4,6,4,1]
]



Solution:
A very simple Problem, pretty straightforward, just do it.
This problem can be natrually sovled using iterative method, so using recursive method is not
a very good option. And iterative method has less and cleaner code.

Edge case: when numRows<=0, we need to return an empty IList<List<int>>.
And when numRows is 1, create a new List with only one element 1 and add it to res and return res.

When numRows>1, just construct level i List according to level i-1 List, the logic is pretty simple.
First add 1 to level i List, then add the sum of every two concecutive elements of level i-1 List to
level i List, and then add 1 to level i List, and that's all.

Time complexity: O(n^2) for both recursive and iterative method.
*/


//Recursive Solution
public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> res = new List<IList<int>>();
        if(numRows<=0) return res; //edge case: return empty IList<IList<int>>
        GenerateHelper(numRows, res);
        return res;
    }
    
    private void GenerateHelper(int numRows,IList<IList<int>> res){
        IList<int> currList = new List<int>(){1};
        if(numRows==1){
            res.Add(currList);
            return;
        }
        GenerateHelper(numRows-1, res);
        var lastList = res[res.Count-1];
        for(int i=0;i<lastList.Count-1;i++){
            currList.Add(lastList[i]+lastList[i+1]);
        }
        currList.Add(1);
        res.Add(currList);
        return;
    }
}

//Iterative Solution
public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> res = new List<IList<int>>();
        if(numRows<=0) return res;
        IList<int> first = new List<int>(){1};
        res.Add(first);
        for(int i=1;i<numRows;i++){
            var lastList = res[res.Count-1];
            IList<int> currList = new List<int>(){1};
            for(int j=0;j<lastList.Count-1;j++){
                currList.Add(lastList[j]+lastList[j+1]);
            }
            currList.Add(1);
            res.Add(currList);
        }
        return res;
    }
}
