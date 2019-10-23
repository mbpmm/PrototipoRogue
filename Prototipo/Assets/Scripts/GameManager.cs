﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonobehaviourSingleton<GameManager>
{
    public int score;
    public Player2 player;

    // Start is called before the first frame update
    void Start()
    {
        Player2.platformTouch += AddScore;
        Player2.playerDeath += PlayerDied;
    }
    private void Update()
    {
        
    }

    void AddScore()
    {
        score++;
    }

    void PlayerDied()
    {
        if (score>PlayerPrefs.GetInt("Highscore",0))
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
        
        score = 0;
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator LoadSceneAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("SampleScene");
    }
}
