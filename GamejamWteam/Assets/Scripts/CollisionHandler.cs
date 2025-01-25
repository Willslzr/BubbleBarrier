using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public AudioSource audioPlayer; // Componente AudioSource
    public AudioClip bubbleSound;   // Sonido para las burbujas
    public AudioClip fishSound;     // Sonido para los peces

    public GameEngine gameEngine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detecta si la colisión es con un objeto de tipo "Burbuja"
        if (collision.gameObject.CompareTag("Bubble"))
        {
            gameEngine.AddOxigen();
            Destroy(collision.gameObject); // Destruye la burbuja

            // Reproducir sonido de burbuja
            audioPlayer.clip = bubbleSound;
            audioPlayer.Play();
        }

        // Detecta si la colisión es con un objeto de tipo "Pez"
        if (collision.gameObject.CompareTag("Fish"))
        {
            Debug.Log("Te comio un pez, perdiste");
            gameEngine.GameOver();

            // Reproducir sonido de pez
            audioPlayer.clip = fishSound;
            audioPlayer.Play();
        }
    }
}
