using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    public float movementLimit = 2.5f; // Limite maximo de movimiento en el eje X

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float movement = horizontalInput * speed * Time.deltaTime;

        // Limitar el movimiento dentro de los limites
        float newPositionX = Mathf.Clamp(transform.position.x + movement, -movementLimit, movementLimit);

        // Mover el objeto directamente sin usar Rigidbody
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
