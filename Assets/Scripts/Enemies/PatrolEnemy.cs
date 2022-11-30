using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    // Variables
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [SerializeField] private Transform enemy;
    [SerializeField] private bool movingLeft;
    [SerializeField] private float speed;
    
    void Update()
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

    private void DirectionChange()
    {
        movingLeft = !movingLeft;
    }

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

        /*// Up & Down
        enemy.position = new Vector3(enemy.position.x, enemy.position.y + Time.deltaTime * direction * speed,
           enemy.position.z);*/
    }
}
