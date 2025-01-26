using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCollider : MonoBehaviour
{
    public AudioSource audioPlayer; // Componente AudioSource
    public AudioClip bubbleSound;   // Sonido para las burbujas
    public AudioClip fishSound;     // Sonido para los peces
    public AudioClip explosionSound; // Sonido para la explosión del FishBomb

    public GameObject woodDuo1; // Referencia a Wood Duo 1
    public GameObject woodDuo2; // Referencia a Wood Duo 2

    // Start is called before the first frame update
    void Start()
    {
        // Asegurarse de que las referencias de los objetos Wood Duo estén asignadas
        if (woodDuo1 == null || woodDuo2 == null)
        {
            Debug.LogError("Las referencias de los objetos Wood Duo no están asignadas.");
        }
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

        // Detecta si la colisión es con un objeto de tipo "Fish"
        if (collision.gameObject.CompareTag("Fish"))
        {
            Debug.Log($"{gameObject.name}: Colisión detectada con un pez");
            Destroy(collision.gameObject); // Destruye el pez
            // Reproducir sonido de pez
            audioPlayer.clip = fishSound;
            audioPlayer.Play();
        }

        // Detecta si la colisión es con un objeto de tipo "FishBomb"
        if (collision.gameObject.CompareTag("FishBomb"))
        {
            Debug.Log($"{gameObject.name}: Colisión detectada con un FishBomb");
            Destroy(collision.gameObject); // Destruye el FishBomb
            // Reproducir sonido de explosión
            audioPlayer.clip = explosionSound;
            audioPlayer.Play();

            // Modificar las posiciones de los Wood Duo al colisionar con el FishBomb
            if (woodDuo1 != null && woodDuo2 != null)
            {
                woodDuo1.transform.position = new Vector3(woodDuo1.transform.position.x - 0.1f, woodDuo1.transform.position.y, woodDuo1.transform.position.z);
                woodDuo2.transform.position = new Vector3(woodDuo2.transform.position.x + 0.1f, woodDuo2.transform.position.y, woodDuo2.transform.position.z);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Aquí puedes agregar lógica adicional si es necesario
    }
}
