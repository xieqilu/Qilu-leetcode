/**
 * Given a positive Integer Number, Convert it to Words formation.
 * you can skip all the "and" in the prounaciation
 * 
 * Example: 65321 -> Sixty five thousand three hundred twenty one
 * 			100 -> one hundred
 * 			1000000 - > one million
 * 			1001 -> one thousand one
 * 			1000001 - > one million one
 * 			1234567 - > one million two hundred thirty four thousand five hundred sixty seven
 * 
 * */



using System;
using System.Text;

namespace ConvertNumberToWords
{
	class Converter{
		private static string[] ones = {
			"zero",
			"one",
			"two",
			"three",
			"four",
			"five",
			"six",
			"seven",
			"eight",
			"nine"
		};

		private static string[] teens = {
			"ten",
			"eleven",
			"twelve",
			"thirteen",
			"fourteen",
			"fifteen",
			"sixteen",
			"seventeen",
			"eighteen",
			"nineteen"
		};

		private static string[] tens = {
			"",
			"ten",
			"twenty",
			"thirty",
			"fourty",
			"fifty",
			"sixty",
			"seventy",
			"eighty",
			"ninety"

		};

		private static string[] thousands = {
			"",
			"thousand",
			"million",
			"billion",
			"trillion",
			"quadrillion"
		};

		//convert an Integer number to words
		public static string ConvertNumber(int value){
			string digits, temp;
			bool showThousand = false;

			StringBuilder sb = new StringBuilder (); //use StringBuilder to build string
			digits = value.ToString (); //convert int value to string

			//traverse chars of digits in reverse order
			for (int i = digits.Length - 1; i >= 0; i--) {
				int currentDigit = (int)(digits[i] - '0'); //get value of current digit
				int currentColumn = digits.Length - (i + 1); //get current column, last digit is at column 0;

				switch(currentColumn % 3){

				case 0:   //digit 0, 3, 6, 9......
					showThousand = true;  //reset showThousand in each case 0
					if (i == 0) {         //first digit in the number, last digit in the loop
						temp = ones [currentDigit];
					} else if (digits [i - 1] == '1') { //this digit is part of teen value
						temp = teens [currentDigit];
						i--;  //skip the '1' digit
					} else if (currentDigit!=0) {
						temp = ones [currentDigit];
					} else {  //this digit is zero
						temp = String.Empty;
						if (digits [i - 1] != '0'|| i > 1 && digits [i - 2] != '0')
							showThousand = true;
						else
							showThousand = false;
					}

					if (showThousand) {
						if (currentColumn > 0) {  //exclude the last digit of number
							temp = temp + " " + thousands [currentColumn / 3] + " ";
						} 
					}

					sb.Insert (0, temp);
					break;

				case 1:  //digit 1,4,7... tens column
					if (currentDigit > 0) {
						temp = tens [currentDigit] + " ";
						sb.Insert (0, temp);
					}
					break;
				
				case 2: //hundred column
					if (currentDigit > 0) {
						temp = ones [currentDigit] + " hundred ";
						sb.Insert (0, temp);
					}
					break;
				}
			}

			string words = String.Format ("{0}{1}", Char.ToUpper (sb [0]), sb.ToString (1, sb.Length - 1));
			return words;
		}

	}


	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine (Converter.ConvertNumber (65321));
			Console.WriteLine (Converter.ConvertNumber (100));
			Console.WriteLine (Converter.ConvertNumber (1000000));
			Console.WriteLine (Converter.ConvertNumber (1001));
			Console.WriteLine (Converter.ConvertNumber (1000005));
			Console.WriteLine (Converter.ConvertNumber (1000700));
			Console.WriteLine (Converter.ConvertNumber (1234567));
		}
	}
}
