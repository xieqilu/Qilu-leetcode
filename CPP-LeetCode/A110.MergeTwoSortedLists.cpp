/**
 * Merge two sorted linked lists and return it as a new list. 
 * The new list should be made by splicing together the nodes of the first two lists.
 * 
 * Solution:
 * The solution is very similiar as merge two sorted array. 
 * We also use two pointers to simultaneously iterate two Lists.
 * 
 * First we need to handle edge case, if one input list is null,
 * we return the other list. If both are null, return null.
 * 
 * Then set a node newHead to the smaller head node of the two lists.
 * And when iterating the two linked lists, each time we append the smaller
 * node to the current newHead. And update newHead and the appened node.
 * 
 * After the above loop, we will append all remaining nodes of a list to 
 * the new list (use two while loop because we do not know which input list
 * has remaining nodes).
 * 
 * */
 
 //Driver Code: two lines form a single input containing two LinkedList head nodes
 int main() {
    ofstream fout("user.out");
    string line;
    while (getline(cin, line)) {
        
        ListNode* param_1 = __Deserializer__::toListNode(line);
        getline(cin, line);
        ListNode* param_2 = __Deserializer__::toListNode(line);
        
        fout << __Serializer__::serialize(Solution().mergeTwoLists(
            param_1, param_2
        )) << endl;
    }
    return 0;
}

//Print Input Code:
string join(vector<string>& elements, char* separator) {
    switch (elements.size()) {
        case 0:
            return "";
        case 1:
            return elements[0];
        default:
            ostringstream os; 
            copy(elements.begin(), elements.end()-1, ostream_iterator<string>(os, separator));
            os << *elements.rbegin();
            return os.str();
    }
}

int main() {
    vector<string> strs(2, "");
    while (true) {
        if (!getline(cin, strs[0])) break;
        getline(cin, strs[1]);
        
        cout << join(strs, ", ") << endl;
    }

  return 0;
}
 
 /**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode(int x) : val(x), next(NULL) {}
 * };
 */
 
//Solution
class Solution {
public:
    ListNode *mergeTwoLists(ListNode *l1, ListNode *l2) {
        ListNode *l3 = NULL;
        ListNode **p = &l3;
        while (l1 && l2) {
            if (l1->val < l2->val) {
                *p = l1;
                l1 = l1->next;
            } else {
                *p = l2;
                l2 = l2->next;
            }
            p = &((*p)->next);
        }
        while (l1) {
            *p = l1;
            p = &((*p)->next);
            l1 = l1->next;
        }
        while (l2) {
            *p = l2;
            p = &((*p)->next);
            l2 = l2->next;
        }
        return l3;
    }
};
