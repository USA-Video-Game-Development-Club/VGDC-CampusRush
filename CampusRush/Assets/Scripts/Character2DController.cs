using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour
{

    public float MovementSpeed = 4;
    public float JumpForce = 15;
    public float grav = 1f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Sprites");
        rb.gravityScale = grav;
        foreach (Sprite s in sprites)
        {
            Console.WriteLine(s.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

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
        
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
