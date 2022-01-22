using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    private enum State {idle, run, jump, falling};
    private State state = State.idle;
    [SerializeField] private LayerMask ground;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D>();
        anim = GetComponent <Animator>();
        coll = GetComponent <Collider2D>();
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

        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            state = State.jump;

        }
        VelocityState();
        anim.SetInteger("State", (int)state);
    }

    private void VelocityState() 
    {
        if(state == State.jump && rb.velocity.y < .1f)
        {
            state = State.falling;
        }
        else if (state == State.falling && coll.IsTouchingLayers(ground)) 
        {
            state = State.idle;
                
        }
        else if (Mathf.Abs(rb.velocity.x) > 2f && coll.IsTouchingLayers(ground)) 
        {
            state = State.run;
        }
        else 
        {
            state = State.idle;
        }
    }
    

}
