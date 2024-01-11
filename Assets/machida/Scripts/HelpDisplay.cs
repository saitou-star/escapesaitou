using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpDisplay : MonoBehaviour
{
    [SerializeField] GameObject HelpScreen;


    bool helpState;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (helpState == true)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                HelpScreen.gameObject.SetActive(false);
                helpState = false;
            }
        }
    }
    public void OnHelpButtonClick()
    {
        HelpScreen.gameObject.SetActive(true);
        helpState = true;

    }
}
