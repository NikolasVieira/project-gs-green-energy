using UnityEngine;

public class ShopManager : MonoBehaviour
{
    BuildManager buildManager;
    void Start() {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTower() {
        buildManager.SetTowerToBuild(buildManager.standardTowerPrefab);
    }
    public void PurchaseAnotherTower() {
        buildManager.SetTowerToBuild(buildManager.anotherTowerPrefab);
    }
}