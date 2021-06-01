using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public GameObject splash;
    public GameObject bar;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "killerTrigger")
        {
            if (transform.tag == "Player")
            {
                if (GetComponent<PlayerHealth>().health > 0)
                {
                    anim.SetTrigger("Fall");
                    Instantiate(splash, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                else
                {
                    Instantiate(splash, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
            }
            else if (transform.tag == "Enemy")
            {
                Instantiate(splash, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            if (bar != null)
            {
                Destroy(bar);
            }
            Destroy(gameObject);
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
