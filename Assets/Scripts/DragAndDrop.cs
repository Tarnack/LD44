using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool selected;
    // Update is called once per frame
    void Update()
    {
      if(selected)
            transform.position = new Vector2();
        }

        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
        }

    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            selected = true;
        }
    }
}
