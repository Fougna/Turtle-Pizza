using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    // Boolean variable to define if the player has picked up or not a pizza.
    // Booleans are set by default to false.
    bool hasPizza;

    // Serialized variable to set game object destruction delay.
    [SerializeField] float destroyDelay = 0.2f;

    // Serialized variable to set the car's color when a pizza is picked up.
    [SerializeField] Color32 hasPizzaColor = new Color32 (1, 1, 1, 1);

    // Serialized variable to set the car's color back to default.
    [SerializeField] Color32 noPizzaColor = new Color32 (1, 1, 1, 1);

    // Variable to call a sprite renderer component later.
    SpriteRenderer spriteRenderer;

    void Start()
    {
        // At the beginning of the game, we assign the GetComponent method to the sprite renderer variable.
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Method to set actions when the player collides on a trigger object.
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the car collides with an object tagged as 'Pizza', and doesn't already have a pizza...
        if (other.tag == "Pizza" && !hasPizza)
        {
            // The following message appears.
            Debug.Log("Pizza picked up !");
            // The car has picked up the pizza.
            hasPizza = true;
            // We get the color component of the sprite renderer and change the color of the car.
            spriteRenderer.color = hasPizzaColor;
            // Once picked up, the game object encountered (pizza) is removed with a delay between collision and removal.
            Destroy(other.gameObject, destroyDelay);
        }

        // If the car collides with an object tagged as 'Turtle'...
        if (other.tag == "Turtle" && hasPizza)
        {
            // The following message appears.
            Debug.Log("Pizza delivered !");
            // The car has delivered the pizza and don't have it anymore.
            hasPizza = false;
            // We get the color component of the sprite renderer and change the color of the car back to default.
            spriteRenderer.color = noPizzaColor;
            // Once picked up, the game object encountered (turtle) is removed with a delay between collision and removal.
            Destroy(other.gameObject, destroyDelay);
        }
    }
}
