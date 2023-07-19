using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetives : MonoBehaviour
{
    public int life;

    [Header("Scale")]
    public float ScaleY;
    public float ScaleX;

    public GameObject[] Neighboards;

    public GameManager gameManager;

   
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void DestroyedObjetive() 
    {
        life--;
        if (life <= 0) 
        {
            gameObject.SetActive(false);
            GameManager.CurrentObjetives -= 1;
            gameManager.VictoryCondition();
            return;
        }
    }

}
