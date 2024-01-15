using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThemeFoundBehavior : MonoBehaviour
{
    // reference the particle system
    [SerializeField]
    private GameObject confetti;

    [SerializeField]
    private GameObject status;

    private string newText;


    // Start is called before the first frame update
    private void Start()
    {
        confetti.SetActive(false);
        newText = GetComponent<Text>().text;
        Debug.Log(newText);
        status.SetActive(false);

    }

    // Update is called once per frame
    private void Update()
    {
        //Click to toggle on/off partilces
        if (Input.GetMouseButtonDown(0))
        {
            status.SetActive(!status.activeSelf);
            confetti.SetActive(!confetti.activeSelf);
            status.GetComponent<TMP_Text>().SetText(newText);
        }

    }

}
