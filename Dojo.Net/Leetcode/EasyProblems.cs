using System.Collections.Generic;

namespace Dojo.Net.Leetcode;

public class EasyProblems
{
    public int RomanToInt(string s)
    {
        Dictionary<char, int> numbers = new()
        {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000
        };

        Dictionary<char, HashSet<char>> subtract = new()
        {
            ['I'] = ['V', 'X'],
            ['X'] = ['L', 'C'],
            ['C'] = ['D', 'M']
        };

        Queue<char> chars = new(s.ToCharArray());

        int sum = 0;
        while (chars.Count > 0)
        {
            char curr = chars.Dequeue();
            if (chars.Count == 0)
            { 
                sum += numbers[curr]; 
                break;
            }

            char next = chars.Peek();

            if (next != curr && subtract.TryGetValue(curr, out HashSet<char>? value) && value.Contains(next))
            {
                next = chars.Dequeue();
                sum += numbers[next] - numbers[curr];
            }
            else if (next != curr && subtract.TryGetValue(curr, out value) && !value.Contains(next))
            {
                sum += numbers[curr];
            }
            else if (next != curr && !subtract.TryGetValue(curr, out _))
            {
                sum += numbers[curr];
            }
            else if (next == curr)
            {
                next = chars.Dequeue();

                if (chars.Count == 0)
                {
                    sum += numbers[curr] * 2;
                    break;
                }

                char third = chars.Peek();
                if (third != next)
                {
                    sum += numbers[curr] * 2;
                }
                else if (third == next)
                {
                    third = chars.Dequeue();
                    sum += numbers[curr] * 3;
                }
            }
        }


        return sum;
    }
}
