using UnityEngine;

public class PanelController : MonoBehaviour
{
    public bool isActive;

    public void Start() {
        isActive = false;
        this.gameObject.SetActive(isActive);
    }

    public void ToggleUI() {
        isActive = !isActive; // Atualiza o estado de isActive
        this.gameObject.SetActive(isActive);
    }
}
