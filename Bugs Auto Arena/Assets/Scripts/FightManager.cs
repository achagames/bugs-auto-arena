using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public Team player;
    public Team enemy;
    public float fightDelay = 5f;
    List<CardController> playerCards;
    List<CardController> enemyCards;

    int currentSlot = 0;
    bool fightOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerCards = player.GetCards();
        enemyCards = enemy.GetCards();
        print(playerCards);
        print(enemyCards);
        StartCoroutine(FightAlgorithm());
    }

    // Update is called once per frame
    void Update()
    {
        

        //if (!fightOver)
        //{
        //    FightAlgorithm();
        //}
        

    }

    public IEnumerator FightAlgorithm()
    {
        yield return new WaitForSeconds(fightDelay);
        if (!CheckDeath())
        {
          int playerPower = playerCards[currentSlot].CurrentPower;
          int enemyPower = enemyCards[currentSlot].CurrentPower;


            enemyCards[currentSlot].TakeDamage(playerPower);

            playerCards[currentSlot].TakeDamage(enemyPower);


        }
        else
        {
            if (currentSlot + 1 == Mathf.Max(playerCards.Count, enemyCards.Count))
            {
                fightOver = true;
                StopCoroutine(FightAlgorithm());
            }
            else
            {
                currentSlot++;
            }
        }

        
    }
    private bool CheckDeath()
    {
        if (playerCards[currentSlot].CurrentPower > 0 || enemyCards[currentSlot].CurrentPower > 0)
        {
            return false;
        }
        else
            return true;
    }
}
