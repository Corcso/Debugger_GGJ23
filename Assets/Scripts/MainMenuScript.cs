using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
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
        Debug.Log("Play Game Presssed");
    }

    public GameObject optionsMenuObject;
    public void ShowControls()
    {
        optionsMenuObject.SetActive(true);

    }

    public void HideOptions()
    {
        optionsMenuObject.SetActive(false);
    }
}
