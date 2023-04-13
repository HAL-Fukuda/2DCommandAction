using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyor : MonoBehaviour
{
    public float speed = 1.0f;
    
    public enum eDirection
    {
        Left,
        Right,
    }
    public eDirection direction = eDirection.Left;

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Command")
        {
            Transform objTransform = collision.gameObject.transform;

            // オブジェクトを移動させる
            switch (direction)
            {
                case eDirection.Left:
                    objTransform.position += Vector3.left * speed /10;
                    break;
                case eDirection.Right:
                    objTransform.position += Vector3.right * speed /10;
                    break;
            }
        }
    }
}
