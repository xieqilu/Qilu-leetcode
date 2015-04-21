import java.util.*;
/**
 * 
 * @author xieqilu
 * For the graph traversing algorithm
 * Give you a graph and two vertices and return if there exists a path between them
 */
public class Solution {
	
	/**
	 * A node in a graph
	 */
	private static class Node {
		private final Set<Node> neighbors;
		Node()
		{
			this.neighbors = new HashSet<>();
		}
	}
	
	//BFS determine if there exists a path between two nodes in a graph
	public static bool determinePath(Node sourceNode, Node targetNode){ //time: O(V+E)
	  if(sourceNode == null || targetNode == null)
	    return false;
	  Queue<Node> bfsQ = new LinkedList<Node>();
	  HashSet<Node> visited = new HashSet<Node>();
	  bfsQ.add(sourceNode);
	  visited.add(sourceNode);
	  while(!bfsQ.isEmpty()){
	    Node temp = bfsQ.remove();
	    for(Node neighbor: temp.neighbors){
	      if(!visited.contains(neighbor)){
	        if(neighbor == targetNode)
	          return true;
	        visited.add(neighbor);
	      }
	    }
	  }
	  return false;
	}
	
	//BFS determine if there is a cycle in an undirected graph
	//For every visited vertex ‘v’, 
	//if there is an adjacent ‘u’ such that u is already visited and u is not parent of v, 
	//then there is a cycle in graph.
	public static bool determineCycle(Node node){  //time: O(V+E)
	  if(node == null)
	    return false;
	  Queue<Node> bfsQ = new LinkedList<Node>();
	  HashMap<Node, Node> visited = new HashMap<Node, Node>();
	  bfsQ.add(node);
	  visited.add(root,null);
	  while(!bfsQ.isEmpty()){
	    Node temp = bfsQ.remove();
	    for(Node neighbor: temp.neighbors){
	      if(!visited.contains(neighbor)){
	        visited.add(neighbor, temp);
	      }
	      else{
	        Node parent = visited.get(temp);//chech if the visited neighbor is the parent of temp
	        if(neighbor!=temp)
	          return true;
	      }
	    }
	  }
	  return false;
	}
	
	//BFS find degree of node in a graph
	private static Map<Integer, Integer> calculateDegreeCount(Node node) {
	      // YOUR CODE HERE
	        Queue<Node> bfsQ=new LinkedList<Node>();
	        HashSet<Node> visited=new HashSet<Node>();
	        HashMap<Integer,Integer> res=new HashMap<Integer,Integer>();
	        bfsQ.add(node);
	        visited.add(node);
	        while (!bfsQ.isEmpty()){
	            Node temp=bfsQ.remove();
	            int count=0;
	            for(Node neighbor:temp.neighbors){
	                count+=1;
	                if(!visited.contains(neighbor)){
	                    visited.add(neighbor);
	                    bfsQ.add(neighbor);
	                }
	            }
	            if (res.containsKey(count)){
	                int prevCount=res.get(count);
	                res.put(count,prevCount+1);
	            }else{
	                res.put(count,1);
	            }
	        }
	        return res;
	    }

}
