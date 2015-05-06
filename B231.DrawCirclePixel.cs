/**
Draw a circle using pixel bits.
Gvien a center(x0,y0) and a radius r, draw all pixels that are on the circle. 

Solution:
Thii is a very classic problem. The key point are: a) how to minimize the work and b) how to quickly
find all pixels on the circle.

Note:
1, We can divide the circle into 8 parts, and by getting pixels on one part, we can get all pixels
on the circle by mirror coordinates. For example, if we know that a pixel (x0+x,y0+y) is on the circle, then
there must be (x-x0)^2+(y-y0)^2 = r^2. Then we can know the following 7 pixels are also on the circle:
(x0-x,y0+y), (x0+x,y0-y), (x0-x,y0-y), (x0+y,y0+x), (x0-y,y0+x),(x0+y,y0-x),(x0-y,y0-x).

2, In order to quickly find all pixels on the circle. We can start from (x0+r, y), or x=r, y=0. Then
each time we check the relationship between (x-x0)^2+(y-y0)^2 and r^2, to determine wether we need 
to increment y or decrement x.
If (x-x0)^2+(y-y0)^2>r^2, x--. If (x-x0)^2+(y-y0)^2<r^2, y++. Otherwise, we find a pixle on circle.
Untile x==y, then this pixel is the end pixel for this part, so when we reach this pixel, we have 
found all pixels on the circle.

*/

using System;

public class Test
{
	//Suppose this method will draw a specific pixel (x,y)
	private static void DrawPixel(int x, int y){
		
	}	
	
	private static int CheckPixel(int x0, int y0, int x, int y){
		int p1 = (x-x0)*(x-x0);
		int p2 = (y-y0)*(y-y0);
		return p1+p2 - r*r;
	}
	
	//Draw all pixels on the circle
	public static void DrawCircle(int x0, int y0, int r){
		int x = r;
		int y = 0;
		while(x<=y){
			int temp = CheckPixel(x0,y0,x,y);
			if(temp>0)
				x--;
			else if(temp<0)
				y++:
			else{
				DrawPixle(x0+x,y0+y);
				DrawPixle(x0-x,y0+y);
				DrawPixle(x0+x,y0-y);
				DrawPixle(x0-x,y0-y);
				DrawPixle(x0+y,y0+x);
				DrawPixle(x0-y,y0+x);
				DrawPixle(x0+y,y0-x);
				DrawPixle(x0-y,y0-x);
				y++; //default: increment y
			}
		}
	}
	
	public static void Main()
	{
		// your code goes here
	}
}
