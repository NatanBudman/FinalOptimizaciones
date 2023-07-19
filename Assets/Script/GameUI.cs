using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public GameObject Win;
    public GameObject Lose;

    public void Winning() 
    {
        Win.gameObject.SetActive(true);
    }
    public void LoseGame()
    {
        Lose.gameObject.SetActive(true);

    }
}
