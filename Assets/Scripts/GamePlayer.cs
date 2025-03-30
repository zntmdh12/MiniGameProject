using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GamePlayer : MonoBehaviour
{
    // ����
    public int Score; // ���� - int
    public string PlayerName; // ���� - string
    public int Hp; //ü��
    public float GameTimer; //���� Ÿ�̸�

    public bool IsPlaying; // �³� Ʋ���� true false

    private void Start()
    {
        Debug.Log("Start");
    }

    private void Update()
    {
        if( ! IsPlaying)
        {
            Debug.Log("������ �������ϴ�");
            return;
        }

        GameTimer = GameTimer - Time.deltaTime;

        if(GameTimer < 0)
        {
            IsPlaying = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        bool isEnemy = other.gameObject.tag == "Enemy";
        bool isItem = other.gameObject.tag == "Item";

        if(isEnemy) // Enemy�� �ε����ٸ�
        {
            Debug.Log("Enemy Check");
            Hp = Hp - 1;

            if(Hp <= 0)
            {
                IsPlaying = false;
            }

            // if hp <= 0 -IsPlayiing = false
        }

        if (isItem)
        {
            Debug.Log("Item Check");

            Score = Score + 1;
        }

        Destroy(other.gameObject);
    }

}
