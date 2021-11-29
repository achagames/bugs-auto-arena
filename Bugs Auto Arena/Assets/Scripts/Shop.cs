using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Card[] allCards;

    public Transform shopSlotsParent;
    public GameObject cardPrefab;

    private Transform[] shopSlots;
    private List<GameObject> shopCards;
    private void Start()
    {
     shopCards = new List<GameObject>();
    shopSlots = shopSlotsParent.GetComponentsInChildren<Transform>();
        RefreshShop();
    }
    private void RefreshShop()
    {
        for (int i = 1; i < shopSlots.Length; i++)
        {
            int randomNr = Random.Range(0, allCards.Length);

            GameObject newCard = Instantiate(cardPrefab, shopSlots[i].position, Quaternion.identity, shopSlots[i]);
            newCard.GetComponent<CardController>().SetCard(allCards[randomNr]);
            shopCards.Add(newCard);
        }
        
    }
}
