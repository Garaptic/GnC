using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void NewGame()
    {
        SaveManager.Instance.ResetGameData(); // Сбрасываем сохранённые данные
        SceneManager.LoadScene("GnC"); // Переключаемся на сцену с игрой
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("GnC"); // Загружаем сцену продолжения
    }
}
