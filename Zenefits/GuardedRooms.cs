/**
求每个元素到guarded room的最短距离
0: closed room
1: open room
2: guarded room. 

例如input
1 2 1
1 0 1
1 2 1
那么output是
1 0 1
2 -1 2
1 0 1

Solution:  Use BFS
Use a private method to do BFS starting from a guarded room. We can still use the one queue, two variables BFS. And use a HashSet to store the visited rooms. Use a variable to store the depth of BFS. 

For each room poped from the queue:
0 If the room has already been visited, or the position is out of range, do nothing.
1, If the room is open, then update the distance for this room, check all connected rooms and push them into the queue.
2, If the room is guarded, then we don’t push its connected rooms into the queue, because the shortest distance should start from this room and we will do BFS start from it later.
3, If the room is closed, then we don’t push its connected rooms into the queue, because we cannot go through this room.

Then we traverse the input matrix and do the above BFS process for every guarded room in the matrix. Every time before doing BFS, we need to clear the HashSet and reset depth to 0 for the next BFS.

Time complexity:
There are totally n^2 nodes, and each node could be visited (n^2) times, so
The running time is O(n^4).

A better Solution: 
The idea is to use a BFS traversal, that starts from a new node connected to all guarded rooms, and scans the rooms in increasing distance order from v0. Each time a node is visited, the number of steps that have been made for reaching it represents the distance from a guarded room, and it is guaranteed to be minimal due to the path expansion order.

This is a brilliant Solutuion!! Instead of doing separate BFS from all guarded rooms, we can create a new node and set it connected to all guarded rooms. Then
We can start from this new node and do just one single BFS. It’s like do BFS from 
All guarded rooms at the same time! And because we traverse all nodes level by level, once we visited an open room, the depth is guaranteed to be minimal due to the path expansion order.

Time complexity: O(n^2), because each node will only be visited once, there are totally n^2 nodes.
*/
