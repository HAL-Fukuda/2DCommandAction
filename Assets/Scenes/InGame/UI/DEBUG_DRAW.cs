using UnityEngine;
using UnityEditor;

public class DEBUG_DRAW : MonoBehaviour
{
    public Vector2 scale = new Vector2(1.0f,1.0f);
    public bool fitToObject = false;

    private void OnDrawGizmos()
    {
        if (fitToObject)
        {
            Vector3 localScale = transform.localScale;
            scale.x = localScale.x;
            scale.y = localScale.y;
        }

        Handles.color = Color.red;
        Vector3[] corners = new Vector3[4];
        corners[0] = transform.position + new Vector3(-scale.x / 2, -scale.y / 2, 0f);
        corners[1] = transform.position + new Vector3(-scale.x / 2, scale.y / 2, 0f);
        corners[2] = transform.position + new Vector3(scale.x / 2, scale.y / 2, 0f);
        corners[3] = transform.position + new Vector3(scale.x / 2, -scale.y / 2, 0f);
        Handles.DrawSolidRectangleWithOutline(corners, new Color(1f, 0f, 0f, 0.1f), Color.red);
    }
}