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

    [SerializeField]
    private GameObject ThemePanel;

    [SerializeField]
    private GameObject Background;

    Material GradientMaterial;
    bool isFading = false;
    bool hasPlayed = false;
    float fade = 1f;
    private string newText;

    private void SetDefaults() {
        GradientMaterial.SetFloat("_Fade", fade);
        confetti.SetActive(false);
        newText = GetComponent<Text>().text;
        status.SetActive(false);
        ThemePanel.SetActive(false);
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Get a reference to the material
        GradientMaterial = Background.GetComponent<SpriteRenderer>().material;

        SetDefaults();
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (hasPlayed) {
                SetDefaults();
                hasPlayed = false;
            } else {
                //turn on or off the status text
                status.SetActive(!status.activeSelf);

                //turn on or off the particles
                confetti.SetActive(!confetti.activeSelf);

                //set the status text to the new text
                status.GetComponent<TMP_Text>().SetText(newText);

                //turn the theme panel on
                ThemePanel.SetActive(!ThemePanel.activeSelf);
                isFading = !isFading;
                hasPlayed = true;

                
            }

            
        }

        if (isFading)
        {
            fade -= Time.deltaTime * 3;
            
            if (fade <= 0f)
            {
                fade = 0f;
                isFading = false;
            }

            Debug.Log(fade);

            //set the property
            GradientMaterial.SetFloat("_Fade", fade);
            
        } else {
            fade = 1f;
        }
    }
    

}
