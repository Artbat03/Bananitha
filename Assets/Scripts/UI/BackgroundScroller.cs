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
        _img = GetComponent<RawImage>();
    }

    void FixedUpdate()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);

        counter++;
        
        if (counter == key && _x == 0.1f && _y == 0.1f)
        {
            _y = -0.1f;
            
            counter = 0;
        }
        else if (counter == key && _x == 0.1f && _y == -0.1f)
        {
            _x = -0.1f;

            counter = 0;
        }
        else if (counter == key && _x == -0.1f && _y == -0.1f)
        {
            _y = 0.1f;
            
            counter = 0;
        }
        else if (counter == key && _x == -0.1f && _y == 0.1f)
        {
            _x = 0.1f;
            
            counter = 0;
        }
    }
}
