using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IOptimizatedUpdate
{
    private bool isPause = false;

    public Canvas _Canvas;
    public GameUI GameUI;

    public static int CurrentObjetives;
    private void Awake()
    {
        CurrentObjetives = FindObjectsOfType<Objetives>().Length;
    }
    public void Start()
    {
     
        isStart = true;
    }
    public void Op_UpdateGameplay()
    {
        Pause();

        
    }public void VictoryCondition() 
    {
        if (CurrentObjetives <= 0) 
        {
            GameUI.Winning();
         
            IsPause(true);
        }
    }

    public void LoseCondition() 
    {
        GameUI.LoseGame();
        IsPause(true);
    }
    void Pause() 
    {
        if (isPause && Input.GetKeyDown(KeyCode.Escape)) 
        {
            SceneManager.LoadScene("Scenes/menu");
        }
        if (Input.GetKey(KeyCode.Return) && isPause)
        {
                IsPause(false);
                return;
        }
        if (Input.GetKey(KeyCode.Escape) && !isPause)
        {
            IsPause(true);
            return;
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
