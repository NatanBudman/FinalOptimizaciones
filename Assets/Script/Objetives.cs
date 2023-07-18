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

    public void DestroyedObjetive() 
    {
        life--;
        if(life <= 0)
        gameObject.SetActive(false);
    }

}
