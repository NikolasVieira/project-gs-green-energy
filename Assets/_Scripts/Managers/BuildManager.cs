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
    public GameObject buildEffct;
    private TowerBlueprint towerToBuild;
    public bool CanBuild { get {return towerToBuild != null; } }
    public bool HasMoney { get {return StatsManager.Money >= towerToBuild.cost; } }
    public void BuildTowerOn(NodeController node) {
        if (StatsManager.Money < towerToBuild.cost)
        {
            return;
        }
        StatsManager.Money -= towerToBuild.cost;
        GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.tower = tower;
        GameObject effect = (GameObject)Instantiate(buildEffct, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }
    public void SelectTowerToBuild(TowerBlueprint tower) {
        towerToBuild = tower;
    }
}
