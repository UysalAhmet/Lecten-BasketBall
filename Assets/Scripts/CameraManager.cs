using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //public Rigidbody ball;
    //float xRot, yRot = 0f;
    //public float rotationspeed=5f;
    //Vector3 offset =new Vector3();
    public GameObject target,cam,ball;
    public float xOffset, yOffset, zOffset;
    public float sensivity = 5f;
    public Vector2 turn;
    Touch touch;
    float positiony;

    // Start is called before the first frame update

    public bool RotateAroundPlayer = true;
    public float RotateSpeed = 5f;
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 offset = cam.transform.position - transform.position;
        //...
        //CameraPos = ballPos + offset;
        //Vector3 nv = new Vector3(0f, target.transform.position.y, target.transform.position.z);
        cam.transform.position = new Vector3(transform.position.x, 0f, transform.position.z)/* target.transform.position */+ new Vector3(xOffset, yOffset, zOffset);
        cam.transform.rotation =  Quaternion.Euler(20, 0, 0);

        //transform.rotation =  Quaternion.Euler(turn.x, 0, 0);

        // transform.position = nv + new Vector3(xOffset, yOffset, zOffset);
        transform.LookAt(target.transform.position);
        //transform.position = ball.position+offset;

        //if (Input.GetMouseButton(0))
        //{
        //turn.x += Input.GetAxis("Mouse X");// * sensivity;
       
       // transform.Rotate(0f, turn.x, 0f);
        // turn.y += Input.GetAxis("Mouse Y")*sensivity;

        //transform.rotation = Quaternion.Euler(turn.y, turn.x, 0);
        //transform.rotation = Quaternion.Euler(0f, turn.x, 0f);
        //transform.position = new Vector3(turn.x, 0f, 0f);
        //transform.rotation = Quaternion.Euler(0f, turn.x, 0f);
        //}
    }
}
