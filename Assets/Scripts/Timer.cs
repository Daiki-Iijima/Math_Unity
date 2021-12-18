using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float Time{ get; private set; }
    public bool IsStartTimer = false;

    void Start()
    {
        Time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsStartTimer)
        {
            Time += UnityEngine.Time.deltaTime;
        }
    }

    public void StartTimer(){
        IsStartTimer = true;
        Time = 0f;
    }
    public void StopTimer(){
        IsStartTimer = false;
    }
}
