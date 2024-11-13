using UnityEngine;

public class WaypointsManager : MonoBehaviour
{
    public static Transform[] waypoints;

    public void Awake() {
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }
}
