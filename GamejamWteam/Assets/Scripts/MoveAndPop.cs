using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndPop : MonoBehaviour
{

    public float speed = 2f; // Velocidad inicial de ascenso
    public float damping = 0.1f; // Factor de amortiguamiento
    public float noiseScale = 0.1f; // Escala del ruido para el movimiento horizontal
    public float movementLimit = 2.5f; // Límite máximo de movimiento en el eje X

    private float noiseOffset;

    void Start()
    {
        noiseOffset = Random.Range(0f, 100f); // Inicializar el offset de ruido para cada burbuja
    }

    void Update()
    {
        // Movimiento vertical con amortiguamiento
        speed -= damping * Time.deltaTime;
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Movimiento horizontal aleatorio (ruido Perlin)
        float noise = Mathf.PerlinNoise(Time.time * noiseScale + noiseOffset, transform.position.y);
        float horizontalMovement = noise - 0.5f; // Centrar el ruido entre -0.5 y 0.5

        // Limitar el movimiento horizontal
        float newPositionX = Mathf.Clamp(transform.position.x + horizontalMovement * Time.deltaTime, -movementLimit, movementLimit);

        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
