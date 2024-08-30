using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBattleTrigger : MonoBehaviour
{
    public string battleSceneName = "BossFight";
    private BossTriggerManager bossTriggerManager;

    private void Start()
    {
        bossTriggerManager = GetComponent<BossTriggerManager>();
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

            if (bossTriggerManager != null)
            {
                bossTriggerManager.DeactivateTrigger();
            }

            SceneManager.LoadScene(battleSceneName);
        }
    }
}
