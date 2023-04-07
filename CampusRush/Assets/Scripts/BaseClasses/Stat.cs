//Author: Rhiannon Strickland
//Date: March 14, 2023
// I built this class out based on a tutorial on youtube.
// I have it just in case we want to use stats in the game
// like damage, armor, etc. In order to make powerups, we'd
// make a scriptable object that includes integers that we'd implement
// as modifiers

using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    [SerializeField]// This is so that we can manipulate the base value in the unity editor
    int baseValue;

    List<int> modifiers = new List<int>();// This is any type of modifier from armor, powerups, etc.
    public int GetValue()// Gets the value based on the modifiers present.
    {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }

    //These two functions are pretty straightforward. Add a modifier to the list or remove it. Pretty simple.
    //They also check to make sure that the modifier being added actually means something.
    public void AddMod(int mod)
    {
        if (mod != 0)
            modifiers.Add(mod);
    }

    public void RemoveMod(int mod)
    {
        if(mod != 0)
            modifiers.Remove(mod);
    }
}
