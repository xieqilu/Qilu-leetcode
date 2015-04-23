//What does the following program print?

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
