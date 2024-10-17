using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float defendTime = 60f;  // 방어해야 하는 시간 (초 단위)
    private bool gameEnded = false;
    public GameObject winPanel;  // 승리 패널
    public GameObject losePanel;   // 패배 패널

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
        // 일정 시간 후 승리 조건 확인
        Invoke("WinGame", defendTime);
    }

    public void LoseGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            // 게임 패배 처리
            Debug.Log("You Lose!");
            losePanel.SetActive(true);
        }
    }

    void WinGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            // 게임 승리 처리
            Debug.Log("You Win!");
            winPanel.SetActive(true);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // 현재 씬 재시작
    }

}
