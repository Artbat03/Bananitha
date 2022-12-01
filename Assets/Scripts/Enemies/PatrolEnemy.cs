using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    // Variables
    [Header("PATROL POINTS")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    
    [Space(15)]
    [Header("ENEMY PARAMS")]
    [SerializeField] private Transform enemy;
    [SerializeField] private bool movingLeft;
    [SerializeField] private float speed;
    
    void Update()
    {
        if (enemy.CompareTag("HorizontalEnemy") || enemy.CompareTag("DiagonalEnemy"))
        {
            HorizontalDiagonalMovement();
        }
    }

    /// <summary>
    /// Method for checking if enemy has arrived at leftEdge or rightEdge in HORIZONTAL and DIAGONAL
    /// ------------------------------------------------------------------------------------------------------------
    /// If enemy is moving left and if the x position of enemy is more or equal than the left edge x position,
    /// move the direction of enemy to -1, else changes the direction.
    /// ------------------------------------------------------------------------------------------------------------
    /// If enemy is moving right and if the x position of enemy is less or equal than the right edge x position,
    /// move the direction of enemy to 1, else changes the direction.
    /// </summary>
    private void HorizontalDiagonalMovement()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
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
            if (enemy.position.x <= rightEdge.position.x)
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
    /// Method for changing movingLeft if true to false, and if false to true
    /// </summary>
    private void DirectionChange()
    {
        movingLeft = !movingLeft;
    }

    /// <summary>
    /// Method for moving enemy through the time
    /// </summary>
    /// <param name="direction">The direction where enemy has to go</param>
    private void MoveToDirection(int direction)
    {
        if (enemy.CompareTag("HorizontalEnemy"))
        {
            // Left & Right
            enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed, enemy.position.y,
                enemy.position.z);
        }

        else if (enemy.CompareTag("DiagonalEnemy"))
        {
            // Diagonal
            enemy.position = new Vector3(enemy.position.y, enemy.position.y + Time.deltaTime * direction * speed,
                enemy.position.z);
        }
    }
}
