//Given a collection of intervals, merge all overlapping intervals.
//
//For example,
//Given [1,3],[2,6],[8,10],[15,18],
//return [1,6],[8,10],[15,18].

/**
 * Definition for an interval.
 * public class Interval {
 *     int start;
 *     int end;
 *     Interval() { start = 0; end = 0; }
 *     Interval(int s, int e) { start = s; end = e; }
 * }
 */

//Solution:
//First Sort the input list by the start of each interval
//Then traverse the sorted list, use an int prev to keep track of the previous interval
//Initially, prev = Intervals[0], traverse from the second interval
//for each interval, if its end <= prev.start, merge them; prev = merged interval
//else, put preve to result list, set prev = current interval

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace MergerIntervals
{

	public class Interval{
		public int start{ get; set;}
		public int end{ get; set;}
		public Interval(){
			start = 0;
			end = 0;
		}
		public Interval(int s, int e){
			start = s; end = e;
		}
	}

	public class Finder{
		public static List<Interval> MergeIntervals(List<Interval> Intervals){
			if (Intervals == null || Intervals.Count <= 1)
				return Intervals;

			List<Interval> sortedIntervals = Intervals.OrderBy (a => a.start).ToList(); //time: O(nlogn)
			List<Interval> result = new List<Interval> (); //store result
			Interval prev = sortedIntervals [0];
			for (int i = 1; i < sortedIntervals.Count; i++) {
				Interval curr = sortedIntervals [i];
				if (prev.end >= curr.start) {
					Interval merged = new Interval (prev.start, Math.Max (prev.end, curr.end)); //merge two overlapping intervals
					prev = merged; //do not forget set prev
				} else {
					result.Add (prev);
					prev = curr;
				}
			}
			result.Add (prev); //do not forget add the last prev to result
			return result;
		}
	}
  	 

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			List<Interval> test = new List<Interval> ();
			test.Add (new Interval (1, 3));
			test.Add (new Interval (2, 6));
			test.Add (new Interval (4, 5));
			test.Add (new Interval (9, 11));
			test.Add (new Interval (15, 19));
			test.Add (new Interval (8, 10));


			foreach (Interval i in Finder.MergeIntervals(test)) {
				Console.WriteLine (i.start + " " + i.end);
			}
		}
	}
}
