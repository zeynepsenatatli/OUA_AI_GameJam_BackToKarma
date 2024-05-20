using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IksirController : MonoBehaviour
{
    [SerializeField]
    public GameObject bookPanel;
    //public GameObject iksirImage;
    public DigitControlSystem digitControlSystem;

    private bool isPlayerClose;

    public bool isIksirDone;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isPlayerClose)
        {
            OpenBook();
        }
    }
    private void OpenBook()
    {
        bookPanel.SetActive(true); 
    }

    public void CloseBook()
    {
        bookPanel.SetActive(false);
    }

    public void MakeIksir()
    {
        if (digitControlSystem.isDigitsMatched)
        {
            //isIksirDone = true;
            EnvanterController.isIksirDone = true;
        } 
        else
        {
            //isIksirDone = false;
            EnvanterController.isIksirDone = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerClose = false;
        }
    }
}
