//using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class Character2DController : MonoBehaviour
{

    public float MovementSpeed = 4;
    public float JumpForce = 15;
    public float grav = 1f;

    private Rigidbody2D rb;
    //private SpriteRenderer sr;
    //private Sprite[] sprites;
    private bool doubleJump = true; //ability to double jump
    private Collider2D[] cls;
    private ContactFilter2D filter;

    // Start is called before the first frame update
    void Start()
    {
        
        cls = new Collider2D[1]; //make array for colliders
        rb = GetComponent<Rigidbody2D>(); //get rigidbody
        rb.GetAttachedColliders(cls); //get colliders attached to rigidbody
        //sr = GetComponent<SpriteRenderer>(); //get sprite renderer
        //sprites = Resources.LoadAll<Sprite>("Sprites"); //store sprites from folder
        rb.gravityScale = grav; //set how fast player should fall
        filter.SetNormalAngle(89.9f,90.1f);
        filter.SetDepth(0.0f,0.5f);
        //UnityEngine.Debug.Log("Is filter working: " + filter.isFiltering);
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal"); //get direction of horizontal movement based on input
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed; //move player by MovementSpeed * dt

/*
        if (!Mathf.Approximately(0, movement))
        {
            if (movement > 0) {
                sr.sprite = sprites[1];
            } else {
                sr.sprite = sprites[0];
            }
        }
*/
        
        if (Input.GetButtonDown("Jump") && (Mathf.Abs(rb.velocity.y) < 0.001f || doubleJump)) //if user inputs jump and they are either on the ground or haven't used their double jump
        {
            //rb.velocity.Set(rb.velocity.x,0.001f);
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            if (!isTouchingGround(cls[0])){doubleJump=false;} //if used jump in the air, lose ability to double jump
        }
        if(isTouchingGround(cls[0])){doubleJump=true;}
    }

    bool isTouchingGround(Collider2D cl){
        List<ContactPoint2D> cons = new List<ContactPoint2D>{};
        cl.GetContacts(filter,cons); //to add walljump, disable the filter
        //UnityEngine.Debug.Log(cons.Count);
        foreach(ContactPoint2D con in cons){
            if (con.collider.attachedRigidbody.tag == "Ground"){
                return true;
            }
        }
        return false;
    }
}