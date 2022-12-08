using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Players : MonoBehaviour
{
    public List<Blue> BlueTeam = new List<Blue>();
    public List<Red> RedTeam = new List<Red>();

    public void CachePlayersByColor()
    {
        string[] blueNames = AssetDatabase.FindAssets("BPlayer");

        foreach (string player in blueNames)
        {
            var SOpath = AssetDatabase.GUIDToAssetPath(player);
            var players = AssetDatabase.LoadAssetAtPath<Blue>(SOpath);
            Debug.Log(player + "" + SOpath);
            BlueTeam.Add(players);
        }


        string[] redNames = AssetDatabase.FindAssets("TRPlayer");

        foreach (string player in redNames)
        {
            var SOpath = AssetDatabase.GUIDToAssetPath(player);
            var players = AssetDatabase.LoadAssetAtPath<Red>(SOpath);
            Debug.Log(player + "" + SOpath);
            RedTeam.Add(players);
        }
    }

    private void Start()
    {
        CachePlayersByColor();
    }
}
