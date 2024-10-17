using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delay);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Base에 도착하면 공격 처리
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("3");
            gameObject.SetActive(false);
        }
    }
}
