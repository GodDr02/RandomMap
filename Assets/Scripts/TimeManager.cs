using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float TimeScale;

    float startTimeScale;
    float startFixedDeltaTime;

    // Start is called before the first frame update
    void Start()
    {
        startTimeScale = Time.timeScale;
        startFixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = TimeScale;
            Time.fixedDeltaTime = startFixedDeltaTime * TimeScale;
        }
        if(Input.GetKeyUp(KeyCode.Q))
        {
            Time.timeScale = startTimeScale;
            Time.fixedDeltaTime = startFixedDeltaTime;
        }
    }
}
