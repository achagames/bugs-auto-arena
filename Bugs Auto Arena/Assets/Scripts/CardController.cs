using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public float attackSpeed = 5f;
    public float returnSpeed = 10f;

    public Card card;
    public SpriteRenderer spriteRenderer;
    public TextMeshPro nameText;
    //public Image sprite;
    public TextMeshPro powerText;

    private int currentPower;
    private bool attack;
    private bool retreat;
    private Vector3 enemyPos;
    private Vector3 oldPos;


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
        if (currentPower > 0 )
        {
            powerText.color = Color.white;
        }
        if (attack)
        {
            Vector3 halfEnemyPos = oldPos + (enemyPos - oldPos)/2;

            transform.position = Vector3.MoveTowards(transform.position, halfEnemyPos , attackSpeed * Time.deltaTime );
            if (transform.position == halfEnemyPos)
            {
                attack = false;
                retreat = true;
            }
        }
        if (retreat)
        {
            if (currentPower != card.power)
            {
                powerText.text = CurrentPower.ToString();
                if (currentPower <= 0)
                {
                    currentPower = 0;
                    powerText.color = Color.red;
                }

            }
            transform.position = Vector3.MoveTowards(transform.position, oldPos, returnSpeed * Time.deltaTime);
        }

       
    }

    public void Attack(Vector3 enemyPos)
    {
        oldPos = transform.position;
        this.enemyPos = enemyPos;
        attack = true;
        retreat = false;
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

