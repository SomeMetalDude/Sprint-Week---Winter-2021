using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInteraction : MonoBehaviour
{
    public GameObject fourthWall;               //The fourth wall of the room
    public List<GameObject> roomWalls;         //All of the walls that make up the room
    public List<RoomInteraction> roomsToHide;   //List of other rooms to hide


    private void Start()
    {
        foreach (var wall in gameObject.GetComponentsInChildren<Wall>())
        {
            roomWalls.Add(wall.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerInputs>())
        {
            fourthWall.GetComponent<MeshRenderer>().enabled = false;
            
            foreach (var room in roomsToHide)
            {
                room.SetRoomWallsEnabled(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerInputs>())
        {
            fourthWall.GetComponent<MeshRenderer>().enabled = true;

            foreach (var room in roomsToHide)
            {
                room.SetRoomWallsEnabled(true);
            }
        }
    }

    public void SetRoomWallsEnabled(bool enabled)
    {
        foreach (var wall in roomWalls)
        {
            wall.GetComponent<MeshRenderer>().enabled = enabled;
        }
    }
}
