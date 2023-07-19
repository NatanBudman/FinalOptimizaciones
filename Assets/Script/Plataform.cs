using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour, IOptimizatedUpdate
{
    // Velocidad de movimiento
    public float speed;
    private float currSpeed;
    public CollisionManager collisionManager;

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

    public void Op_UpdateGameplay()
    {
        collisionManager.Plataform();
        collisionManager.CheckPowerUpCollision();
    }

    public void Op_UpdateUX()
    {
        throw new System.NotImplementedException();
    }
}
