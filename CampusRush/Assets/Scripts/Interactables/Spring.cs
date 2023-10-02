using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour{
    public int force = 1;
    public float cooldown = 0.5f;
    private float lastTriggerTime;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (lastTriggerTime + cooldown <= Time.time &&other.isTrigger){
            other.attachedRigidbody.velocity = new Vector2(0,0);
            other.attachedRigidbody.AddForce(new Vector2(0,force),ForceMode2D.Impulse);
        }
    }
}
