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
            // Сохранение состояния игры
            var saveManager = SaveManager.Instance;
            if (saveManager != null)
            {
                var player = other.GetComponent<Transform>();
                var inventory = FindObjectOfType<Inv_Inventory>();
                if (player != null && inventory != null)
                {
                    saveManager.SavePlayerPosition(player.position);
                    saveManager.SaveInventoryState(inventory.GetInventoryState()); // Сохраняем состояние инвентаря
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
