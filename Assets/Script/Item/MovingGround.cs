using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{

    [Header("Patrol Point")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Movement parameters")]
    [SerializeField] private float speed;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    private Vector3 initScale;
    public bool movingLeft;

    [Header("Enemy")]
    [SerializeField] private Transform ground;

    private void Awake()
    {
        initScale = ground.localScale;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (ground.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                DirectionChange();
            }

        }
        else
        {
            if (ground.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                DirectionChange();
            }

        }

    }

    private void DirectionChange()
    {
        

        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }

    }
    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;

        ground.localScale = new Vector3(Mathf.Abs(initScale.x) * -_direction, initScale.y, initScale.z);
        ground.position = new Vector3(ground.position.x + Time.deltaTime * _direction * speed,
            ground.position.y,
            ground.position.z);
    }
}
