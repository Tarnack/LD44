using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool isSelected;
    private Vector3 mOffset;
    private float mZCoord;




    // Update is called once per frame

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

    private void OnMouseDown()
    {
       // Transform parent = GameObject.FindGameObjectWithTag("Parent").transform;
        //GameObject gObject = Instantiate(go, Input.mousePosition, Quaternion.identity, parent);


        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();
        isSelected = true;

    }

    private void OnMouseUp()
    {
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
