
**Author: Thomas**\
Date: 27th May 2024
 
This console program is about converting the keys from the keypad into the String. 
  
 
 Description:
  1. Define the keypad using a two-dimensional array.
  2. Initialize variables: resultStr for storing the output string, currentKey to track the current key pressed,
     and currentCount to count the number of times the currentKey is pressed consecutively.
  3. Then, check  and output the result string
 
  Conditions:
 * (i) If the character is a digit:
 *     - Check if it is the same as currentKey.
 *     - If yes, increment currentCount.
 *     - If no, append the current character using appendCurrentCharacter() method,
 *       then update currentKey and currentCount.
 
 * (ii) If the character is '#':
 *      - Append the current character using appendCurrentCharacter() method and terminate the loop.
 *        '#' denotes the end of input.
 
 * (iii) If the character is ' ' (space):
 *       - Append the current character using appendCurrentCharacter() method.
 *       - Reset currentKey and currentCount as spaces indicate a pause.
 
 * (iv) If the character is '*':
 *      - Append the current character using appendCurrentCharacter() method.
 *      - Delete the last character of resultStr to simulate backspace.
 *      - Reset currentKey and currentCount.
 

  These are the possible test cases for using the oldPhonePad function.\
   **Default Scenario provided in the assignment:**
   [![temp-Imagea-Gmln-E.avif](https://i.postimg.cc/HxmBdgH5/temp-Imagea-Gmln-E.avif)](https://postimg.cc/WD9Mwxdb)
   
  There are other possible 7 scenarios that users can do:
 * (i) **Simple one-key scenario:**
   [![temp-Imagebog3xu.avif](https://i.postimg.cc/Hx3jnwGz/temp-Imagebog3xu.avif)](https://postimg.cc/hzzK37tQ)  


 * (ii) **Consecutive same key presses**
   [![temp-Image-Z59-Bqe.avif](https://i.postimg.cc/QtWhGc8V/temp-Image-Z59-Bqe.avif)](https://postimg.cc/0MxL7MJq)
   
 * (iii) **Handling back presses**
   [![temp-Imagewp10-QM.avif](https://i.postimg.cc/hvLnhg7B/temp-Imagewp10-QM.avif)](https://postimg.cc/m1gJ6vwX)
   
 * (iv) **Handling spaces (pauses)**
   [![temp-Image5-Rj-Pia.avif](https://i.postimg.cc/L4L2xkQb/temp-Image5-Rj-Pia.avif)](https://postimg.cc/Yjr59FH6)
   
 * (v) **Mixed key presses**
   [![temp-Image-TDg-HOH.avif](https://i.postimg.cc/KvbFwKdv/temp-Image-TDg-HOH.avif)](https://postimg.cc/z3x9Rfz9)
   
 * (vi) **Multiple backspaces**
   [![temp-Image-BPd7-BH.avif](https://i.postimg.cc/xTPY2f2G/temp-Image-BPd7-BH.avif)](https://postimg.cc/SJjHLpjj)
   
 * (vii) **Handling edge cases**
   [![temp-Imagehnoi-LI.avif](https://i.postimg.cc/K8vbc6G6/temp-Imagehnoi-LI.avif)](https://postimg.cc/7fcdmQT9)

