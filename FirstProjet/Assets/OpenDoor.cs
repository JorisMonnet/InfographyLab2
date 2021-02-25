using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpenDoor : MonoBehaviour
{

	public GameObject door;
	public GameObject doorClosed;
	public GameObject doorOpened;

	private bool opened = false;

    private void OnTriggerEnter()
    {
        changeDoorState();
    }

    private void OnTriggerExit()
    {
        changeDoorState();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void changeDoorState()
    {
        if (opened)
        {
            // Close the door
            door.transform.DOMove(doorClosed.transform.position, 1f);
            door.transform.DORotateQuaternion(doorClosed.transform.rotation, 1f);
        }
        else
        {
            // Open the door
            door.transform.DOMove(doorOpened.transform.position, 1f);
            door.transform.DORotateQuaternion(doorOpened.transform.rotation, 1f);
        }

        opened = !opened;
    }
	
}
