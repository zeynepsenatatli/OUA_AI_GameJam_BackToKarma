using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvanterController : MonoBehaviour
{
    public GameObject iksirImage;

    public static bool isIksirDone;

    // Update is called once per frame
    void Update()
    {
        if (isIksirDone)
        {
            iksirImage.SetActive(true);
        } 
        else
        {
            iksirImage.SetActive(false);
        }
    }
}
