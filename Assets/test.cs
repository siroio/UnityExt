using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    private ReactiveValue<int> v;

    private void Start()
    {
        v = new ReactiveValue<int>(0, (value) => Debug.Log("value is " + value));
        v.Set(0);
    }
    bool f = true;
    // Update is called once per frame
    private async void Update()
    {
        if(!f) return;
        f = false;
        await Task.Delay(TimeSpan.FromSeconds(1));
        v.Set(v.value + 1);
        f = true;
    }
}
