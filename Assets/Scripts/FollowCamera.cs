using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Creation of a game object selector, in order to link the camera with the selected game object later.
    [SerializeField] GameObject thingToFollow;

    // Variable for camera's X coordinates.
    [SerializeField] float cameraXCoordinates = 0;

    // Variable for camera's Y coordinates.
    [SerializeField] float cameraYCoordinates = 0;

    // Variable for camera's Z coordinates.
    [SerializeField] float cameraZCoordinates = -10;

    // Update has been modified to LateUpdate in order to insure Unity will update the camera movement
    // after all other elements have been updated (such as physics...).
    // This can avoid any jittering from the camera and keep its movement smooth.
    void LateUpdate()
    {
        // Variable of camera's position is equal to selected game object's position.
        // Since the camera is exactly on the game object, we need to elevate it a little so we can see the screen.
        // In order to do so, we add a new "Vector3" for X, Y, Z coordinates.
        transform.position = thingToFollow.transform.position + new Vector3 (cameraXCoordinates, cameraYCoordinates, cameraZCoordinates);
    }
}