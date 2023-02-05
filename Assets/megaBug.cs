using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class megaBug : MonoBehaviour
{
    public gameManager gameManager;

    public Transform playerTransform;

    public Rigidbody2D enemyRigidbody;
    public Collider2D enemyCollider;
    public int speed;
    public int enemyHealth;
    public Sprite[] bugFrame;
    SpriteRenderer bugRenderer;
    public int currentStepFrame = 0;
    public int currentDeathFrame = 2;

    float timeSinceLastTstep = 0;

    public TextMeshProUGUI killCounterText;

    // Start is called before the first frame update
    void Start()
    {
        bugRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
        killCounterText = GameObject.Find("KillCountText").GetComponent<TextMeshProUGUI>();
        enemyCollider = this.gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentGameState == gameManager.gameState.paused)
        {
            return;
        }

        if (enemyHealth > 0)
        {
            // Move to player
            float dy = playerTransform.position.y - enemyRigidbody.position.y;
            float dx = playerTransform.position.x - enemyRigidbody.position.x;
            float magnitude = Mathf.Abs(dx) + Mathf.Abs(dy);
            enemyRigidbody.AddForce(new Vector2(dx / magnitude, dy / magnitude) * Time.deltaTime * speed);

            // Look at player
            float AngleRad = Mathf.Atan2(playerTransform.position.y - this.transform.position.y, playerTransform.position.x - this.transform.position.x);

            float AngleDeg = (180 / Mathf.PI) * AngleRad;

            this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);

            if (Time.realtimeSinceStartup >= timeSinceLastTstep + 0.1 && enemyHealth != 0)
            {
                timeSinceLastTstep = Time.realtimeSinceStartup;
                if (currentStepFrame == 0)
                {
                    currentStepFrame++;
                    bugRenderer.sprite = bugFrame[currentStepFrame];
                }
                else if (currentStepFrame == 1)
                {
                    currentStepFrame = 0;
                    bugRenderer.sprite = bugFrame[currentStepFrame];
                }
            }
        }

        if (enemyHealth <= 0)
        {
            if (Time.realtimeSinceStartup >= timeSinceLastTstep + 0.2)
            {
                timeSinceLastTstep = Time.realtimeSinceStartup;
                if (currentDeathFrame == 2)
                {
                    bugRenderer.sprite = bugFrame[currentDeathFrame];
                    currentDeathFrame++;
                    gameManager.killCounter++;
                    killCounterText.text = "Bugs Debugged: " + gameManager.killCounter;
                    Destroy(enemyCollider); // Delete the collider so the bullets dont get caught on dead bugs
                }
                else if (currentDeathFrame == 3)
                {
                    bugRenderer.sprite = bugFrame[currentDeathFrame];
                    currentDeathFrame++;
                }
                else if (currentDeathFrame == 4)
                {
                    bugRenderer.sprite = bugFrame[currentDeathFrame];
                    currentDeathFrame++;
                }
                else if (currentDeathFrame == 5)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet" && enemyHealth > 0)
        {
            enemyHealth--;
            Destroy(col.gameObject);
        }
    }
}
