using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 initialPosition;
    public float panSpeed = 30f;
    public float scrollSpeed = 5f;
    public float panBorderThickness = 10f;
    public float minY = 20f;
    public float maxY = 60f;

    // Limites para o movimento da câmera
    public float minX = -50f;
    public float maxX = 50f;
    public float minZ = -50f;
    public float maxZ = 50f;

    void Start() {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = initialPosition;
        }

        Vector3 direction = Vector3.zero;

        // Detectar entrada de movimento
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            direction += Vector3.back;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            direction += Vector3.right;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            direction += Vector3.left;
        }

        // Aplicar movimento
        transform.Translate(direction * panSpeed * Time.deltaTime, Space.World);

        // Zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;

        // Restringir altura (Y)
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        // Restringir posição X e Z
        pos.x = Mathf.Clamp(transform.position.x, minX, maxX);
        pos.z = Mathf.Clamp(transform.position.z, minZ, maxZ);

        transform.position = pos;
    }
}
