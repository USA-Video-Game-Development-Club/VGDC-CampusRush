//Author: Rhiannon Strickland
//Date: April 4, 2023
//This is put onto the collectible prefab
//to allow for collectibles to be used in game.
using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    [SerializeField]
    CollectibleSO item;

    private void Awake()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = item.icon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")//Make sure the player has this tag, or the script won't work!
        {
            Debug.Log("Found the player!");
            CollectibleInventory.instance.AddCollectible(item);
            Destroy(gameObject);
        }
    }
}
