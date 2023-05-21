using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move5 : MonoBehaviour
{
    public float moveDistance = 1f;
    public float moveDuration = 1f;
    public Ease moveEase = Ease.Linear;

    private bool isMovingRight = true;
    private Vector3 initialPosition;
    private void Start()
    {
        initialPosition = transform.position;
        MoveObject();
    }

    private void MoveObject()
    {
        float targetX = isMovingRight ? initialPosition.x + moveDistance : initialPosition.x - moveDistance;
        transform.DOMoveX(targetX, moveDuration).SetEase(moveEase).OnComplete(ChangeDirection);
    }

    private void ChangeDirection()
    {
        isMovingRight = !isMovingRight;
        MoveObject();
    }
}
