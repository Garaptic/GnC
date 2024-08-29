using UnityEngine;
using UnityEngine.Playables;

public class CutSceneTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector cutScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cutScene.Play();
            Destroy(gameObject); // Удаляем триггер после использования, чтобы избежать повторного срабатывания
        }
    }
}
