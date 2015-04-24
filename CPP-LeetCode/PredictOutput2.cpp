//What does the following program print?

/**
Key point: Pass by value and Pass by reference
In the foo function: A is passed by value, thus the change to A cannot be seen outside of foo
In the bar function: A is passed by reference, thus the change to A can be seen outside of foo

Reference:
Pass By Reference

In this version of the example, the Twice function looks like this:
  void Twice(int& a, int& b)
  {
    a *= 2;
    b *= 2;
  }
Note that when it is run, the variables passed into Twice from the main() function DO get changed by the function
The parameters a and b are still local to the function, but they are reference variables 
(i.e. nicknames to the original variables passed in (x and y))

When reference variables are used as formal parameters, this is known as Pass By Reference
  void Func2(int& x, double& y)
  {
    x = 12;		// these WILL affect the original arguments
    y = 20.5;
  }
When a function expects strict reference types in the parameter list, an L-value 
(i.e. a variable, or storage location) must be passed in
  int num;
  double avg;
  Func2(num, avg);		// legal
  Func2(4, 10.6);		// NOT legal
  Func2(num + 6, avg - 10.6);	// NOT legal
Note: This also works the same for return types. A return by value means a copy will be made. 
A reference return type sends back a reference to the original.
  int Task1(int x, double y);	// uses return by value
  int& Task2(int x, double y);  // uses return by reference
*/

#include <iostream>

using namespace std;

class A {
  public:
    A() : val_(0) {}
    ~A() {}
    A(const A& c) {
        if(&c != this) {
            cout<<"Copying\n";
            this->val_ = c.val_;
        }
    }
    void SetVal(int v ) { this->val_ = v;}
    int GetVal() { return (this->val_);}
   private:
    int val_;
};


static void foo(A a) {
    printf("foo called\n");
    a.SetVal(18);
}

static void bar(A& a) {
    printf("bar called\n");
    a.SetVal(22);
}

int main(int, char**) {
    A a;
    a.SetVal(99);
    printf("Val starts as %d\n", a.GetVal());
    foo(a);
    printf("After foo, Val is %d\n", a.GetVal());
    bar(a);
    printf("After bar, Val is %d\n", a.GetVal());
    
    return (0);
}

/**
Output:
Val starts as 99
Copying
foo called
After foo, Val is 99
bar called
After bar, Val is 22
*/
