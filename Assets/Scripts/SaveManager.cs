using UnityEngine;
using System.Collections.Generic;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SavePlayerPosition(Vector3 position)
    {
        PlayerPrefs.SetFloat("PlayerPosX", position.x);
        PlayerPrefs.SetFloat("PlayerPosY", position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", position.z);
        PlayerPrefs.Save();
    }

    public Vector3 LoadPlayerPosition()
    {
        return new Vector3(
            PlayerPrefs.GetFloat("PlayerPosX", 0),
            PlayerPrefs.GetFloat("PlayerPosY", 0),
            PlayerPrefs.GetFloat("PlayerPosZ", 0)
        );
    }

    public void SaveInventoryState(InventoryState state)
    {
        PlayerPrefs.SetInt("InventoryCount", state.items.Count);
        for (int i = 0; i < state.items.Count; i++)
        {
            PlayerPrefs.SetString("InventoryItem" + i, state.items[i]);
        }
        PlayerPrefs.Save();
    }

    public InventoryState LoadInventoryState()
    {
        InventoryState state = new InventoryState();
        int count = PlayerPrefs.GetInt("InventoryCount", 0);
        state.items = new List<string>(count);
        for (int i = 0; i < count; i++)
        {
            state.items.Add(PlayerPrefs.GetString("InventoryItem" + i, ""));
        }
        return state;
    }

    public void ResetGameData()
    {
        PlayerPrefs.DeleteAll();
    }
}
