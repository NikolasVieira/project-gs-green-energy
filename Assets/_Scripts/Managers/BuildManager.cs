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
    public GameObject buildEffct;
    private TowerBlueprint towerToBuild;
    private NodeController selectedNode;
    public NodeUI nodeUI;
    public bool CanBuild { get {return towerToBuild != null; } }
    public bool HasMoney { get {return StatsManager.Money >= towerToBuild.cost; } }
    public void SelectNode(NodeController node) {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        towerToBuild = null;
        
        nodeUI.SetTarget(node);
    }

    public void SelectTowerToBuild(TowerBlueprint tower) {
        towerToBuild = tower;
        DeselectNode();
    }

    public TowerBlueprint GetTowerToBuild() {
        return towerToBuild;
    }

    public void DeselectNode() {
        selectedNode = null;
        nodeUI.Hide();
    }
    
}
