//Author: Rhiannon Strickland
//Date: April 4, 2023
//This is placed into the scene manager to hold all the collectibles the player has aquired.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make sure this is placed into the SCENEMANAGER object, so that it can be passed on through levels
public class CollectibleInventory : MonoBehaviour
{
    #region SINGLETON
    public static CollectibleInventory instance;

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }
    #endregion

    public List<CollectibleSO> collectibles = new List<CollectibleSO>();

    public void AddCollectible(CollectibleSO collectible)
    {
        collectibles.Add(collectible);
    }
    public void RemoveCollectible(CollectibleSO collectible)
    {
        collectibles.Remove(collectible);
    }
}
