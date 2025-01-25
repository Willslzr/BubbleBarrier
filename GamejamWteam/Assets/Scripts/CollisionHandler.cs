using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public GameEngine gameEngine;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detecta si la colisión es con un objeto de tipo "Burbuja"
        if (collision.gameObject.CompareTag("Bubble"))
        {
            // Llama a la función AddOxigen() si la referencia es válida
            if (gameEngine != null)
            {
                gameEngine.AddOxigen();
            }
            else
            {
                Debug.LogWarning("No se pudo llamar a AddOxigen porque GameEngine no está inicializado.");
            }

            Destroy(collision.gameObject); // Destruye la burbuja
        }

        if (collision.gameObject.CompareTag("Fish"))
        {
            Debug.Log("Te comio un pez, perdiste");
            gameEngine.GameOver();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
