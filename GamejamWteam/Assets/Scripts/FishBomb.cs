using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBomb : MonoBehaviour
{
    // Duración del movimiento (en segundos)
    public float moveDuration = 1.0f;

    // Dirección inicial del movimiento (1 para derecha, -1 para izquierda)
    public int direction = 1;

    // Velocidad del ataque hacia arriba
    public float attackSpeed = 5f;

    private Vector3 startPosition;

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

        // Iniciar el movimiento inicial del pez
        StartCoroutine(MoveAndAttack());
    }

    private IEnumerator MoveAndAttack()
    {
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

        // Iniciar el ataque hacia arriba
        StartCoroutine(AttackUpwards());
    }

    private IEnumerator AttackUpwards()
    {
        // Realizar el giro de 90 grados en el eje Z
        Quaternion initialRotation = transform.rotation; // Rotación inicial
        Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, 90f)); // Rotación objetivo

        float rotationDuration = 0.2f; // Duración del giro (en segundos)
        float elapsedRotationTime = 0f;

        // Interpolar suavemente la rotación hacia el objetivo
        while (elapsedRotationTime < rotationDuration)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedRotationTime / rotationDuration);
            elapsedRotationTime += Time.deltaTime;
            yield return null;
        }

        // Asegurarse de que la rotación final sea exactamente la deseada
        transform.rotation = targetRotation;

        // Movimiento hacia arriba a gran velocidad
        while (true)
        {
            transform.position += Vector3.up * attackSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
