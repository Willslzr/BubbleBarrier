using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public GameObject BubbleMaker;
    public float oxigeno = 20; // Valor inicial de oxígeno
    public float cantidadOxigenoAumentar = 10; // Cantidad de oxígeno a sumar
    private bool isGameOver = false; // Bandera para controlar el estado del juego
    private float tiempoSobrevivido = 0f; // Variable para rastrear el tiempo transcurrido
    public GameOverScreen gameOverScreen;

    void Start()
    {
        BubbleMaker.GetComponent<BubbleMaker>().isActive = true;
    }

    void Update()
    {
        // Si el juego ya está en estado "Game Over", no continuar
        if (isGameOver) return;

        // Incrementar el tiempo transcurrido
        tiempoSobrevivido += Time.deltaTime;

        // Disminuir el oxígeno cada segundo
        oxigeno -= Time.deltaTime;

        // Verificar si el oxígeno se agotó
        if (oxigeno <= 0)
        {
            Debug.Log("¡Se acabó el oxígeno! Game Over.");
            GameOver();
        }
    }

    public void AddOxigen()
    {
        if (!isGameOver)
        {
            oxigeno += cantidadOxigenoAumentar;
            Debug.Log("¡Oxígeno añadido! Nuevo nivel: " + oxigeno);
        }
    }

    public void GameOver()
    {
        isGameOver = true; // Cambiar la bandera a "Game Over"
        Time.timeScale = 0; // Pausar el juego

        // Mostrar el tiempo sobrevivido
        Debug.Log("Tiempo sobrevivido: " + tiempoSobrevivido.ToString("F2") + " segundos");

        gameOverScreen.Setup(tiempoSobrevivido);
    }

}
