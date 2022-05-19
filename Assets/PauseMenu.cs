using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public GameObject crosshair;
    public AudioSource musicPlayer;
    public GameObject fpsAudio;
    public GameObject menuGemOne;
    public GameObject menuGemTwo;
    public GameObject menuGemThree;
    public GameObject diamond;
    public GameObject star;
    public GameObject sphere;
    public GameObject checkOne; //pertains to diamond gem
    public GameObject checkTwo; //pertains to star gem
    public GameObject checkThree; //pertains to sphere gem
    public GameObject shiggins;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        crosshair.SetActive(true);
        musicPlayer.Play();
        fpsAudio.SetActive(true);
        menuGemOne.SetActive(false);
        menuGemTwo.SetActive(false);
        menuGemThree.SetActive(false);
        checkOne.SetActive(false);
        checkTwo.SetActive(false);
        checkThree.SetActive(false);
        shiggins.SetActive(false);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        crosshair.SetActive(false);
        musicPlayer.Pause();
        fpsAudio.SetActive(false);
        menuGemOne.SetActive(true);
        menuGemTwo.SetActive(true);
        menuGemThree.SetActive(true);
        ShowChecks();
        if(RandomShig())
        {
            shiggins.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void ShowChecks()
    {
        if(!diamond.activeSelf)
        {
            checkOne.SetActive(true);
        }
        if(!star.activeSelf)
        {
            checkTwo.SetActive(true);
        }
        if(!sphere.activeSelf)
        {
            checkThree.SetActive(true);
        }
    }

    public bool RandomShig()
    {
        System.Random rnd = new System.Random();
        int num = rnd.Next(100);
        if (num == 66)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
