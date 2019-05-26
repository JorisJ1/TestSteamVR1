using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Awake");

        GameObject textWall = GameObject.Find("TextWall");
        textWall.GetComponentInChildren<TextMeshPro>().text = "Blub.";
        //GetComponent<TextMeshPro>().text = "Blub.";
    }
}
