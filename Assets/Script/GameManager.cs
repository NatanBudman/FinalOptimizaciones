using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IOptimizatedUpdate
{
    private bool isPause = false;

    public Canvas _Canvas;
    public void Start()
    {
        isStart = true;
    }
    public void Op_UpdateGameplay()
    {
        Pause();

    }
    
    void Pause() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPause)
            {
                IsPause(true);
                return;
            }
            else 
            {
                IsPause(false);
                return;
            }
         
        }
    }

    public void IsPause( bool IsPause) 
    {
        if (IsPause)
        {
            _Canvas.enabled = true;
            isPause = true;
            Time.timeScale = 0;
            Debug.Log("2");
            return;

        }
        else if (!IsPause)
        {
            Debug.Log("p");
            _Canvas.enabled = false;
            isPause = false;
            Time.timeScale = 1;
            return;
        }
    }

    public static bool isStart;
    
    public void Op_UpdateUX()
    {
    }
}
