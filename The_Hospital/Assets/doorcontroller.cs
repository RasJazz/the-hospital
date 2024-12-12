using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false; // Tracks whether the door is open
    private UnityEngine.AI.NavMeshObstacle navMeshObstacle;

    void Start()
    {
        navMeshObstacle = GetComponent<UnityEngine.AI.NavMeshObstacle>();
        if (navMeshObstacle == null)
        {
            Debug.LogError("NavMeshObstacle component is missing!");
        }
    }

    public void OpenDoor()
    {
        // Logic to open the door (e.g., play animation)
        isOpen = true;
        if (navMeshObstacle != null)
        {
            navMeshObstacle.enabled = false; // Disable obstacle to allow navigation
        }
        Debug.Log("Door is now open.");
    }

    public void CloseDoor()
    {
        // Logic to close the door (e.g., play animation)
        isOpen = false;
        if (navMeshObstacle != null)
        {
            navMeshObstacle.enabled = true; // Enable obstacle to block navigation
        }
        Debug.Log("Door is now closed.");
    }

    void Update()
    {
    if (Input.GetKeyDown(KeyCode.O)) // Press 'O' to open the door
    {
        OpenDoor();
    }
    if (Input.GetKeyDown(KeyCode.C)) // Press 'C' to close the door
    {
        CloseDoor();
    }
    }

}
