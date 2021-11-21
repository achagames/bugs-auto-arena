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

    private int currentPower;

    public int CurrentPower
    {
        get { return currentPower; }
        set { currentPower = value; }
    }

    private void Start()
    {
        nameText.text = card.name;
        powerText.text = card.power.ToString();
        currentPower = card.power;
    }
    private void Update()
    {
        powerText.text = CurrentPower.ToString();
    }

    public int TakeDamage(int dmg)
    {
        CurrentPower -= dmg;
        return CurrentPower;
    }
}

