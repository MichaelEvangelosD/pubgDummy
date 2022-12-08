using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ControlPointManager : MonoBehaviour
{
    //this is a control point manager...
    //when a team of players enter a control point room...
    //based on the number of players of each team...
    //if one team have more players in the room...
    //give points to that team.

    public List<GameObject> BlueTeam = new List<GameObject>();
    public List<GameObject> RedTeam = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Red>())
        {
            Debug.Log("Hello");
            CountRedPlayers(gameObject);
        }
        else if (other.gameObject.GetComponent<Blue>())
        {
            CountBluePlayers(gameObject);
        }
    }

    public void CountRedPlayers(GameObject player)
    {
        RedTeam.Add(player);
    }

    public void CountBluePlayers(GameObject player)
    {
        BlueTeam.Add(player);
    }

    public void GivePoints()
    {
        //this method will give the point in the team...
        //with the most players in a room.

        if(BlueTeam.Count > RedTeam.Count)
        {
            //TODO: Give points

            Debug.Log("Blue team takes the point");
        }
        else if(BlueTeam.Count == RedTeam.Count)
        {
            //TODO: Dont give points

            Debug.Log("No team takes the point");
        }
        else
        {
            //TODO: Give points

            Debug.Log("Red team takes the point");
        }

    }

    private void Update()
    {
        GivePoints();
    }
}
