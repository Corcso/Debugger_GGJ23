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

    public AudioSource keyPressSound;
    public AudioSource clickSound;
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
                keyPressSound.Play();
                usernameText.text = "R";
                currentTextFrame++;

            }
            else if (currentTextFrame == 1)
            {
                keyPressSound.Play();
                usernameText.text = "RO";
                currentTextFrame++;
            }
            else if (currentTextFrame == 2)
            {
                keyPressSound.Play();
                usernameText.text = "ROO";
                currentTextFrame++;
            }
            else if (currentTextFrame == 3)
            {
                keyPressSound.Play();
                usernameText.text = "ROOT";
                currentTextFrame++;
            }
            else if (currentTextFrame == 4)
            {
                keyPressSound.Play();
                passwordText.text = "*";
                currentTextFrame++;
            }
            else if (currentTextFrame == 5)
            {
                keyPressSound.Play();
                passwordText.text = "**";
                currentTextFrame++;
            }
            else if (currentTextFrame == 6)
            {
                keyPressSound.Play();
                passwordText.text = "***";
                currentTextFrame++;
            }
            else if (currentTextFrame == 7)
            {
                keyPressSound.Play();
                passwordText.text = "****";
                currentTextFrame++;
            }
            else if (currentTextFrame == 8)
            {
                keyPressSound.Play();
                passwordText.text = "*****";
                currentTextFrame++;
            }
            else if (currentTextFrame == 9)
            {
                keyPressSound.Play();
                passwordText.text = "******";
                currentTextFrame++;
            }
            else if (currentTextFrame == 10)
            {
                keyPressSound.Play();
                passwordText.text = "*******";
                currentTextFrame++;
            }
            else if (currentTextFrame == 11)
            {
                keyPressSound.Play();
                passwordText.text = "********";
                currentTextFrame++;
            }
            else if (currentTextFrame == 12)
            {
                keyPressSound.Play();
                passwordText.text = "*********";
                currentTextFrame++;
            }
            else if (currentTextFrame == 11)
            {
                keyPressSound.Play();
                passwordText.text = "**********";
                currentTextFrame++;
            }
            else if (currentTextFrame == 13)
            {
                clickSound.Play();
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
