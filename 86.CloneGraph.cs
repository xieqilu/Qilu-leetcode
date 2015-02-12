/**
 * Clone an undirected graph. Each node in the graph contains a label and a list of its neighbors.
 * 
 * Definition for undirected graph.
 * class UndirectedGraphNode {
 *     int label;
 *     List<UndirectedGraphNode> neighbors;
 *     UndirectedGraphNode(int x) { label = x; neighbors = new ArrayList<UndirectedGraphNode>(); }
 * };
 * 
 * Solution:
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
 */

using System;
using System.Collections.Generic;

namespace CloneGraph
{
	public class UndirectedGraphNode {
		public int label{ get; set;}
		public List<UndirectedGraphNode> neighbors{ get; set;}
		public UndirectedGraphNode(int x) { 
			label = x;
			neighbors = new List<UndirectedGraphNode>(); 
		}
	}

	public class Finder{
		public static UndirectedGraphNode cloneGraph(UndirectedGraphNode node){
			if (node == null)
				return null;
			Dictionary<UndirectedGraphNode, UndirectedGraphNode> dic = new Dictionary<UndirectedGraphNode, UndirectedGraphNode> ();
			Queue<UndirectedGraphNode> q = new Queue<UndirectedGraphNode> ();
			UndirectedGraphNode newNode = new UndirectedGraphNode (node.label);
			q.Enqueue (node);
			dic.Add (node, newNode);
			while (q.Count != 0) {
				UndirectedGraphNode currNode = q.Dequeue ();
				List<UndirectedGraphNode> neighbors = currNode.neighbors;
				foreach (UndirectedGraphNode neighbor in neighbors) {
					if (!dic.ContainsKey (neighbor)) {
						q.Enqueue (neighbor);
						UndirectedGraphNode copyNeighbor = new UndirectedGraphNode (neighbor.label);
						dic [currNode].neighbors.Add (copyNeighbor);
						dic.Add (neighbor, copyNeighbor);
					} else
						dic [currNode].neighbors.Add (dic [neighbor]);
				}
			}
			return newNode;
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
