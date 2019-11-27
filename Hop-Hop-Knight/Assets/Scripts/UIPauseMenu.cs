﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIPauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Image[] powerBarLevel;
    public GameObject player;
    private Rigidbody2D playerRB;
    private Player playerScript;
    public Slider dragSlider;
    public Slider powerSlider;
    public Slider gravitySlider;
    public Text gravity;
    public Text drag;
    public Text power;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<Player>();
        playerRB = player.GetComponent<Rigidbody2D>();
        dragSlider.value = playerRB.drag;
        powerSlider.value = playerScript.power;
        gravitySlider.value = playerRB.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        playerRB.drag=dragSlider.value;
        playerScript.power=powerSlider.value;
        playerRB.gravityScale = gravitySlider.value;
        gravity.text = "GravityScale: " + playerRB.gravityScale;
        drag.text="Drag:"+ playerRB.drag;
        power.text = "Power: " + playerScript.power;

        for (int i = 0; i < powerBarLevel.Length; i++)
        {
            powerBarLevel[i].gameObject.SetActive(i < playerScript.cantGemas);
        }
    }

    public void Pause()
    {
        AkSoundEngine.PostEvent("ui_pause_on", gameObject);
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
    }

    public void Unpause()
    {
        AkSoundEngine.PostEvent("ui_pause_off", gameObject);
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
    }

    public void Menu()
    {
        AkSoundEngine.PostEvent("ui_home", gameObject);
        Player.platformTouch -= FindObjectOfType<CameraMovement>().Advance;
        SceneManager.LoadScene("IntroScene");
        GameManager.Get().score = 0;
    }
    
}
