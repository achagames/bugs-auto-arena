using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    public List<CardController> team;
    int size;



    public List<CardController> GetCards()
    {
        return team;
    }
    public int GetSize()
    {
        return size;
    }
}
