//traverse a binary tree so that the order returned
//is ordered from smallest to greatest
//use a priority_queue and a stack!

#include <iostream>
#include <queue>
#include <stack>

using namespace std;

struct TreeNode
{
	int value;
	TreeNode *left;
	TreeNode *right;
};

class Finder
{
	std::priority_queue<int> Q;
	std::stack<int> S;
public:
	void ascendingTraverse(TreeNode *root);
	void printNodes();

};

void Finder::ascendingTraverse(TreeNode *root)
{
	if(root == NULL) return;
	Q.push(root->value);
	ascendingTraverse(root->left);
	ascendingTraverse(root->right);

}

void Finder::printNodes()
{
	while(!Q.empty()) 
	{
		int temp = Q.top();
		S.push(temp);
		Q.pop();
	}

	while(!S.empty())
	{
		std::cout<<S.top()<<"\n";
		S.pop();
	}
}
int main (int argc, char *argv[])
{
	TreeNode node1;
	TreeNode node2;
	TreeNode node3;
	TreeNode node4;
	TreeNode node5;
	TreeNode node6;

	node1.value=4;
	node2.value=3;
	node3.value=2;
	node4.value=5;
	node5.value=6;
	node6.value=8;

	node1.left = &node2;
	node1.right = &node3;
	node2.left = &node4;
	node2.right = &node5;
	node3.left = &node6;
	node3.right = NULL;
	node4.left = NULL;
	node4.right = NULL;
	node5.left = NULL;
	node5.right = NULL;
	node6.right = NULL;
	node6.left = NULL;

	Finder finder;
	finder.ascendingTraverse(&node1);
	finder.printNodes();
	
	return 0;
}

