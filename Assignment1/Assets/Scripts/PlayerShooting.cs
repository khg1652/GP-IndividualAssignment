using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;

    public Color redColor = Color.red;   // ������
    public Color blueColor = Color.blue; // �Ķ���
    private Color currentColor;
    private string currentTag = "Bullet";
    // Start is called before the first frame update
    void Start()
    {
        currentColor = redColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
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

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleColor();
        }
    }
    void ToggleColor()
    {
        // ���� ������ �������̸� �Ķ�������, �Ķ����̸� ���������� ����
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
    }
}
