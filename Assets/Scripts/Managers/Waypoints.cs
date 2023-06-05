using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    void Awake()
    {
        points = new Transform[transform.childCount]; //number of children under the parent
        for (int i = 0; i < points.Length; i++) //loops through each child and sets the transform of each in the array
        {
            points[i] = transform.GetChild(i);
        }
    }
}
