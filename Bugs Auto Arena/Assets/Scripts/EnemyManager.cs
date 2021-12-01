using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Team enemy;
    public Card[] allCards;
    public Transform spawn;
    public GameObject cardPrefab;

    private List<CardController> enemyCards;

    private void Start()
    {
        enemyCards = enemy.GetCards();
        SetEnemyTeam();
    }

    public void SetEnemyTeam()
    {
        for (int i = 0; i < enemyCards.Count; i++)
        {
            int randomNr = Random.Range(0, allCards.Length);

            GameObject newCard = Instantiate(cardPrefab, spawn.position, Quaternion.identity, spawn);
            newCard.GetComponent<CardController>().SetCard(allCards[randomNr]);
            newCard.tag = "Card";
            if (enemyCards[i] != null)
            {
                GameObject oldCard = enemyCards[i].gameObject;
                Destroy(oldCard);
            }
            enemyCards[i] = newCard.GetComponent<CardController>();
            
            
        }

        enemy.SetTeam(enemyCards);
    }
}
