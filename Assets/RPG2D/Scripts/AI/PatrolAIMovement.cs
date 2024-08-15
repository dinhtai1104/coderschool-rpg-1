using System.Collections.Generic;
using UnityEngine;

public class PatrolAIMovement : AIMovement // Inheritance
{
    // Move Patrol
    [SerializeField] private List<Transform> listPoint;

    private List<Vector3> listPosition;

    private int currentIndexPos = 0;

    private void Start()
    {
        listPosition = new List<Vector3>();
        foreach (var point in listPoint)
        {
            listPosition.Add(point.position);
        }
    }
    private void Update()
    {
        if (currentIndexPos >= listPosition.Count)
        {
            currentIndexPos = 0;
        }

        Vector2 direction = listPosition[currentIndexPos] - transform.position;
        if (direction.magnitude <= 0.05f)
        {
            currentIndexPos++;
        }
        direction.Normalize();
        Vector2 velocity = direction * moveSpeed;

        velocity.y = 0;

        Move(velocity);
        FlipHandler(velocity);
    }
}