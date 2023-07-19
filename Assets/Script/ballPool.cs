using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballPool : MonoBehaviour
{
    public GameObject ballPrefab;

    public int poolSize = 10;

    private Queue<GameObject> balls;

    void Start()
    {
        balls = new Queue<GameObject>();

        // Instancia las balas y a��delas a la queue
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(ballPrefab, transform);
            bullet.SetActive(false);
            balls.Enqueue(bullet);
        }
    }

    // Retorna una bala del pool
    public GameObject GetBall()
    {
        OptimizatedUpdateGameplay update = null;
        if (balls.Count == 0)
        {

            GameObject bullet = Instantiate(ballPrefab, transform);
            update = bullet.GetComponent<OptimizatedUpdateGameplay>();
            bullet.SetActive(false);
            balls.Enqueue(bullet);
        }

        GameObject bulletToReturn = balls.Dequeue();

        bulletToReturn.SetActive(true);

        update = bulletToReturn.GetComponent<OptimizatedUpdateGameplay>();

        return bulletToReturn;
    }

    // Devuelve una bala al pool
    public void ReturnBallToPool(GameObject ball)
    {
        ball.SetActive(false);
        balls.Enqueue(ball);
    }
}
