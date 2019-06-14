using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectAdder : MonoBehaviour
{
    public Button[] adderButtons;
    public GameObject[] ObjectList;
    public GameObject[] ObjectPool;

    public GameObject CanvasUI;
    public GameObject player;
    public float spawnDistance = 3;

    public bool withGrid = false;
    public bool fixedRotate = false;
    public Toggle gridToggle;
    public Toggle rotateToggle;

    public string[] buttonNames;

    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i < adderButtons.Length; i++)
        {
            buttonNames[i] = adderButtons[i].name.ToString();
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        //buka INVENTORY
        if (Input.GetKeyDown("i"))
        {
            CanvasUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }

        if (CanvasUI.activeInHierarchy)
        { 

            for (int i = 0; i < adderButtons.Length; i++)
            {
                ObjectList[i].GetComponent<Draggable>().withGrid = gridToggle;
                ObjectList[i].GetComponent<Draggable>().fixedRotate = rotateToggle;
            }
        }
    }

    public void ButtonAdder()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        int buttonIndex = System.Array.IndexOf(buttonNames, buttonName);
        Debug.Log(buttonIndex);
        Instantiate(ObjectList[buttonIndex], new Vector3(player.transform.position.x + spawnDistance, 0f, player.transform.position.z + spawnDistance), player.transform.rotation);

    }

}
