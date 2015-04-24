/**
What is the purpose of the following function?
The function is supposed to check if a char exist in a given string.

Does it work?
No, it doesn't work. 
1, the bool variable found is not initialized which will cause undefined behaviour.
2, The condition of while loop should not check s
3, If we find a ch in s, we don't need to compare any more, we can just break the while loop.

How can it be improved?
1, Initialize found to false (bool found = false)
2, change the condition of while loop to while(*s)
3, If we find a ch in s, after changing found to true, break the loop
*/
//original wrong code
bool findch(const char* s, char ch){
    bool found;
    while(s){
        if(*s==ch){
          found=true;
        }
        ++s;
    }
    return (found);
}

//modified c++ version for this problem, the answer
#include<stdio.h>
#include<iostream>
#include<string.h>

using namespace std;

//check if char ch exist in string s
bool findch(const char* s, char ch){
    bool found=false; //must initialize bool, otherwise undefined behaviour
    while(*s){ //use *s instead of s, because s is only an address
        if(*s==ch){
          found=true;
          break; //if we find ch in s, break
        }
        ++s;
    }
    return (found);
}

int main(int, char**){
	const char* s = "this is my test string";
	char ch = 'c';
	cout<< findch(s, ch)<<endl; 
}


//A C version that can run correctly
#include<stdio.h>
#include<iostream>
#include<string.h>

using namespace std;

//check if char ch exist in string s
bool findch(char* s, const char* ch){
	bool found = 0; //must initialize found to 0, or undefined behaviour!
	char* c = s;
	while(*c){
		if(strchr(ch, *c)){
			found=1;
		}
		++c;
	}
	return found;
}

int main(int, char**){
	char* s = "this is my test string";
	const char* ch = "a";
	cout<< findch(s, ch)<<endl; 
}



/**
Some references:

const int* foo
foo is a variable pointer to a constant int. 
This lets you change what you point to but not the value that you point to. 
Most often this is seen with cstrings where you have a pointer to a const char. 
You may change which string you point to but you can't change the content of these strings. 
This is important when the string itself is in the data segment of a program and 
shouldn't be changed.

* is also a dereference operator
*p means get the value that pointer p pointed to. 
bar = *p, means assign bar the value that p points to.

It is also possible to declare a pointer to a constant variable by using the const 
before the data type.

int nValue = 5;
const int *pnPtr = &nValue;

Note that the pointer to a constant variable does not actually have to point to 
a constant variable! Instead, think of it this way: 
a pointer to a constant variable treats the variable as constant 
when it is accessed through the pointer.

Thus, the following is okay:

nValue = 6; // nValue is non-const

But the following is not:

*pnPtr = 6; // pnPtr treats its value as const
* 
Because a pointer to a const value is a non-const pointer, 
the pointer can be redirected to point at other values:

int nValue = 5;
int nValue2 = 6;
const int *pnPtr = &nValue;
pnPtr = &nValue2; // okay


#include<stdio.h>
#include<iostream>
#include<string.h>

using namespace std;

//check if char ch exist in string s
bool findch(char* s, const char* ch){
	bool found = 0; //must initialize found to 0, or undefined behaviour!
	char* c = s;
	while(*c){
		if(strchr(ch, *c)){
			found=1;
		}
		c++;
	}
	return found;
}

int main(int, char**){
	char* s = "this is my test string";
	const char* ch = "a";
	cout<< findch(s, ch)<<endl; 
}
*/
