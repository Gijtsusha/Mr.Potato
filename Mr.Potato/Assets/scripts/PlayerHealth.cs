using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float damageRepeat = 0.5f;
    public AudioClip[] ouchClips;
    public float hurtBloodPoint = 20f;
    public float hurtForce=100f;

    float health=100f;
    private SpriteRenderer healthBar;
    private Vector3 healthScale;
    private float lastHurt;
    private Animator anim;
    

    private void Awake()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
        healthScale = GameObject.Find("HealthBar").transform.localScale;
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        lastHurt = Time.time;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (Time.time > lastHurt + damageRepeat)
            {
                if (health > 0)
                {
                    //减血
                    TakeDamage(collision.gameObject.transform);
                    lastHurt = Time.time;
                }
                else
                {
                    //播放死亡动画
                    anim.SetTrigger("Die");
                    //掉落
                    Collider2D[] colliders = GetComponents<Collider2D>();
                    foreach(Collider2D c in colliders)
                    {
                        c.isTrigger = true;
                    }
                    /*
                    SpriteRenderer[] sp = GetComponentsInChildren<SpriteRenderer>();
                    foreach(SpriteRenderer s in sp)
                    {
                        s.sortingLayerName = "UI";
                    }
                    */
                    GetComponent<PlayerControl>().enabled = false;
                    GetComponentInChildren<Gun>().enabled = false;
                }
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "killerTrigger")
        {
            anim.SetTrigger("Fall");
        }
    }

    void TakeDamage(Transform enemy)
    {
        health -= hurtBloodPoint;
        //更新血条状态
        UpdateHealthBar();
        Vector3 hurtVector = transform.position - enemy.position + Vector3.up;
        GetComponent<Rigidbody2D>().AddForce(hurtVector * hurtForce);

        int i = Random.Range(0, ouchClips.Length-1);
        AudioSource.PlayClipAtPoint(ouchClips[i], transform.position);
    }

    void UpdateHealthBar()
    {
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);
        healthBar.transform.localScale = new Vector3(healthScale.x*health * 0.01f, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
