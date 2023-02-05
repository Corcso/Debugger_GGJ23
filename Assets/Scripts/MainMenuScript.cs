using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public AudioSource buttonClickSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Function to Quit the game
    public void QuitGame() {
        Application.Quit();
    }

    public void PlayGame()
    {
        buttonClickSound.Play();
        SceneManager.LoadScene("preGameCutscene");
    }

    public GameObject optionsMenuObject;
    public GameObject controlsButton;
    public GameObject quitButton;
    public void ShowControls()
    {
        buttonClickSound.Play();
        optionsMenuObject.SetActive(true);
        controlsButton.SetActive(false);
        quitButton.SetActive(false);

    }

    public void HideOptions()
    {
        buttonClickSound.Play();
        optionsMenuObject.SetActive(false);
        controlsButton.SetActive(true);
        quitButton.SetActive(true);
    }
}
