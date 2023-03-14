//Author: Rhiannon Strickland
//Date: March 14, 2023
//This script is simply to debug the health mechanics.
//You press Q to take damage, and R to heal it.
//It will not be implimented in the final game.

using UnityEngine;

public class PlayerHealthTest : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetComponent<PlayerStats>().TakeDamage(1);
        }else if(Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<PlayerStats>().HealDamage(1);
        }
    }
}
