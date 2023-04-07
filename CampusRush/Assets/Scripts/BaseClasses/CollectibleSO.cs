//Author: Rhiannon Strickland
//Date: April 4, 2023
//This is a scriptable object holding a collectible to be added to the collectible inventory object when specific conditions are met.

using UnityEngine;

[CreateAssetMenu(fileName = "New Collectible", menuName = "Inventory/Collectible")]
public class CollectibleSO : ScriptableObject
{
    new public string name = "New Collectible";
    public Sprite icon = null;
    public int id = 0;
}
