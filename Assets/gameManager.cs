using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public enum gameState { 
        playing,
        paused
    }
    public gameState currentGameState;

    public float difficulty = 1;

    public int killCounter = 0;

    float timeSinceLastDiffIncrease = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGameState == gameState.playing)
        {
            if (Time.realtimeSinceStartup >= timeSinceLastDiffIncrease + 0.1)
            {
                timeSinceLastDiffIncrease = Time.realtimeSinceStartup;
                difficulty += 0.003f;
            }
        }
    }
}
