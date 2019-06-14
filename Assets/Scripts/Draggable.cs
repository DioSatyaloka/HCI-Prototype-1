using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draggable : MonoBehaviour
{
    Vector3 distance;
    public Camera cam;
    float rotY;
    float rotZ;
    float rotX;
    float posX;
    float posY;
    public int rotationSensitivity = 100;

    public bool withGrid = false;
    public bool fixedRotate = false;
    private bool rotateZ, rotateY, rotateX;
    private bool mouseHover;

    public bool isBeingDragged = false; 

    public Vector3 truePos;
    public float gridSize = 1;

    private void Start()
    {
        
    }

    private void Update()
    {
        withGrid = GameObject.Find("GridToggle").GetComponent<Toggle>().isOn;
        fixedRotate = GameObject.Find("RotateToggle").GetComponent<Toggle>().isOn;
        rotateZ = GameObject.Find("RotateZ").GetComponent<Toggle>().isOn;
        rotateX = GameObject.Find("RotateX").GetComponent<Toggle>().isOn;
        rotateY = GameObject.Find("RotateY").GetComponent<Toggle>().isOn;

        if (mouseHover)
        {
            if (Input.GetKeyDown("r"))
            {
                rotX = rotY = rotZ = 0;
            }

            if (Input.GetKeyDown(KeyCode.Backspace)) Destroy(this.gameObject);
        }
    }
    /*
    private void LateUpdate()
    {
        if (withGrid)
        {
            truePos.x = Mathf.Floor(transform.position.x / gridSize) * gridSize;
            truePos.y = Mathf.Floor(transform.position.y / gridSize) * gridSize;
            truePos.z = Mathf.Floor(transform.position.z / gridSize) * gridSize;

            transform.position = truePos;
        }
    }
    */
    private void OnMouseDown()
    {
        distance = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - distance.x;
        posY = Input.mousePosition.y - distance.y;

        
    }

    private void OnMouseDrag()
    {
        isBeingDragged = true;
        

        if (withGrid)
        {
            Vector3 currentPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, distance.z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(currentPos);
            transform.position = worldPosition;
            truePos.x = Mathf.Floor(transform.position.x / gridSize) * gridSize;
            truePos.y = Mathf.Floor(transform.position.y / gridSize) * gridSize;
            truePos.z = Mathf.Floor(transform.position.z / gridSize) * gridSize;

            transform.position = truePos;
        }
        else
        {
            Vector3 currentPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, distance.z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(currentPos);
            transform.position = worldPosition;
        }

            
    }

    private void OnMouseUp()
    {
        isBeingDragged = false;
    }

    private void OnMouseOver()
    {
        mouseHover = true;
        //ROTATE Y AXIS
        if (Input.mouseScrollDelta.y > 0 && rotateY)
        {
            if(fixedRotate) rotY += 45;
            rotY += Time.deltaTime * rotationSensitivity * Input.mouseScrollDelta.y;
            
        }


        if (Input.mouseScrollDelta.y < 0 && rotateY)
        {
            if (fixedRotate) rotY -= 45;
            rotY += Time.deltaTime * rotationSensitivity * Input.mouseScrollDelta.y;
            
        }

        //ROTATE Z AXIS
        if (Input.mouseScrollDelta.y > 0 && rotateZ)
        {
            if (fixedRotate) rotZ += 45;
            rotZ += Time.deltaTime * rotationSensitivity * Input.mouseScrollDelta.y;
        }

        if (Input.mouseScrollDelta.y < 0 && rotateZ)
        {
            if (fixedRotate) rotZ -= 45;
            rotZ += Time.deltaTime * rotationSensitivity * Input.mouseScrollDelta.y;
        }

        // ROTATE X AXIS
        if (Input.mouseScrollDelta.y > 0 && rotateX)
        {
            if (fixedRotate) rotX += 45;
            rotX += Time.deltaTime * rotationSensitivity * Input.mouseScrollDelta.y;
        }

        if (Input.mouseScrollDelta.y < 0 && rotateX)
        {
            if (fixedRotate) rotX -= 45;
            rotX += Time.deltaTime * rotationSensitivity * Input.mouseScrollDelta.y;
        }

        //rotY += Time.deltaTime * rotationSensitivity * Input.mouseScrollDelta.y;
        transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
        Debug.Log(rotZ);
        Debug.Log(Input.mouseScrollDelta.x);
    }

    private void OnMouseExit()
    {
        mouseHover = false;
    }
}
