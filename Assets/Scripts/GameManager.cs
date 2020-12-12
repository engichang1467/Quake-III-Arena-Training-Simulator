/**
    **GameManager.cs**

    This file focus on allowing the player to restart after falling off the map
    
    ----

    *Created by Michael Chang on 12-12-2020*

    *Copyright (c) 2020. All rights reserved*
*/
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            // Restart game
            Invoke("Restart", restartDelay);
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
