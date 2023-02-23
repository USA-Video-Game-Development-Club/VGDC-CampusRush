using System.Collections;
using System.Collections.Generic;
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
    private ContactPoint2D[] cons;

    // Start is called before the first frame update
    void Start()
    {
        cls = new Collider2D[1]; //make array for colliders
        rb = GetComponent<Rigidbody2D>(); //get rigidbody
        rb.GetAttachedColliders(cls); //get colliders attached to rigidbody
        //sr = GetComponent<SpriteRenderer>(); //get sprite renderer
        //sprites = Resources.LoadAll<Sprite>("Sprites"); //store sprites from folder
        rb.gravityScale = grav; //set how fast player should fall
        cons = new ContactPoint2D[2]; //make array for contact points
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
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            if (!cls[0].IsTouching(cons[0].collider)){doubleJump=false;} //if used jump in the air, lose ability to double jump
        }

        cls[0].GetContacts(cons); //get contact points for the main collider
        //Debug.Log(cons[0].collider.name.Substring(0,10));
        if ((cls[0].IsTouching(cons[0].collider) && cons[0].collider.name.Substring(0,10)=="SolidTerra") && !doubleJump){doubleJump=true;} //if  our collider is touching a different collider, refresh double jump
    }
}
