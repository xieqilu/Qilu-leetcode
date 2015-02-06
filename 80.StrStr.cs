/**
 * Implement int strstr(string s, string t)
 * check if t is a valid substring of s, 
 * if it is, return starting index of the substring
 * if it is not, return -1
 * 
 * Solution:
 * start from the first char of s, compare each char with t,
 * if found a matching substring, return.
 * if not, start over from the next char of s
 * if the rest char of s is less than t, no need to compare anymore.
 * Time Complexity: O((n-m)*m) or O(n*m) n is size of s, m is the size of t
 * 
 * If not allowed use any system library, eg: cannot get the length of s and t.
 * the use following c code:
 * 
 * char* StrStr(const char *str, const char *target) {
  if (!*target) return str;
  char *p1 = (char*)str, *p2 = (char*)target;
  char *p1Adv = (char*)str;
  while (*++p2) //前置++返回递增后的值，优先级与*相同，所以等于*(++p2)
    p1Adv++; //利用p1Adv控制下面的循环次数
  while (*p1Adv) {
    char *p1Begin = p1;
    p2 = (char*)target;
    while (*p1 && *p2 && *p1 == *p2) {
      p1++;
      p2++;
    }
    if (!*p2)
      return p1Begin;
    p1 = p1Begin + 1;
    p1Adv++;
  }
  return NULL;
}

 */

using System;

namespace Strstr
{

	class Finder{
		public static int strStr(string str, string target) //return index of first match char in str
		{
			int slen = str.Length;
			int tlen = target.Length;
			if(tlen == 0) return 0;
			if(tlen > slen) return -1;
			int p1 = 0, p2=0;
			while(p1 <= slen-tlen){
				int p1Begin = p1;
				p2=0;
				while(p1<slen && p2<tlen && str[p1] == target[p2]){
					p1++;
					p2++;
				}
				if(p2 == tlen) return p1Begin;
				p1=p1Begin+1;
			}
			return -1;
		}

	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine(Finder.strStr("applebabamamayouthey","bamamay"));
			Console.WriteLine(Finder.strStr("applebabamamayouthey","yout"));
		}
	}
}
