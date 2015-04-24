//What does the following program print?

#include<stdio.h>

int main(int, char**){
	int a=2;
	int b=4;
	
	printf("|: %d\n", a | b);
	printf("||: %d\n", a || b);
	return (0);
}

/**
Output:
|: 6
||: 1

Explain:
"|" is a BitWise OR operator, it get the BitWise OR result of a and b. a is 010, b is 100, so a|b is 110, which is 6
"||" is a Logical OR operator, it get the Logical OR result of a and b. Since a and b both are greater than 0 (true), so the result
is true, which is 1. (note onlyh 0 is false, all other numbers are true).
*/
