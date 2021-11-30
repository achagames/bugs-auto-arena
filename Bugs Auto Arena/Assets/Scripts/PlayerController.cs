using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask selectableMask;
    public Shop shop;

    private Vector3 originalPos;
    private Camera cam;
    private bool hasSelected;
    private GameObject selectedCard;

    private void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (hasSelected)
        {
            Vector3 mousePos = Input.mousePosition;
            selectedCard.transform.position = cam.ScreenToWorldPoint(mousePos);
            selectedCard.transform.position = new Vector3(selectedCard.transform.position.x, selectedCard.transform.position.y, 0);
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D[] hits = Physics2D.RaycastAll(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                foreach (RaycastHit2D hit in hits)
                {
                    if (hit.collider.gameObject.CompareTag("EmptyCard"))
                    {

                        if (selectedCard.CompareTag("ShopCard") && shop.BuyCard(selectedCard.GetComponent<CardController>()))
                        {
                            Destroy(selectedCard);
                            hasSelected = false;
                            return;
                        }

                    }
                    if (hit.collider.gameObject.CompareTag("Sell"))
                    {
                        shop.SellCard(selectedCard.GetComponent<CardController>());
                    }
                }
                    selectedCard.transform.position = originalPos;
                    hasSelected = false;
            }
        }

        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    originalPos = hit.transform.position;
                    selectedCard = hit.collider.gameObject;
                    hasSelected = true;
                    print("Selected a card");
                }
            }
        }
        }

          
    }

