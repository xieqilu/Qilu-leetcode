
using System;
using System.Collections.Generic;


namespace NClosestPointsOnAPlane
{
	public class Point
	{
		public int X{ get; private set;}
		public int Y{ get; private set;}
		public int Distance{ get; set;}
		public Point(int X, int Y)
		{
			this.X = X;
			this.Y = Y;
		}
	}

	public interface PointsOnAPlane {

		/**
     * Stores a given point in an internal data structure
     */
		void addPoint(Point point);

		/**
     * For given 'center' point returns a subset of 'm' stored points that are
     * closer to the center than others.
     *
     * E.g. Stored: (0, 1) (0, 2) (0, 3) (0, 4) (0, 5)
     *
     * findNearest(new Point(0, 0), 3) -> (0, 1), (0, 2), (0, 3)
     */
		List<Point> findNearest(Point center, int m);

	}

	public class PointsHandler : PointsOnAPlane
	{
		public List<Point> storageList { get; private set;}
		//public List<Point> nearestList {get;private set;}

		public PointsHandler()
		{
			this.storageList = new List<Point> ();
			//this.nearestList = new List<Point> ();
		}

		void PointsOnAPlane.addPoint(Point point)
		{
//			int x = point.X;
//			int y = point.Y;
//			point.Distance = (x * x) + (y * y);
			storageList.Add (point);
		}

		List<Point> PointsOnAPlane.findNearest(Point center, int m)
		{
			foreach (Point p in storageList) { //O(n)
				int diffX = Math.Abs (p.X - center.X);
				int diffY = Math.Abs (p.Y - center.Y);
				int distance = (diffX * diffX) + (diffY * diffY);
				p.Distance = distance;
			}

			List<Point> nearestList =new List<Point>();

			Point temp = this.QuickSelect(storageList,m);
			foreach (Point p in storageList) { //O(n)
				if (p.Distance <= temp.Distance)
					nearestList.Add (p);
			}

			return nearestList;
		}

		private Point QuickSelect(List<Point> list, int k) //O(n)
		{
			List<Point> leftlist = new List<Point> ();
			List<Point> rightlist = new List<Point> ();

			Point pivot = list [list.Count / 2];

			foreach (Point p in list) {
				if (p.Distance < pivot.Distance)
					leftlist.Add (p);
				if (p.Distance > pivot.Distance)
					rightlist.Add (p);
			}

			if (leftlist.Count < k - 1)
				return this.QuickSelect (rightlist, k - 1 - leftlist.Count); 
			if (leftlist.Count > k - 1)
				return this.QuickSelect (leftlist, k);
			else
				return pivot;

		}
	}

	class MainClass
	{
		public static void Main (string[] args){
			PointsHandler ph = new PointsHandler ();
			PointsOnAPlane pa = (PointsOnAPlane) ph;
			pa.addPoint (new Point (3, 5));
			pa.addPoint (new Point (1, 2));
			pa.addPoint (new Point (2, 4));
			pa.addPoint (new Point (1, 1));
			pa.addPoint (new Point (3, 1));
			pa.addPoint (new Point (0, 1));


			Point center = new Point (0, 0);

			List<Point> result = pa.findNearest (center, 3);
			foreach (Point p in result)
				Console.WriteLine ("(" + p.X + "," + p.Y + ")");
		}


	}
}
