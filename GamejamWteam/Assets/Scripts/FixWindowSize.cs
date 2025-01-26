using UnityEngine;

public class FixWindowSize : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(360, 640, false);
        // Deshabilitar la redimensión de la ventana (si es posible en la plataforma)
        // Por ejemplo, en Windows puedes usar:
        // Screen.fullScreenMode = FullScreenMode.Windowed;
    }
}
