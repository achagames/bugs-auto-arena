using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    public List<CardController> team;


    public List<CardController> GetCards()
    {
        return team;
    }
    public void SetTeam(List<CardController> newTeam)
    {
        team = newTeam;
    }

}
