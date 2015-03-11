/**
 * Design and implement a TwoSum class. It should support the following operations: 
 * add and find.

add - Add the number to an internal data structure.
find - Find if there exists any pair of numbers which sum is equal to the value.

For example,
add(1); add(3); add(5);
find(4) -> true
find(7) -> false


Solution:
use a HashMap, key is the number and value is the number of this elements(count) 
in the Data Structure.
add: if element is already in the map, increment the count. Otherwiese, add
(element,1) to the map.
find: for each element in map, check if value-element exist in the map. If not,
then return false. If exists, then if and only if value-element==element and 
the count of element is 1, return false. Otherwise, return true.
*/

//My Solution: Same as Leetcode official Solution
public class TwoSum {
    private Dictionary<int,int> dict = new Dictionary<int,int>();
	public void Add(int number) {
	    if(dict.ContainsKey(number))
	        dict[number]++;
	    else 
	        dict.Add(number, 1);
	}

	public bool Find(int value) {
	    foreach(KeyValuePair<int,int> kp in dict){
	        int i = kp.Key;
	        if(dict.ContainsKey(value-i)){
	            if(i==value-i&&dict[i]==1)
	                return false;
	            return true;
	        }
	    }
	    return false;
	}
}
