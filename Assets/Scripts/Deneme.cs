using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball, cam;
    public float xOffset, yOffset, zOffset;
    Touch touch;
    float positiony, x, y, z;
    Rigidbody rb;
    public GameObject Basket;



    private Vector3 firstpoint; //change type on Vector3
    private Vector3 secondpoint;
    private float xAngle = 0.0f; //angle for axes x for rotation
    private float yAngle = 0.0f;
    private float xAngTemp = 0.0f; //temp variable for angle
    private float yAngTemp = 0.0f;

    void Start()
    {
        xAngle = 0.0f;
        yAngle = 0.0f;
        this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
        rb = ball.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = transform.position - ball.transform.position;

        transform.position = Basket.transform.position;// new Vector3(ball.transform.position.x, transform.position.y, ball.transform.position.z)/* target.transform.position */+ new Vector3(xOffset, yOffset, zOffset);
        cam.transform.LookAt(Basket.transform.GetChild(0));
        //if(xOffset<ball.transform.localPosition.x)
        //cam.transform.localPosition = new Vector3(ball.transform.localPosition.x - xOffset, 0f, ball.transform.localPosition.z-zOffset);// ball.transform.position;//Basket.transform.position+ new Vector3(xOffset, yOffset, zOffset);
        //ball.transform.position = cam.transform.position;//+ new Vector3(xOffset,yOffset,zOffset);
        // cam.transform.Rotate(20,0,0);



        if (Input.touchCount > 0)
        {
            //Touch began, save position
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                firstpoint = Input.GetTouch(0).position;
                xAngTemp = xAngle;
                yAngTemp = yAngle;
            }
            //Move finger by screen
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                cam.transform.position = ball.transform.position;
                secondpoint = Input.GetTouch(0).position;
                //Mainly, about rotate camera. For example, for Screen.width rotate on 180 degree
                xAngle = (float)(xAngTemp + (secondpoint.x - firstpoint.x) * 180.0 / Screen.width);
                yAngle = (float)(yAngTemp - (secondpoint.y - firstpoint.y) * 90.0 / Screen.height);
               
                //Rotate camera
                this.transform.rotation = Quaternion.Euler(0f, xAngle , 0.0f);
                //cam.transform.GetComponent<Rigidbody>().AddForce((cam.transform.forward + new Vector3(0, 0, -yAngle)) * Time.deltaTime * 500);
                print(yAngle);
                // cam.transform.position = cam.transform.position - new Vector3(0, 0, yAngle/30f);
                 //rb.AddForce(cam.transform.forward * 750f * Time.deltaTime);
                //print("güç uygulandý");
                //rb.AddForce(new Vector3(-xAngle*300*Time.deltaTime,0,0));
                //ball.transform.position = cam.transform.forward;
                yAngle = 0;
            }

        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            cam.transform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);



        }

    }
}