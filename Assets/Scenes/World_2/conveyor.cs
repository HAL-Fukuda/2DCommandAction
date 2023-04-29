using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed = 1.0f;

    public Material material1; // �؂�ւ���}�e���A��1
    public Material material2; // �؂�ւ���}�e���A��2
    public float switchTime = 2f; // �}�e���A����؂�ւ���Ԋu

    private Renderer objectRenderer;
    private float timer = 0f;
    private bool isMaterial1 = true;
    public bool ONOFFconveyor;

    public enum eDirection
    {
        Left,
        Right,
    }
    public eDirection direction = eDirection.Left;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        ONOFFconveyor = true;
    }

    void Update()
    {
        if (ONOFFconveyor)
        {
            timer += Time.deltaTime;

            if (timer >= switchTime)
            {
                timer = 0f;
                isMaterial1 = !isMaterial1;

                if (isMaterial1)
                {
                    objectRenderer.material = material1;
                }
                else
                {
                    objectRenderer.material = material2;
                }
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (ONOFFconveyor)
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Command")
            {
                Transform objTransform = collision.gameObject.transform;

                // �I�u�W�F�N�g���ړ�������
                switch (direction)
                {
                    case eDirection.Left:
                        objTransform.position += Vector3.left * speed / 10;
                        break;
                    case eDirection.Right:
                        objTransform.position += Vector3.right * speed / 10;
                        break;
                }
            }
        }
    }
}
