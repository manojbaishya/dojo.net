using System;
using System.Collections.Generic;
using System.Linq;

namespace Dojo.Net.Leetcode;

public class EasyProblemsBenchmark
{
    private const int ITERATIONS = 50;

    public static void RomanToInt()
    {
        string[] romanNumerals = ["III", "LVIII", "MCMXCIV", "MMMCMXCIX", "MMMCXCIX", "XLIX", "CMXCIX"];
        EasyProblems easyProblems = new();

        for (int j = 0; j < ITERATIONS; j++)
        {
            for (int i = 0; i < romanNumerals.Length; i++)
            {
                int actual = easyProblems.RomanToInt(romanNumerals[i]);
            }
        }
    }

    public static void LongestCommonPrefix()
    {
        string[] strs = ["flower", "flow", "flight"];
        EasyProblems easyProblems = new();

        for (int j = 0; j < ITERATIONS; j++)
        {
            string actual = easyProblems.LongestCommonPrefix(strs);
        }
    }
}

public class EasyProblems
{
    private int GetRomanValue(char key) => key switch
    {
        'I' => 1,
        'V' => 5,
        'X' => 10,
        'L' => 50,
        'C' => 100,
        'D' => 500,
        'M' => 1000,
        _ => 0
    };

    private bool IsSubtractRuleApply(char key, char value)
    {
        switch (key)
        {
            case 'I':
                if (value == 'V' || value == 'X') return true;
                else return false;
            case 'X':
                if (value == 'L' || value == 'C') return true;
                else return false;
            case 'C':
                if (value == 'D' || value == 'M') return true;
                else return false;
            default:
                return false;
        }
    }

    public int RomanToInt(string s)
    {
        Queue<char> chars = new(s.ToCharArray());

        int sum = 0;
        while (chars.Count > 0)
        {
            char curr = chars.Dequeue();
            if (chars.Count == 0)
            {
                sum += GetRomanValue(curr);
                break;
            }

            char next = chars.Peek();

            if (next != curr && IsSubtractRuleApply(curr, next))
            {
                next = chars.Dequeue();
                sum += GetRomanValue(next) - GetRomanValue(curr);
            }
            else if (next != curr && !IsSubtractRuleApply(curr, next))
            {
                sum += GetRomanValue(curr);
            }
            else if (next == curr)
            {
                next = chars.Dequeue();

                if (chars.Count == 0)
                {
                    sum += GetRomanValue(curr) * 2;
                    break;
                }

                char third = chars.Peek();
                if (third != next)
                {
                    sum += GetRomanValue(curr) * 2;
                }
                else if (third == next)
                {
                    third = chars.Dequeue();
                    sum += GetRomanValue(curr) * 3;
                }
            }
        }

        return sum;
    }


    public string LongestCommonPrefix(string[] strs)
    {
        Array.Sort(strs);
        string first = strs[0];
        string last = strs[^1];

        int minLength = Math.Min(first.Length, last.Length);

        int idx = 0;
        while (idx < minLength && first[idx] == last[idx]) idx++;

        return first[..idx];
    }

    public void MergeSortedArrays(int[] nums1, int m, int[] nums2, int n)
    {
        int k = m + n - 1;
        int i = m - 1;
        int j = n - 1;

        while(i >= 0 && j >= 0)
        {
            if (nums1[i] > nums2[j])
            {
                nums1[k] = nums1[i];
                k--;
                i--;
            }
            else
            {
                nums1[k] = nums2[j];
                k--;
                j--;
            }
        }

        if (i < 0 && j >= 0)
        {
            while (j >= 0)
            {
                nums1[k] = nums2[j];
                k--;
                j--;
            }
        }
    }
}
