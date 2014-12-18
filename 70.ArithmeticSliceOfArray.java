public static int getLAS(int[] A)
{
  //Time：(n) Space: O(1)
  
  if(A.Length) <3) return 0;
  int res = 0;
  int diff = Integer.MIN_VALUE;
  int count=0;
  int start = 0;
  for (int i =1;i<A.length;i++)
  {
    int currDiff = A[i]-A[i-1];
    if(diff == currDiff){
      count+= i-start-1>0? i-start-1:0;
    }
    else{
      start = i-1;
      diff = currDiff;
      res += count;
      count = 0;
    }
  }
  res+=count;
  return res;
}
