using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(PlayerController))]
public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    public float mouseSensitivity = 3f;
    public float tempMouseSensitivity = 3f;

    public Toggle GridToggle, RotationToggle, RotateZ, RotateX, RotateY;
    public GameObject CanvasUI;
    private PlayerMotor motor;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.mouseScrollDelta.y.ToString());
        Debug.Log(Input.mouseScrollDelta.x.ToString());

        Cursor.visible = true;
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");
        float yMov = 0f;
        

        if (Input.GetKey(KeyCode.Space) && yMov < 1) yMov += 0.1f;
        if (Input.GetKey(KeyCode.LeftControl)) yMov -= 0.1f;

        if (Input.GetKeyDown("g"))
        {
            if (GridToggle.isOn) GridToggle.isOn = false;
            else GridToggle.isOn = true;
        }

        if (Input.GetKeyDown("t"))
        {
            if (RotationToggle.isOn) RotationToggle.isOn = false;
            else RotationToggle.isOn = true;
        }


        //ROTATION TOGGLES
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            RotateZ.isOn = true;
            RotateX.isOn = false;
            RotateY.isOn = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RotateZ.isOn = false;
            RotateX.isOn = false;
            RotateY.isOn = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            RotateZ.isOn = false;
            RotateX.isOn = true;
            RotateY.isOn = false;
        }

        //ENDOF ROTATION TOGGLES


        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;
        Vector3 movUpDown = transform.up * yMov;
        

        Vector3 velocity = (movHorizontal + movVertical + movUpDown).normalized * speed;

        motor.Move(velocity);

        //ROTATION
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRot, 0f) * mouseSensitivity;

        motor.Rotate(rotation);

        //CAMERA ROTATION
        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot, 0f, 0f) * mouseSensitivity;

        motor.RotateCamera(cameraRotation);


        //ROTATION DISABLER
        if (CanvasUI.activeInHierarchy)
        {
            
            mouseSensitivity = 0;
        }
        else mouseSensitivity = tempMouseSensitivity;

    }

    private void OnApplicationFocus(bool focus)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
