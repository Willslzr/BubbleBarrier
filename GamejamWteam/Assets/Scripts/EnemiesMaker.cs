using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMaker : MonoBehaviour
{

    public GameObject fishPrefab; // Prefabricado del pez enemigo
    public float maxSpawnInterval = 4f; // Máximo intervalo de generación (puede cambiar con la dificultad)

    private float timer = 0f;
    private float currentSpawnInterval;

    void Start()
    {
        // Establecer el primer intervalo aleatorio
        SetRandomSpawnInterval();
    }

    void Update()
    {
        // Incrementar el temporizador
        timer += Time.deltaTime;

        // Generar un enemigo cuando se alcanza el intervalo actual
        if (timer >= currentSpawnInterval)
        {
            SpawnFish();
            timer = 0f; // Reiniciar el temporizador
            SetRandomSpawnInterval(); // Establecer un nuevo intervalo aleatorio
        }
    }

    void SpawnFish()
    {
        // Decidir aleatoriamente si generar el pez en el lado izquierdo o derecho
        bool spawnOnLeft = Random.value < 0.5f;

        // Generar una posición aleatoria en el rango especificado
        float randomY = Random.Range(-4.5f, 0f);
        float spawnX = spawnOnLeft ? -4.5f : 4.5f; // x=-4.5 para izquierda, x=4.5 para derecha
        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0f);

        // Instanciar el pez
        GameObject fish = Instantiate(fishPrefab, spawnPosition, Quaternion.identity);

        // Orientar el pez hacia el centro
        if (!spawnOnLeft)
        {
            // Si el pez aparece en el lado derecho, invertir su rotación en el eje Y para que apunte hacia el centro
            fish.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    void SetRandomSpawnInterval()
    {
        // Asignar un intervalo aleatorio entre 1 y el máximo definido
        currentSpawnInterval = Random.Range(1f, maxSpawnInterval);
    }

    // Método público para cambiar la dificultad (ajustar maxSpawnInterval)
    public void SetDifficulty(float newMaxInterval)
    {
        maxSpawnInterval = Mathf.Max(1f, newMaxInterval); // Asegurarse de que no sea menor que 1 segundo
    }
}
