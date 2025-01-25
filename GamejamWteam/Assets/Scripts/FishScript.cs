using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    // Duración del movimiento (en segundos)
    public float moveDuration = 1.0f;

    // Dirección inicial del movimiento (1 para derecha, -1 para izquierda)
    public int direction = 1;

    // Velocidad del ataque hacia arriba
    public float attackSpeed = 5f;

    private Vector3 startPosition;
    private bool isMoving = false;

    void Start()
    {
        startPosition = transform.position;

        // Determinar la dirección inicial según la posición del pez
        if (startPosition.x > 0)
        {
            direction = -1; // Si está en el lado derecho, moverse hacia la izquierda
        }
        else
        {
            direction = 1; // Si está en el lado izquierdo, moverse hacia la derecha
        }

        StartCoroutine(MoveFish());
    }

    private IEnumerator MoveFish()
    {
        isMoving = true;
        float elapsedTime = 0f;

        // Asignar una distancia aleatoria (negativa para la izquierda)
        float moveDistance = Random.Range(4.5f, 6f) * direction;

        // Movimiento en la dirección inicial
        while (elapsedTime < moveDuration)
        {
            float progress = elapsedTime / moveDuration;
            float smoothStep = Mathf.SmoothStep(0f, 1f, progress);

            // Calcular la posición actual
            float currentX = Mathf.Lerp(0f, moveDistance, smoothStep);
            transform.position = startPosition + new Vector3(currentX, 0f, 0f);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegurar que el pez llegue exactamente a su posición final
        transform.position = startPosition + new Vector3(moveDistance, 0f, 0f);

        // Decidir si realizará el ataque
        if (Random.value < 0.5f)
        {
            StartCoroutine(AttackUpwards());
            yield break; // Terminar el ciclo actual
        }

        // Voltear el pez
        direction = -direction; // Invertir la dirección

        // Voltear visualmente el pez (por ejemplo, cambiando la escala en el eje X)
        Vector3 scale = transform.localScale;
        scale.x = -scale.x; // Invertir la escala en el eje X
        transform.localScale = scale;

        // Esperar un breve momento antes de iniciar el siguiente movimiento
        yield return new WaitForSeconds(0.5f);

        // Repetir el movimiento en la dirección opuesta
        startPosition = transform.position; // Actualizar la posición inicial
        StartCoroutine(MoveFish());
    }

    private IEnumerator AttackUpwards()
    {
        while (true)
        {
            // Moverse hacia arriba a gran velocidad
            transform.position += Vector3.up * attackSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
