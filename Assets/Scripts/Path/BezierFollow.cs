using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BezierFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform[] routes;
    private int routoToGo;
    private float tParam;
    private Vector3 CubePosition;
    private float speedModifier;
    public Transform leftConfetti, rightConfetti, bursConfetti;
    public GameObject Basket;
    //private bool coroutineAllowed;
    Touch touch;
    void Start()
    {
        routoToGo = 0;
        tParam = 0f;
        speedModifier = 0.5f;
        //coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            
            if (Input.touchCount == 2)
            {
                touch = Input.GetTouch(1);

                if (touch.phase == TouchPhase.Began)
                {
                    //print("sa");
                    // Halve the size of the cube.
                    //this.transform.GetComponent<Rigidbody>().detectCollisions = false;
                    StartCoroutine( GoByTheRoute(routoToGo));
                    this.transform.GetComponent<Collider>().material.bounciness =0.2f;
                   
                    
                    

                }
            }
        }


    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(0);
    }
    IEnumerator RenkDegistir(float time)
    {
        Basket.GetComponent<Renderer>().material.color = Color.Lerp(Basket.GetComponent<Renderer>().material.color, Color.yellow, 1f);
        yield return new WaitForSeconds(time);
        Basket.GetComponent<Renderer>().material.color = Color.Lerp(Basket.GetComponent<Renderer>().material.color, Color.red, 1f);
    }
    private IEnumerator GoByTheRoute(int routeNumber)
    {

        //print("sa");
        //coroutineAllowed = false;
        routes[routeNumber].GetChild(0).position = transform.position;
        routes[routeNumber].GetChild(1).position = routes[routeNumber].GetChild(0).position+new Vector3(0,10,0);
        Vector3 p0 = routes[routeNumber].GetChild(0).position;
        Vector3 p1 = routes[routeNumber].GetChild(1).position;
        Vector3 p2 = routes[routeNumber].GetChild(2).position;
        Vector3 p3 = routes[routeNumber].GetChild(3).position;
        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;
            CubePosition = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;
            transform.position = CubePosition;
            yield return new WaitForEndOfFrame();
        }
        tParam = 0f;
        routoToGo += 1;
        if (routoToGo > routes.Length - 1)
        {
            routoToGo = 0;
            Vector3 leftvector = new Vector3(46.4f, 2.2f, 6.5f);
            Vector3 rightvector = new Vector3(46.4f, 2.2f, 6.5f);
            Vector3 burstvector = new Vector3(46.86f, 3.28f, 0.53f);




            Transform left = Instantiate(leftConfetti, leftvector, Quaternion.Euler(-90f, 0, 0));
           

           // Destroy(left.gameObject, 0.5f);
            Transform right = Instantiate(rightConfetti, rightvector, Quaternion.Euler(-90f, 0, 0));
            //Destroy(right.gameObject, 0.5f);
            Transform burst = Instantiate(bursConfetti, burstvector, Quaternion.identity);
            // Destroy(burst.gameObject, 0.5f);
            //Basket.GetComponent<Renderer>().material.SetColor("_Color",Color.yellow) ;
            StartCoroutine(RenkDegistir(0.2f));
           
            //Basket.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            StartCoroutine(ExecuteAfterTime(5));
        }

        //coroutineAllowed = true;
    }
}
