using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class SquirrelMove : MonoBehaviour{
    //GameObject player = null;
    Rigidbody2D body;
    //public float moveDelay = 1f;
    //float lastMove = 0f;
    //public float force = 5;
    //private Timer timer;
    public bool initMoveDir = true; //direction to move, true = right and false = left
    public int speed = 3; //speed of movement, subject to change
    private ContactFilter2D contFilt; //contact filter
    private List<ContactPoint2D> contPoints = new List<ContactPoint2D>();

    // Start is called before the first frame update
    void Start(){
        //timer = GameObject.Find("Canvas").transform.Find("Timer").gameObject.GetComponent<Timer>();
        //if (player == null){
        //    player = GameObject.FindWithTag("Player");
        //}
        if (body == null){
            body = GetComponent<Rigidbody2D>();
        }
    }
    void Awake(){
        if (body == null){
            body = GetComponent<Rigidbody2D>();
        }
        body.AddForce(new Vector2((initMoveDir ? 1 : -1)*150f,0));
    }
    void OnEnable(){
        if(body == null){
            body = GetComponent<Rigidbody2D>();
        }
        body.AddForce(new Vector2((initMoveDir ? 1 : -1)*150f,0));
    }

    // Update is called once per frame
    void FixedUpdate(){
        /* rabbit movement
        if (lastMove <= timer.getTime()-moveDelay){
            lastMove = timer.getTime();
            body.AddForce(new Vector2((Mathf.Cos(45)/(1/force))*(((transform.localPosition.x - player.transform.localPosition.x)*-1)/Mathf.Abs(transform.localPosition.x - player.transform.localPosition.x)),Mathf.Sin(45)/(1/force)),ForceMode2D.Impulse);
        }
        */

        //Goomba movement
        //body.AddForce(new Vector2((moveDir ? 1 : -1) * (maxspeed < Math.Abs(maxspeed/body.velocity.x) ? ((moveDir ? 1 : -1) * maxspeed) : maxspeed/body.velocity.x), 0),ForceMode2D.Impulse);
        body.GetContacts(contFilt.NoFilter(),contPoints); 
        foreach (ContactPoint2D contPt in contPoints){
            if(contPt.normal.x != 0){
                //Debug.Log(body.velocity.x);
                body.velocity = new Vector2(contPt.normal.x * speed,body.velocity.y);
                contPoints.Clear();
                break;
            }
        }
    }
}
