using System;
using UnityEngine;

[System.Serializable]
public class TowerBlueprint {
    public String Name;
    [TextArea] public String Description;
    public GameObject prefab;
    public int cost;
    public GameObject upgradedPrefab;
    public int upgradeCost;
    public int GetSellAmount () 
    {
        return cost/2;
    }
}
