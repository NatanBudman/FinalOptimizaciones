using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetives : MonoBehaviour
{
    public int life;
    public GameObject[] Neighboards;

    public void DestroyedObjetive() 
    {
        life--;
        if(life <= 0)
        gameObject.SetActive(false);
    }

}
