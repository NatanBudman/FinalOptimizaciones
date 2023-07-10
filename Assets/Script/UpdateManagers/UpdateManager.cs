using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    
    public List<OptimizatedUpdateGameplay> GameplayUpdates;
    [Space]

    public List<OptimizatedUpdateUX> UXUpdates;
    
    #region FPS

        public int GameplayFPS;
        public int UXFPS;
        
        private float GameplaytimePerFrame;
        private float UItimePerFrame;
        
        private float GameplaynextTime = 0;
        private float UInextTime = 0;


    #endregion

    private void Awake()
    {
        GameplayUpdates = new List<OptimizatedUpdateGameplay>(1000);
        UXUpdates = new List<OptimizatedUpdateUX>(1000);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set Limited FPS
        GameplaytimePerFrame = 1f / GameplayFPS;
        UItimePerFrame = 1f / UXFPS;

    }

    void Update()
    {
        var gameplayLenght = GameplayUpdates.Count;
        var UXLenght = UXUpdates.Count;

        float currentTime = Time.realtimeSinceStartup;

        if (currentTime >= GameplaynextTime)
        {
            List<OptimizatedUpdateGameplay> updatesCopy = new List<OptimizatedUpdateGameplay>(GameplayUpdates);

            foreach (var updateGameplay in updatesCopy)
            {
                if (updateGameplay != null)
                {
                    updateGameplay.UpdateGameplay();
                }
            }
            updatesCopy = GameplayUpdates;

            GameplaynextTime = currentTime + GameplaytimePerFrame;

        }

        if (currentTime >= UInextTime)
        {
            for (int i = 0; i < UXLenght; i++)
            {
                UXUpdates[i].UpdateUX();
            }

            UInextTime = currentTime + UItimePerFrame;
        }

    }

    /*
    void Update()
    {
        var gameplayLenght = GameplayUpdates.Count;
        var UXLenght = UXUpdates.Count;

        GameplaynextTime += Time.deltaTime;
        UInextTime += Time.deltaTime;

        if (GameplaynextTime >= GameplaytimePerFrame)
        {
            List<OptimizatedUpdateGameplay> updatesCopy = new List<OptimizatedUpdateGameplay>(GameplayUpdates);

            foreach (var updateGameplay in updatesCopy)
            {
                if (updateGameplay != null)
                {
                    updateGameplay.UpdateGameplay();
                }
            }
            updatesCopy = GameplayUpdates;

            GameplaynextTime = 0;

        }
      
        if (UInextTime >= UItimePerFrame)
        {
            for (int i = 0; i < UXLenght; i++)
            {
                    UXUpdates[i].UpdateUX();
            }

            UInextTime = 0;
        }
     
    }
    */

    #region Method
    // Agregar objeto a actualizar a la lista
    public void AddUpdate(OptimizatedUpdateGameplay obj)
    {
        if (!GameplayUpdates.Contains(obj))
        {
            GameplayUpdates.Add(obj);
        }
    }

// Quitar objeto de la lista
  public  void RemoveUpdate(OptimizatedUpdateGameplay obj)
    {
        if (GameplayUpdates.Contains(obj))
        {
            GameplayUpdates.Remove(obj);
        }
    }
    public void AddUpdate(OptimizatedUpdateUX UX)
    {
        if (!UXUpdates.Contains(UX))
        {
             UXUpdates.Add(UX);
        }
    }

    public void RemoveUpdate(OptimizatedUpdateUX UX)
    {
        if (UXUpdates.Contains(UX))
        {
            UXUpdates.Remove(UX);
        }
    }


    #endregion
}
