using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornMove : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed = 4f;
    public float grav = 0f;
    public Vector2 direction = Vector2.down;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = grav;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(direction.x,direction.y,0) * Time.deltaTime * speed;
    }
}
