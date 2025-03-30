using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GamePlayer : MonoBehaviour
{
    // 숫자
    public int Score; // 숫자 - int
    public string PlayerName; // 문자 - string
    public int Hp; //체력
    public float GameTimer; //게임 타이머

    public bool IsPlaying; // 맞냐 틀리냐 true false

    private void Start()
    {
        Debug.Log("Start");
    }

    private void Update()
    {
        if( ! IsPlaying)
        {
            Debug.Log("게임이 끝났습니다");
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

        if(isEnemy) // Enemy와 부딪혔다면
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
