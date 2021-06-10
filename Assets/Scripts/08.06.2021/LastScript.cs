using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject basketBall;
    public Vector3 offset;
    public GameObject cam,obj,Basket;
    public ParticleSystem leftConfetti, rightConfetti, bursConfetti;

    private Vector3 firstpoint; //change type on Vector3
    private Vector3 secondpoint;
    private float xAngle = 0.0f; //angle for axes x for rotation
    private float yAngle = 0.0f;
    private float xAngTemp = 0.0f; //temp variable for angle
    private float yAngTemp = 0.0f;
    private float temp = 0f;
    void Start()
    {
        Basket.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        xAngle = 0.0f;
        yAngle = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.position = new Vector3( basketBall.transform.position.x,obj.transform.position.y,basketBall.transform.position.z);
        
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

                //cam.transform.position = ball.transform.position;
                secondpoint = Input.GetTouch(0).position;
                //Mainly, about rotate camera. For example, for Screen.width rotate on 180 degree
                xAngle = (float)(xAngTemp + (secondpoint.x - firstpoint.x) * 180.0 / Screen.width);
                yAngle = (float)(yAngTemp - (secondpoint.y - firstpoint.y) * 90.0 / Screen.height);
                temp = xAngle;

                //Rotate camera
                obj.transform.rotation = Quaternion.Euler(0f, -xAngle, 0f);
                //cam.transform.GetComponent<Rigidbody>().AddForce((cam.transform.forward + new Vector3(0, 0, -yAngle)) * Time.deltaTime * 500);
                //print(yAngle);
                //cam.transform.position = cam.transform.position - new Vector3(0, 0, yAngle/30f);
                if((basketBall.transform.GetComponent<Rigidbody>().velocity.z<=10||  basketBall.transform.GetComponent<Rigidbody>().velocity.x <= 10)&& yAngle!=0 )
                basketBall.transform.GetComponent<Rigidbody>().AddForce(/*new Vector3(yAngle,0f,xAngle)+*/cam.transform.forward * 750f * Time.deltaTime);
                //print("güç uygulandý");
                //rb.AddForce(new Vector3(-xAngle*300*Time.deltaTime,0,0));
                //ball.transform.position = cam.transform.forward;
                yAngle = 0;
                //xAngle = 0;
            }

        }
        else
        {
            //basketBall.transform.GetComponent<Rigidbody>().velocity = new Vector3(0, basketBall.transform.GetComponent<Rigidbody>().velocity.y, 0);
            



        }
    }
}
