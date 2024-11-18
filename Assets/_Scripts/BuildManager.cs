using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    void Awake() {
        if (instance != null)
        {
            Debug.Log("More than on BuildManager in scene!");
        }
        instance = this;
    }
    public GameObject standardTowerPrefab;
    void Start () {
        towerToBuild = standardTowerPrefab;
    }
    private GameObject towerToBuild;
    public GameObject getTowerToBuild() {
        return towerToBuild;
    }
}
