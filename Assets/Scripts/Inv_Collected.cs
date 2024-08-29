using UnityEngine;

public class Inv_Collected : MonoBehaviour
{
    public string name;
    public Sprite image;
    private Inv_Inventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inv_Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Picking up item: {name}");
            inventory.AddItem(image, name, gameObject);
        }
    }
}
