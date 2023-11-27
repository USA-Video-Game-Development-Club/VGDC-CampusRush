using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//DOES NOT MOVE THE RIGIDBODY, MAKE A SEPERATE SCRIPT FOR THAT

public class DamagePlayer : MonoBehaviour{
    public bool dieOnSolid = true;  //despawn attached body on collision with Solid
    public bool dieOnDamage = true; //despawn once body damaged player
    private Rigidbody2D body;
    private List<Collider2D> colliders = new List<Collider2D>{}; //all colliders attached to rigidbody
    private GameObject player = null;
    public int damage = 1;
    // Start is called before the first frame update
    void Start(){
        body = GetComponent<Rigidbody2D>();
        GetComponents<Collider2D>(colliders);
        if (player == null){
            player = GameObject.FindWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update(){
        /*
        if (body.IsTouching(player.GetComponent<Collider2D>())){
            player.GetComponent<PlayerStats>().TakeDamage(damage);
            if (dieOnDamage){
                Destroy(this.gameObject);
            }
        }
        //if(dieOnSolid){UnityEngine.Debug.Log(this.gameObject.name + " " + isTouchingSolid());
        */
    }

    void OnCollisionEnter2D(Collision2D other) {
        //UnityEngine.Debug.Log("Collider: " + other.collider);

        if (other.collider == player.GetComponent<Collider2D>()){ //collide with and damage player
            player.GetComponent<PlayerStats>().TakeDamage(damage);
            if (dieOnDamage){
                Destroy(this.gameObject);
            }
        }

        if (dieOnSolid && other.collider.attachedRigidbody != null){
            Destroy(this.gameObject);
        }
    }

    bool isTouchingSolid(){
        List<ContactPoint2D> contacts = new List<ContactPoint2D>{};
        body.GetContacts(contacts);
        UnityEngine.Debug.Log("Contacts Length: " + contacts.ToArray().GetLength(0));
        foreach (ContactPoint2D con in contacts){
            UnityEngine.Debug.Log(con.collider + ": " + con.collider.attachedRigidbody);
            if (con.collider.attachedRigidbody != null){
                return true;
            }
        }
        return false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        //UnityEngine.Debug.Log("Collider: " + other.collider);

        if (other == player.GetComponent<Collider2D>()){ //collide with and damage player
            player.GetComponent<PlayerStats>().TakeDamage(damage);
            if (dieOnDamage){
                Destroy(this.gameObject);
            }
        }

        if (dieOnSolid && other.attachedRigidbody != null){
            Destroy(this.gameObject);
        }
    }
}
