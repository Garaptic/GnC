using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CreditsManager : MonoBehaviour
{
    public float displayTime = 10f; // ����� ������ ������ ����� �������������

    private void Start()
    {
        // ������ �������� ��� �������� � ������������ �����
        StartCoroutine(WaitAndSwitchScene());
    }

    private IEnumerator WaitAndSwitchScene()
    {
        yield return new WaitForSeconds(displayTime);
        // ������������ �� ��������� ����� (��������, �� ������� ����� ��� ���������)
        SceneManager.LoadScene("Menu"); // �������� �� ��� ����� �������� �����
    }
}
