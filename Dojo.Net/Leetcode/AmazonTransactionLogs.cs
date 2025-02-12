using System;
using System.Collections.Generic;
using System.Linq;

namespace Dojo.Net.Leetcode;

public class AmazonTransactionLogs
{
    public List<string> ProcessLogs(List<string> logs, int threshold)
    {
        Dictionary<string, int> transactions = [];

        foreach(string txn in logs)
        {
            string[] data = txn.Split(' ');

            string sender = data[0];
            string receiver = data[1];

            if (!sender.Equals(receiver))
            {
                if (!transactions.TryAdd(sender, 1))
                {
                    transactions[sender] += 1;
                }

                if (!transactions.TryAdd(receiver, 1))
                {
                    transactions[receiver] += 1;
                }
            }
            else
            {
                if (!transactions.TryAdd(sender, 1))
                {
                    transactions[sender] += 1;
                }
            }
        }

        Dictionary<string, int> excessiveUsers = transactions.Where(pair => pair.Value >= threshold).ToDictionary();

        List<string> users = [.. excessiveUsers.Keys.Select(int.Parse).OrderBy(name => name).Select(num => num.ToString())];

        return users;
    }
}
