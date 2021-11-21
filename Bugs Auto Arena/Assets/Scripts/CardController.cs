using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public Card card;

    public TextMeshPro nameText;
    //public Image sprite;
    public TextMeshPro powerText;

    public int AttacksLeft
    {
        get { return card.attacksLeft; }
        set { card.attacksLeft = value; }
    }
    public int Power
    {
        get { return card.power; }
        set { card.power = value; }
    }

    private void Start()
    {
        nameText.text = card.name;
        powerText.text = card.power.ToString();
    }
    

    public int TakeDamage(int dmg)
    {
        card.power -= dmg;
        return card.power;
    }
}

