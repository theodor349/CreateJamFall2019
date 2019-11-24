using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objectsToHide;

    private void OnEnable()
    {
        
    }

    private void HideObjects()
    {
        for(int i = 0; i < objectsToHide.Length; i++)
        {
            objectsToHide[i].SetActive(false);
        }
    }
}
