using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public Card card;
    public SpriteRenderer spriteRenderer;
    public TextMeshPro nameText;
    //public Image sprite;
    public TextMeshPro powerText;

    private int currentPower;

    public int CurrentPower
    {
        get { return currentPower; }
        set { currentPower = value; }
    }
    public string BugName
    {
        get { return card.bugName; }
    }

    private void Start()
    {
        nameText.text = card.name;
        if(spriteRenderer != null)
        spriteRenderer.sprite = card.sprite;
        powerText.text = card.power.ToString();
        currentPower = card.power;
    }
    private void Update()
    {
        if (currentPower != card.power)
        {
        powerText.text = CurrentPower.ToString();

        }
    }

    public int TakeDamage(int dmg)
    {
        CurrentPower -= dmg;
        return CurrentPower;
    }

    public void SetCard(Card newCard)
    {
        card = newCard;
    }
}

