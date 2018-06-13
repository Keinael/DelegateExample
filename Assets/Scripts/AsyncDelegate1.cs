using System.Threading;
using UnityEngine;

public delegate int SampleDelegate(string data);

public class AsyncDelegate1 : MonoBehaviour
{
    private void Start()
    {
        SampleDelegate counter = CountCharacters;
        SampleDelegate parser = Parse;

        var counterResult = counter.BeginInvoke("hello", null, null);
        var parserResult = parser.BeginInvoke("10", null, null);

        print("Основной поток с ID = " + Thread.CurrentThread.ManagedThreadId + " продолжает выполняться");

        print("Счетчик вернул " + counter.EndInvoke(counterResult));
        print("Парсер вернул " + parser.EndInvoke(parserResult));

        print("Основной поток с ID = " + Thread.CurrentThread.ManagedThreadId + " завершился");
    }

    private static int CountCharacters(string text)
    {
//        Thread.Sleep(5000);
//        print("Подсчет символов в строке " + text + " в потоке с ID = " + Thread.CurrentThread.ManagedThreadId);
        for (var i = 0; i < 100; i += 10)
        {
            print("Поток: " + Thread.CurrentThread.ManagedThreadId + ". I = " + i);
        }

//        return text.Length;
        return 0;
    }

    private static int Parse(string text)
    {
//        Thread.Sleep(100);
//        print("Парсинг строки " + text + " в потоке с ID = " + Thread.CurrentThread.ManagedThreadId);
        for (var i = 0; i < 100; i += 10)
        {
            print("Поток: " + Thread.CurrentThread.ManagedThreadId + ". J = " + i);
        }

//        return int.Parse(text);
        return 1;
    }
}