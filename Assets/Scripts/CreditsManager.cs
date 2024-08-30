using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CreditsManager : MonoBehaviour
{
    public float displayTime = 10f; // Время показа титров перед переключением

    private void Start()
    {
        // Запуск корутины для ожидания и переключения сцены
        StartCoroutine(WaitAndSwitchScene());
    }

    private IEnumerator WaitAndSwitchScene()
    {
        yield return new WaitForSeconds(displayTime);
        // Переключение на следующую сцену (например, на главную сцену или начальную)
        SceneManager.LoadScene("Menu"); // Замените на имя вашей основной сцены
    }
}
