using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody2D rocket;
    public float fSpeed = 10;
    PlayerControl playerCtrl;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = transform.root.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))//if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (playerCtrl.bFaceRight)
            {
                Rigidbody2D rocketInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                rocketInstance.velocity = new Vector2(fSpeed, 0);
            }
            else
            {
                Rigidbody2D rocketInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                rocketInstance.velocity = new Vector2(-fSpeed, 0);
            }
        }
    }
}
