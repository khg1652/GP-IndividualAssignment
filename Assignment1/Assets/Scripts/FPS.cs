using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro 사용

public class FPS : MonoBehaviour
{
    private TMP_Text fpsText; // Text 컴포넌트 참조
    private float deltaTime = 0.0f;

    void Awake()
    {
        // 현재 오브젝트의 Text 컴포넌트 가져오기
        fpsText = GetComponent<TMP_Text>();
    }
    void Start()
    {
        // 1초마다 UpdateFPS 메서드 호출
        InvokeRepeating("UpdateFPS", 1.0f, 1.0f);
    }

    void Update()
    {
        // deltaTime 계산
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void UpdateFPS()
    {
        if (fpsText != null)
        {
            float fps = 1.0f / deltaTime; // FPS 계산
            fpsText.text = $"FPS: {Mathf.Ceil(fps)}";
        }
    }
}
