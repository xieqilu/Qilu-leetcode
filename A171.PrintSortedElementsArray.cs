//parameters: character array, integer representing the length of the array
//function should print the contents of the array in sorted order
//array contains only lower case letters

//example - bbcdezzaab --->   aabbbcdezz

public void sortCharArray(char[] array, int length) {

    int[] count = new int[26];

    for(int i=0; i<length; i++) {

        char c = array[i];
        if(c<'a'||c>'z') {
            Console.WriteLine("There is illegal letter!");
            return;
        }
        count[array[i]-'a']++;
    }

    for(int j=0; j<26; j++) {
        for(int m = 0; m<count[j]; m++) {
            Console.WriteLine((char)('a'+j));
        }

    }
    return;
}
