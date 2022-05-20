using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float rotatespeed = 5f;
    public float mobilespeed = 1f;
   
    Vector3 touchposition;
    Touch touch;
    Quaternion rotationz;

    bool left;
    bool right;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pcinput();
        mobileinput();
    }
    void pcinput()
    {
        if (Input.GetKey(KeyCode.A)||left)
        {

            transform.Rotate(0, 0, rotatespeed * Time.deltaTime * -1);
        }       
        if (Input.GetKey(KeyCode.D)||right)
        {

            transform.Rotate(0, 0, rotatespeed * Time.deltaTime * 1);

        }
    }

  public   void leftmove()
    {
        left = true;
    }
  public   void rightmove()
    {
        right = true;
    }

    public void offmove()
    {
        left = false;
        right = false;
    }
    

    
    void mobileinput()
    {
     


        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
        }

        if (touch.phase == TouchPhase.Began)
        {
            touchposition = touch.position;

        }
        if (touch.phase == TouchPhase.Moved)
        {

            if (Mathf.Abs( touchposition.x) > Mathf.Abs( touch.position.x))
            {
                //transform.Rotate(0, 0, screentouch.deltaPosition.x * Time.deltaTime * 1);
                rotationz = Quaternion.Euler(0f, 0f, touch.position.x * mobilespeed);
                transform.rotation = rotationz * transform.rotation;
                touchposition = touch.position;

            }
            else
            {
                rotationz = Quaternion.Euler(0f, 0f, -touch.position.x * mobilespeed);
                transform.rotation = rotationz * transform.rotation;
                touchposition = touch.position;

            }
            if (Input.touchCount < 0 && TouchPhase.Moved == TouchPhase.Stationary)
            {
                Input.touches[0].phase = TouchPhase.Canceled;
            }
        }
       

    }
    
}
