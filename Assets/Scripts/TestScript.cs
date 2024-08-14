using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public Button testButton;  // Присвойте кнопку в инспекторе

    void Start()
    {
        Debug.Log("TestScript Start called");

        if (testButton != null)
        {
            testButton.onClick.AddListener(OnTestButtonClick);
        }
        else
        {
            Debug.LogWarning("TestButton is not assigned in the inspector!");
        }
    }

    void OnTestButtonClick()
    {
        Debug.Log("Test Button Clicked!");
    }

    void Update()
    {

    }
}
