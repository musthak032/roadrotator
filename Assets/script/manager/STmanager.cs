using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STmanager : MonoBehaviour
{
    public Text score;
    public Text timer;
    // fore 4type score value
    [Header("all highscore text value")]
    public Text[] highscoretext;
    public Text[] currentscoretext;
    [Header("life system")]
    public Text lifetextvalue;
    int currentlife;

    //highscore and current score
    float highscore;
    float currentScore;

    //timer
    public float time = 60f;

    public bool stoptime;
    public bool starttime = false;




    public UIManager uimanger;
    public player player;

    // Start is called before the first frame update
    void Start()
    {
        load();
        currentScore = 0;

        restlife();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScore > highscore)
        {
            highscore = currentScore;
            for (int i = 0; i < highscoretext.Length; i++)
            {
                highscoretext[i].text = highscore.ToString("0");

            }
            save();
        }
        timersetup();

        scorecal();
    }


    void scorecal()
    {
        if (player.playerStartToMove)
        {
            currentScore += 1 * Time.deltaTime;
            for(int i = 0; i < currentscoretext.Length; i++)
            {
                currentscoretext[i].text = currentScore.ToString("0");
            }
        }
    }
    public void addscore(int a)
    {
        currentScore += a;
        score.text = currentScore.ToString("0");
        for(int i = 0; i < currentscoretext.Length; i++)
        {
            currentscoretext[i].text = currentScore.ToString("0");

        }
    }
    public void resetcurentscore()
    {
        currentScore = 0;
        score.text = currentScore.ToString();

    }

    public void load()
    {
        if (!PlayerPrefs.HasKey("highscore"))
        {
            highscore = 0;
        }
        else
        {
            highscore = PlayerPrefs.GetFloat("highscore");

            for (int i = 0; i < highscoretext.Length; i++)
            {
                highscoretext[i].text = highscore.ToString("0");

            }
        }
    }
    public void save()
    {
        PlayerPrefs.SetFloat("highscore", highscore);
    }

    public void resettime()
    {
        time = 60f;
        stoptime = false;
        starttime = true;

    }
    public void stoptimerwhendaie()
    {
        //time = 60f;
        stoptime = true;
        starttime = false;

    }

    public void setcorrecttime()
    {
        time = 20f;
        timer.text = time.ToString("0");


    }
    public void stoptimer()
    {
        stoptime = true;
    }

    void timersetup()
    {

        if (!stoptime)
        {
            if (starttime)
            {
                time -= 1 * Time.deltaTime;
                timer.text = time.ToString("0");
                if (time <= 0)
                {
                    //timeranim.SetTrigger("showtimeup");
                    time = 0;
                    stoptime = true;
                    //Invoke("callnextquestion", 4.5f);
                    GameObject.FindObjectOfType<player>().GetComponent<player>().playerStartToMove = false;
                    Invoke("showfinishtab", 2f);
                }
            }
        }
    }

    public void showfinishtab()
    {
        //GameObject.FindObjectOfType<player>().GetComponent<player>().playerStartToMove = true;
        uimanger.showcompleted();
        
    }
    public void restlife()
    {
        currentlife = 0;
        currentlife = 3;
        lifetextvalue.text = currentlife.ToString();
    }
    public bool damagelife()
    {
        if (currentlife >1)
        {
            currentlife -= 1;
            lifetextvalue.text = currentlife.ToString();
            return true;
        }
        else
        {
            restlife();
            return false;
        }
       
    }

 
 

}
