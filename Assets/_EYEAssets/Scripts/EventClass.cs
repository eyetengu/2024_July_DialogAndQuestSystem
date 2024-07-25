using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventClass : MonoBehaviour
{
    public delegate void Dawn();
    public static event Dawn dawn;

    int _indexCounter;
    bool _isCounting;

    void Update()
    {
        if (_isCounting == false)
            StartCoroutine(CounterIncrementer());

        if (_indexCounter == 7)        
            dawn();        
    }

    IEnumerator CounterIncrementer()
    {
        _isCounting = true;
        yield return new WaitForSeconds(1.0f);
        _indexCounter++;
        Debug.Log("Counter: " + _indexCounter);
        _isCounting = false;
    }
}
