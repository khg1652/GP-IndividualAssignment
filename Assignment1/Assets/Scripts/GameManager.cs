using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float defendTime = 60f;  // ����ؾ� �ϴ� �ð� (�� ����)
    private bool gameEnded = false;
    public GameObject winPanel;  // �¸� �г�
    public GameObject losePanel;   // �й� �г�

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // ���� �ð� �� �¸� ���� Ȯ��
        Invoke("WinGame", defendTime);
    }

    public void LoseGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            // ���� �й� ó��
            Debug.Log("You Lose!");
            losePanel.SetActive(true);
        }
    }

    void WinGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            // ���� �¸� ó��
            Debug.Log("You Win!");
            winPanel.SetActive(true);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // ���� �� �����
    }

}
