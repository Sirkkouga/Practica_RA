using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class changeText : MonoBehaviour
{
    public TextMeshProUGUI[] textObjects; // Array con todos los objetos de texto
    public Button toggleButton; // Botón para cambiar los textos

    private int currentIndex = 0; // Índice del texto actual

    void Start()
    {
        // Asegúrate de que los elementos esten configurados
        if (textObjects.Length == 0 || toggleButton == null)
        {
            Debug.LogError("Faltan referencias en el Inspector.");
            return;
        }

        // Oculta todos los textos excepto el primero
        for (int i = 0; i < textObjects.Length; i++)
        {
            textObjects[i].gameObject.SetActive(i == currentIndex);
        }

        // Asocia el evento del botón
        toggleButton.onClick.AddListener(SwitchText);
    }

    void SwitchText()
    {
        // Oculta el texto actual
        textObjects[currentIndex].gameObject.SetActive(false);

        // Cambia al siguiente texto
        currentIndex = (currentIndex + 1) % textObjects.Length;

        // Muestra el texto nuevo
        textObjects[currentIndex].gameObject.SetActive(true);
    }
}