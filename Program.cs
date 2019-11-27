using System;
using System.Collections.Generic;

namespace DelegatesTest
{
    delegate bool Predicate<T>(T value);
    public delegate T[] Sorter<T>(T[] masivche);
    class Program
    {
        static IEnumerable<T> Filter<T>(IEnumerable<T> nums, Predicate<T> predicate)
        {
            var list = new List<T>();
            foreach (var num in nums)
            {
                if (predicate(num))
                {
                    list.Add(num);
                }
            }
            return list;

        }
        static bool IsEven(int value)
        {
            return value % 2 == 0;
        }
        static bool IsPrime(int value)
        {
            var upperBount = Math.Sqrt(value);
            var candidate = 2;
            bool isPrime = true;
            while (candidate < upperBount && isPrime)
            {
                isPrime = value % candidate != 0;
                candidate++;
            }
            return isPrime;
        }

        static int[] CountingSort(int[] array)
        {
            Console.WriteLine("called counting");
            var max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i])
                    max = array[i];
            }

            var helper = new int[max + 1];
            for (int i = 0; i < array.Length; i++)
            {
                helper[array[i]]++;
            }
            for (int i = 1; i < helper.Length; i++)
            {
                helper[i] += helper[i - 1];
            }
            var result = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                helper[array[i]]--;
                result[helper[array[i]]] = array[i];
            }
            return result;
        }
        static int[] BubbleSort(int[] array)
        {
            Console.WriteLine("called bubble");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }

        static int[]SelectionSort(int[]array)
        {
            Console.WriteLine("called selection");
            for (int i = 0; i < array.Length-1; i++)
            {
                int min_index = i;
                for(int j=i+1;j<array.Length;j++)
                {
                    if(array[min_index]>array[j])
                    {
                        min_index = j;
                    }
                }
                int temp = array[min_index];
                array[min_index] = array[i];
                array[i] = temp;

            }
            return array;
        }
        static void Main(string[] args)
        {
            int[] nums = { 3, 5, 1, 2, 8, 13 };
            // var res = CountingSort(nums);
            Sorter<int> s = new Sorter<int>(CountingSort);
            s += BubbleSort;
            s += SelectionSort;
            var res = s(nums);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
    }
}
