using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{
    public int currentTextFrame = 0;
    float timeSinceLastTstep = 0;
    public TextMeshProUGUI usernameText;
    public TextMeshProUGUI passwordText;
    public Image Login;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup >= timeSinceLastTstep + 0.2)
        {
            timeSinceLastTstep = Time.realtimeSinceStartup;
            if (currentTextFrame == 0)
            {
                usernameText.text = "R";
                currentTextFrame++;

            }
            else if (currentTextFrame == 1)
            {
                usernameText.text = "RO";
                currentTextFrame++;
            }
            else if (currentTextFrame == 2)
            {
                usernameText.text = "ROO";
                currentTextFrame++;
            }
            else if (currentTextFrame == 3)
            {
                usernameText.text = "ROOT";
                currentTextFrame++;
            }
            else if (currentTextFrame == 4)
            {
                passwordText.text = "*";
                currentTextFrame++;
            }
            else if (currentTextFrame == 5)
            {
                passwordText.text = "**";
                currentTextFrame++;
            }
            else if (currentTextFrame == 6)
            {
                passwordText.text = "***";
                currentTextFrame++;
            }
            else if (currentTextFrame == 7)
            {
                passwordText.text = "****";
                currentTextFrame++;
            }
            else if (currentTextFrame == 8)
            {
                passwordText.text = "*****";
                currentTextFrame++;
            }
            else if (currentTextFrame == 9)
            {
                passwordText.text = "******";
                currentTextFrame++;
            }
            else if (currentTextFrame == 10)
            {
                passwordText.text = "*******";
                currentTextFrame++;
            }
            else if (currentTextFrame == 11)
            {
                passwordText.text = "********";
                currentTextFrame++;
            }
            else if (currentTextFrame == 12)
            {
                passwordText.text = "*********";
                currentTextFrame++;
            }
            else if (currentTextFrame == 11)
            {
                passwordText.text = "**********";
                currentTextFrame++;
            }
            else if (currentTextFrame == 13)
            {
                Login.color = new Color(0.6f, 0.6f, 0.6f);
                currentTextFrame++;
            }
            else if (currentTextFrame == 14)
            {
                SceneManager.LoadScene("GameScene");
            }





        }
    }
}
