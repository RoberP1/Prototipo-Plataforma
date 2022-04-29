using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text winTxt;
    [SerializeField] private Text loseTxt;
    [SerializeField] private Button restartbt;

    public int enemys;
    void Start()
    {
        winTxt.gameObject.SetActive(false);
        loseTxt.gameObject.SetActive(false);
        restartbt.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lose()
    {
        loseTxt.gameObject.SetActive(true);
        restartbt.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void Win()
    {
        winTxt.gameObject.SetActive(true);
        restartbt.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void EnemyDie()
    {
        enemys--;
        if (enemys == 0)
        {
            Win();
        }
    }
}
