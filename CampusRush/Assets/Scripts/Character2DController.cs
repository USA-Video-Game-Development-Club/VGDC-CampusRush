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
    //private ContactFilter2D filter;
    private List<RaycastHit2D> castHits = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        
        cls = new Collider2D[1]; //make array for colliders
        rb = GetComponent<Rigidbody2D>(); //get rigidbody
        rb.GetAttachedColliders(cls); //get colliders attached to rigidbody
        //sr = GetComponent<SpriteRenderer>(); //get sprite renderer
        //sprites = Resources.LoadAll<Sprite>("Sprites"); //store sprites from folder
        rb.gravityScale = grav; //set how fast player should fall
        //filter.SetNormalAngle(89.5f,90.5f);
        //filter.SetDepth(0.0f,0.5f);
        //UnityEngine.Debug.Log("Is filter working: " + filter.isFiltering);
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxisRaw("Horizontal"); //get direction of horizontal movement based on input in a range of [-1,1]
        castHits.Add(Physics2D.Raycast(new Vector2(transform.position.x+(movement*0.6f),transform.position.y+0.5f),(movement > 0 ? Vector2.right : Vector2.left),Time.deltaTime * MovementSpeed)); //head
        castHits.Add(Physics2D.Raycast(new Vector2(transform.position.x+(movement*0.6f),transform.position.y),(movement > 0 ? Vector2.right : Vector2.left),Time.deltaTime * MovementSpeed)); //body
        castHits.Add(Physics2D.Raycast(new Vector2(transform.position.x+(movement*0.6f),transform.position.y-0.5f),(movement > 0 ? Vector2.right : Vector2.left),Time.deltaTime * MovementSpeed)); //feet
        if(movement != 0 && //if moving
        ((castHits[0].collider != null && !castHits[0].collider.isTrigger) || 
        (castHits[1].collider != null && !castHits[1].collider.isTrigger) || 
        (castHits[2].collider != null && !castHits[2].collider.isTrigger))
        ){
            rb.AddForce(new Vector2(movement,0));
        }else{
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed; //teleport player by MovementSpeed * dt
        }
        castHits.Clear();

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
        castHits.Add(Physics2D.Raycast(new Vector2(transform.position.x-0.5f,transform.position.y-1.01f),Vector2.down,0.1f)); //back
        castHits.Add(Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y-1.01f),Vector2.down,0.1f)); //middle
        castHits.Add(Physics2D.Raycast(new Vector2(transform.position.x+0.5f,transform.position.y-1.01f),Vector2.down,0.1f)); //front
        foreach(RaycastHit2D cast in castHits){
            //Debug.Log(cast.collider.tag);
            if (cast && cast.collider.tag == "Ground"){
                castHits.Clear();
                return true;
            }
        }
        castHits.Clear();
        return false;
    }
}