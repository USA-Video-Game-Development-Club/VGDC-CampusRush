//Author: Rhiannon Strickland
//Date: March 14, 2023
//This is a derived class from CharacterStats,
//where the game over screen will be implemented.
//Remember to imput the canvas in the editor when you use this script.

using System.IO.Pipes;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStats : CharacterStats
{
    [SerializeField]
    Health pips;
    public float invulnTime = 1f; //seconds for player to be invuln after damaged
    float hitTime = 0f; //time of getting hit
    private List<Collider2D> touching = new List<Collider2D>(); //list of touching colliders
    private Collider2D[] colliders = new Collider2D[2]; //list of colliders
    private int triggerIndex; //index of the first trigger collider (should be the "stomp" hitbox)
    private ContactFilter2D contFilt; //placeholder (atm) contact filter

    private void Start()
    {
        //pips.AddHearts(maxHealth);

        colliders = GetComponents<Collider2D>();
        if (colliders[0].isTrigger){
            triggerIndex = 0;
        }else{
            triggerIndex = 1;
        }
        contFilt.NoFilter(); //tell contFilt to filter nothing
    }

    void LateUpdate(){
        if (GetComponent<Rigidbody2D>().velocity.y < 0){ //if player is falling
            colliders[triggerIndex].OverlapCollider(contFilt,touching); //research if ContactFilter can filter by tag
            for(int i=0;i<touching.Count;i++){ //for everything touching the "stomp" hitbox, check prefab for hitbox placement
                if (touching[i].tag == "Enemy"){ //if thing is an enemy
                    Object.Destroy(touching[i].gameObject); //destroy enemy
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,0); //set player velocity to 0
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, GetComponent<PlayerMovement>().jumpForce), ForceMode2D.Impulse); //add force to player equal to a jump
                    GetComponent<PlayerMovement>().doubleJump = true; //refresh double jump
                }
            }
        }
    }

    public override void TakeDamage(int damage)
    {
        //Switch line 27 with the commented ones if implementing armor
        //if(damage - armor.GetValue() > 0)
        //  pips.RemoveHearts(damage - armor.GetValue());
        if(hitTime+invulnTime <= Time.time){ //if not in the invuln time frame
            hitTime = Time.time; //hit time is now
            //pips.RemoveHearts(damage);
            base.TakeDamage(damage);
        }
    }
    public override void HealDamage(int damage)
    {
        if((currentHealth + damage) <= maxHealth)
            pips.AddHearts(damage);
        base.HealDamage(damage);
    }

    protected override void Die()
    {
        base.Die();
        //This calls the sceneChanger and tells it to load the game over scene.
        //Make sure there is an instance of the prefab that handles scene changes.
        SceneChanger.instance.GameOver();
    }

    //Example of using an IEnumerator
    /* 
    IEnumerator attack(){
        ContactFilter2D temp = new ContactFilter2D(); //required by OverlapCollider()
        BoxCollider2D hitbox = gameObject.AddComponent<BoxCollider2D>();
        hitbox.isTrigger = true;
        hitbox.size = hitboxSize;
        hitbox.offset = new Vector2((hitbox.offset.x+hitboxOffset.x)*Input.GetAxis("Horizontal"),hitbox.offset.y+hitboxOffset.y);
        hitbox.OverlapCollider(temp.NoFilter(),touching);
        for(int i=0;i<touching.Count;i++){
            if (touching[i].tag == "Enemy"){
                Object.Destroy(touching[i].gameObject);
            }
        }
        yield return null; //yield to pass a frame
        Object.Destroy(hitbox);
    }
    */
}
