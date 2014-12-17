//Given a list of ints and a window size, the window is moving one step once.
//return a new list containing the sum of each window


public static List<Integer> getSumWindow(int[] A, int k)
{
  if(A == null || A.Length == 0|| k <=0}
    return null;
  
  ArrayList<Integer> res = new ArrayList<Integer>();
  int count = 0;
  for(int i =0; i<A.Length; i++)
  {
    count++;
    if(count>=k){
      int sum = 0;
      for(int j=i; j>=i-k+1;j--){
        sum +=A[j];
      }
      res.add(sun);
    }
  }
  return res;
}
