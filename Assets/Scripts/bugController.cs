using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugController : MonoBehaviour
{
    public Transform playerTransform;
    public Rigidbody2D enemyRigidbody;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Move to player
        float dy = playerTransform.position.y - enemyRigidbody.position.y;
        float dx = playerTransform.position.x - enemyRigidbody.position.x;
        float magnitude = Mathf.Abs(dx) + Mathf.Abs(dy);
        enemyRigidbody.AddForce(new Vector2(dx / magnitude, dy / magnitude) * Time.deltaTime * speed);

        // Look at player
        float AngleRad = Mathf.Atan2(playerTransform.position.y - this.transform.position.y, playerTransform.position.x - this.transform.position.x);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

    }
}
