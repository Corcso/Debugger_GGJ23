using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
            Debug.Log("test");
        }
        previousEsc = Input.GetAxis("Cancel");
    }

}
