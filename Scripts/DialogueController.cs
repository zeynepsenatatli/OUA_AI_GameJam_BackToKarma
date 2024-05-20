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
        "Ýksirlerinle hastalýklarý iyileþtirdiðini duydum.",
        "Lütfen karýmýn hastalýðý için iksir hazýrlar mýsýn?"};

    private string[] dialogueTrue = { "Karým iyileþti!",
        "Teþekkür ederim. Sen çok iyi birisin!"};

    private string[] dialogueFalse = { "Olamaz ölüyor!",
        "Senden nefret ediyorum!"};

    private string[] dialogueKing = { "Beni kurtardýn!",
        "Sayende ülkemizi ele geçiremeyecekler!"};

    private string[] dialogueVillage = { "NE! Hemen kaçalým!",
        "Haber verdiðin için teþekkürler!"
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
            Debug.Log("Yakýn");
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
