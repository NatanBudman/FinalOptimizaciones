using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetives : MonoBehaviour
{
    public int life;
    public GameObject[] Neighboards;

    int rayLength = 12;

    List<GameObject> n ;
 
    void Raycast(Vector3 start,Vector3 direction)
    {
        RaycastHit hit;
        Physics.Raycast(start, direction, out hit, rayLength);

        if (hit.collider != null)
        {
            n.Add(hit.collider.gameObject);
        }
    }
    public void DestroyedObjetive() 
    {
        life--;
        if(life <= 0)
        gameObject.SetActive(false);
    }

}
