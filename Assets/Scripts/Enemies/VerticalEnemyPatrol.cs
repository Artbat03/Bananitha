using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalEnemyPatrol : MonoBehaviour
{
    // Variables
    [Header("PATROL POINTS")]
    [SerializeField] private Transform upEdge;
    [SerializeField] private Transform downEdge;
    
    [Space(15)]
    [Header("ENEMY PARAMS")]
    [SerializeField] private Transform enemy;
    [SerializeField] private bool movingDown;
    [SerializeField] private float speed;

    private void Update()
    {
        VerticalMovement();
    }

    /// <summary>
    /// Method for checking if enemy has arrived at leftEdge or rightEdge in VERTICAL.
    /// ------------------------------------------------------------------------------------------------------------
    /// If enemy is moving left and if the y position of enemy is more or equal than the left edge y position,
    /// move the direction of enemy to -1, else changes the direction.
    /// ------------------------------------------------------------------------------------------------------------
    /// If enemy is moving right and if the y position of enemy is less or equal than the right edge y position,
    /// move the direction of enemy to 1, else changes the direction.
    /// </summary>
    private void VerticalMovement()
    {
        if (movingDown)
        {
            speed = 2f;
            if (enemy.position.y >= downEdge.position.y)
            {
                MoveToDirection(-1);
            }
            else
            {
                DirectionChange();
            }
        }
        else
        {
            speed = 1f;
            if (enemy.position.y <= upEdge.position.y)
            {
                MoveToDirection(1);
            }
            else
            {
                DirectionChange();
            }
        }
    }

    /// <summary>
    /// Method for changing movingUp if true to false, and if false to true
    /// </summary>
    private void DirectionChange()
    {
        movingDown = !movingDown;
    }

    /// <summary>
    /// Method for moving enemy through the time
    /// </summary>
    /// <param name="direction">The direction where enemy has to go</param>
    private void MoveToDirection(int direction)
    {
        // Up & Down
        enemy.position = new Vector3(enemy.position.x, enemy.position.y + Time.deltaTime * direction * speed,
            enemy.position.z);
    }
}
