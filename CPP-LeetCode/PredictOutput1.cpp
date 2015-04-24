//What does the following program print?

//Key point:
//When the subclass is created and deleted, the constructors and destructors of itself and its parent class 
//will be called.

#include <iostream>

using namespace std;

class A {
  public:
	A() {cout<<"Constructor A\n";}
    virtual ~A() {cout << "Destructor A\n";}
    virtual const char* Classname() const{return "A";}
};


class B : public A {
public:
    B() {cout<<"Constructor B\n";}
    virtual ~B() {cout << "Destructor B\n";}
    virtual const char* Classname() const{return "B";}
};


void foo(A *a) {
    printf("foo has been passed an object of class %s\n", a->Classname());
    delete a;
}

int main(int, char**) {
    A *a = new A; 
    B *b = new B; //calls both A and B constructor
    foo(a);
    foo(b); //calls both A and B destructor
    
    return (0);
}

/**
Output:
Constructor A
Constructor A
Constructor B
foo has been passed an object of class A
Destructor A
foo has been passed an object of class B
Destructor B
Destructor A
*/
