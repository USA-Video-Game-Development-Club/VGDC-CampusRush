using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//allows bird to hover and move around above the player
//controls the movement of the bird
public class BirdMove : MonoBehaviour
{
    public GameObject player; //stores the players and used to find the players location
    private float playerLocation; //stores the players X position
    public float velocityMultiplier; //how much velocity increases each frame
    public float maximumMovementForce = 10; //the max amount of force that can be added to move the bird

    private Rigidbody2D rb; //birds rigidbody

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //get players X position and distance between bird
        playerLocation = player.transform.position.x;

        //calcualtes distance between bird and player
        //tries to be exactly above player and higher
        Vector2 distance = new Vector2(playerLocation - rb.position.x, 0);

        //add X velocity to which ever direction the player is
        rb.AddForce(distance.normalized * maximumMovementForce);

        //clamps X velovity to make sure bird dose not go too fast 
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maximumMovementForce, maximumMovementForce), rb.velocity.y);
    }
}
