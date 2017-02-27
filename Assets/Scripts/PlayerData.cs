using UnityEngine;
using System.Collections;

public class PlayerData
{
    public string id;
    public string name;
    public float scores;
    public float seeds;
    public PlayerData(string newId, string newName, float newScores, float newSeeds)
    {
        id = newId;
        name = newName;
        scores = newScores;
        seeds = newSeeds;
    }
}
