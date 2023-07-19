using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IOptimizatedUpdate
{
    public float Jump = 10f;
    public float gravityScale = 10f;
    private float Velocity;
    public float DireccionX;
    private float _dirX;
    [HideInInspector] public ballPool Pool;
     CollisionManager collisionManager;
    [Header("Scale")]
    public float ScaleY;
    public float ScaleX;
    private void Start()
    {
        _dirX = DireccionX;
        StopBall();
        collisionManager = FindAnyObjectByType<CollisionManager>();
    }
    public void Move() 
    {
        Velocity += Physics.gravity.y * gravityScale * Time.deltaTime;
     

        transform.Translate(new Vector3(_dirX, Velocity, 0) * Time.deltaTime);
     }

    public void BallJump() 
    {
        Velocity = Mathf.Sqrt(Jump * -2 * (Physics.gravity.y * gravityScale));
    }

    public void StopBall() 
    {
        Velocity = 0;
        _dirX = 0;
    }
    public void Bounce(string DirectionY,string DirectionX) 
    {
        _dirX = DireccionX;

        switch (DirectionY)
        {
            case "Down":
                Velocity = -Mathf.Sqrt(Jump * -2 * (Physics.gravity.y * gravityScale));
                break;
            case "Up":
                Velocity = Mathf.Sqrt(Jump * -2 * (Physics.gravity.y * gravityScale));
                break;
           
        }

        switch (DirectionX)
        {
            case "Left":
                DireccionX = -Mathf.Abs(DireccionX);
                break;
            case "Right":
                DireccionX = Mathf.Abs(DireccionX);
                break;

        }
        Vector3 movement = new Vector3(_dirX, Velocity, 0);

        // Mover la pelota
        transform.Translate(movement * Time.deltaTime);
    }

    public void RandomBounce(string DirY)
    {
        int random = Random.Range(0, 2);

        switch (random)
        {
            case 0:
                Bounce(DirY, "Right");
                break;
            case 1:
                Bounce(DirY, "Left");
                break;
        }
    }

    public void Op_UpdateGameplay()
    {
        if (GameManager.isStart == false )
        {
            collisionManager.isCollisionWithBall(this);
            collisionManager.CheckCollisionWithObjectives(this);
            Move();
            collisionManager.LostBall(this);
        }
       
        collisionManager.CheckCollisionWithPlataform(this);

    }

    public void Op_UpdateUX()
    {
        throw new System.NotImplementedException();
    }
}
