using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    // Velocidad de movimiento
    public float speed;
    private float currSpeed;

    private void Start()
    {
        currSpeed = speed;
    }
 
   public void PlataformMove(bool isCanMoveLeft, bool isCanMoveRight) 
    {
        if (Input.GetKey(KeyCode.A) && isCanMoveLeft)
            transform.Translate(Vector2.up * currSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D) && isCanMoveRight)
            transform.Translate(Vector2.down * currSpeed * Time.deltaTime);
    }
}
