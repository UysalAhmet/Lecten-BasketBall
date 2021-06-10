using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform DustParticle, IsGroundCheck;
    public Vector3 velocity;
    Touch touch;

    // Start is called before the first frame update
    public bool IsGrounded = true;
    Rigidbody Ball;
    Vector2 gecispos;
    Vector2 camerapos;
   public GameObject obj;
    Collider cl;
    public PhysicMaterial jump;
    //public GameObject BasketBall;
    void Start()
    {
        Ball = this.GetComponent<Rigidbody>();
        cl = this.GetComponent<Collider>();
       // velocity = Ball.velocity;
        // BasketBall = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position = Camera.main.transform.position;
        //velocity = Ball.velocity;
        //float yatay = Input.GetAxis("Horizontal");
        //float dikey = Input.GetAxis("Vertical");

        //Vector3 v = new Vector3(yatay,0, dikey);

        //if (yatay != 0 || dikey != 0)
        //{
        //    Ball.AddForce(v * 10f);
        //}
        //else if(Input.GetMouseButtonDown(0))
        //{
        //    Ball.AddForce(0, 300, 300);
        //}
        //if (Input.touchCount > 0)
        //{
        //    touch = Input.GetTouch(0);
        //    if (touch.phase == TouchPhase.Moved)
        //    {
        //        Ball.transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * 10, transform.position.y, transform.position.z + touch.deltaPosition.y * 10);
        //    }
        //}
      

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
           
            Transform go = Instantiate(DustParticle, transform.position, Quaternion.identity);
            Destroy(go.gameObject, 0.5f);

            //Vector3 vel = Ball.velocity;
            //vel.y += 5 * Time.deltaTime;
            //Ball.velocity = vel;
            //Ball.AddForce(new Vector3(0,1000,0));
            //transform.position += Vector3.up * 100f * Time.deltaTime;
            
           // cl.material = jump;
            
           
        }
       
       

    }


}
