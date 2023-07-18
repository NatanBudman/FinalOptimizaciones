using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    // Velocidad de movimiento
    public float speed;
    private float currSpeed;


    [Header("Scale")]
    public float ScaleY;
    public float ScaleX;
    private void Start()
    {
        currSpeed = speed;
    }
 
   public void PlataformMove(bool isCanMoveLeft, bool isCanMoveRight) 
    {
        if (Input.GetKey(KeyCode.A) && isCanMoveLeft)
            transform.Translate(Vector2.left * currSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D) && isCanMoveRight)
            transform.Translate(Vector2.right * currSpeed * Time.deltaTime);
    }
}
