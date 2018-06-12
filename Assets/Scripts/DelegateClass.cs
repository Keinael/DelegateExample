using UnityEngine;

public delegate string FirstDelegate(int x);

internal class DelegateClass : MonoBehaviour
{
    private string _name;

    private void Start()
    {
        FirstDelegate d1 = Method;

        _name = "My instance";

        FirstDelegate d2 = InstanceMethod;

        print(d1(10));
        print(d2(5));
    }

    private string Method(int i)
    {
        return string.Format("Method: {0}", i);
    }

    private string InstanceMethod(int i)
    {
        return string.Format("{0}: {1}", _name, i);
    }
}