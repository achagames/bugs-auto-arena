using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    public List<CardController> team;
    int size;

    private void Awake()
    {
        team = new List<CardController>();
    }

    public List<CardController> GetCards()
    {
        return team;
    }
    public int GetSize()
    {
        return size;
    }
}
