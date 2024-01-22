using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//��(�ٽý���)�Ŵ���������ҰŴ� 

public class gameManager : MonoBehaviour
{

    public GameObject square; //�׸ſ��Թݺ�������� 
    public Text timeTxt; //�׸ſ��Խð������
    float alive = 0f; //�ٷγ���
    public static gameManager I; //�̱��漱�𳪸��ҷ����ϴ���
    public GameObject endPanel;//�׸ſ��Կ����ǳڵ�ã�Խ�Ŵ 
    public Text thisScoreTxt;
    bool isRunning = true;//�ð���������
    public Text maxScoreTxt; //�ְ���.. 
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
            //�������������̸����̺�����ؼ�Ÿ�ӽ���������ϰ������߾ƴ������� 
            alive += Time.deltaTime;
            timeTxt.text = alive.ToString("N2");
        }
    }

    void makeSquare()
    {
        Instantiate(square); 
    }

    public void gameOver() //���������Լ� 
    {
        anim.SetBool("isDie", true);

        isRunning = false; //���ӿ������ȼ����ð�����
        Invoke("timeStop", 0.5f); //������ �ִϸ��̼� ���� ƴ(�ð�)
        endPanel.SetActive(true);
        //�����׸ſ���panel�������ָ鿬��!
        thisScoreTxt.text = alive.ToString("N2");

        //�ְ���.. 
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
