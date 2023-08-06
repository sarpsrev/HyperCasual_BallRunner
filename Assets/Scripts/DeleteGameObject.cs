using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGameObject : MonoBehaviour
{

    public  void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.CompareTag("Untagged"))
        {
            hit.gameObject.SetActive(false);
          
        }

        
    }


}
