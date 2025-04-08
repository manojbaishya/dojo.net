using System;
using System.Collections.Generic;
using System.Linq;

namespace Dojo.Net.Leetcode;

public class StacksAndQueues
{
    public int[] AsteroidCollision(int[] asteroids) 
    {
        Stack<int> stack = new(asteroids.Length);

        for (int i = 0; i < asteroids.Length; i++)
        {
            int num = asteroids[i];
            int sign = Math.Sign(num);

            if (stack.Count == 0)
            {
                stack.Push(num);
                continue;
            }

            if (sign != Math.Sign(stack.Peek()))
            {
                if (sign < Math.Sign(stack.Peek()))
                {
                    while(sign < Math.Sign(stack.Peek()))
                    {
                        int top = stack.Peek();

                        if (Math.Abs(top) > Math.Abs(num))
                        {
                            break;
                        }
                        else if (Math.Abs(top) == Math.Abs(num))
                        {
                            stack.Pop();
                            break;
                        }
                        else if (Math.Abs(top) < Math.Abs(num))
                        {
                            stack.Pop();

                            if (stack.Count == 0) stack.Push(num);
                            else if (sign >= Math.Sign(stack.Peek())) stack.Push(num);
                        }
                    }
                }
                else
                {
                    stack.Push(num);
                }
            }
            else
            {
                stack.Push(num);
            }
        }

        return stack.Reverse().ToArray();
    }
}
