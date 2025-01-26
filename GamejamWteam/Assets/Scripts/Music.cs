using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource audioPlayer; // Componente AudioSource para reproducir música
    public AudioClip[] musicTracks; // Array de audios (4 en este caso)
    
    private int currentTrackIndex; // Índice para la pista actual

    // Start is called before the first frame update
    void Start()
    {
        if (musicTracks.Length > 0)
        {
            PlayRandomTrack(); // Inicia con una pista aleatoria
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Si el audio actual ha terminado, reproduce otro
        if (!audioPlayer.isPlaying)
        {
            PlayRandomTrack();
        }
    }

    void PlayRandomTrack()
    {
        // Elegir un índice aleatorio que no sea el mismo que el anterior
        int newTrackIndex;
        do
        {
            newTrackIndex = Random.Range(0, musicTracks.Length);
        } while (newTrackIndex == currentTrackIndex); // Evita que repita la misma pista

        currentTrackIndex = newTrackIndex;

        // Asignar y reproducir el nuevo audio
        audioPlayer.clip = musicTracks[currentTrackIndex];
        audioPlayer.Play();
    }
}
