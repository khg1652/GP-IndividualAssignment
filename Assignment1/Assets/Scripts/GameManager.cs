using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshPro ���

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float defendTime = 65f;  // ����ؾ� �ϴ� �ð� (�� ����)
    private float remainingTime;
    private bool gameEnded = false;
    public GameObject winPanel;  // �¸� �г�
    public GameObject losePanel;   // �й� �г�
    public AudioClip winSound;
    public AudioClip loseSound;

    public bool isPaused = false; // ������ �Ͻ����� ���¸� ����
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
        Time.timeScale = 1f;                  // ���� �ð� �簳
        // ���� �ð� �� �¸� ���� Ȯ��
        remainingTime = defendTime;
        Invoke("WinGame", defendTime);
        Invoke("EnableGameUI", 5f);
    }
    private void EnableGameUI()
    {
        gameUI.SetActive(true);  // 5�� �Ŀ� ���� UI�� Ȱ��ȭ
    }
    private void Update()
    {
        if (!gameEnded)
        {
            // ���� �ð� ���
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0)
            {
                remainingTime = 0;
                WinGame();
            }

            // ���� �ð� UI ������Ʈ
            UpdateTimeUI();
            // ESC Ű�� PauseMenu Ȱ��ȭ/��Ȱ��ȭ
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
            int minutes = Mathf.FloorToInt(remainingTime / 60); // ���� �� ���
            int seconds = Mathf.FloorToInt(remainingTime % 60); // ���� �� ���

            timeRemainingText.text = $"{minutes:00}:{seconds:00}";
        }
    }
    public void PauseGame()
    {
        isPaused = true;
        pauseMenuUI.SetActive(true);           // PauseMenu Ȱ��ȭ
        gameUI.SetActive(false);
        Time.timeScale = 0f;                  // ���� �ð� ����
    }
    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);         // PauseMenu ��Ȱ��ȭ
        gameUI.SetActive(true);
        Time.timeScale = 1f;                  // ���� �ð� �簳
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
            // ���� �й� ó��
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
            // ���� �¸� ó��
            Debug.Log("You Win!");
            PlaySound(winSound);
            gameUI.SetActive(false);
            winPanel.SetActive(true);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // ���� �� �����
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
