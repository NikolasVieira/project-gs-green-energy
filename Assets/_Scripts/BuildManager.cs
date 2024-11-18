using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    void Awake() 
    {
        if (instance != null)
        {
            Debug.Log("More than on BuildManager in scene!");
        }
        instance = this;
    }
    public GameObject standardTowerPrefab;
    public GameObject anotherTowerPrefab;
    private TowerBlueprint towerToBuild;
    public bool CanBuild { get {return towerToBuild != null; } }
    public void BuildTowerOn(NodeController node) {
        if (StatsManager.Money < towerToBuild.cost)
        {
            Debug.Log ("Not Money");
            return;
        }
        StatsManager.Money -= towerToBuild.cost;
        GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.tower = tower;
        Debug.Log("Current Money: "+StatsManager.Money);
    }
    public void SelectTowerToBuild(TowerBlueprint tower) {
        towerToBuild = tower;
    }
}
