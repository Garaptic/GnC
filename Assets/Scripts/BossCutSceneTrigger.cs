using UnityEngine;
using UnityEngine.Playables;

public class BossCutSceneTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector cutScene;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform mainCameraCutScenePosition;

    private Vector3 mainCameraStartPos;
    private Quaternion mainCameraStartRot;

    private void Start()
    {
        if (mainCamera == null || mainCameraCutScenePosition == null)
        {
            Debug.LogError("Один или несколько обязательных объектов не установлены.");
            return;
        }

        // Сохраняем начальное положение и ориентацию камеры
        mainCameraStartPos = mainCamera.transform.position;
        mainCameraStartRot = mainCamera.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Проверяем, что камера активна перед изменением её позиции
            if (mainCamera != null)
            {
                // Устанавливаем камеру в позицию для кат-сцены
                mainCamera.transform.position = mainCameraCutScenePosition.position;
                mainCamera.transform.rotation = mainCameraCutScenePosition.rotation;

                cutScene.Play();

                // Подписываемся на событие завершения кат-сцены
                cutScene.stopped += OnCutSceneStopped;
            }
            else
            {
                Debug.LogError("Не удается найти камеру для кат-сцены!");
            }

            Destroy(gameObject); // Удаляем триггер после использования
        }
    }

    private void OnCutSceneStopped(PlayableDirector director)
    {
        // Возвращаем камеру на её исходные позиции
        if (mainCamera != null)
        {
            mainCamera.transform.position = mainCameraStartPos;
            mainCamera.transform.rotation = mainCameraStartRot;
        }
        else
        {
            Debug.LogError("Не удается найти камеру для возврата на исходные позиции!");
        }
    }
}
