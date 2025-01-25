using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCollider : MonoBehaviour
{
    public AudioSource audioPlayer; // Componente AudioSource
    public AudioClip bubbleSound;   // Sonido para las burbujas
    public AudioClip fishSound;     // Sonido para los peces

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
            // Reproducir sonido de burbuja
            audioPlayer.clip = bubbleSound;
            audioPlayer.Play();
        }

        if (collision.gameObject.CompareTag("Fish"))
        {
            Debug.Log($"{gameObject.name}: Colisión detectada con un pez");
            Destroy(collision.gameObject); // Destruye el pez
            // Reproducir sonido de pez
            audioPlayer.clip = fishSound;
            audioPlayer.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
