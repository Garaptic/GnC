using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleTrigger : MonoBehaviour
{
    public string battleSceneName = "Fight";
    private TriggerManager triggerManager;

    private void Start()
    {
        triggerManager = GetComponent<TriggerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ���������� ��������� ����
            var saveManager = SaveManager.Instance;
            if (saveManager != null)
            {
                var player = other.GetComponent<Transform>();
                var inventory = FindObjectOfType<Inv_Inventory>();
                if (player != null && inventory != null)
                {
                    saveManager.SavePlayerPosition(player.position);
                    saveManager.SaveInventoryState(inventory.GetInventoryState()); // ��������� ��������� ���������
                }
            }

            if (triggerManager != null)
            {
                triggerManager.DeactivateTrigger();
            }

            SceneManager.LoadScene(battleSceneName);
        }
    }
}
