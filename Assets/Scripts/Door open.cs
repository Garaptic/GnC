using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject Door;
    public float liftHeight = 5f;
    public float liftSpeed = 2f;

    private Vector3 initialPosition;
    private bool isPlayerOnPlate = false;

    void Start()
    {
        if (Door != null)
        {
            initialPosition = Door.transform.position;
        }
    }

    void Update()
    {
        if (isPlayerOnPlate && Door != null)
        {
            Door.transform.position = Vector3.Lerp(Door.transform.position, initialPosition + Vector3.up * liftHeight, Time.deltaTime * liftSpeed);
        }
        else if (Door != null)
        {
            Door.transform.position = Vector3.Lerp(Door.transform.position, initialPosition, Time.deltaTime * liftSpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnPlate = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnPlate = false;
        }
    }
}

