using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Image whiteImage;

    public float transitionDuration = 1.0f;
    public float delayTime = 0.001f;      

    private Coroutine effectCoroutine;

    public Text coinText;

    public Sprite openSprite;   
    public Sprite closedSprite; 
    public Image SoundOpenCloseImage;
    private bool isImageOpen = true;

    public Sprite vibrationSprite;   
    public Sprite nonVibrationSprite; 
    public Image vibrationOpenCloseImage;
    public GameObject[] firsrScreenItems;
    public GameObject resetButton;
    private bool isVibrationOpen = true;
    public  GameObject rewardScreen;



    void Start()
    {
        coinTextUpdate();
    }


    public void coinTextUpdate()
    {
       coinText.text = PlayerPrefs.GetInt("coin").ToString();
    }
    
    public void StartWhiteScreenEffect()
    {


        if (effectCoroutine != null)
        {
            StopCoroutine(effectCoroutine);
        }


        effectCoroutine = StartCoroutine(WhiteScreenEffectCoroutine());
    }

    public IEnumerator WhiteScreenEffectCoroutine()
    {   
        

        whiteImage.gameObject.SetActive(true);

        yield return StartCoroutine(FadeTo(1f));


        yield return StartCoroutine(FadeTo(0f));


        
    }

    public void firstScreenClose()
    {
            foreach (GameObject item in firsrScreenItems)
            {
                item.SetActive(false);
                   
            }
    }

    public void whenPlayerDied()
    {
        resetButton.SetActive(true);
    }

    public IEnumerator FadeTo(float targetAlpha)
    {

        Color startColor = whiteImage.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, targetAlpha);

        float elapsedTime = 0f;
        while (elapsedTime < transitionDuration)
        {
            whiteImage.color = Color.Lerp(startColor, targetColor, elapsedTime / transitionDuration );
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        whiteImage.color = targetColor;
    }

    public void ToggleSoundImage()
    {
        isImageOpen = !isImageOpen; 

        UpdateSoundImageSprite();
    }

    private void UpdateSoundImageSprite()
    {
        SoundOpenCloseImage.sprite = isImageOpen ? openSprite : closedSprite;
    }

    public void ToggleVibrationImage()
    {
        isVibrationOpen = !isVibrationOpen; 

        UpdateVibrationImageSprite();
    }

    private void UpdateVibrationImageSprite()
    {
        vibrationOpenCloseImage.sprite = isVibrationOpen ? vibrationSprite : nonVibrationSprite;
    }

    public void RestartScne()
    {
        GameVariables.firstTouch = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void rewardScreenAction()
    {
        rewardScreen.SetActive(true);

    }
        
 }

    




