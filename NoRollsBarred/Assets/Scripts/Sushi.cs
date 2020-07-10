using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sushi : MonoBehaviour
{
   
    private static float sceneWidth;
    private static float sceneHeight;
    private static bool sceneSizeIsInitialized;
    public static Sushi selectedSushi;
    private static Vector3 lastMousePos;
    private SushiCell[] cells;
    // Start is called before the first frame update
    void Start()
    {
        cells = GetComponentsInChildren<SushiCell>();
        if(!sceneSizeIsInitialized)
        {
            InitializeSceneSize();
        }
    }

    internal void Deselect()
    {
        selectedSushi = null;
    }

    private void Update()
    {
        if(selectedSushi==this)
        {
            gameObject.transform.position += new Vector3((Input.mousePosition.x-lastMousePos.x) / Screen.width * sceneWidth, (Input.mousePosition.y-lastMousePos.y)/ Screen.height * sceneHeight);
            lastMousePos = Input.mousePosition;
        }
    }

    internal void Select()
    {
        selectedSushi = this;
        lastMousePos = Input.mousePosition;
    }

    private static void InitializeSceneSize()
    {
        Vector2 topRightCorner = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));
        sceneWidth = topRightCorner.x*2;
        sceneHeight = topRightCorner.y*2;
    }
}
