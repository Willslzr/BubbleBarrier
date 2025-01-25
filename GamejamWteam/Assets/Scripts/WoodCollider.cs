using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detecta si la colisión es con un objeto de tipo "Burbuja"
        if (collision.gameObject.CompareTag("Bubble"))
        {
            Debug.Log($"{gameObject.name}: Colisión detectada con una burbuja");
            Destroy(collision.gameObject); // Destruye la burbuja
        }

        if (collision.gameObject.CompareTag("Fish"))
        {
            Debug.Log($"{gameObject.name}: Colisión detectada con un pez");
            Destroy(collision.gameObject); // Destruye el pez
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
