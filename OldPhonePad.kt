/**
 * Author: Thomas
 * Date: 27th May 2024
 *
 * This function converts input keys into an output string based on an old phone keypad.
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

fun getOutputStr(inputString: String): String {
    // Define the keypad mapping
    val keypad = arrayOf(
        charArrayOf(),                   // 0
        charArrayOf(),                   // 1
        charArrayOf('A', 'B', 'C'),      // 2
        charArrayOf('D', 'E', 'F'),      // 3
        charArrayOf('G', 'H', 'I'),      // 4
        charArrayOf('J', 'K', 'L'),      // 5
        charArrayOf('M', 'N', 'O'),      // 6
        charArrayOf('P', 'Q', 'R', 'S'), // 7
        charArrayOf('T', 'U', 'V'),      // 8
        charArrayOf('W', 'X', 'Y', 'Z')  // 9
    )

    val resultStr = StringBuilder()  // outputStr
    var currentKey: Char? = null     // Current Pressed Key
    var currentCount = 0             // To indicate how many times same key has pressed

    /**
     * This function adds characters to the result string based on the current key.
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

    fun appendCurrentCharacter() {
        if (currentKey != null) {
            val number = currentKey.toString().toInt()
            if (number in 2..9) {
                val index = (currentCount - 1) % keypad[number].size
                resultStr.append(keypad[number][index])
            }
        }
    }

    for (char in inputString) {
        when {
            char.isDigit() -> {
                if (char == currentKey) {
                    currentCount++  //key is same, increase count
                } else {
                    appendCurrentCharacter() // append the character & update
                    currentKey = char
                    currentCount = 1
                }
            }

            char == '#' -> {
                appendCurrentCharacter()
                break
            }

            char == ' ' -> {
                appendCurrentCharacter() // append and reset because it's pause
                currentKey = null
                currentCount = 0
            }

            char == '*' -> {
                appendCurrentCharacter() // append and delete last character from resultStr & reset vars
                if (resultStr.isNotEmpty()) {
                    resultStr.deleteCharAt(resultStr.length - 1)
                }
                currentKey = null
                currentCount = 0
            }
        }
    }

    return resultStr.toString()
}

fun main() {
    // samples test cases contained in the assignment
    println(getOutputStr("222 2 22#"))          // Output: CAB
    println(getOutputStr("33#"))                // Output: E
    println(getOutputStr("227*#"))              // Output: B
    println(getOutputStr("4433555 555666#"))    // Output: HELLO
    println(getOutputStr("8 88777444666*664#")) // Output: TURING

    otherDifferentTestCases()

}

/**
 * These are the possible test cases for using the oldPhonePad function.
 * There are 7 scenarios that users can do:
 * (i) Simple one-key scenario
 * (ii) Consecutive same key presses
 * (iii) Handling back presses
 * (iv) Handling spaces (pauses)
 * (v) Mixed key presses
 * (vi) Multiple backspaces
 * (vii) Handling edge cases
 */

fun otherDifferentTestCases() {

    // (1) Simple one-key scenario
    println(getOutputStr("2#"))        // Output: A
    println(getOutputStr("22#"))       // Output: B
    println(getOutputStr("222#"))      // Output: C
    println(getOutputStr("3#"))        // Output: D
    println(getOutputStr("33#"))       // Output: E
    println(getOutputStr("333#"))      // Output: F

    // (2) Consecutive same key presses scenario
    println(getOutputStr("444#"))      // Output: I
    println(getOutputStr("555#"))      // Output: L
    println(getOutputStr("666#"))      // Output: O
    println(getOutputStr("7777#"))     // Output: S
    println(getOutputStr("888#"))      // Output: V
    println(getOutputStr("9999#"))     // Output: Z

    // (3) Handling back presses scenario (*)
    println(getOutputStr("22*#"))      // Output: ""
    println(getOutputStr("222*#"))     // Output: ""
    println(getOutputStr("227*#"))     // Output: B
    println(getOutputStr("22*22#"))    // Output: B
    println(getOutputStr("222*22#"))   // Output: B
    println(getOutputStr("22*2*#"))    // Output: ""

    // (4) Handling spaces (pauses) scenario
    println(getOutputStr("2 22#"))       // Output: AB
    println(getOutputStr("22 2#"))       // Output: BA
    println(getOutputStr("2 2 2#"))      // Output: AAA
    println(getOutputStr("44 444#"))     // Output: HI
    println(getOutputStr("7777 7777#"))  // Output: SS
    println(getOutputStr("8888 8888#"))  // Output: TT
    println(getOutputStr("2222 2222#"))  // Output: AA

    // (5) Mixed key presses scenario
    println(getOutputStr("4433555 555666#"))                  // Output: HELLO
    println(getOutputStr("8 88777444666*664#"))               // Output: TURING
    println(getOutputStr("222 33 444 555#"))                  // Output: CEIL
    println(getOutputStr("222 333 4444#"))                    // Output: CFG
    println(getOutputStr("7777 8888 9999#"))                  // Output: STZ
    println(getOutputStr("555 666 777#"))                     // Output: LOR
    println(getOutputStr("444 55566688833 222 2 8#"))         // Output: ILOVECAT
    println(getOutputStr("446669 277733 99966688#"))          // Output: HOWAREYOU
    println(getOutputStr("444777666 66 777766633389277733#")) // Output: IRONSOFTWARE

    // (6) Multiple backspaces scenario
    println(getOutputStr("22*2*#"))    // Output: ""
    println(getOutputStr("222*2*2#"))  // Output: A
    println(getOutputStr("227*7*#"))   // Output: B
    println(getOutputStr("777*77*7#")) // Output: P
    println(getOutputStr("888*8*88#")) // Output: U
    println(getOutputStr("999*99*9#")) // Output: W

    // (7) Handling edge cases scenario
    println(getOutputStr(""))          // Output: ""
    println(getOutputStr("#"))         // Output: ""
    println(getOutputStr("*#"))        // Output: ""
    println(getOutputStr("2*#"))       // Output: ""
    println(getOutputStr("2*2#"))      // Output: A
    println(getOutputStr("22*#"))      // Output: ""
    println(getOutputStr("22*22*#"))   // Output: ""
    println(getOutputStr("22 2*22#"))  // Output: BB
    println(getOutputStr("2*22 2#"))   // Output: BA
}
