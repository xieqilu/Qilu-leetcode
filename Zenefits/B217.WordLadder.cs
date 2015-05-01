/**
Given two words (beginWord and endWord), and a dictionary, find the length of shortest transformation sequence from beginWord to endWord, such that:

Only one letter can be changed at a time
Each intermediate word must exist in the dictionary
For example,

Given:
start = "hit"
end = "cog"
dict = ["hot","dot","dog","lot","log"]
As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
return its length 5.

Note:
Return 0 if there is no such transformation sequence.
All words have the same length.
All words contain only lowercase alphabetic characters.


Idea:
This is a very classic graph or tree problem. Don't think it as a string question, it's actually a tree question.
Think of the beginWord as a root, and the length of it is n, then each char in beginWord can be changed to other 25 chars.
So there are totally 25*n possible children for this root. Then each children will also have 25*n children. Then it's just
like a tree in which each root can have 25*n children. So our task is to perform a BFS on this tree level by level and once 
we hit the endWord at a level, return the current depth. Job Done!


Solution: Modified BFS
Assume the length of beginWord and endWord is len, we use q to store word, and a Hashset visited to store the words
in wordDict that have already been visited. Some key points to note:
1, initially depth is 2, because if only one change needed, there are at least two words in the sequence.
2, We will use one queue and two variables, current and next, to perform the classic level order traverse.
3, In the while loop, get current word from the queue and current--. Then for each char in currWord, try to change it
to all 26 chars. Note we must use a StringBuilder to get currWord in each pass of the for loop. Because at the start of
each pass the word should be original. 
4, If the changed word is equal to currWord, continue. If it's equal to endWord, we find the shortest path and return depth.
If the changed word is in wordDict and is not in visited set, we add it to visited set, push it to queue and increment next.
5, After the for loop, check if the count of visited set is equal to wordDict, if it is, means all words in wordDict have
already been used, it's not possible to find a path, so break the outter while loop.
6, if current is 0, update current to next, set next to 0 and increment depth.

Time complexity: O(25^n), n is the length of beginWord and endWord.
If the wordDict is very huge, the worst case is O(25^n).

Space: O(m), m is the length of wordDict.
We will at most store all words in wordDict to queue and visited set.


Note: Because we use a BFS, the first time we hit endWord, the depth must be the shortes.
*/

//Solution: Modified BFS 
public class Solution {
    public int LadderLength(string beginWord, string endWord, ISet<string> wordDict) {
        if(beginWord==endWord) //if don't need change, the sequence only has one word
            return 1;
        int len = beginWord.Length;
        Queue<string> q = new Queue<string>();
        HashSet<string> visited = new HashSet<string>();
        int current = 1, next=0;
        q.Enqueue(beginWord);
        int depth = 2; //if only one need one change, the sequence has two word
        while(current!=0){
            string currWord = q.Dequeue();
            current--;
            for(int i=0;i<len;i++){ //try to change each char of currWord
                StringBuilder sb = new StringBuilder(currWord);
                for(char c='a';c<='z';c++){ //use all possible letters to try change current char
                    sb[i] = c;
                    string temp = sb.ToString();
                    if(temp==currWord)
                        continue;
                    if(temp==endWord) //if find endWord, directly return depth
                        return depth;
                    //if temp is in wordDict and has not been visited before
                    if(wordDict.Contains(temp) && !visited.Contains(temp)){
                        visited.Add(temp);
                        q.Enqueue(temp);
                        next++;
                    }
                }
            }
            //if all words in wordDict have been visited, then no need to continue searching
            if(visited.Count==wordDict.Count) break; 
            if(current==0){  //need to go to next level
                current = next;
                next = 0;
                depth++;
            }
        }
        return 0;
    }
}
