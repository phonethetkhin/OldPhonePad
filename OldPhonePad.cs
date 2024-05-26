using System;
using System.Text;

/**
 * Author: Thomas
 * Date: 27th May 2024
 *
 * GetOutputStrFunction converts input keys into an output string based on an old phone keypad.
 *
 * @param inputString Input string containing numeric keys, spaces, '*', and '#'.
 * @return Resulting string translated from input keys.
 *
 * Description:
 * 1. Define the keypad using a two-dimensional array.
 * 2. Initialize variables: resultStr for storing the output string, currentKey to track the current key pressed,
 *    and currentCount to count the number of times the currentKey is pressed consecutively.
 *
 * Conditions:
 * (i) If the character is a digit:
 *     - Check if it is the same as currentKey.
 *     - If yes, increment currentCount.
 *     - If no, append the current character using appendCurrentCharacter() method,
 *       then update currentKey and currentCount.
 *
 * (ii) If the character is '#':
 *      - Append the current character using appendCurrentCharacter() method and terminate the loop.
 *        '#' denotes the end of input.
 *
 * (iii) If the character is ' ' (space):
 *       - Append the current character using appendCurrentCharacter() method.
 *       - Reset currentKey and currentCount as spaces indicate a pause.
 *
 * (iv) If the character is '*':
 *      - Append the current character using appendCurrentCharacter() method.
 *      - Delete the last character of resultStr to simulate backspace.
 *      - Reset currentKey and currentCount.
 */
public class OldPhonePadConverter
{
    public string GetOutputStr(string inputString)
    {
        // Define the keypad mapping
        char[][] keypad = new char[][]
        {
            new char[] {},                   // 0
            new char[] {},                   // 1
            new char[] {'A', 'B', 'C'},      // 2
            new char[] {'D', 'E', 'F'},      // 3
            new char[] {'G', 'H', 'I'},      // 4
            new char[] {'J', 'K', 'L'},      // 5
            new char[] {'M', 'N', 'O'},      // 6
            new char[] {'P', 'Q', 'R', 'S'}, // 7
            new char[] {'T', 'U', 'V'},      // 8
            new char[] {'W', 'X', 'Y', 'Z'}  // 9
        };

        StringBuilder resultStr = new StringBuilder();
        char? currentKey = null;
        int currentCount = 0;


        /**
        * This inner function adds characters to the result string based on the current key.
        * If the current key is not null:
        * - Convert currentKey to a number.
        *
        * - If the number is between 2 and 9,
        * calculate the index in the second array by taking modulo with the size of the keypad's first array.
        *
        * - Retrieve the corresponding character from the keypad array
        * using the number as the first index and the calculated index as the second index.
        *
        * - Append the retrieved character to the result string.
        */
        void AppendCurrentCharacter()
        {
            if (currentKey.HasValue)
            {
                int number = int.Parse(currentKey.Value.ToString());
                if (number >= 2 && number <= 9)
                {
                    int index = (currentCount - 1) % keypad[number].Length;
                    resultStr.Append(keypad[number][index]);
                }
            }
        }


        // iterate inputStr and check each character

        foreach (char ch in inputString)
        {
            if (char.IsDigit(ch))
            {
                if (ch == currentKey)
                {
                    currentCount++;
                }
                else
                {
                    AppendCurrentCharacter();
                    currentKey = ch;
                    currentCount = 1;
                }
            }
            else if (ch == '#')
            {
                AppendCurrentCharacter();
                break;
            }
            else if (ch == ' ')
            {
                AppendCurrentCharacter();
                currentKey = null;
                currentCount = 0;
            }
            else if (ch == '*')
            {
                AppendCurrentCharacter();
                if (resultStr.Length > 0)
                {
                    resultStr.Length -= 1; // Delete last character (simulate backspace)
                }
                currentKey = null;
                currentCount = 0;
            }
        }

        return resultStr.ToString();
    }

    public static void Main()
    {
        OldPhonePadConverter converter = new OldPhonePadConverter();

        // Sample test cases
        Console.WriteLine(converter.GetOutputStr("222 2 22#"));          // Output: CAB
        Console.WriteLine(converter.GetOutputStr("33#"));                // Output: E
        Console.WriteLine(converter.GetOutputStr("227*#"));              // Output: B
        Console.WriteLine(converter.GetOutputStr("4433555 555666#"));    // Output: HELLO
        Console.WriteLine(converter.GetOutputStr("8 88777444666*664#")); // Output: Turing

        // Additional test cases for various scenarios
        OtherDifferentTestCases();
    }

    /**
     * These are the possible test cases for using the oldPhonePad function.
     * There are 7 scenarios that users can test:
     * (i) Simple one-key scenario
     * (ii) Consecutive same key presses
     * (iii) Handling back presses
     * (iv) Handling spaces (pauses)
     * (v) Mixed key presses
     * (vi) Multiple backspaces
     * (vii) Handling edge cases
     */
    public static void OtherDifferentTestCases()
    {
        OldPhonePadConverter converter = new OldPhonePadConverter();

        // (1) Simple one-key scenario
        Console.WriteLine(converter.GetOutputStr("2#"));     // Output: A
        Console.WriteLine(converter.GetOutputStr("22#"));    // Output: B
        Console.WriteLine(converter.GetOutputStr("222#"));   // Output: C
        Console.WriteLine(converter.GetOutputStr("3#"));     // Output: D
        Console.WriteLine(converter.GetOutputStr("33#"));    // Output: E
        Console.WriteLine(converter.GetOutputStr("333#"));   // Output: F

        // (2) Consecutive same key presses scenario
        Console.WriteLine(converter.GetOutputStr("444#"));    // Output: I
        Console.WriteLine(converter.GetOutputStr("555#"));    // Output: L
        Console.WriteLine(converter.GetOutputStr("666#"));    // Output: O
        Console.WriteLine(converter.GetOutputStr("7777#"));   // Output: S
        Console.WriteLine(converter.GetOutputStr("888#"));    // Output: V
        Console.WriteLine(converter.GetOutputStr("9999#"));   // Output: Z

        // (3) Handling back presses scenario (*)
        Console.WriteLine(converter.GetOutputStr("22*#"));    // Output: ""
        Console.WriteLine(converter.GetOutputStr("222*#"));   // Output: ""
        Console.WriteLine(converter.GetOutputStr("227*#"));   // Output: B
        Console.WriteLine(converter.GetOutputStr("22*22#"));  // Output: B
        Console.WriteLine(converter.GetOutputStr("222*22#")); // Output: B
        Console.WriteLine(converter.GetOutputStr("22*2*#"));  // Output: ""

        // (4) Handling spaces (pauses) scenario
        Console.WriteLine(converter.GetOutputStr("2 22#"));       // Output: AB
        Console.WriteLine(converter.GetOutputStr("22 2#"));       // Output: BA
        Console.WriteLine(converter.GetOutputStr("2 2 2#"));      // Output: AAA
        Console.WriteLine(converter.GetOutputStr("44 444#"));     // Output: HI
        Console.WriteLine(converter.GetOutputStr("7777 7777#"));  // Output: SS
        Console.WriteLine(converter.GetOutputStr("8888 8888#"));  // Output: TT
        Console.WriteLine(converter.GetOutputStr("2222 2222#"));  // Output: AA

        // (5) Mixed key presses scenario
        Console.WriteLine(converter.GetOutputStr("4433555 555666#"));                  // Output: HELLO
        Console.WriteLine(converter.GetOutputStr("8 88777444666*664#"));               // Output: Turing
        Console.WriteLine(converter.GetOutputStr("222 33 444 555#"));                  // Output: CFIL
        Console.WriteLine(converter.GetOutputStr("222 333 4444#"));                    // Output: CFG
        Console.WriteLine(converter.GetOutputStr("7777 8888 9999#"));                  // Output: STZ
        Console.WriteLine(converter.GetOutputStr("555 666 777#"));                     // Output: LOR
        Console.WriteLine(converter.GetOutputStr("444 55566688833 222 2 8#"));         // Output: I love cat
        Console.WriteLine(converter.GetOutputStr("446669 277733 99966688#"));          // Output: How are you
        Console.WriteLine(converter.GetOutputStr("444777666 66 777766633389277733#")); // Output: Iron Software

        // (6) Multiple backspaces scenario
        Console.WriteLine(converter.GetOutputStr("22*2*#"));    // Output: ""
        Console.WriteLine(converter.GetOutputStr("222*2*2#"));  // Output: A
        Console.WriteLine(converter.GetOutputStr("227*7*#"));   // Output: B
        Console.WriteLine(converter.GetOutputStr("777*77*7#")); // Output: P
        Console.WriteLine(converter.GetOutputStr("888*8*88#")); // Output: U
        Console.WriteLine(converter.GetOutputStr("999*99*9#")); // Output: W

        // (7) Handling edge cases scenario
        Console.WriteLine(converter.GetOutputStr(""));         // Output: ""
        Console.WriteLine(converter.GetOutputStr("#"));        // Output: ""
        Console.WriteLine(converter.GetOutputStr("*#"));       // Output: ""
        Console.WriteLine(converter.GetOutputStr("2*#"));      // Output: ""
        Console.WriteLine(converter.GetOutputStr("2*2#"));     // Output: A
        Console.WriteLine(converter.GetOutputStr("22*#"));     // Output: ""
        Console.WriteLine(converter.GetOutputStr("22*22*#"));  // Output: ""
        Console.WriteLine(converter.GetOutputStr("22 2*22#")); // Output: BB
        Console.WriteLine(converter.GetOutputStr("2*22 2#"));  // Output: BA
    }
}
