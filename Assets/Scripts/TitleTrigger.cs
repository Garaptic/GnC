using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleTrigger : MonoBehaviour
{
    public string creditsSceneName = "CreditsScene"; // Имя сцены с титрами

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Переключение на сцену титров
            SceneManager.LoadScene(creditsSceneName);
        }
    }
}