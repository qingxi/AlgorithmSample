#1: You want to park your bicycle in a bicycle parking area where bike racks are aligned in a row. There are already N bikes parked there(each bike is attached to exactly one rack, but a rack can have multiple bikes attached to it). We call racks that already have bikes attached used.
 You want to park your bike in a rack in the parking area according to the following criteria:
        the chosen rack must lie between te first and the last used racks(inclusive);
        the distance between the chose rack and any other used rack is as big as possible.
A description of the bikes already parked in the racks is given in a non-empty zero-indexed array A: element A[K] denotes the postion of the rack to which bike number K is attaced (for 0 <= K < N). The central position in the parking area is position 0. A positive value means that the rack is located A[K] meters to the right of the cetral position 0; a negative value means that it's located |A[K]| meters to the left.
That, given a non-empty zero-indexed array A of N integers, returns the largest possible distance in meters between the chosen rack and any other used rack.
Assume that:
        N is an integer within the range [2..100,000];
        each element of array A is an integer within the range [-1,000,000,000..1,000,000,000].
Complexity:
        expected worst-case time complexity isO(N*log(N));
        expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

#2: Given an array arr[] consisting of N positive integers, and an integer K, the task is to find the maximum possible even sum of any subsequence of size K. If it is not possible to find any even sum subsequence of size K, then print -1.

Examples:

Input: arr[] ={4, 2, 6, 7, 8}, K = 3
Output: 18
Explanation: Subsequence having maximum even sum of size K( = 3 ) is {4, 6, 8}.
Therefore, the required output is 4 + 6 + 8 = 18.

Input: arr[] = {5, 5, 1, 1, 3}, K = 3
Output: -1

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Naive Approach: The simplest approach to solve this problem to generate all possible subsequences of size K from the given array and print the value of the maximum possible even sum the possible subsequences of the given array.



Time Complexity: O(K * NK)
Auxiliary Space: O(K)

Efficient Approach: To optimize the above approach the idea is to store all even and odd numbers of the given array into two separate arrays and sort both these arrays. Finally, use the Greedy technique to calculate the maximum sum even subsequence of size K. Follow the steps below to solve the problem:

Initialize a variable, say maxSum to store the maximum even sum of a subsequence of the given array.
Initialize two arrays, say Even[] and Odd[] to store all the even numbers and odd numbers of the given array respectively.
Traverse the given array and store all the even numbers and odd numbers of the given array into Even[] and Odd[] array respectively.
Sort Even[] and Odd[] arrays.
Initialize two variables, say i and j to store the index of Even[] and Odd[] array respectively.
Traverse Even[], Odd[] arrays and check the following conditions:
If K % 2 == 1 then increment the value of maxSum by Even[i].
Otherwise, increment the value of  maxSum by max(Even[i] + Even[i – 1], Odd[j] + Odd[j – 1]).
Finally, print the value of maxSum.

#3: Days of the week are represented s three-letter strings ("Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun").

Write a function solution that, given a string S representing the day of the week and an integer K (between 0 and 500, inclusive), returns the day of the week that is K days later.

For example, given S = "Wed" and K = 2, the function should return "Fri".

Given S = "Sat" and K = 23, the function should return "Mon".
