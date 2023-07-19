using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTimeCustom : MonoBehaviour
{
    public static float deltaTime = 0f;
    private float lastUpdateTime = 0f;
    public static float TimeScale = 1f;

    void Start()
    {
        lastUpdateTime = Time.realtimeSinceStartup;
    }

    void Update()
    {
        if (TimeScale > 0f)
        {
            deltaTime = Time.realtimeSinceStartup - lastUpdateTime;
            lastUpdateTime = Time.realtimeSinceStartup;
        }

    }
}
