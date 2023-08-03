//Author: Rhiannon Strickland
//Date: March 14, 2023
//This handles all the UI for the health points.
//Each heart I call a pip for simplicity's sake.
//All you have to do is slot in the pip prefab
//and you're good to go!
//This script dynamically changes based on the
//dimensions of the screen and pip size.

using System.Collections.Generic;
using UnityEngine;

//MAKE SURE THIS CLASS IS ATTACHED TO THE CANVAS OBJECT!!!//
public class Health : MonoBehaviour 
{
    [SerializeField]//this is so that the prefab can be input through the editor
    GameObject pipPrefab;//this is a reference to the pip prefab
    float pipSize;//this keeps track of the size of the pips. It takes the size off of the prefab that is inserted.
    //Make sure that the pip prefab is a perfect square. Otherwise there will be bugs.
    List<Transform> healthPips = new List<Transform>();//This is to keep track of the pips.

    private void Awake()
    {
        pipSize = pipPrefab.GetComponent<RectTransform>().rect.width;//This gets the size of the pips. MAKE SURE THE WIDTH AND HEIGHT ARE THE SAME!!
    }

    public void RemoveHearts(int damage)
    {
        damage = damage > healthPips.Count ? healthPips.Count : damage;
        int startCount = healthPips.Count;//I put this before the for loop so that the count doesn't change dynamically
        for(int i = 0; i < damage; i++)
        {
            int index = startCount - (1 + i); // This is to track which pip is being removed
            Destroy(healthPips[index].gameObject); // Destroys the game object to remove it from the scene
            healthPips.RemoveAt(index);// Removes the pip from the list
        }
    }
    public void AddHearts(int health)
    {
        int startCount = healthPips.Count;//I put this before the for loop so that the count doesn't change dynamically
        for (int i = 0; i < health; i++)
        {
            int index = startCount + i; //This is to track which pip is being inserted
            Rect rect = GetComponent<RectTransform>().rect; // This is so that I can access the canvas size
            float startX = rect.width / 2 - (pipSize / 2); // This... this is for readability.
            float startY = rect.height / 2 - (pipSize / 2); // This... this is for readability.
            healthPips.Add(Instantiate(pipPrefab,// The pip prefab
                new Vector3(transform.position.x - startX + (index * (pipSize + 5)), transform.position.y + startY, transform.position.z),// Location of the pip
                transform.rotation,// Rotation of the pip
                transform) // Pip's parent
                .transform);// Insert transform into the list.
        }
    }
}
