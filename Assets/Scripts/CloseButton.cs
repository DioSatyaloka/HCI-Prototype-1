using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public GameObject CanvasUI;
    private PlayerController Controller;
    private float mouseSensitivity;

    private void Awake()
    {
        Controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        
    }

    public void ButtonClose()
    {
        
        CanvasUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
