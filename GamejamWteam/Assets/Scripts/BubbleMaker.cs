using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMaker : MonoBehaviour
{
    public GameObject bubblePrefab; // Prefabricado de la burbuja
    public float spawnRange = 2.5f; // Rango de generación en el eje X
    public bool isActive = false; // Activador del generador de burbujas

    private float timer = 0f;
    private float nextSpawnTime; // Tiempo aleatorio hasta la próxima generación

    void Start()
    {
        // Asignar un tiempo inicial aleatorio para la primera burbuja
        nextSpawnTime = Random.Range(3f, 10f);
    }

    void Update()
    {
        if (isActive)
        {
            timer += Time.deltaTime;

            if (timer >= nextSpawnTime)
            {
                timer = 0f;

                // Generar una posición aleatoria en X
                float randomX = Random.Range(-spawnRange, spawnRange);

                // Instanciar la burbuja en una posición aleatoria
                Instantiate(bubblePrefab, new Vector3(randomX, transform.position.y, transform.position.z), Quaternion.identity);

                // Asignar un nuevo tiempo aleatorio para la siguiente generación
                nextSpawnTime = Random.Range(3f, 10f);
            }
        }
    }
}
