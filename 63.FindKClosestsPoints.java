public class Point
{
  int x;
  int y;
  public Point(int x, int y)
  {
    this.x = x;
    this.y = y;
  }
}

public class PointwithDis
{
  Point p;
  int dis;
  public PointwithDis(Point p, int d)
  {
    this.p = p;
    this.dis = d;
  }
}

public class Finder
{
  public static Point[] getCloseK(Point[] points, Point origin, int k)
  {
    PriorityQueue<PointwithDis> kPoints = new PriorityQueue<PointwithDis>(K, new Comparator<PointwithDis>(){
      public int compare(PointwithDis arg0, PointwithDis arg1) {
        return (int) (arg1.dis - arg0.dis)
      }
      });
      PointwithDis[] pointswithdis = new PointwithDis[points.length]; //create new array to store all points with dis
      int index = 0;
      for(Point p : points)
      {
        double dis = Match.abs((double)(origin.x -p.x)/(origin.y-p.y));
        pointswithdis[index++] = new PointwithDis(p, dis);
      }
      
      for(PointwithDis p : pointswithdis)
      {
        if(kPoints.size() < k)
          kPoints.offer(p);
        else{
          if(kPoints.peek().dis > p.dis){
            kPoints.poll();
            kPoints.offer(p);
          }
        }
      }
      
      Point[] result = new Point[K];
      index = 0;
      while(!kPoints.isEmpty())
      {
        result[index++] = kPoints.poll().p;
      }
      
      return result;
    
  }
}
