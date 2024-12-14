using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro ���

public class FPS : MonoBehaviour
{
    private TMP_Text fpsText; // Text ������Ʈ ����
    private float deltaTime = 0.0f;

    void Awake()
    {
        // ���� ������Ʈ�� Text ������Ʈ ��������
        fpsText = GetComponent<TMP_Text>();
    }
    void Start()
    {
        // 1�ʸ��� UpdateFPS �޼��� ȣ��
        InvokeRepeating("UpdateFPS", 1.0f, 1.0f);
    }

    void Update()
    {
        // deltaTime ���
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void UpdateFPS()
    {
        if (fpsText != null)
        {
            float fps = 1.0f / deltaTime; // FPS ���
            fpsText.text = $"FPS: {Mathf.Ceil(fps)}";
        }
    }
}
