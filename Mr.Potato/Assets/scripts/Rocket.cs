using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D rocketBody;
    float faceTo;
    bool rocketLive = false;
    public float rocketForce=5f;
    // Start is called before the first frame update
    private void Awake()
    {
        faceTo = GameObject.Find("Hero").transform.localScale.x;
    }
    void Start()
    {
        rocketBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rocketLive = true;
        }
        if(rocketLive == true)
        {
            if (faceTo > 0)
            {

                rocketBody.AddForce(new Vector2(rocketForce, 0f));
            }
            else
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                rocketBody.AddForce(new Vector2(-rocketForce, 0f));
            }
        }
    }
}
