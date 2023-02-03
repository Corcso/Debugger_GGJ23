using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{

    //public Transform playerTransform;
    public Rigidbody2D playerRigidbody;
    public int speed;

    bool previousFireButton = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Control X and Y movement
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        
        playerRigidbody.AddForce(new Vector2(horizontalAxis, verticalAxis) * Time.deltaTime * speed);

        // Rotate player to mouse pointer.
        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float AngleRad = Mathf.Atan2(mouseScreenPosition.y - this.transform.position.y, mouseScreenPosition.x - this.transform.position.x);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);


        // Assuming we only using the single camera ( we are )
        var camera = Camera.main;

        // Lock camera onto player position, this isnt smooth but will be replaced. 
        camera.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,-10);


        // Shooting Code

        
        if (Input.GetButton("Fire1") && !previousFireButton) {
            Debug.Log("FIRE");
        }

        previousFireButton = Input.GetButton("Fire1");
    }
}
