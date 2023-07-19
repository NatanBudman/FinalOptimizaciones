using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour, IOptimizatedUpdate
{
    public void Op_UpdateGameplay()
    {
        throw new System.NotImplementedException();
    }

    public void Op_UpdateUX()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");

        }
    }




}
