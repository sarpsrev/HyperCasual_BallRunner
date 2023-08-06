using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public void OnTriggerEnter(Collider hit) {

        void Start()
        {
            levelCoinCalculator(0);
            
            
        }

        if(hit.gameObject.CompareTag("Player")&&gameObject.CompareTag("levelEnd"))
        {
            Debug.Log("gameOver");
            levelCoinCalculator(100);
            uiManager.coinTextUpdate();
            uiManager.rewardScreenAction();
        
        }
        
    }

    public void levelCoinCalculator(int coin)
    {
        if(PlayerPrefs.HasKey("coin"))
        {
            int oldScore = PlayerPrefs.GetInt("coin");
            PlayerPrefs.SetInt("coin",oldScore + coin);
        } 
        else
        {
            PlayerPrefs.SetInt("coin",0);
        }

    }

}
