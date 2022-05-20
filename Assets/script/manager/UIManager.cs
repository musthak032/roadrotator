using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("onplayui")]
    public GameObject onplayui; //hide to on
    public GameObject deathpannels;
    public GameObject showfinishpannelui;
    public Animator openpannel;
    public Animator showdeathpannel;

    player player;
    [Header("time manager")]
    public STmanager stmanager;
 

    void Start()
    {
        player = FindObjectOfType<player>();
        deathpannels.SetActive(false);
        offallUi();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //button
    public void starttoplay()
    {
        player.transform.position = new Vector3(0, 8, -992);
        player.playermesh.enabled = true;

        openpannel.SetTrigger("openpannelopen");
        Invoke("onplayermove", 3f);
        stmanager.stoptimerwhendaie();
        stmanager.restlife();
        stmanager.resetcurentscore();


    }
    //button

    private void onplayermove()
    {
        offallUi();
        stmanager.resettime();
        
        onplayui.SetActive(true);
        player.playerStartToMove = true;
        onplayui.SetActive(true);
        //
        
    }

    public void showdeathui()
    {
        stmanager.stoptimerwhendaie();
        offallUi();
        deathpannels.SetActive(true);
        showdeathpannel.SetTrigger("showdeathpannelopen");
        //onplayui.SetActive(false);

    }

    //button
    public void backtomain()
    {
        stmanager.time = 60f;
        stmanager.stoptimerwhendaie();
        player.transform.position = new Vector3(0, 8, -992);

        offallUi();
        openpannel.SetTrigger("openpannelclose");

        stmanager.resetcurentscore();

    }
    public void exit()
    {
        Application.Quit();
    }
    public void playagain()
    {
        //
        player.playermesh.enabled = true;

        stmanager.resettime();
        player.transform.position = new Vector3(0, 8, -992);
        offallUi();
        // expect scoreui
        onplayui.SetActive(true);
        stmanager.restlife();

        player.playerStartToMove = true;

        // score reset
        stmanager.resetcurentscore();
    }

    //
    public void offallUi()
    {
        deathpannels.SetActive(false);
        onplayui.SetActive(false);
        showfinishpannelui.SetActive(false);

    }

    public void showcompleted()
    {
        offallUi();
        showfinishpannelui.SetActive(true);

    }
}
