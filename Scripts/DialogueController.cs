using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index = 0;

    public GameObject continueButton;
    public float dialogueSpeed;
    public bool isPlayerClose;
    [SerializeField]
    public GameObject message;

    private int sceneIndex;

    private string[] dialogueFirst = { "Merhaba!",
        "�ksirlerinle hastal�klar� iyile�tirdi�ini duydum.",
        "L�tfen kar�m�n hastal��� i�in iksir haz�rlar m�s�n?"};

    private string[] dialogueTrue = { "Kar�m iyile�ti!",
        "Te�ekk�r ederim. Sen �ok iyi birisin!"};

    private string[] dialogueFalse = { "Olamaz �l�yor!",
        "Senden nefret ediyorum!"};

    private string[] dialogueKing = { "Beni kurtard�n!",
        "Sayende �lkemizi ele ge�iremeyecekler!"};

    private string[] dialogueVillage = { "NE! Hemen ka�al�m!",
        "Haber verdi�in i�in te�ekk�rler!"
        };


    void Start()
    {
        index = 0;
        dialogueText.text = "";
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerClose)
        {
            if(dialogueBox.activeInHierarchy)
            {
                zeroText();
            } 
            else
            {
                dialogueBox.SetActive(true);
                StartCoroutine(Typing());

            }
        }
        if (dialogueText.text == dialogue[index])
        {
            continueButton.SetActive(true);
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialogueBox.SetActive(false);
    }

    IEnumerator Typing()
    {
        if (sceneIndex == 1)
        {
            if (EnvanterController.isIksirDone)
            {
                dialogue = dialogueTrue;
            }
            else
            {
                dialogue = dialogueFirst;
            }
        }
        else if (sceneIndex == 3)
        {
            dialogue = dialogueKing;
        }
        else if (sceneIndex == 4)
        {
            dialogue = dialogueVillage;
        }

        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueSpeed);
        }
    }

    public void NextLine()
    {
        continueButton.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        } 
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Player")) 
       {
            Debug.Log("Yak�n");
            isPlayerClose = true;
            message.SetActive(true);
       }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       if (other.CompareTag("Player"))
       {
            isPlayerClose = false;
            message.SetActive(false);
            zeroText();
       }
    }

}
