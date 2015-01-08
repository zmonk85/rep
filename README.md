VelirCodeContest
================
Greetings and welcome to our first Velir Code Contest.  We’ve come up with a small challenge based on one of our interview questions.

To start:

Create a clone this repository locally.

Inside, you'll find a solution with two projects.

1.  CodeContest:
This project contains a few files:
A console app that may be used for interacting with your class.
A MethodExtensions class that we will be using to measure performance.
A 'SmartShopper' class that is a template for your solution.

2. ContestTests:
This has a single test class with a few tests these will not be the only tests used for the final judgment, but should be able to help identify any issues or bottlenecks with your solution.

To submit, you will create a copy of this class and it should be named 'SmartShopper' followed by your name. (eg SmartShopperMikeDiStaula)

Information about how to submit these will be provided later, but assume that the only class being tested will be this newly created class.

Problem

You receive a credit C at a local store and would like to buy two items. 
You first walk through the store and create a list L of all available items. 
From this list you would like to buy two items that add up to the entire value of the credit. 

The output will consist of the two integers indicating the positions of the items in your list (smaller number first).

Input

The first line of input provides the number of times this will be run.  For each test case there will be:

One line containing the amount of credit you have at the store.
One line containing the number of items in the store.
One line containing a space separated list of I integers. Each integer indicates the price of an item in the store.
Prices may be the same, but we expect that the earliest index will be the correct one.  (eg  if you only have one test case, have 100 dollars, and the five item list is '5 10 25 25 75 50 75', the correct output would be '3 5')

Output

For each test case, output one line containing "Case #x: " followed by the indices of the two items whose price adds up to the store credit. The lower index should be output first.  (The first number in the list is ‘1’) and finally, the last line in the output will be "Finished." indicating that your results are complete.

A couple of rules:

1.  The TextStream should not be considered accurate or changed until the call to 'GetResult'.
2.  Assume all data will be valid.
  This means:
    * If '6' is the first input line of the stream, you can assume that there will be exactly 18 more lines to the stream and no more.
    * If '100' is the second input line of the stream, you can assmume that there will be at least two items in the store that add up to 100.
    * if '4' is the third input line of the stream, you can assume that there will be exactly 3 ' ' characters.  (e.g. '15 65 40 35')
  
You will have until 9am on January 9th to finish your solution.  

Submission instructions will be provided at a later time, and we will use a much larger dataset (run many times to get an accurate representation of the performance).
