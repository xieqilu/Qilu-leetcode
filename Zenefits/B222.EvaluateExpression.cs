/**
// An "expression" is either a number, or a list (AKA vector/array) with the first element one of '+',' -', '*', '/' , and then other expressions. 
//Write a function "evaluate" that gets an expression and returns its value.
// ['+', 1, 2] --> 3
// ['*', 3, ['+', 1, 10]] --> 33
// ['+', 1, 2, 3, 4] --> 10 
// Expression(operator='*', numbers=[])
// ['+', a, b, c] == ['+', a, ['+', b, c]]

clarifing questions:
How to handle the following invalid expression:
[1,2], ['/', 1], ['/',1,2,3,4], ['-',1,2,3,4], null, ['+', [],[],[]];

Solution:
We need to build an expression that supports two kinds of expression: the expression with only a
number and full expression. If the expression only has a number, we directly return the number.
If it's a full expression, recursivelly caculate all values of child expression then finally 
get the value of itself.

Expression class:
fields:
bool isNumber: indicate if this expression only has a number
int val: the only number that this expression has
char op: the operator
List<Expression>: expressions this expression contains

constructors:
Expression(int num): constructe the expression with only a number
Expression(char op, List<Expression> exps): constructe full expression

Methods for this problem:
EvaluateExpression(Expression exp): return the value of the given expression
If the given expression is only a number, directly return the number. Otherwise recursively
call itself to caculate values of child expressions then call Caculate to get the value.

Caculate(char op, List<int> numbers): caculate value using the given operator and list of numbers.
Note that the list must contains more than 1 number, and if the operator is '-' or '/', the list
must has excately 2 numbers. And operator must be '+', '-', '*' or '/'. Otherwise throw Exception.

*/


using System;
using System.Collections.Generic;

public class Expression
{
	//set must be private to prevent fields being changed outside
	public bool isNumber{get;private set;}
	public int val{get;private set;}
	public char op{get;private set;}
	public List<Expression> exps{get;private set;}
	
	//constructor for expression with only a number
	public Expression(int num){
		isNumber = true;
		val = num;
	}
	
	//constructor for full expression
	public Expression(char op, List<Expression> exps){
		isNumber = false;
		this.exps = exps; //must use this to distinguish argument and field
		this.op = op;
	}
}

public class Test
{
	public static int EvaluateExpression(Expression exp){
		if(exp==null)
			return 0;
		if(exp.isNumber)  //if the expression is only a number
			return exp.val;
		char op = exp.op;
		List<Expression> exps = exp.exps;
		List<int> numbers = new List<int>();
		//if the expression only has an operator and no numbers
		if(exps==null || exps.Count==0){
			if(op=='/' || op=='*')
				return 1;
			return 0;
		}
		//if it's a full expression,recursively get all values of child expressions
		//Suppose input is valid, no null child expression
		foreach(Expression e in exps){
			//If need to consider invalid input, child expression could be null
			// if(e==null){
			// 	if(op=='*' || op='/')
			// 		return 1;
			// 	return 0;
			// }
			numbers.Add(EvaluateExpression(e));
		}
		return Caculate(op, numbers);
	}
	
	public static int Caculate(char op, List<int> numbers){
		if(numbers==null || numbers.Count==0)
			throw new ArgumentNullException("numbers");
		int res = 0;
		switch(op){
			case '+':
				foreach(int i in numbers)
					res+=i;
				return res;
			case '-':
				if(numbers.Count==2){
					res = numbers[0]-numbers[1];
					return res;
				}
				break;
			case '*':
				res = 1;
				foreach(int i in numbers)
					res*=i;
				return res;
			case '/':
				if(numbers.Count==2){
					res = numbers[0]/numbers[1];
					return res;
				}
				break;
			default:
				throw new ArgumentException("invalid operator");
		}
		throw new ArgumentException("invalid numbers");
	}
	
	public static void Main()
	{
		//['*', 3, ['+',1, 10]] = 33
		List<Expression> list = new List<Expression>(){new Expression(1),new Expression(10)};
		Expression exp1 = new Expression('+', list);
		Expression exp = new Expression('*', new List<Expression>(){new Expression(3), exp1});
		Console.WriteLine(EvaluateExpression(exp));
		 
		//['+', 1, 2, 3, 4] = 10
		list = new List<Expression>(){new Expression(1),new Expression(2),new Expression(3),
										new Expression(4)};
		exp = new Expression('+', list);
		Console.WriteLine(EvaluateExpression(exp));
		
		//['+', 1, 2] = 3
		list = new List<Expression>(){new Expression(1),new Expression(2)};
		exp = new Expression('+', list);
		Console.WriteLine(EvaluateExpression(exp));
		
		//['+',1, 2, ['*', 1, 3]] = 6
		list = new List<Expression>(){new Expression(1),new Expression(3)};
		exp1 = new Expression('*', list);
		list = new List<Expression>(){new Expression(1),new Expression(2),exp1};
		exp = new Expression('+', list);
		Console.WriteLine(EvaluateExpression(exp));
		
		//['+']
		exp = new Expression('+', new List<Expression>());
		Console.WriteLine(EvaluateExpression(exp));
		
		//['*']
		exp = new Expression('*', null);
		Console.WriteLine(EvaluateExpression(exp));
		
		//invalid input
		//exp = new Expression('-', new List<Expression>(){new Expression(1)});
		//Console.WriteLine(EvaluateExpression(exp));
	}
}
