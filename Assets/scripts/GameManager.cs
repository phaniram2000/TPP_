using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ObjectPool poollist;
    public Text t1;
    public Text t2;
    public Text t3;
    public int scoreincre;
    public int life=3;
    public int Highscore;
    public AudioClip crash;
    AudioSource music;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        music = GetComponent<AudioSource>();
        Highscore = PlayerPrefs.GetInt("FinalScore",0);
        life = 3;
    }
   
    private void Update()
    {
        t1.text = "Score:" + scoreincre;
        t2.text = "Lifes:" + life;
        t3.text = "HighScore:" + Highscore;
        
    }
    public void UpdateScore()
    {
        if (scoreincre > Highscore)
        {
            Highscore = scoreincre;
            PlayerPrefs.SetInt("FinalScore", Highscore);
            
        }
        scoreincre += 1;
    }
    public void LiveScore()
    {
        life-=1;
    }

    public void WritetoMyFile()
    {
        string textfile = Application.dataPath + "/MyData/" + "mydataforfile" + ".txt";
        if(File.Exists(textfile))
        {
            File.AppendAllText(textfile, t3.text + "\n");
        }
    }
    private void OnApplicationQuit()
    {
        WritetoMyFile();
    }

    public void SoundManager()
    {
        music.PlayOneShot(crash, 1.0f);
    }

    public void Healthbooster()
    {
        life += 1;
    }
}
