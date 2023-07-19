using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour,IOptimizatedUpdate
{

    public Plataform plataform;
    public int StartHeightDetectedColliders;
    public MultiBall power;
    public List<GameObject> Collisions;
    public float MaxHeight;
    public float MinHeight;
    public float MaxHorizontal;
    public float MinHorizontal;
    public GameObject ballPrefab;
    public float rangeIterationCollision;
    public ballPool ballPool;
    public int totalLifes = 3;
    private int currentLifes;
    public GameObject multiballPrefab;
    public int ballsCount = 0;
    private Dictionary<GameObject, bool> powerUps = new Dictionary<GameObject, bool>();
    public GameObject[] powers;


    GameManager gameManager;
     private void Start()
     {
        gameManager = FindObjectOfType<GameManager>();
        currentLifes = totalLifes;
        Vector3 playerPosition = new Vector3(plataform.transform.position.x, plataform.transform.position.y + plataform.ScaleY * 0.5f, plataform.transform.position.z);
        LaunchNewBall(playerPosition, plataform.transform);

    }
    public void isCollisionWithBall(Ball ball) 
    {
        // Rebota si no esta en la plataforma

            if (ball.transform.position.x > MaxHorizontal && ball.transform.position.y < MinHeight)
            {
                ball.RandomBounce("Up");
                return ;

            }
            if (ball.transform.position.x < MinHorizontal && ball.transform.position.y < MinHeight)
            {
                ball.RandomBounce("Up");
                return ;
            }

            // Toca izquierda
            if (ball.transform.position.x < MinHorizontal)
            {
                ball.Bounce("Up", "Right");
                return ;


            }
        // Toca derecha
            if (ball.transform.position.x > MaxHorizontal) 
            {
                ball.Bounce("Up", "Left");
                return ;

            }
           
            // Toca Techo
            if (ball.transform.position.y > MaxHeight)
            {
                ball.RandomBounce("Down");
                return ;
            }
        
    }
    public void CheckPowerUpCollision()
    {
        foreach (GameObject powerUp in powers)
        {
            if (powerUps.ContainsKey(powerUp))
            {
                if (powerUps[powerUp] == false)
                {
                    if (OnCheckCollision(plataform.gameObject, powerUp, plataform.ScaleX, plataform.ScaleY, powerUp.GetComponent<Renderer>().bounds.size.x, powerUp.GetComponent<Renderer>().bounds.size.y))
                    {

                        // Verifica si el power-up es el Multiball
                        if (powerUp.CompareTag("PowerUp"))
                        {


                            // Destruye el power-up
                            powerUp.SetActive(false);
                            RemoveCollision(powerUp);
                            // Lanza 2 nuevas pelotas desde la posición del jugador
                            Vector3 playerPosition = plataform.transform.position;
                            LaunchNewBall(playerPosition);
                            LaunchNewBall(playerPosition);
                            powerUps[powerUp] = true;
                        }
                    }

                }

            }
          
        }
    }

    private void LaunchNewBall(Vector3 position)
    {
         GameObject newBall = ballPool.GetBall();
        ballsCount++;
        newBall.transform.position = position;

    }
    private void LaunchNewBall(Vector3 position, Transform parent)
    {
        GameObject newBall = ballPool.GetBall();
        ballsCount++;
        newBall.transform.position = position;
        newBall.transform.SetParent(parent);
    }

    public void Plataform() 
    {
        // Plataform
        if (plataform.transform.position.x - (plataform.transform.localScale.x * 0.5f) < MinHorizontal)
        {
            plataform.PlataformMove(false, true);
        }
        else if (plataform.transform.position.x + (plataform.transform.localScale.x * 0.5f) > MaxHorizontal)
        {
            plataform.PlataformMove(true, false);
        }
        if (plataform.transform.position.x - (plataform.transform.localScale.x * 0.5f) > MinHorizontal && plataform.transform.position.x + (plataform.transform.localScale.x * 0.5f) < MaxHorizontal)
        {
            plataform.PlataformMove(true, true);

        }
    }

    public bool OnCheckCollision(GameObject _selft, GameObject other)
    {

        float _selftLowPosx = _selft.transform.position.x - (_selft.transform.localScale.x * 0.5f);
        float _selftMuchPosX = _selft.transform.position.x + (_selft.transform.localScale.x * 0.5f);
        float _OthertLowPosx = other.transform.position.x - (other.transform.localScale.x * 0.5f);
        float _OtherMuchPosX = other.transform.position.x + (other.transform.localScale.x * 0.5f);

        float _selftLowPosY = _selft.transform.position.y - (_selft.transform.localScale.y * 0.5f);
        float _selftMuchPosY = _selft.transform.position.y + (_selft.transform.localScale.y * 0.5f);
        float _OthertLowPosY = other.transform.position.y - (other.transform.localScale.y * 0.5f);
        float _OtherMuchPosY = other.transform.position.y + (other.transform.localScale.y * 0.5f);

        if (_selftLowPosx <= _OthertLowPosx + other.transform.localScale.x && _selftMuchPosX >= _OthertLowPosx &&
        _selftLowPosY <= _OthertLowPosY + other.transform.localScale.y && _selftMuchPosY >= _OthertLowPosY)
        {
            return true;
        }

        return false;
    }
 
    public bool OnCheckCollision(GameObject _selft, GameObject other, float _SelfScaleX,float _SelftSacaleY, float _OtherScaleX, float _OtherSacaleY)
    {

        float _selftLowPosx = _selft.transform.position.x - (_SelfScaleX * 0.5f);
        float _selftMuchPosX = _selft.transform.position.x + (_SelfScaleX * 0.5f);
        float _OthertLowPosx = other.transform.position.x - (_OtherScaleX * 0.5f);
        float _OtherMuchPosX = other.transform.position.x + (_OtherScaleX * 0.5f);

        float _selftLowPosY = _selft.transform.position.y - (_SelftSacaleY * 0.5f);
        float _selftMuchPosY = _selft.transform.position.y + (_SelftSacaleY * 0.5f);
        float _OthertLowPosY = other.transform.position.y - (_OtherSacaleY * 0.5f);
        float _OtherMuchPosY = other.transform.position.y + (_OtherSacaleY * 0.5f);

        if (_selftLowPosx <= _OthertLowPosx + _OtherScaleX  && _selftMuchPosX >= _OthertLowPosx &&
        _selftLowPosY <= _OthertLowPosY + _OtherSacaleY && _selftMuchPosY >= _OthertLowPosY)
        {
            return true;
        }

        return false;
    }
 
    private void AddCollision(GameObject add) 
    {
        if (!Collisions.Contains(add))
        {
            Collisions.Add(add);
        }
    }

    public void CheckCollisionWithObjectives(Ball ball)
    {

        if (ball.transform.position.y >= rangeIterationCollision)
        {

            List<GameObject> copyColls = new List<GameObject>(Collisions);
            foreach (var coll in copyColls)
            {
                if (coll.activeInHierarchy != false )
                {

                    Objetives obj = coll.GetComponent<Objetives>();

                    if (OnCheckCollision(ball.gameObject, obj.gameObject, ball.ScaleX, ball.ScaleY, obj.ScaleX, obj.ScaleY))
                    {


                        // Si es mayor a la y del padre pica para arriba
                        if (ball.transform.position.y > coll.transform.parent.position.y)
                        {
                            Debug.Log("salta");
                            ball.RandomBounce("Down");

                        }
                        else
                        {
                            ball.BallJump();

                            Debug.Log("baja");

                        }


                        obj.DestroyedObjetive();

                        if (!coll.gameObject.activeInHierarchy)
                        {
                            int lenght = obj.Neighboards.Length;

                            for (int i = 0; i < lenght; i++)
                            {
                                AddCollision(obj.Neighboards[i]);
                            }
                            Collisions.Remove(coll);
                        }

                    }
                }
                else
                {
                    RemoveCollision(coll);
                }
            }

            copyColls = Collisions;

        }
    }
    public void CheckCollisionWithPlataform(Ball ball)
    {
        if (OnCheckCollision(ball.gameObject, plataform.gameObject, ball.ScaleX, ball.ScaleY, plataform.ScaleX, plataform.ScaleY))
        {

            //  ball.transform.SetParent(plataform.transform);
            if (GameManager.isStart == true)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    ball.transform.SetParent(null);
                    GameManager.isStart = false;
                    ball.RandomBounce("Up");
                }

            }
            else
            {
                ball.RandomBounce("Up");
            }


        }

    }
    private void RemoveCollision(GameObject Remove) 
    {
        if (Collisions.Contains(Remove))
        {
            Collisions.Remove(Remove);

        }
    }

    public void LostBall(Ball ball)
    {
        if (ball.transform.position.y < MinHeight)
        {
            if (ball.gameObject.activeInHierarchy) 
            {           
                ballsCount--;
                ballPool.ReturnBallToPool(ball.gameObject);

            }
            if (ballsCount <= 0)
            {
                Vector3 playerPosition = new Vector3(plataform.transform.position.x, plataform.transform.position.y + plataform.ScaleY * 0.5f, plataform.transform.position.z);
                LaunchNewBall(playerPosition, plataform.transform);
                GameManager.isStart = true;
                currentLifes--;
                if (currentLifes <= 0)
                {
                    gameManager.LoseCondition();
                }

            }

        }

    }
    public void Op_UpdateGameplay()
    {
     
    }

    public void Op_UpdateUX()
    {
        throw new NotImplementedException();
    }

}
