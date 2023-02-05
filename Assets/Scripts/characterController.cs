using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class characterController : MonoBehaviour
{
    public gameManager gameManager;
    //public Transform playerTransform;
    public Rigidbody2D playerRigidbody;
    public int speed;
    public int playerHealth;

    bool previousFireButton = false;

    public GameObject gameOverScreen;
    public TextMeshProUGUI finalKillCountText;
    public TextMeshProUGUI killCounterText;
    public GameObject[] heartsObjects;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.currentGameState == gameManager.gameState.paused)
        {
            return;
        }

        // Control X and Y movement
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        
        playerRigidbody.AddForce(new Vector2(horizontalAxis, verticalAxis) * Time.deltaTime * speed);

        // Rotate player to mouse pointer.
        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float AngleRad = Mathf.Atan2(mouseScreenPosition.y - this.transform.position.y, mouseScreenPosition.x - this.transform.position.x);

        float AngleDeg = (180 / Mathf.PI) * AngleRad - 90; // -90 to get texture facing right way

        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);


        // Assuming we only using the single camera ( we are )
        var camera = Camera.main;

        // Lock camera onto player position, this isnt smooth but will be replaced. 
        camera.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,-10);


        // Shooting Code

        
        if (Input.GetButton("Fire1") && !previousFireButton) {
            //Debug.Log("FIRE");
            fireRegular();
        }

        previousFireButton = Input.GetButton("Fire1");


        if (playerHealth == 0)
        {
            //Destroy(this.gameObject);
            gameManager.currentGameState = gameManager.gameState.paused;
            finalKillCountText.text = "Bugs Debugged: " + gameManager.killCounter;
            killCounterText.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);

        }
    }

    // Fire Bullet Function
    public GameObject zeroBulletPrefab;
    public GameObject oneBulletPrefab;

    void fireRegular() {
        int choice = Random.Range(0,2);
        GameObject firedBullet;
        if (choice == 0)
        {
            firedBullet = Instantiate(zeroBulletPrefab, this.transform.position + this.transform.up / 1.3f , Quaternion.Euler(0, 0, this.transform.rotation.eulerAngles.z + 90));
        }
        else
        {
            firedBullet = Instantiate(oneBulletPrefab, this.transform.position + this.transform.up / 1.3f, Quaternion.Euler(0, 0, this.transform.rotation.eulerAngles.z + 90));
        }
        //Destroy(firedBullet, 3);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            playerHealth--;
            heartsObjects[playerHealth].SetActive(false);
            Rigidbody2D enemyRigidbody = col.gameObject.GetComponent<Rigidbody2D>();

            enemyRigidbody.AddForce(col.gameObject.transform.up * -500);

            
        }
    }
}
