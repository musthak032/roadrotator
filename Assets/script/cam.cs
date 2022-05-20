using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public Transform player;
    public float camdisz = 7.8f;
    public float camdizy;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rotateobject();
    }
    private void LateUpdate()
    {
        //transform.position = new Vector3(transform.position.x, player.position.y+camdizy, player.position.z - camdisz);
        {
            transform.position = new Vector3(player.position.x, player.position.y + camdizy, player.position.z - camdisz);

        }
       

    }
    void rotateobject()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "cube")
                {
                    var objectscipt = hit.collider.GetComponent<playercontroller>();
                    //objectscipt.isactive = !objectscipt.isactive;
                }
            }
        }
    }
}
