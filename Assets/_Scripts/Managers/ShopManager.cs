using UnityEngine;

public class ShopManager : MonoBehaviour
{
    BuildManager buildManager;
    public TowerBlueprint SolarTower;
    public TowerBlueprint eolicTower;
    public TowerBlueprint gravityTower;
    public TowerBlueprint smartGridTower;
    void Start() {
        buildManager = BuildManager.instance;
    }
    public void SelectSolarTower() {
        buildManager.SelectTowerToBuild(SolarTower);
    }
    public void SelectEolicTower() {
        buildManager.SelectTowerToBuild(eolicTower);
    }
    public void SelectGravityTower() {
        buildManager.SelectTowerToBuild(gravityTower);
    }
    public void SelectSmartGridTower() {
        buildManager.SelectTowerToBuild(smartGridTower);
    }
}