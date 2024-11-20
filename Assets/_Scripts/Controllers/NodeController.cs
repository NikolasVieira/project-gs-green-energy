using UnityEngine;
using UnityEngine.EventSystems;

public class NodeController : MonoBehaviour
{
    public Color hoverColor;
    public Color nothEnoughMoney;
    public Vector3 positionOffset;
    [Header("Optional")]
    public GameObject tower;
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
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (tower != null)
        {
            Debug.Log("Can't build there!");
            return;
        }
        buildManager.BuildTowerOn(this);
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
