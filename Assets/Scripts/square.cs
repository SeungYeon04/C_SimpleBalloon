using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square : MonoBehaviour
{

    void Start()
    {
        //랜덤위치에서 네모 스폰하기 
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
        //상대(ballon)가 부딪히면(coll) 게임 종료 
        if (coll.gameObject.tag == "balloon")
        {
            gameManager.I.gameOver();
        }
    }

}
