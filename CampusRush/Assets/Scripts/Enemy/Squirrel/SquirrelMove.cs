using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelMove : MonoBehaviour{
    GameObject player = null;
    Rigidbody2D body;
    public float moveDelay = 1f;
    float lastMove = 0f;
    public float force = 5;
    private Timer timer;
    // Start is called before the first frame update
    void Start(){
        timer = GameObject.Find("Canvas").transform.Find("Timer").gameObject.GetComponent<Timer>();
        if (player == null){
            player = GameObject.FindWithTag("Player");
        }
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        if (lastMove <= timer.getTime()-moveDelay){
            lastMove = timer.getTime();
            body.AddForce(new Vector2((Mathf.Cos(45)/(1/force))*(((transform.localPosition.x - player.transform.localPosition.x)*-1)/Mathf.Abs(transform.localPosition.x - player.transform.localPosition.x)),Mathf.Sin(45)/(1/force)),ForceMode2D.Impulse);
        }
    }
}
