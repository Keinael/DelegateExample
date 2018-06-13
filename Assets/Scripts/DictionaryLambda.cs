using System;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryLambda : MonoBehaviour
{
    public string Operation;
    public int X;
    public int Y;

    private void Start()
    {
        print(Call(Operation));
    }

    private int Call(string message)
    {
        if (message == null)
        {
           print("Message is null");
        }
        else if (!_dSelector.ContainsKey(message))
        {
            return _dSelector["default"](0, 0);
        }
        
        return _dSelector[message](X, Y);
    }

    private static Dictionary<string, Func<int, int, int>> _dSelector = new Dictionary<string, Func<int, int, int>>
    {
        {"reset", (x, y) => 0},
        {"substraction", (x, y) => x - y},
        {"addition", (x, y) => x + y},
        {"multiplication", (x, y) => x * y},
        {"xx", (x, y) => ((x / 100) * y)},
        {"1k", (x, y) => 1000},
        {"default", (x, y) => x},
    };
}