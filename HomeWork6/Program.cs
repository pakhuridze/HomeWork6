using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Example array initialization
        string[] names = { "giorgi", "elene", "mariam", "beka", "teo" };
        DisplayNames(names);

        int[] nums = { 2, 15, 32, 7, 8, 20, 10, 15 };

        // Find Max
        int maxNumber = FindMax(nums);
        Console.WriteLine($"Max number in array: {maxNumber}");

        // Find Min
        int minNumber = FindMin(nums);
        Console.WriteLine($"Min number in array: {minNumber}");

        // Sum Array
        int sumArray = SumArray(nums);
        Console.WriteLine($"Sum of array: {sumArray}");

        // Reverse Array
        Console.WriteLine("Reversed array: ");
        int[] reveresedArr = ReverseArray(nums);
        Print("Reversed", reveresedArr);

        // Even or Odd Check
        Console.WriteLine("Check array element even or odd");
        string[] evenOrOdd = EvenOrOdd(nums);
        Console.WriteLine($"Even/Odd: [{string.Join(", ", evenOrOdd)}]");

        // Search Element
        Console.Write("Enter number for search in array: ");
        int target = int.Parse(Console.ReadLine());
        Console.WriteLine($"Searching for: {target}");
        bool targetExists = SearchElement(target, nums);
        Console.WriteLine(targetExists ? "Exists!" : "Not Exists!");

        // Copy Array
        int[] copyedArr = CopyArray(nums);
        Print("Copyed", copyedArr);

        // Second Largest Number
        int secondMax = SecondLargestN(nums);
        Console.WriteLine($"Second Max N in arr: {secondMax}");

        // Frequency of Elements
        FrequencyNumbers(nums);

        // --- Extra Tasks ---

        // 1. Rotate
        int[] rotateArrLeft = (int[])nums.Clone();
        Print("RotateLeft by 2", RotateLeft(rotateArrLeft, 2));
        int[] rotateArrRight = (int[])nums.Clone();
        Print("RotateRight by 2", RotateRight(rotateArrRight, 2));

        // 2. Bubble Sort
        int[] sorted = (int[])nums.Clone();
        BubbleSort(sorted);
        Print("BubbleSort asc", sorted);

        // 3. Remove Duplicates
        Print("Remove Duplicates", RemoveDuplicates(nums));

        // 4. Merge Sorted Arrays
        int[] a = { 1, 3, 5 };
        int[] b = { 2, 4, 6 };
        Print("Merge Sorted", MergeSortedArrays(a, b));

        // 5. Insert Element
        Print("Insert 99 at pos 3", InsertElement(nums, 3, 99));

        // 6. Delete Element
        Print("Delete 15", DeleteElement(nums, 15));

        // 7. Find Pairs with Given Sum
        FindPairsWithSum(nums, 17);

        // 8. Check Palindrome
        int[] palindromeArr = { 1, 2, 3, 2, 1 };
        int[] nonPalindromeArr = { 1, 2, 3, 4, 5 };
        Console.WriteLine($"Is {{1, 2, 3, 2, 1}} Palindrome? {IsPalindrome(palindromeArr)}");
        Console.WriteLine($"Is {{1, 2, 3, 4, 5}} Palindrome? {IsPalindrome(nonPalindromeArr)}");


        // 9. Find Missing Number (1..N)
        int[] arrMissing = { 1, 2, 4, 5 }; // 3 is missing, N=5
        Console.WriteLine($"Missing number from {{1, 2, 4, 5}} (N=5): {FindMissingNumber(arrMissing, 5)}");

        // 10. Longest Consecutive Duplicates
        int[] arrDup = { 1, 1, 1, 2, 2, 3, 3, 3, 3 };
        Console.WriteLine($"Longest Consecutive Element in {{1, 1, 1, 2, 2, 3, 3, 3, 3}}: {LongestConsecutive(arrDup)}");
    }

    // names array
    static void DisplayNames(string[] names)
    {
        Console.WriteLine("\n--- Display Names ---");
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    // find max
    static int FindMax(int[] nums)
    {
        if (nums == null || nums.Length == 0) throw new ArgumentException("Array cannot be empty.");
        int max = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > max)
            {
                max = nums[i];
            }
        }
        return max;
    }

    // find min
    static int FindMin(int[] nums)
    {
        if (nums == null || nums.Length == 0) throw new ArgumentException("Array cannot be empty.");
        int min = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < min)
            {
                min = nums[i];
            }
        }
        return min;
    }

    // sum of array
    static int SumArray(int[] nums)
    {
        int sum = 0;
        foreach (var num in nums)
        {
            sum += num;
        }
        return sum;
    }

    // Reverse array
    static int[] ReverseArray(int[] nums)
    {
        int[] reversedArr = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            reversedArr[i] = nums[nums.Length - 1 - i];
        }
        return reversedArr;
    }

    // Check array element even or odd
    static string[] EvenOrOdd(int[] nums)
    {
        string[] sortedNums = new string[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            sortedNums[i] = nums[i] % 2 == 0 ? "Even" : "Odd";
        }

        return sortedNums;
    }

    // Search Target Element in array
    static bool SearchElement(int target, int[] nums)
    {
        foreach (var num in nums)
        {
            if (num == target)
            {
                return true;
            }
        }
        return false;
    }

    // Copy array
    static int[] CopyArray(int[] nums)
    {
        int[] newArray = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            newArray[i] = nums[i];
        }
        return newArray;
    }

    // Second Largest number
    static int SecondLargestN(int[] nums)
    {
        if (nums == null || nums.Length < 2) throw new ArgumentException("Array must have at least two elements.");

        int max = int.MinValue;
        int secondMax = int.MinValue;

        foreach (var num in nums)
        {
            if (num > max)
            {
                secondMax = max; // Old max becomes secondMax
                max = num;       // New num becomes max
            }
            else if (num > secondMax && num != max)
            {
                secondMax = num;
            }
        }


        return secondMax;
    }

    // Frequency of elements 
    static void FrequencyNumbers(int[] nums)
    {
        Console.WriteLine("\n--- Frequency of Elements ---");
        // Using a Dictionary for efficient tracking
        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (frequencyMap.ContainsKey(num))
            {
                frequencyMap[num]++;
            }
            else
            {
                frequencyMap.Add(num, 1);
            }
        }

        foreach (var kvp in frequencyMap)
        {
            Console.WriteLine($"{kvp.Key} appears {kvp.Value} times");
        }
    }

    // Utility print
    static void Print(string msg, int[] arr)
    {
        Console.WriteLine($"\n--- {msg} ---");
        Console.WriteLine($"{msg}: [{string.Join(", ", arr)}]");
    }

    // 1. Rotate Left
    static int[] RotateLeft(int[] arr, int k)
    {
        int n = arr.Length;
        if (n == 0) return arr;
        k = k % n; // Handle cases where k > n
        int[] res = new int[n];
        for (int i = 0; i < n; i++)
            res[i] = arr[(i + k) % n];
        return res;
    }

    // 1. Rotate Right
    static int[] RotateRight(int[] arr, int k)
    {
        int n = arr.Length;
        if (n == 0) return arr;
        k = k % n; // Handle cases where k > n
        int[] res = new int[n];
        for (int i = 0; i < n; i++)
            res[i] = arr[(i - k + n) % n];
        return res;
    }

    // 2. Bubble Sort
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped) break;
        }
    }

    // 3. Remove Duplicates
    static int[] RemoveDuplicates(int[] arr)
    {
        // Using a List and checking for Contains is one way
        List<int> list = new List<int>();
        foreach (var num in arr)
        {
            if (!list.Contains(num))
                list.Add(num);
        }
        return list.ToArray();


    }

    // 4. Merge Two Sorted Arrays
    static int[] MergeSortedArrays(int[] a, int[] b)
    {
        int i = 0, j = 0, k = 0;
        int[] res = new int[a.Length + b.Length];

        // Merge until one array is exhausted
        while (i < a.Length && j < b.Length)
        {
            if (a[i] < b[j])
            {
                res[k++] = a[i++];
            }
            else
            {
                res[k++] = b[j++];
            }
        }

        // Copy remaining elements of a[]
        while (i < a.Length)
        {
            res[k++] = a[i++];
        }

        // Copy remaining elements of b[]
        while (j < b.Length)
        {
            res[k++] = b[j++];
        }
        return res;
    }

    // 5. Insert Element
    static int[] InsertElement(int[] arr, int pos, int val)
    {
        // Positional check to ensure validity
        if (pos < 0 || pos > arr.Length)
        {
            Console.WriteLine("Invalid position for insertion.");
            return arr;
        }

        int[] res = new int[arr.Length + 1];

        for (int i = 0; i < res.Length; i++)
        {
            if (i < pos)
            {
                res[i] = arr[i];
            }
            else if (i == pos)
            {
                res[i] = val;
            }
            else // i > pos
            {
                res[i] = arr[i - 1];
            }
        }
        return res;
    }

    // 6. Delete Element (first occurrence)
    static int[] DeleteElement(int[] arr, int val)
    {
        int indexToDelete = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == val)
            {
                indexToDelete = i;
                break;
            }
        }

        if (indexToDelete == -1)
        {
            Console.WriteLine($"Element {val} not found for deletion.");
            return arr;
        }

        int[] res = new int[arr.Length - 1];

        for (int i = 0, j = 0; i < arr.Length; i++)
        {
            if (i != indexToDelete)
            {
                res[j++] = arr[i];
            }
        }
        return res;


    }

    // 7. Find Pairs with Given Sum
    static void FindPairsWithSum(int[] arr, int target)
    {
        Console.WriteLine($"\n--- Pairs with sum {target} ---");
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] + arr[j] == target)
                    Console.WriteLine($"{arr[i]} + {arr[j]} = {target}");
            }
        }
    }

    // 8. Check Palindrome
    static bool IsPalindrome(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n / 2; i++)
        {
            if (arr[i] != arr[n - 1 - i]) return false;
        }
        return true;
    }

    // 9. Find Missing Number (1..N)
    static int FindMissingNumber(int[] arr, int N)
    {
        int expectedSum = N * (N + 1) / 2;
        int actualSum = 0;
        foreach (var num in arr) actualSum += num;

        return expectedSum - actualSum;
    }


    static int LongestConsecutive(int[] arr)
    {
        if (arr == null || arr.Length == 0) return 0;

        int maxCount = 1;
        int currentCount = 1;
        int elementWithLongestRun = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                currentCount++;
            }
            else
            {
                currentCount = 1;
            }

            if (currentCount > maxCount)
            {
                maxCount = currentCount;
                elementWithLongestRun = arr[i];
            }
        }
        return elementWithLongestRun;
    }
}