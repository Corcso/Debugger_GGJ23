using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public gameManager gameManager;
    public float bulletSpeed;

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

        this.transform.position += this.transform.right * Time.deltaTime * bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
