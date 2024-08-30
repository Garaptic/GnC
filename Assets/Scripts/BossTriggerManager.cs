using UnityEngine;

public class BossTriggerManager : MonoBehaviour
{
    private static bool isTriggerDeactivated = false;

    private void Start()
    {
        // ���������, ���� ������� ��� ��� ������������� �����
        if (isTriggerDeactivated)
        {
            gameObject.SetActive(false);
        }
    }

    public void DeactivateTrigger()
    {
        isTriggerDeactivated = true;
        gameObject.SetActive(false);
    }
}