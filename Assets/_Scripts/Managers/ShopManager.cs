using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public TowerBlueprint standardTower;
    public TowerBlueprint anotherTower;
    BuildManager buildManager;
    void Start() {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTower() {
        buildManager.SelectTowerToBuild(standardTower);
    }
    public void SelectAnotherTower() {
        buildManager.SelectTowerToBuild(anotherTower);
    }
}