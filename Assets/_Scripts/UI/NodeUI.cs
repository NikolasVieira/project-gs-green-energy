using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class NodeUI : MonoBehaviour
{
    public GameObject canvas;
    public TextMeshProUGUI upgradeCost;
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


        canvas.SetActive(true);
    }

    public void Hide() 
    {
        canvas.SetActive(false);
    }

    public void Upgrade() {
        target.UpgradeTower();
        BuildManager.instance.DeselectNode();
    }
}
