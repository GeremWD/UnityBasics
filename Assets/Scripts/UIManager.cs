using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    private RectTransform playerGreen, playerRed, bossGreen, bossRed;
    private GameObject restartButton, exitButton;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Transform lifeBar = transform.Find("LifeBar");
        playerGreen = lifeBar.Find("Green").GetComponent<RectTransform>();
        playerRed = lifeBar.Find("Red").GetComponent<RectTransform>();
        Transform bossBar = transform.Find("BossBar");
        bossGreen = bossBar.Find("Green").GetComponent<RectTransform>();
        bossRed = bossBar.Find("Red").GetComponent<RectTransform>();

        setPlayerLife(1f);
        setBossLife(1f);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void setPlayerLife(float lifeProportion)
    {
        setLife(playerGreen, playerRed, lifeProportion);
    }

    public void setBossLife(float lifeProportion)
    {
        setLife(bossGreen, bossRed, lifeProportion);
    }

    void setLife(RectTransform green, RectTransform red, float lifeProportion)
    {
        green.anchoredPosition = new Vector2(20, 40);
        green.sizeDelta = new Vector2(lifeProportion * 255, 20);
        red.anchoredPosition = new Vector2(275 - (1 - lifeProportion) * 255, 40);
        red.sizeDelta = new Vector2((1 - lifeProportion) * 255, 20);
    }

    void Stop()
    {
        Time.timeScale = 0;
        player.GetComponent<CPMPlayer>().enabled = false;
        player.GetComponent<Shoot>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void UnStop()
    {
        Time.timeScale = 1;
        player.GetComponent<CPMPlayer>().enabled = true;
        player.GetComponent<Shoot>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Lose()
    {
        Stop();
        transform.Find("LoseUI").gameObject.SetActive(true);
    }

    public void PrepareWin()
    {
        Invoke("Win", 1f);
    }

    public void Win()
    {
        Stop();
        transform.Find("WinUI").gameObject.SetActive(true);
        StartCoroutine("WinCoroutine");
    }

    IEnumerator WinCoroutine()
    {
        yield return new WaitForSecondsRealtime(2f);
        Exit();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void Exit()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }

    public void Pause()
    {
        Stop();
        transform.Find("PauseUI").gameObject.SetActive(true);
    }

    public void OnContinue()
    {

        transform.Find("PauseUI").gameObject.SetActive(false);
        UnStop();
    }
}
