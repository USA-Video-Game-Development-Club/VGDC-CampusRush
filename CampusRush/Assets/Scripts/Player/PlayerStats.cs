//Author: Rhiannon Strickland
//Date: March 14, 2023
//This is a derived class from CharacterStats,
//where the game over screen will be implemented.
//Remember to imput the canvas in the editor when you use this script.

using System.IO.Pipes;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    [SerializeField]
    Health pips;
    [SerializeField]
    GameObject scene;

    private void Start()
    {
        pips.AddHearts(maxHealth);
    }

    public override void TakeDamage(int damage)
    {
        //Switch line 24 with the commented ones if implementing armor
        //if(damage - armor.GetValue() > 0)
        //  pips.RemoveHearts(damage - armor.GetValue());
        pips.RemoveHearts(damage);
        base.TakeDamage(damage);
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
        scene.GetComponent<SceneChanger>().GameOver();
    }
}
