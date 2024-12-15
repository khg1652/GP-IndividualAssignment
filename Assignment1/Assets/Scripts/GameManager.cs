using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshPro 사용

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float defendTime = 65f;  // 방어해야 하는 시간 (초 단위)
    private float remainingTime;
    private bool gameEnded = false;
    public GameObject winPanel;  // 승리 패널
    public GameObject losePanel;   // 패배 패널
    public AudioClip winSound;
    public AudioClip loseSound;

    public bool isPaused = false; // 게임의 일시정지 상태를 추적
    public GameObject pauseMenuUI;
    public GameObject gameUI;
    public TMP_Text timeRemainingText;

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
        Time.timeScale = 1f;                  // 게임 시간 재개
        // 일정 시간 후 승리 조건 확인
        remainingTime = defendTime;
        Invoke("WinGame", defendTime);
        Invoke("EnableGameUI", 5f);
    }
    private void EnableGameUI()
    {
        gameUI.SetActive(true);  // 5초 후에 게임 UI를 활성화
    }
    private void Update()
    {
        if (!gameEnded)
        {
            // 남은 시간 계산
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0)
            {
                remainingTime = 0;
                WinGame();
            }

            // 남은 시간 UI 업데이트
            UpdateTimeUI();
            // ESC 키로 PauseMenu 활성화/비활성화
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }
    }
    void UpdateTimeUI()
    {
        if (timeRemainingText != null)
        {
            int minutes = Mathf.FloorToInt(remainingTime / 60); // 남은 분 계산
            int seconds = Mathf.FloorToInt(remainingTime % 60); // 남은 초 계산

            timeRemainingText.text = $"{minutes:00}:{seconds:00}";
        }
    }
    public void PauseGame()
    {
        isPaused = true;
        pauseMenuUI.SetActive(true);           // PauseMenu 활성화
        gameUI.SetActive(false);
        Time.timeScale = 0f;                  // 게임 시간 정지
    }
    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);         // PauseMenu 비활성화
        gameUI.SetActive(true);
        Time.timeScale = 1f;                  // 게임 시간 재개
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoseGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            // 게임 패배 처리
            Debug.Log("You Lose!");
            PlaySound(loseSound);
            gameUI.SetActive(false);
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
            PlaySound(winSound);
            gameUI.SetActive(false);
            winPanel.SetActive(true);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // 현재 씬 재시작
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip == null) return;

        GameObject audioObject = new GameObject("TempAudio");
        AudioSource tempSource = audioObject.AddComponent<AudioSource>();
        tempSource.clip = clip;
        tempSource.Play();

        Destroy(audioObject, clip.length);
    }
}
