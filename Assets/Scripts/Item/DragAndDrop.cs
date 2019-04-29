using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool isSelected;
    private Vector3 mOffset;
    private float mZCoord;
    private Vector3 originalsize;


    private void Start()
    {
        originalsize = GetComponent<Transform>().localScale;
    }

    private void OnMouseDrag()
    {
       
        transform.position = GetMouseWorldPos() + mOffset;
    }

    private void OnMouseDown()
    {
        // Transform parent = GameObject.FindGameObjectWithTag("Parent").transform;
        //GameObject gObject = Instantiate(go, Input.mousePosition, Quaternion.identity, parent);

        GetComponent<Transform>().localScale = new Vector3(GetComponent<Transform>().localScale.x * 2, GetComponent<Transform>().localScale.y * 2, GetComponent<Transform>().localScale.z * 2);
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();
        isSelected = true;

    }

    private void OnMouseUp()
    {
        GetComponent<Transform>().localScale = originalsize;
        isSelected = false;
    }

    private Vector3 GetMouseWorldPos()
    {
        //pixel coordinates (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

   
}
