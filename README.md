# Old Phone Pad Conversion Program

**Author: Thomas**  
Date: 27th May 2024

## Description

This console program converts key presses from a simulated old phone keypad into a resulting string. This console program contains both C# file and Kotlin file.

1. Define the keypad using a two-dimensional array.
2. Initialize variables: `resultStr` for storing the output string, `currentKey` to track the current key pressed, and `currentCount` to count consecutive key presses.
3. Implement the following conditions to construct the output string:

   - **Digit Character:** Track consecutive presses of the same key.
   - **'#' Character:** Denotes the end of input.
   - **Space (' ') Character:** Indicates a pause in input.
   - **'*' Character:** Simulates a backspace by deleting the last character in `resultStr`.

## Possible Test Cases

### Default Scenario
[![Default Scenario](https://i.postimg.cc/HxmBdgH5/temp-Imagea-Gmln-E.avif)](https://postimg.cc/WD9Mwxdb)
- Example of typical usage as provided in the assignment.

### Other Scenarios

(i) **Simple One-Key Scenario**
[![Simple One-Key](https://i.postimg.cc/Hx3jnwGz/temp-Imagebog3xu.avif)](https://postimg.cc/hzzK37tQ)

(ii) **Consecutive Same Key Presses**
[![Consecutive Same Key](https://i.postimg.cc/QtWhGc8V/temp-Image-Z59-Bqe.avif)](https://postimg.cc/0MxL7MJq)

(iii) **Handling Back Presses**
[![Handling Back Presses](https://i.postimg.cc/hvLnhg7B/temp-Imagewp10-QM.avif)](https://postimg.cc/m1gJ6vwX)

(iv) **Handling Spaces (Pauses)**
[![Handling Spaces](https://i.postimg.cc/L4L2xkQb/temp-Image5-Rj-Pia.avif)](https://postimg.cc/Yjr59FH6)

(v) **Mixed Key Presses**
[![Mixed Key Presses](https://i.postimg.cc/KvbFwKdv/temp-Image-TDg-HOH.avif)](https://postimg.cc/z3x9Rfz9)

(vi) **Multiple Backspaces**
[![Multiple Backspaces](https://i.postimg.cc/xTPY2f2G/temp-Image-BPd7-BH.avif)](https://postimg.cc/SJjHLpjj)

(vii) **Handling Edge Cases**
[![Handling Edge Cases](https://i.postimg.cc/K8vbc6G6/temp-Imagehnoi-LI.avif)](https://postimg.cc/7fcdmQT9)

These test cases demonstrate various scenarios to validate the functionality of the `oldPhonePad` function, ensuring robustness and accuracy across different input patterns and user interactions.
