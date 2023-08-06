using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerControl : MonoBehaviour
{

    public CameraShake cameraShake;
    public UIManager uiManager;

    public float speedRatio;

    public int startSpeed;

    public bool isPlayerDeath;

    public Rigidbody rb;

    public GameObject mainCam;
    public GameObject vectorBack;
    public GameObject vectorForward;
    public GameObject[] sphereFracture;
    public GameObject finalText;
    public GameObject handCta;
    public bool speedBallForward = false;
    




 
    public void Update()
    {
       if(GameVariables.firstTouch == 1&&!speedBallForward){
          transform.position += new Vector3(0,0,startSpeed * Time.deltaTime);


          vectorBack.transform.position += new Vector3(0,0,startSpeed * Time.deltaTime);

          vectorForward.transform.position += new Vector3(0,0,startSpeed * Time.deltaTime);          
                    
       }


        if(Input.touchCount > 0)
        {          
            Touch touch = Input.GetTouch(0);
            if(!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    switch (touch.phase)
                    {  
                    case TouchPhase.Began:
                    GameVariables.firstTouch = 1;
                    uiManager.firstScreenClose();
                    break;

                    case TouchPhase.Moved:
                    
                    rb.velocity =  new Vector3(
                    touch.deltaPosition.x * speedRatio * Time.deltaTime, 
                    transform.position.y,
                    touch.deltaPosition.y * speedRatio * Time.deltaTime);    

                    break;

                    case TouchPhase.Ended:
                    //rb.velocity = Vector3.zero;
                    break;
                  }    
                        
                }        

        }
       
    }

    public void OnCollisionEnter(Collision hit) {

        if(hit.gameObject.CompareTag("Obstacles")&&!isPlayerDeath){
            
            isPlayerDeath = true;
            startSpeed = 0;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            cameraShake.CameraShakeStart();
            uiManager.StartWhiteScreenEffect();
            uiManager. Invoke("whenPlayerDied", 1.5f);
            Time.timeScale=0.4f;
            finalText.transform.position = transform.position;
            finalText.SetActive(true);



            foreach (GameObject item in sphereFracture)
            {
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.GetComponent<BoxCollider>().enabled = true;   
            }
        }
            
    }

    
}
