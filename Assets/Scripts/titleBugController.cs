using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleBugController : MonoBehaviour
{

    public float wantX, wantY;

    public Rigidbody2D enemyRigidbody;
    public int speed;
    public Sprite[] bugFrame;
    SpriteRenderer bugRenderer;
    public int currentStepFrame = 0;

    float timeSinceLastTstep = 0;

    // Start is called before the first frame update
    void Start()
    {
        bugRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        // Move to player
        float magnitude = Mathf.Abs(wantX) + Mathf.Abs(wantY);
        enemyRigidbody.AddForce(new Vector2(wantX / magnitude, wantY / magnitude) * Time.deltaTime * speed);

        // Look at player
        float AngleRad = Mathf.Atan2(wantY, wantX);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);

        if (Time.realtimeSinceStartup >= timeSinceLastTstep + 0.1)
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
       
}
