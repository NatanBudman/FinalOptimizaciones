using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour,IOptimizatedUpdate
{
    public Plataform plataform;
    public Ball ball;
    public Transform bola;
    public int StartHeightDetectedColliders;

    public List<GameObject> Collisions;

    public float MaxHeight;
    public float MinHeight;
    public float MaxHorizontal;
    public float MinHorizontal;

    public float rangeIterationCollision;
    bool isCollisionWhithPlataform = false;

    private void Walls() 
    {
        // Rebota si no esta en la plataforma
        if (!isCollisionWhithPlataform)
        {

            if (ball.transform.position.x > MaxHorizontal && ball.transform.position.y < MinHeight)
            {
                ball.RandomBounce("Up");
                ball.transform.SetParent(null);
                return;

            }
            if (ball.transform.position.x < MinHorizontal && ball.transform.position.y < MinHeight)
            {
                ball.RandomBounce("Up");
                ball.transform.SetParent(null);
                return;
            }
            if (ball.transform.position.x < MinHorizontal)
            {
                ball.Bounce("Up", "Right");
                ball.transform.SetParent(null);
                return;


            }
            if (ball.transform.position.x > MaxHorizontal) 
            {
                ball.Bounce("Up", "Left");
                ball.transform.SetParent(null);
                return;

            }
            if (ball.transform.position.y < MinHeight)
            {
                ball.RandomBounce("Up");
                ball.transform.SetParent(null);
                return;


            }
            if (ball.transform.position.y > MaxHeight)
            {
                ball.RandomBounce("Down");
                ball.transform.SetParent(null);
                return;


            }
        }
    }
    private void Plataform() 
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

    private void AddCollision(GameObject add) 
    {
        if (!Collisions.Contains(add))
        {
            Collisions.Add(add);
        }
    }

    private void RemoveCollision(GameObject Remove) 
    {
        if (Collisions.Contains(Remove))
        {
            Collisions.Remove(Remove);

        }
    }

    public void Op_UpdateGameplay()
    {
        ball.Move();
        // Chequea collisiones cuando pasa determinado valor Y
        if (ball.transform.position.y >= rangeIterationCollision)
        {
            List<GameObject> copyColls = new List<GameObject>(Collisions);
            foreach (var coll in copyColls)
            {
                if (OnCheckCollision(bola.gameObject, coll))
                {
                    Objetives obj = coll.GetComponent<Objetives>();

                    if (ball.transform.position.y > coll.transform.parent.position.y)
                        ball.BallJump();
                    else
                        ball.RandomBounce("Down");

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

            copyColls = Collisions;
        }

        if (ball.transform.position.y < plataform.transform.position.y + 1)
        {
            if (OnCheckCollision(bola.gameObject, plataform.gameObject))
            {

                isCollisionWhithPlataform = true;
                ball.transform.SetParent(plataform.transform);

                if (Input.GetKey(KeyCode.Space))
                {
                    ball.transform.SetParent(null);
                    isCollisionWhithPlataform = false;
                    ball.RandomBounce("Up");
                }
                else
                {
                    ball.StopBall();
                }
            }
        }



        Plataform();
        Walls();
    }

    public void Op_UpdateUX()
    {
        throw new System.NotImplementedException();
    }
}
