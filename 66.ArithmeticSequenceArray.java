//Find longest possible arithmetic in an array

public static int getLLAP(int[] A)
{
  if(A==null || A.length <= 2){
    return A.length;
}

Arrays.sort(A);
int llap = 2;
int [][] dp = new int [A.length][A.length];
for(int i = 0; i<A.length; i++)
{
  dp[i][A.length-1] = 2;
}
for(int j = A.length -2; j>=0; j--)
{
  int i = j-1; int k = j+1;
  while(i > = 0 && k <A.length){
    if(A[i]+A[K] < A[j] *2)
      k++;
    else if (A[i] + A[k] > A[j]*2){
      dp[i][j] =2;
      i--;
    }
    else{
      dp[i][j] = dp[j][k]+1;
      llap = Math.max(llap,dp[i][j]);
      i--;
      k++;
    }
  }
  while(i>=0){
    dp[i][j] =2;
    i--;
  }
}
return llap;
}
