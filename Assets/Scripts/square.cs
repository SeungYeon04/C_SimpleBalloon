using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square : MonoBehaviour
{

    void Start()
    {
        //������ġ���� �׸� �����ϱ� 
       float x = Random.Range(-3f, 3f);
       float y = Random.Range(3f, 5f);
        transform.position = new Vector3(x, y, 0);

        float size = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3(size, size, 0); 
    }

    void Update()
    {
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject); 
        }
    }

    void OnCollisionEnter2D(Collision2D coll) 
    {
        //���(ballon)�� �ε�����(coll) ���� ���� 
        if (coll.gameObject.tag == "balloon")
        {
            gameManager.I.gameOver();
        }
    }

}
