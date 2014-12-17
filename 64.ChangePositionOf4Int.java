//Given four integers, public int solution (int A, int B, int C, int D){}
//Change their positions, so that F(s) = abs(S[0]-S[1]) + abs(S[1] - S[2])+abs(S[2]-S[3])
//can get the max value.

public static int[] fourIntegers(int A, int B, int C, int D)
{
  int[] arr = new int[4];
  arr[0] = A;
  arr[1] = B;
  arr[2] = C;
  arr[3] = D;
  Arrays.sort(arr);
  swap(arr, 0 ,1);
  swap(arr, 2, 3);
  swap(arr, 0, 3);
  return arr;
}
public static void swap(intp[] arr, int a, int b)
{
  int temp = arr[a];
  arr[a] = arr[b];
  arr[b] = temp;
}
