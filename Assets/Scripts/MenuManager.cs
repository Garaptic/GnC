using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void NewGame()
    {
        SaveManager.Instance.ResetGameData(); // ���������� ���������� ������
        SceneManager.LoadScene("GnC"); // ������������� �� ����� � �����
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("GnC"); // ��������� ����� �����������
    }
}
