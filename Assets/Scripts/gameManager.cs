using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//씬(다시시작)매니저를사용할거다 

public class gameManager : MonoBehaviour
{

    public GameObject square; //겜매에게반복법쥐어줌 
    public Text timeTxt; //겜매에게시계쥐어줌
    float alive = 0f; //바로끝남
    public static gameManager I; //싱글톤선언나만불러줘하는중
    public GameObject endPanel;//겜매에게엔드판넬도찾게시킴 
    public Text thisScoreTxt;
    bool isRunning = true;//시간업뎃조절
    public Text maxScoreTxt; //최고기록.. 
    public Animator anim; 


    void Awake()
    {
        I = this;
    }

    void Start()
    {
        Time.timeScale = 1.0f; 
        InvokeRepeating("makeSquare", 0.0f, 0.5f);
    }

    
    void Update()
    {
        alive += Time.deltaTime; 
        timeTxt.text = alive.ToString("N2");

        if (isRunning) 
        {
            //게임이진행중이면얼라이브업뎃해서타임스퀘어를업뎃하고진행중아님하지마 
            alive += Time.deltaTime;
            timeTxt.text = alive.ToString("N2");
        }
    }

    void makeSquare()
    {
        Instantiate(square); 
    }

    public void gameOver() //게임종료함수 
    {
        anim.SetBool("isDie", true);

        isRunning = false; //게임오버가된순간시간멈춤
        Invoke("timeStop", 0.5f); //끝나면 애니메이션 나올 틈(시간)
        endPanel.SetActive(true);
        //이제겜매에게panel옵젝만주면연결!
        thisScoreTxt.text = alive.ToString("N2");

        //최고기록.. 
        if(PlayerPrefs.HasKey("bestscore") == false)
        {
            PlayerPrefs.SetFloat("bestscore", alive);
        }
        else
        {
            if (alive > PlayerPrefs.GetFloat("bestscore"))
            {
                PlayerPrefs.SetFloat("bestscore", alive);
            }
        }
        float maxScore = PlayerPrefs.GetFloat("bestscore");
        maxScoreTxt.text = maxScore.ToString("N2");
    }

    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    void timeStop()
    {
        Time.timeScale = 0.0f;
    }
}
