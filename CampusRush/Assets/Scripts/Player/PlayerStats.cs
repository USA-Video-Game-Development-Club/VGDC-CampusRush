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
    public float invulnTime = 1f;
    float hitTime = 0f;
    public Vector2 hitboxSize;
    public Vector2 hitboxOffset;
    private List<Collider2D> touching = new List<Collider2D>();

    private void Start()
    {
        pips.AddHearts(maxHealth);
    }

    void Update(){
        if (Input.GetKeyDown("q")){
            StartCoroutine(attack());
        }
    }

    public override void TakeDamage(int damage)
    {
        //Switch line 27 with the commented ones if implementing armor
        //if(damage - armor.GetValue() > 0)
        //  pips.RemoveHearts(damage - armor.GetValue());
        if(hitTime+invulnTime <= Time.time){
            hitTime = Time.time;
            pips.RemoveHearts(damage);
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
}
