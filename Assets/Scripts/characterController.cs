using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{

    //public Transform playerTransform;
    public Rigidbody2D playerRigidbody;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        //playerTransform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime * speed;
        playerRigidbody.AddForce(new Vector2(horizontalAxis, verticalAxis) * Time.deltaTime * speed);

        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float AngleRad = Mathf.Atan2(mouseScreenPosition.y - this.transform.position.y, mouseScreenPosition.x - this.transform.position.x);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);


        //assuming we only using the single camera:
        var camera = Camera.main;

        camera.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,-10);
    }
}
