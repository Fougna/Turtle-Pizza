using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Serialized variable that sets the rotation speed of the car when it turns.
    [SerializeField] float rotateSpeed = 0.1f;
    
    // Serialized variable that sets the actual moving speed of the car.
    [SerializeField] float moveSpeed = 0.01f;

    // Serialized variable that sets the speed slowdown amount when a car will bump on an obstacle.
    [SerializeField] float slowSpeed = 15f;

    // Serialized variable that sets the speed boost amount when a car will collide in a booster.
    [SerializeField] float boostSpeed = 30f;

    // Serialized variable to set game object destruction delay.
    [SerializeField] float destroyDelay = 0.2f;

    // Collision method to slow down the car when it hits an obstacle.
    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }

    // Trigger method to speed up the car when it collides with a booster.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Booster")
        {
            // Actual speed becomes boost speed.
            moveSpeed = boostSpeed;
            // Booster is removed after collision.
            Destroy(other.gameObject, destroyDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Variable that sets the rotation speed to be changed when using the input method GetAxis,
        // attached to the "Horizontal" parameter in Unity's Input Manager.
        // Added multiply by the rotateSpeed value (to match its default value).
        // Added multiply by the Time.deltaTime that will modify the number of frames required
        // depending on the power of the computer it runs on.
        float rotateAmount = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

        // Variable that sets the move speed to be changed when using the input method GetAxis,
        // attached to the "Vertical" parameter in Unity's Input Manager.
        // Added multiply by the moveSpeed value (to match its default value).
        // Added multiply by the Time.deltaTime that will modify the number of frames required
        // depending on the power of the computer it runs on.
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Rotate the object on axis (X, Y, Z).
        // The rotateAmount variable has a negative value because by default the controls are backwards,
        // so now they are reversed to the correct position.
        transform.Rotate(0, 0, -rotateAmount);

        // Move the object on axis (X, Y, Z).
        transform.Translate(0, moveAmount,0);
    }
}