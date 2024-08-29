using UnityEngine;

public class PlayerPositionController : MonoBehaviour
{
    public Transform playerTransform; // ������ ������

    private void Start()
    {
        if (SaveManager.Instance != null)
        {
            Vector3 savedPosition = SaveManager.Instance.LoadPlayerPosition();
            if (playerTransform != null)
            {
                playerTransform.position = savedPosition;
            }
        }
    }
}
