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
            Debug.LogError("���� ��� ��������� ������������ �������� �� �����������.");
            return;
        }

        // ��������� ��������� ��������� � ���������� ������
        mainCameraStartPos = mainCamera.transform.position;
        mainCameraStartRot = mainCamera.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ���������, ��� ������ ������� ����� ���������� � �������
            if (mainCamera != null)
            {
                // ������������� ������ � ������� ��� ���-�����
                mainCamera.transform.position = mainCameraCutScenePosition.position;
                mainCamera.transform.rotation = mainCameraCutScenePosition.rotation;

                cutScene.Play();

                // ������������� �� ������� ���������� ���-�����
                cutScene.stopped += OnCutSceneStopped;
            }
            else
            {
                Debug.LogError("�� ������� ����� ������ ��� ���-�����!");
            }

            Destroy(gameObject); // ������� ������� ����� �������������
        }
    }

    private void OnCutSceneStopped(PlayableDirector director)
    {
        // ���������� ������ �� � �������� �������
        if (mainCamera != null)
        {
            mainCamera.transform.position = mainCameraStartPos;
            mainCamera.transform.rotation = mainCameraStartRot;
        }
        else
        {
            Debug.LogError("�� ������� ����� ������ ��� �������� �� �������� �������!");
        }
    }
}
