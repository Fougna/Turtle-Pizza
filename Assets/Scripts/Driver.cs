using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Variable that defines the rotation speed of the car when it turns.
    [SerializeField] float rotateSpeed = 0.1f;
    
    // Variable that defines the actual moving speed of the car.
    [SerializeField] float moveSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Variable that defines the rotation speed can be changed when using the input method GetAxis,
        // attached to the "Horizontal" parameter in Unity's Input Manager.
        // Added multiply by the rotateSpeed value (to match its default value).
        // Added multiply by the Time.deltaTime that will modify the number of frames required
        // depending on the power of the computer it runs on.
        float rotateAmount = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

        // Variable that defines the move speed can be changed when using the input method GetAxis,
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