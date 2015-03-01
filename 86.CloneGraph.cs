/**
 * Clone an undirected graph. Each node in the graph contains a label and a list of its neighbors.
 * 
 * 
 * Definition for undirected graph.
 * public class UndirectedGraphNode {
 *     public int label;
 *     public IList<UndirectedGraphNode> neighbors;
 *     public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
 * };
 * 
 * Solution 1: BFS
 * use a queue to do BFS on the graph
 * use a HashMap<Node, Node> to store each Node and its copy
 * Also use the HashMap to check if a Node is already been visited
 * For each new node, create a copy of itself and a list of neighbours
 * 
 * Details:
 * edge case: check if input node is null, if it is, return null
 * 
 * put the head node into queue, then create a copy of it, put
 * head node and its copy to hashmap.
 * 
 * In the while loop, remove a current node from queue, 
 * for each neighbor, check if the neighbor is already in hashmap.
 * If it's not, create a copy of the neighbor, put the neighbor and
 * its copy to hashmap. Then add the copy to the neighbors list of current
 * node. Then add the neighbor itself to the queue.
 * 
 * After the loop, return the copy of the head node.
 * 
 * Solution 2: DFS
 * Use a Recursive DFS approach
 * A HashMap will be used through the entire recursive stack
 * The key of map is the original node and value is the copied node
 * In the recursive call, if the input node is already in the map,
 * we directly return the copy of the input node from the map.
 * If it is not in the map yet. we creat a copy and put the node
 * and its copy to the map. 
 * Then for each of its neighbors, we use the recursive call to get
 * the copy and put the copy into the curent copyNode's list.
 * 
 */

using System;
using System.Collections.Generic;

namespace CloneGraph
{
	public class UndirectedGraphNode {
		public int label{ get; set;}
		public IList<UndirectedGraphNode> neighbors{ get; set;}
		public UndirectedGraphNode(int x) { 
			label = x;
			neighbors = new List<UndirectedGraphNode>(); 
		}
	}

	//BFS Iterative Solution
	public class Solution {
    		public UndirectedGraphNode CloneGraph(UndirectedGraphNode node) {
        		if (node == null)
				return null;
			Dictionary<UndirectedGraphNode, UndirectedGraphNode> dic = new Dictionary<UndirectedGraphNode, UndirectedGraphNode>();			
			Queue<UndirectedGraphNode> q = new Queue<UndirectedGraphNode>();
			UndirectedGraphNode newNode = new UndirectedGraphNode (node.label);
			q.Enqueue(node);
			dic.Add(node, newNode);
			while (q.Count != 0) {
				UndirectedGraphNode currNode = q.Dequeue();
				foreach (UndirectedGraphNode neighbor in currNode.neighbors) {
					if (!dic.ContainsKey (neighbor)) {
						q.Enqueue(neighbor);
						UndirectedGraphNode copyNeighbor = new UndirectedGraphNode (neighbor.label);
						dic[currNode].neighbors.Add(copyNeighbor);
						dic.Add(neighbor, copyNeighbor);
					} else
						dic[currNode].neighbors.Add (dic[neighbor]);
				}
			}
			return newNode;
    }
}
    
 //DFS Recursive Solution
 public class Solution {
    public UndirectedGraphNode CloneGraph(UndirectedGraphNode node) {
        if(node==null) return null;
        Dictionary<UndirectedGraphNode,UndirectedGraphNode> dic = new Dictionary<UndirectedGraphNode,UndirectedGraphNode>();
        return DFS(node,dic);
    }
    
    private UndirectedGraphNode DFS(UndirectedGraphNode node, Dictionary<UndirectedGraphNode,UndirectedGraphNode> dic){
        if(dic.ContainsKey(node))
            return dic[node];
        UndirectedGraphNode copyNode = new UndirectedGraphNode(node.label);
        dic.Add(node,copyNode);
        foreach(UndirectedGraphNode neighbor in node.neighbors){
            copyNode.neighbors.Add(DFS(neighbor,dic));
        }
        return copyNode;
    }
}
}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
		}
	}
}
