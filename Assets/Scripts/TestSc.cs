using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSc : MonoBehaviour
{
    Touch touch;
    public GameObject cam;
    float x, y, z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                x += touch.deltaPosition.x*Time.deltaTime;
                z += touch.deltaPosition.y*Time.deltaTime;
                cam.transform.Rotate(new Vector3(x, 0f, z)); print("sürüklüyor");
            }
            print(touch.deltaPosition);
           
          

            //if (touch.phase == TouchPhase.Began)
            //{
            //    print("dokunma basladý");
            //    }
            //if (touch.phase == TouchPhase.Stationary)
            //{
            //    print("dokunma devam ediyor");
            //}
            //if (touch.phase == TouchPhase.Moved)
            //{
            //    print("sürüklüyor");
            //}
            //if (touch.phase == TouchPhase.Ended)
            //{
            //    print("dokunma bitti");
            //}
            //if (touch.phase == TouchPhase.Canceled)
            //{
            //    print("iptal");
            //}
        }

    }
}
