using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody2D rocket;
    public float fSpeed = 10f;
    PlayerControl playerCtrl;
    private AudioSource ac;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = transform.root.GetComponent<PlayerControl>();
        ac = GetComponent<AudioSource>();
        anim = transform.root.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))//if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Shoot");
            ac.Play();
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
