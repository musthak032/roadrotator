using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [Header("partical effect")]
    public ParticleSystem destroy;
    public ParticleSystem coinparticles;

    public MeshRenderer playermesh;

    [Header("manger")]
    public STmanager stmanager;
    public UIManager uimanager;


    public float forwardspeed;
    public float sidemove;


    public bool playerStartToMove=false;

    List<GameObject> triggerobj = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStartToMove)
        {
            playermove();

        }
    }

    void playermove()
    {
      
        transform.Translate(transform.forward * forwardspeed * Time.deltaTime);
    }

   public void stopplayermove()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obtacle")
        {
            if (stmanager.damagelife())
            {
                destroy.Play();
                triggerobj.Add(other.gameObject);
                other.gameObject.SetActive(false);
                Invoke("showhideobject",2f);
                
                //Instantiate(destroy, new Vector3(transform.position.x, 9, transform.position.z), Quaternion.identity);
            }
            else
            {
                destroy.Play();
                other.gameObject.SetActive(false);
                playermesh.enabled = false;
                Invoke("showhideobject", 2f);
                Debug.Log("player death");
                playerStartToMove = false;
                uimanager.showdeathui();
                stmanager.restlife();
            }

          
        }
        if (other.gameObject.tag == "points")
        {
            coinparticles.Play();
            Debug.Log("increase score");
            stmanager.addscore(10);
        }
        //Debug.Log(other.gameObject.tag);


    }

    void showhideobject()
    {
        foreach(GameObject obj in triggerobj)
        {
            obj.SetActive(true);
        }
        triggerobj.Clear();

    }





}
