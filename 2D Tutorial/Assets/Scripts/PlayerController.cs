using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private enum State {idle, run, jump};
    private State state = State.idle;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D>();
        anim = GetComponent <Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hDirection = Input.GetAxis("Horizontal");

        if (hDirection > 0)
        {
            rb.velocity = new Vector2(5,rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            //anim.SetBool("running", true);
        }
        else if (hDirection < 0)
        {
            rb.velocity = new Vector2(-5,rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            //anim.SetBool("running", true);
        }
        else {
            //anim.SetBool("running", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            state = State.jump;
        }
        VelocityState();
        anim.SetInteger("State", (int)state);
    }

    private void VelocityState() 
    {
        if(state == State.jump)
        {
            state = State.jump;
        }
        else if (Mathf.Abs(rb.velocity.x) > 2f) 
        {
            state = State.run;
        }
        else 
        {
            state = State.idle;
        }
    }
    

}
