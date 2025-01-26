using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleFish : MonoBehaviour
{
    public float fadeDuration = 0.5f; // Duración del desvanecimiento en segundos
    private Material fishMaterial; // Material del pez
    private Color originalColor; // Color original del material
    private bool isFading = false; // Para evitar solapamiento de efectos

    void Start()
    {
        // Obtener el material del objeto
        fishMaterial = GetComponent<Renderer>().material;

        // Guardar el color original
        originalColor = fishMaterial.color;

        // Iniciar la corrutina de invisibilidad
        StartCoroutine(InvisibilityRoutine());
    }

    private IEnumerator InvisibilityRoutine()
    {
        while (true)
        {
            // Hacer el pez invisible
            yield return StartCoroutine(FadeTo(0f));

            // Esperar 1 segundo mientras está invisible
            yield return new WaitForSeconds(1f);

            // Hacer el pez visible
            yield return StartCoroutine(FadeTo(1f));

            // Esperar 1 segundo mientras está visible
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator FadeTo(float targetAlpha)
    {
        if (isFading) yield break; // Evitar solapamiento
        isFading = true;

        // Obtener el color actual
        Color currentColor = fishMaterial.color;

        // Calcular el cambio en alfa
        float startAlpha = currentColor.a;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;

            // Interpolar entre el alfa actual y el objetivo
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);

            // Aplicar el nuevo color con el alfa interpolado
            fishMaterial.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

            yield return null;
        }

        // Asegurarse de que el alfa final sea exactamente el objetivo
        fishMaterial.color = new Color(currentColor.r, currentColor.g, currentColor.b, targetAlpha);

        isFading = false;
    }
}
