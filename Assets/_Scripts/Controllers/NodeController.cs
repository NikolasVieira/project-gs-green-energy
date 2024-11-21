using UnityEngine;
using UnityEngine.EventSystems;

public class NodeController : MonoBehaviour
{
    public Color hoverColor;
    public Color nothEnoughMoney;
    public Vector3 positionOffset;
    [HideInInspector] public GameObject tower;
    [HideInInspector] public TowerBlueprint towerBlueprint;
    [HideInInspector] public bool isUpgraded;
    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;
    void Start() 
    {
        rend = GetComponentInChildren<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition() 
    {
        return transform.position + positionOffset;
    }    

    void OnMouseDown() 
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (tower != null){
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild)
            return;
        BuildTower(buildManager.GetTowerToBuild());
    }

    void BuildTower(TowerBlueprint blueprint) {
        if (StatsManager.Money < blueprint.cost)
            return;
        StatsManager.Money -= blueprint.cost;

        GameObject _tower = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        tower = _tower;

        towerBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffct, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    public void UpgradeTower() {
        if (StatsManager.Money < towerBlueprint.upgradeCost)
            return;
        StatsManager.Money -= towerBlueprint.upgradeCost;
        Destroy(tower);

        GameObject _tower = (GameObject)Instantiate(towerBlueprint.prefab, GetBuildPosition(), Quaternion.identity);
        tower = _tower;
        
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffct, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
    }

    void OnMouseEnter () 
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else 
        {
            rend.material.color = nothEnoughMoney;
        }
    }
    void OnMouseExit(){
        rend.material.color = startColor;
    }
}
