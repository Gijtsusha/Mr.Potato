using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D heroBody;
    public float moveForce;
    public float MaxSpeed;
    private float flinput;
    private bool bFaceRight = true;
    private bool bGrounded = false;
    Transform mGroundCheck;
    private bool bJump = false;
    public float JumpForce;
    
    void Start()
    {
        heroBody = GetComponent<Rigidbody2D>();
        mGroundCheck = transform.Find("GroundCheck");

    }

    // Update is called once per frame
    void Update()
    {
        flinput = Input.GetAxis("Horizontal");
        if (flinput > 0 && !bFaceRight)
        {
            flip();
        }
        else if (flinput < 0 && bFaceRight)
        {
            flip();
        }

        bGrounded = Physics2D.Linecast(transform.position, mGroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        /*if (Input.GetButtonDown("Jump") && bGrounded)
        {
            bJump = true;
        }*/
        if (Input.GetKeyDown(KeyCode.Space) && bGrounded)
        {
            bJump = true;
        }

    }

    private void FixedUpdate()
    {
        //控制移动
        if (Mathf.Abs(heroBody.velocity.x) < MaxSpeed)
        {
            heroBody.AddForce(Vector2.right * flinput * moveForce);
        }

        if (Mathf.Abs(heroBody.velocity.x) > MaxSpeed)
        {
            heroBody.velocity = new Vector2(Mathf.Sign(heroBody.velocity.x) * MaxSpeed, heroBody.velocity.y);
        }

        if (bJump)
        {
            heroBody.AddForce(new Vector2(0f, JumpForce));
            bJump = false;
        }
    }

    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        bFaceRight = !bFaceRight;
    }


}
