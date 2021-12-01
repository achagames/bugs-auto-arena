using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    
    public string bugName = "Bug";
    public Sprite sprite;
    public int power = 0;
    public BugTrait trait = BugTrait.Undefined;

}
