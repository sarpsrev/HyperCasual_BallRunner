using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{

    public Transform menuTransform; 
    public Vector3 openPosition;    
    public Vector3 closedPosition;  
    public float speed = 5f;        
    private bool isMenuOpen = false;

 public void onClickedSettings()
    {
        if (isMenuOpen)
        {
            CloseMenu();
        }
        else
        {
            OpenMenu();
        }
    }

    public void OpenMenu()
    {
        StopAllCoroutines();
        StartCoroutine(MoveToPosition(openPosition));
        isMenuOpen = true;
    }

    public void CloseMenu()
    {
        StopAllCoroutines();
        StartCoroutine(MoveToPosition(closedPosition));
        isMenuOpen = false;
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        // it changes menu position and checking target position is neraby.
        while (Vector3.Distance(menuTransform.localPosition, targetPosition) > 0.01f)
        {
            menuTransform.localPosition = Vector3.Lerp(menuTransform.localPosition, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}
