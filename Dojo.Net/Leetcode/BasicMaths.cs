using System.Collections.Generic;

namespace Dojo.Net.Leetcode;

public class BasicMaths
{
    public int EvenlyDivides(int n) 
    {
        int num = n;

        List<int> divDigits = new List<int>();

        while (num > 0)
        {
            int lastDigit = num % 10;
            if (lastDigit != 0 && n % lastDigit == 0)
            {
                divDigits.Add(lastDigit);
            }
            num /= 10;
        }
        
        return divDigits.Count;
    }
}
