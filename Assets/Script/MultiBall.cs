using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBall : MonoBehaviour, IOptimizatedUpdate
{
    public float ScaleY;
    public float ScaleX;
    private float _dirX;
    public float gravityScale = 10f;
    private float Velocity;
    public GameObject bloque;
    void Start()
    {
        
    }

  
    public void Op_UpdateGameplay()
    {

        if (!bloque.gameObject.activeSelf)
        {
            Move();
        }

    }
    public void Move()
    {
        Velocity += Physics.gravity.y * gravityScale * Time.deltaTime;


        transform.Translate(new Vector3(_dirX, Velocity, 0) * Time.deltaTime);
    }
    public void Op_UpdateUX()
    {
        throw new System.NotImplementedException();
    }
}
