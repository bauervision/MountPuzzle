using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginManager : MonoBehaviour
{
    public GameObject initialScreen;
    public GameObject loginScreen;
    public GameObject createScreen;
    // Start is called before the first frame update
    void Start()
    {
        loginScreen.SetActive(false);
        createScreen.SetActive(false);
    }

    public void ShowCreateScreen()
    {
        createScreen.SetActive(true);
        initialScreen.SetActive(false);
    }


    public void ShowLoginScreen()
    {
        loginScreen.SetActive(true);
        initialScreen.SetActive(false);
    }


    public void ShowInitialScreen()
    {
        loginScreen.SetActive(false);
        createScreen.SetActive(false);
        initialScreen.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
