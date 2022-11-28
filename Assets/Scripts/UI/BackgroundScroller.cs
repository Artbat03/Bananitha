using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroller : MonoBehaviour
{
    // Variables
    [SerializeField] private RawImage _img;
    [SerializeField] private float _x = 0.1f;
    [SerializeField] private float _y = 0.1f;

    [SerializeField] private int counter;
    [SerializeField] private int key = 320;
 

    private void Awake()
    {
        // Getting the Raw Image component
        _img = GetComponent<RawImage>();
    }

    void FixedUpdate()
    {
        // Moving the uvRect of the Raw Image
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);

        // Increasing the counter
        counter++;
        
        // If the counter gets the key and x and y are 0.1f, y changes to -0.1f and we restart the counter
        if (counter == key && _x == 0.1f && _y == 0.1f)
        {
            _y = -0.1f;
            
            counter = 0;
        }
        // If the counter gets the key and x is equal to 0.1f and y is equal to -0.1f, x changes to -0.1f and we restart the counter
        else if (counter == key && _x == 0.1f && _y == -0.1f)
        {
            _x = -0.1f;

            counter = 0;
        }
        // If the counter gets the key and x and y are -0.1f, y changes to 0.1f and we restart the counter
        else if (counter == key && _x == -0.1f && _y == -0.1f)
        {
            _y = 0.1f;
            
            counter = 0;
        }
        // If the counter gets the key and x is equal to -0.1f and y is equal to 0.1f, x changes to 0.1f and we restart the counter
        else if (counter == key && _x == -0.1f && _y == 0.1f)
        {
            _x = 0.1f;
            
            counter = 0;
        }
    }
}
