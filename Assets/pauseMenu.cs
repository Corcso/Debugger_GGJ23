using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pauseMenu : MonoBehaviour
{
    public gameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>(); 
    }

    public GameObject pauseMenuObject;
 
    float previousEsc = 0;
    bool isPauseOpen = false;
    // Update is called once per frame
    void Update()
    {
       
        
        
        if (Input.GetAxis("Cancel") == 1 && previousEsc != 1)
        {
            isPauseOpen = !isPauseOpen;
            pauseMenuObject.SetActive(isPauseOpen);
            
            if (isPauseOpen)
            {
                gameManager.currentGameState = gameManager.gameState.paused;
            }
            else
            {
                gameManager.currentGameState = gameManager.gameState.playing;
            }
        }
        previousEsc = Input.GetAxis("Cancel");
    }

    public void QuitMenu()
    {
        SceneManager.LoadScene("Title_Scene");
    }
}
