using UnityEngine;
using UnityEngine.EventSystems;

public class NodeController : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    private Color startColor;
    private Renderer rend;
    private GameObject tower;
    BuildManager buildManager;
    void Start() 
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    void OnMouseDown() 
    {
        if (buildManager.getTowerToBuild() == null)
        {
            return;
        }
        if (tower != null)
        {
            Debug.Log("Can't build there!");
            return;
        }
        GameObject towerToBuild = buildManager.getTowerToBuild();
        tower = (GameObject)Instantiate(towerToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter () 
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (buildManager.getTowerToBuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
    }
    void OnMouseExit(){
        rend.material.color = startColor;
    }
}
