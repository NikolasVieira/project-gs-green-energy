using UnityEngine;

public class NodeController : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    private Color startColor;
    private Renderer rend;
    private GameObject tower;
    void Start() 
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    void OnMouseDown() 
    {
        if (tower != null)
        {
            Debug.Log("Can't build there!");
            return;
        }
        GameObject towerToBuild = BuildManager.instance.getTowerToBuild();
        tower = (GameObject)Instantiate(towerToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter () 
    {
        rend.material.color = hoverColor;
    }
    void OnMouseExit(){
        rend.material.color = startColor;
    }
}
