using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public Team player;
    public Team enemy;

    List<CardController> playerCards;
    List<CardController> enemyCards;

    int currentSlot = 0;

    // Start is called before the first frame update
    void Start()
    {
        List<CardController> playerTeam = new List<CardController>();
        List<CardController> enemyTeam = new List<CardController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerCards = player.GetCards();
        enemyCards = enemy.GetCards();


        FightAlgorithm();

    }

    public void FightAlgorithm()
    {
        if (playerCards[currentSlot].AttacksLeft > 0)
        {
          // int playerPower = playerTeam[playerNr].GetPower();
           // int enemyPower = enemyTeam[playerNr].GetPower();
            //enemyTeam[playerNr].TakeDamage(playerPower);
           // playerTeam[playerNr].TakeDamage(enemyPower);

            playerCards[currentSlot].AttacksLeft--;
            enemyCards[currentSlot].AttacksLeft--;
        }

    }
}
