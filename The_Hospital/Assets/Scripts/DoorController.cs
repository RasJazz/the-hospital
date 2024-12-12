using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false; // Tracks whether the door is open
    private UnityEngine.AI.NavMeshObstacle navMeshObstacle;
    private bool isPlayerNear = false; // Tracks if the player is near the door

    void Start()
    {
        navMeshObstacle = GetComponent<UnityEngine.AI.NavMeshObstacle>();
        if (navMeshObstacle == null)
        {
            Debug.LogError("NavMeshObstacle component is missing!");
        }
    }

    void Update()
    {
        // Check for player input to open/close the door
        if (isPlayerNear && Input.GetKeyDown(KeyCode.O))
        {
            if (isOpen)
            {
                CloseDoor();
            }
            else
            {
                OpenDoor();
            }
        }
    }

    public void OpenDoor()
    {
        isOpen = true;
        if (navMeshObstacle != null)
        {
            navMeshObstacle.enabled = false; // Disable obstacle to allow navigation
        }
        Debug.Log("Door is now open.");
    }

    public void CloseDoor()
    {
        isOpen = false;
        if (navMeshObstacle != null)
        {
            navMeshObstacle.enabled = true; // Enable obstacle to block navigation
        }
        Debug.Log("Door is now closed.");
    }

    // Detect if the player is near the door
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Player is near the door.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("Player left the door.");
        }
    }
}
