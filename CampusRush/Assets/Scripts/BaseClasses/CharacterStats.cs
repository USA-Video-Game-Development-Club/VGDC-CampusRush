//Author: Rhiannon Strickland
//Date: March 14, 2023
//This class was made so that we could implement
//a more streamlined situation to consolidate code
//between all objects with stats such as health,
//damage, etc. mostly because it'd be redundant
//to make a separate new class with copy pasted
//code for each type of creature in the game, be it
//player, enemy, npc, or whatever.

using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    // This is where you'd put any Stat objects
    // I've commented one out so we could think about implementing it into the full game
    // If not, we just leave it commented
    //public Stat armor;

    public int maxHealth = 5;
    public int currentHealth { get; private set; }

    private void Awake()//This function calls whenever the object is enabled
    {
        currentHealth = maxHealth;
    }

    // I made this a virtual function because enemies and player display damage differently.
    // For example, enemies won't have hearts on the screen, but the player does.
    // enemies might have a health bar, but it won't behave the same way as the player's health
    // bar.
    public virtual void TakeDamage(int damage)// Says it right on the tin. Take damage.
    {
        // Uncomment this if you want to implement an armor system into the game
        //if(damage - armor.GetValue() > 0)
        //  damage -= armor.GetValue();
        
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void HealDamage(int damage)
    {
        if((currentHealth + damage) < maxHealth){
            currentHealth += damage;
        }else{
            currentHealth = maxHealth;
        }
    }

    // This function changes based on whatever is using it. For example,
    // the player does not die the same way an enemy does. An enemy might
    // drop loot, for example, whereas the player will lead to a game over
    // screen.
    protected virtual void Die()
    {
        Debug.Log(transform.name + " has died.");
    }
}
