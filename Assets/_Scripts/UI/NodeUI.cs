using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class NodeUI : MonoBehaviour
{
    public GameObject canvas;
    public GameObject canvasRotate;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellCost;
    public Button btnUpgrade;
    private NodeController target;

    public void SetTarget(NodeController _target) {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = target.towerBlueprint.upgradeCost.ToString();
            btnUpgrade.interactable = true;
        }
        else
        {
            upgradeCost.text = "MAX";
            btnUpgrade.interactable = false;
        }

        sellCost.text = target.towerBlueprint.GetSellAmount().ToString();
        canvas.SetActive(true);
        if (target.tower.GetComponent<TowerController>().useWind)
        {
            canvasRotate.SetActive(true);
        } else
        {
            canvasRotate.SetActive(false);
        }
    }

    public void Hide() 
    {
        canvas.SetActive(false);
    }

    public void Upgrade() {
        target.UpgradeTower();
        BuildManager.instance.DeselectNode();
    }
    public void Sell() {
        target.SellTower();
        BuildManager.instance.DeselectNode();
    }
    public void TurnTowerClockwise() {
        target.TurnTowerClockwise();
    }
}
