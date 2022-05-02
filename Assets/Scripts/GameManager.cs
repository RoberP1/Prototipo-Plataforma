using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text coinTxt;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject loseUI;
    [SerializeField] private Text enemyTxt;
    [SerializeField] private Text coinsTxt;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip EnemyClip;
    [SerializeField] private AudioClip finishClip;

    public int enemys;
    public int coins;
    void Start()
    {
        winUI.gameObject.SetActive(false);
        loseUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lose()
    {
        loseUI.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void Win()
    {
        audio.clip = finishClip;
        audio.Play();
        winUI.gameObject.SetActive(true);
        coinsTxt.text = "x" + coins.ToString();
        enemyTxt.text = "x" + enemys.ToString();
        Time.timeScale = 0;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void EnemyDie()
    {
        audio.clip = EnemyClip;
        audio.Play();
        enemys++;
    }
    public void AddCoin(int quantity)
    {
        coins += quantity;
        coinTxt.text = coins.ToString();
    }
}
