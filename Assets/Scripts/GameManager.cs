using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event System.Action<bool> OnFightEnd;  // Изменено событие для передачи результата боя

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EndFight(bool isPlayerVictory)
    {
        Debug.Log("EndFight called with victory: " + isPlayerVictory);
        if (OnFightEnd != null)
        {
            OnFightEnd(isPlayerVictory);
        }

        if (isPlayerVictory)
        {
            SceneManager.LoadScene("GnC");
        }
        else
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}