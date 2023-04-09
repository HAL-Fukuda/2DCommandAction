using UnityEngine;
using UnityEditor;

public class DEBUG_DRAW : MonoBehaviour
{
    public float size = 1.0f;

    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Vector3[] corners = new Vector3[4];
        corners[0] = transform.position + new Vector3(-size, -size, 0f);
        corners[1] = transform.position + new Vector3(-size, size, 0f);
        corners[2] = transform.position + new Vector3(size, size, 0f);
        corners[3] = transform.position + new Vector3(size, -size, 0f);
        Handles.DrawSolidRectangleWithOutline(corners, new Color(1f, 0f, 0f, 0.1f), Color.red);
    }
}