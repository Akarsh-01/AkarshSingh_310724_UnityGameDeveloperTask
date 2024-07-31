using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour
{
    public GameObject left, right, up; 
    private groundCheck gc; 
    private GameObject lastSelectedObject;

    void Start()
    {
        gc = GetComponent<groundCheck>();
        
        left.SetActive(false);
        right.SetActive(false);
        up.SetActive(false);
    }

    void Update()
    {
        if (gc != null && gc.isGrounded)
        {
            HandleInput();
            if (Input.GetKeyDown(KeyCode.Return))
            {
                DeactivateAllObjects();
                lastSelectedObject = null;
            }
        }
    }

    void HandleInput()
    {
        left.SetActive(false);
        right.SetActive(false);
        up.SetActive(false);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            lastSelectedObject = up;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            lastSelectedObject = right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            lastSelectedObject = left;
        }

        if (lastSelectedObject != null)
        {
            lastSelectedObject.SetActive(true);
        }
    }

    void DeactivateAllObjects()
    {
        left.SetActive(false);
        right.SetActive(false);
        up.SetActive(false);
    }
}
