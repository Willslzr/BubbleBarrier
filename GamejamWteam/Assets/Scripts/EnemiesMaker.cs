using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMaker : MonoBehaviour
{
public GameObject fish1Prefab; // Prefabricado del pez 1
    public GameObject fish2Prefab; // Prefabricado del pez 2
    public GameObject fish3Prefab; // Prefabricado del pez 3

    public float fish1MaxSpawnInterval = 4f; // Máximo intervalo de generación para Fish1
    public float fish2MinSpawnInterval = 5f; // Mínimo intervalo de generación para Fish2
    public float fish2MaxSpawnInterval = 9f; // Máximo intervalo de generación para Fish2
    public float fish3MinSpawnInterval = 8f; // Mínimo intervalo de generación para Fish3
    public float fish3MaxSpawnInterval = 12f; // Máximo intervalo de generación para Fish3

    private float fish1Timer = 0f;
    private float fish2Timer = 0f;
    private float fish3Timer = 0f;

    private float fish1CurrentSpawnInterval;
    private float fish2CurrentSpawnInterval;
    private float fish3CurrentSpawnInterval;

    void Start()
    {
        // Establecer los primeros intervalos aleatorios
        SetRandomSpawnIntervalFish1();
        SetRandomSpawnIntervalFish2();
        SetRandomSpawnIntervalFish3();
    }

    void Update()
    {
        // Temporizador para Fish1
        fish1Timer += Time.deltaTime;
        if (fish1Timer >= fish1CurrentSpawnInterval)
        {
            SpawnFish(fish1Prefab);
            fish1Timer = 0f;
            SetRandomSpawnIntervalFish1();
        }

        // Temporizador para Fish2
        fish2Timer += Time.deltaTime;
        if (fish2Timer >= fish2CurrentSpawnInterval)
        {
            SpawnFish(fish2Prefab);
            fish2Timer = 0f;
            SetRandomSpawnIntervalFish2();
        }

        // Temporizador para Fish3
        fish3Timer += Time.deltaTime;
        if (fish3Timer >= fish3CurrentSpawnInterval)
        {
            SpawnFish(fish3Prefab);
            fish3Timer = 0f;
            SetRandomSpawnIntervalFish3();
        }
    }

    void SpawnFish(GameObject fishPrefab)
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

    void SetRandomSpawnIntervalFish1()
    {
        // Asignar un intervalo aleatorio entre 1 y el máximo definido para Fish1
        fish1CurrentSpawnInterval = Random.Range(1f, fish1MaxSpawnInterval);
    }

    void SetRandomSpawnIntervalFish2()
    {
        // Asignar un intervalo aleatorio entre los valores definidos para Fish2
        fish2CurrentSpawnInterval = Random.Range(fish2MinSpawnInterval, fish2MaxSpawnInterval);
    }

    void SetRandomSpawnIntervalFish3()
    {
        // Asignar un intervalo aleatorio entre los valores definidos para Fish3
        fish3CurrentSpawnInterval = Random.Range(fish3MinSpawnInterval, fish3MaxSpawnInterval);
    }
}
