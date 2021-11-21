using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public int attacksLeft = 1;
    public string bugName = "Bug";
    public int power = 0;
    public BugTrait trait = BugTrait.Undefined;

}
