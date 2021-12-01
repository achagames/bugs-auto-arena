using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Card[] allCards;

    public Transform shopSlotsParent;
    public Transform playerSlotsParent;
    public GameObject cardPrefab;
    public GameObject emptyCardPrefab;

    public Team player;

    private Transform[] shopSlots;
    private Transform[] playerSlots;
    private List<GameObject> shopCards;
    private List<CardController> playerCards;
    private bool canRefresh = true;

    private void Start()
    {
        playerCards = player.GetCards();
        shopCards = new List<GameObject>();
       shopSlots = shopSlotsParent.GetComponentsInChildren<Transform>();
        playerSlots = playerSlotsParent.GetComponentsInChildren<Transform>();
        RefreshShop();
        RefreshPlayerCards();
    }

    private void RefreshShop()
    {
        foreach (GameObject card in shopCards)
        {
            if(card != null)
            Destroy(card);
        }

        for (int i = 1; i < shopSlots.Length; i++)
        {
            int randomNr = Random.Range(0, allCards.Length);

            GameObject newCard = Instantiate(cardPrefab, shopSlots[i].position, Quaternion.identity, shopSlots[i]);
            newCard.GetComponent<CardController>().SetCard(allCards[randomNr]);
            newCard.tag = "ShopCard";
            shopCards.Add(newCard);
        }
        
    }
    
    private void RefreshPlayerCards()
    {
        for (int i = 1; i < playerSlots.Length; i++)
        {

            if (playerCards[i - 1] != null)
            {

            GameObject newCard = Instantiate(playerCards[i - 1].gameObject, playerSlots[i].position, Quaternion.identity, playerSlots[i]);
                if (!newCard.CompareTag("EmptyCard"))
                {
                newCard.tag = "Card";

                }
                GameObject oldCard = playerCards[i - 1].gameObject;
                playerCards[i - 1] = newCard.GetComponent<CardController>();
                Destroy(oldCard.gameObject);
            }
            else
            {
                GameObject empty = Instantiate(emptyCardPrefab, playerSlots[i].position, Quaternion.identity, playerSlots[i]);
                playerCards[i - 1] = empty.GetComponent<CardController>();

            }
        }
    }

    public bool BuyCard(CardController card)
    {
        for (int i = 0; i < playerCards.Count; i++)
        {
            if (playerCards[i].CompareTag("EmptyCard"))
            {
                card.tag = "Card";
                playerCards[i] = card;
                player.SetTeam(playerCards);
                RefreshPlayerCards();
                return true;
            }
        }
        return false;
        

    }
    public bool SellCard(CardController card)
    {
        for (int i = 0; i < playerCards.Count; i++)
        {
           
            if (playerCards[i] == card)
            {
                playerCards[i] = null;
                Destroy(card);
                player.SetTeam(playerCards);
                RefreshPlayerCards();
                return true;
            }
        }
        return false;
    }
    public void RefreshByButton()
    {
        if (canRefresh)
        {
            RefreshShop();
            canRefresh = false;
        }
    }
    public void BackToShop()
    {
        RefreshShop();
        RefreshPlayerCards();
        canRefresh = true;
    }
}
