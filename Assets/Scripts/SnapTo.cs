using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapTo : MonoBehaviour
{
    private Draggable draggerScript;
    private bool gridIsOn;

    // Start is called before the first frame update
    void Start()
    {
        draggerScript = this.GetComponentInParent<Draggable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLIDED");
        if (draggerScript.isBeingDragged)
        {
            this.transform.parent.position = other.transform.position + (this.transform.parent.position - this.transform.position);
        }

    }
}
