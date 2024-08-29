using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inv_Inventory : MonoBehaviour
{
    [SerializeField] List<Button> buttons = new List<Button>();
    [SerializeField] List<GameObject> resourceItems = new List<GameObject>();
    [SerializeField] GameObject buttonsPath;
    [SerializeField] List<string> inventoryItems = new List<string>();
    GameObject itemInArm;
    [SerializeField] Transform itemPoint;
    [SerializeField] Transform[] itemPositions;
    [SerializeField] TMP_Text warning;
    [SerializeField] List<GameObject> playerItems = new List<GameObject>();
    public TextMeshProUGUI pickupText;

    private void Start()
    {
        GameObject[] objArr = Resources.LoadAll<GameObject>("TestItems");
        resourceItems.AddRange(objArr);
        foreach (Transform child in buttonsPath.transform)
        {
            buttons.Add(child.GetComponent<Button>());
        }

        // Загрузка состояния инвентаря с передачей состояния
        InventoryState state = SaveManager.Instance.LoadInventoryState(); // Пример загрузки состояния
        LoadInventoryState(state);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked) ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

    public void AddItem(Sprite img, string itemName, GameObject obj)
    {
        if (inventoryItems.Count >= buttons.Count)
        {
            warning.text = "Full Inventory!";
            Invoke("WarningUpdate", 1f);
            return;
        }

        if (inventoryItems.Contains(itemName))
        {
            warning.text = "You already have " + itemName;
            Invoke("WarningUpdate", 1f);
            return;
        }

        inventoryItems.Add(itemName);
        var buttonImage = buttons[inventoryItems.Count - 1].GetComponent<Image>();
        buttonImage.sprite = img;
        Destroy(obj);

        pickupText.text = "You picked up " + itemName;
        Invoke("PickupTextUpdate", 1f);
    }

    void WarningUpdate()
    {
        warning.text = "";
    }

    void PickupTextUpdate()
    {
        pickupText.text = "";
    }

    public void UseItem(int itemPos)
    {
        if (inventoryItems.Count <= itemPos) return;
        string item = inventoryItems[itemPos];
        GetItemFromInventory(item);
    }

    public InventoryState GetInventoryState()
    {
        InventoryState state = new InventoryState();
        state.items = new List<string>(inventoryItems); // Копируем текущие предметы в состояние
        return state;
    }

    public void LoadInventoryState(InventoryState state)
    {
        inventoryItems = new List<string>(state.items); // Восстанавливаем предметы из сохранённого состояния

        // Обновляем изображения на кнопках
        for (int i = 0; i < buttons.Count; i++)
        {
            var buttonImage = buttons[i].GetComponent<Image>();

            if (i < inventoryItems.Count)
            {
                var itemName = inventoryItems[i];
                // Загружаем изображение карточки из ресурсов
                Sprite itemSprite = Resources.Load<Sprite>(itemName);

                if (itemSprite != null)
                {
                    buttonImage.sprite = itemSprite; // Присваиваем картинку карточки
                    buttonImage.color = Color.white; // Убедись, что цвет изображения не изменен
                }
                else
                {
                    Debug.LogWarning($"Sprite for item '{itemName}' not found in Resources.");
                    // Устанавливаем изображение пустого слота, если карточка не найдена
                    buttonImage.sprite = Resources.Load<Sprite>("Slot");
                    buttonImage.color = Color.white;
                }
            }
            else
            {
                // Устанавливаем изображение слота, если предметов меньше, чем слотов
                buttonImage.sprite = Resources.Load<Sprite>("Slot"); // Путь к изображению слота
                buttonImage.color = Color.white;
            }
        }
    }

    public void GetItemFromInventory(string itemName)
    {
        Debug.Log($"Trying to get item: {itemName}");

        var resourceItem = resourceItems.Find(x => x.name == itemName);

        if (resourceItem == null)
        {
            Debug.LogWarning($"Item {itemName} not found in resourceItems.");
            return;
        }

        var putFind = playerItems.Find(x => x.name == itemName);

        if (putFind == null)
        {
            if (itemInArm != null)
            {
                itemInArm.SetActive(false);
                Debug.Log($"Deactivating current item: {itemInArm.name}");
            }

            // Находим точку для размещения объекта
            var pos = resourceItem.GetComponent<Inv_ItemPosition>().positon;
            if (pos == Inv_ItemPosition.ItemPos.Head)
            {
                itemPoint = itemPositions[0]; // Присваиваем сам Transform, а не позицию
            }
            else if (pos == Inv_ItemPosition.ItemPos.Spine)
            {
                itemPoint = itemPositions[1];
            }
            else
            {
                itemPoint = itemPositions[2];
            }

            Debug.Log($"Instantiating new item: {itemName} at {itemPoint.name}");

            // Создаем новый объект и привязываем его к нужной точке
            var newItem = Instantiate(resourceItem, itemPoint.position, itemPoint.rotation, itemPoint);
            newItem.name = itemName;

            // Устанавливаем локальные параметры
            newItem.transform.localPosition = Vector3.zero; // Центрируем объект
            newItem.transform.localRotation = Quaternion.identity; // Устанавливаем ориентацию
            newItem.transform.localScale = new Vector3(0.4645516f, 0.04637306f, 0.7200254f); // Устанавливаем нормальный масштаб
            newItem.transform.rotation = Quaternion.Euler(0, 245, 0);

            Debug.Log($"Item {newItem.name} instantiated and positioned.");

            playerItems.Add(newItem);
            itemInArm = newItem;
        }
        else
        {
            Debug.Log($"Item {itemName} already in playerItems.");

            if (putFind == itemInArm)
            {
                putFind.SetActive(!putFind.activeSelf);
                Debug.Log($"Toggling visibility of {putFind.name}.");
            }
            else
            {
                itemInArm.SetActive(false);
                putFind.SetActive(true);
                itemInArm = putFind;
                Debug.Log($"Switching active item to {putFind.name}.");
            }
        }
    }
}
