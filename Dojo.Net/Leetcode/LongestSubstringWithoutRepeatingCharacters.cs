using System;
using System.Collections.Generic;

namespace Dojo.Net.Leetcode;

public class LongestSubstringWithoutRepeatingCharactersSolution
{
    public int LengthOfLongestSubstring(string s) 
    {
        int maxLength = int.MinValue;
        int start = 0;
        HashSet<char> uniqueCharset = new(s.Length);

        for (int end = 0; end < s.Length; end++)
        {
            char c = s[end];
            while (uniqueCharset.Contains(c))
            {
                uniqueCharset.Remove(s[start]);
                start++;
            }
            bool added = uniqueCharset.Add(c);
            if (added) maxLength = Math.Max(maxLength, (end + 1) - start);
        }
        
        return maxLength != int.MinValue ? maxLength : 0;
    }
}