/**
 * In the object-oriented language of your choice, 
 * write a function that takes as input an array (or equivalent data structure) of objects. 
 * These objects are black boxes; 
 * you don’t know anything about them, except that they have a color property. 
 * The color property can take one of three values: red, green, or blue. 
 * Your function must sort the array in place by color using the ordering relationship 
 * that red is less than green and green is less than blue. The function must run in O(N) time and
 * O(1) extra space.
*/

using System;
using System.Collections.Generic;
namespace SortColors
{
	class Finder{

		//red = 1, green = 2, blue = 3

		//scan the arr twice
		public static int[] sortColors(int[] arr){ //TIme: O(n) space:O(1)
			int red = 0, green = 0, blue = 0;

			//scan arr and caculate occurence of three colors
			for (int i = 0; i < arr.Length; i++) {
				switch (arr [i]) {
				case 0:
					red++;
					break;
				case 1:
					green++;
					break;
				case 2:
					blue++;
					break;
				}
			}
				
			//reset the arrar according to occurence
			for (int i = 0; i < arr.Length; i++) {
				if (red > 0) {
					arr [i] = 0;
					red--;
				} else if (green > 0) {
					arr [i] = 1;
					green--;
				} else
					arr [i] = 2;

			}

			return arr;
		}

		//scan arr once
		public static int[] sortColorsOnePass(int[] arr){
			//scan array once and repeatedly swap element to right location

			int redLocation = 0;
			int blueLocation = arr.Length - 1;
			int i = 0;

			while (i < blueLocation + 1) {
				if (arr [i] == 0) {
					swap (ref arr [i], ref arr [redLocation]);
					redLocation++;
					i++;
				} else if (arr [i] == 2) {
					swap (ref arr [i], ref arr [blueLocation]);
					blueLocation--;
					i++;
				} else
					i++;
					
			}
			return arr;

		}

		private static void swap(ref int a, ref int b){
			int temp = a;
			a = b;
			b = temp;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] arr = new int[]{ 2, 0, 1, 2, 0, 1, 1, 2, 0, 0, 2, 1, 0, 1, 2 };
			int[] a1 = new int[arr.Length];
			a1 = Finder.sortColors (arr);
			int[] a2 = Finder.sortColorsOnePass (arr);

			foreach (int a in a1)
				Console.Write(a + " ");
			Console.WriteLine (" ");

			foreach (int a in a2)
				Console.Write (a + " ");
			Console.WriteLine (" ");

		}
	}
}
