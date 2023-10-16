//using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
//using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float normalSpeed = 4; //how fast the player can move when walking
    public float sprintSpeed = 8; //how fast the player can move when sprinting
    public float sprintAcceleration = 6; //how fast players accelerate and deaccelerate from printing to walking
    private float currentSpeed; //the current speed of the player used with acceleration 

    public float maxXSpeed = 20; //the max velocity of X
    public float maxYSpeed = 20; //the max velocity of Y

    public float jumpForce = 15; //how much is added to a jump 
    public bool doubleJump = true; //used to know if player
    public bool canDoubleJump = false; //determines if player can double jump

    public float grav = 1f;

    //manages user inputs and mechanics around the inputs
    private bool jumpInput; //stores if the jump input is being used
    private bool jumpInputRelease; //stores if the jump input has been released
    private bool sprintInput; //stores if the move imput is being used


    private Rigidbody2D rb;
    //private SpriteRenderer sr;
    //private Sprite[] sprites;
    //private bool doubleJump = false; //ability to double jump
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

    //tests for inputs and other mechanics interacting with inputs
    //inputs done in update due to fixed update eating inputs
    private void Update()
    {
        //used for jumping
        if (Input.GetButtonDown("Jump")) { jumpInput = true; } //pressing button makes player start jumping when hitting ground

        if (Input.GetButtonUp("Jump")) { jumpInputRelease = true; jumpInput = false; } //letting go of button makes player stop jumping when hitting ground

        //used for sprinting
        sprintInput = Input.GetButton("Sprint");
    }

    // used for physics updates
    // physics done in fixed update due to consistant updates
    void FixedUpdate()
    {
        var movement = Input.GetAxis("Horizontal"); //get direction of horizontal movement based on input in a range of [-1,1]
        
        //controls player movement
        //calls the MovePlayer method to acually move player
        if (sprintInput) //if user inputs sprint (left/right shift) they will sprint/run
        {
            sprintInput = false;
            MovePlayer(movement, sprintSpeed); //moves player
        }
        else //if player is not pressing sprint, they will walk instead
        {
            MovePlayer(movement, normalSpeed); //moves player
        }

        //controls player jump
        if (jumpInput && (isTouchingGround(cls[0]) || doubleJump && canDoubleJump)) //if user inputs jump and they are either on the ground or haven't used their double jump
        {
            jumpInput = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            if (!isTouchingGround(cls[0])) { doubleJump = false; } //if used jump in the air, lose ability to double jump
        }

        //slows players upward momentum when jump is released
        if (jumpInputRelease && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2); //slows player upward momentum
            jumpInputRelease = false;
        }

        if (isTouchingGround(cls[0])) { doubleJump = true; } //adds double jump back to player when hitting ground
    }


    //method used to determine if player is touching the ground based on charaters feet
    bool isTouchingGround(Collider2D cl)
    {
        castHits.Add(Physics2D.Raycast(new Vector2(transform.position.x - 0.5f, transform.position.y - 1.01f), Vector2.down, 0.1f)); //back
        castHits.Add(Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 1.01f), Vector2.down, 0.1f)); //middle
        castHits.Add(Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y - 1.01f), Vector2.down, 0.1f)); //front

        //tests each raycast to see if its hit a collider with ground
        foreach (RaycastHit2D cast in castHits)
        {
            //Debug.Log(cast.collider.tag);
            if (cast && cast.collider.tag == "Ground" || cast && cast.collider.tag == "Enemy")
            {
                castHits.Clear();
                jumpInputRelease = false; //resets jumpInputRelease just in case
                return true; //player is not touching ground
            }
        }

        castHits.Clear();
        return false; //player is not touching ground
    }


    /// <summary>
    /// method used for moving/adds velocity to player
    /// </summary>
    /// <param name="movementInput">The input used to determine which direction a plyer is moving</param>
    /// <param name="movementSpeed">how fast the player will move/accelerate</param>
    void MovePlayer(float movementInput, float movementSpeed)
    {
        if (movementSpeed == sprintSpeed && currentSpeed <= movementSpeed) //changes speed when sprinting
        {
            currentSpeed += Time.deltaTime * sprintAcceleration; //how fast player changes form walk to sprinting
        }

        if (movementSpeed == normalSpeed && currentSpeed >= movementSpeed) //changes speed when walking
        {
            currentSpeed -= Time.deltaTime * sprintAcceleration;  //how fast player changes form sprinting to walking
        }

        currentSpeed = Mathf.Clamp(currentSpeed, normalSpeed, sprintSpeed); //clamps speed to make sure player wont go to fast
        rb.velocity = new Vector2(movementInput * currentSpeed, rb.velocity.y); //adds velocity/moves player

        Vector2 clampVector = rb.velocity; //stores the updated velocity after being clamped to make sure player dose not move too fast
        clampVector.x = Mathf.Clamp(rb.velocity.x, -maxXSpeed, maxXSpeed); //clamps X velocity
        clampVector.y = Mathf.Clamp(rb.velocity.y, -maxYSpeed, maxYSpeed); //clamps Y velocity

        rb.velocity = clampVector; //updates velocity to clamped version
    }


}
