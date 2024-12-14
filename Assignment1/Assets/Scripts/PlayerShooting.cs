using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro 사용

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;

    public Color redColor = Color.red;   // 빨간색
    public Color blueColor = Color.blue; // 파란색
    private Color currentColor;
    private string currentTag = "Bullet";
    public AudioClip tigerSound;
    public TMP_Text bulletStateText;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentColor = redColor;
        bulletStateText.text = "Red";
        bulletStateText.color = redColor;
        UpdateBulletStateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !GameManager.instance.isPaused)
        {
            //Instantiate(prefab, transform.position, transform.rotation);
            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;

            Renderer bulletRenderer = clone.GetComponent<Renderer>();
            bulletRenderer.material.color = currentColor;
            clone.tag = currentTag;
            if(currentTag == "Bullet")
                clone.transform.localScale = new Vector3(2f, 2f, 2f);
            if (currentTag == "Bullet2")
                clone.transform.localScale = new Vector3(4f, 4f, 4f);
            PlaySound(tigerSound);
            anim.SetTrigger("jump");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleColor();
        }
    }
    void ToggleColor()
    {
        // 현재 색상이 빨간색이면 파란색으로, 파란색이면 빨간색으로 변경
        if (currentColor == redColor)
        {
            currentColor = blueColor;
            currentTag = "Bullet2";
        }
        else
        {
            currentColor = redColor;
            currentTag = "Bullet";
        }
        UpdateBulletStateUI();
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip == null) return;

        GameObject audioObject = new GameObject("TempAudio");
        AudioSource tempSource = audioObject.AddComponent<AudioSource>();
        tempSource.volume = 0.2f;
        tempSource.clip = clip;
        tempSource.Play();

        Destroy(audioObject, clip.length);
    }

    private void UpdateBulletStateUI()
    {
        // Bullet 상태에 따라 UI 텍스트 변경
        if (bulletStateText != null)
        {
            if (currentTag == "Bullet")
            {
                bulletStateText.text = "Red";
                bulletStateText.color = redColor;
            }
            else if (currentTag == "Bullet2")
            {
                bulletStateText.text = "Blue";
                bulletStateText.color = blueColor;
            }
        }
    }
}
