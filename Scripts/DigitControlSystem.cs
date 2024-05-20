using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DigitControlSystem : MonoBehaviour
{

    [SerializeField] public GameObject inference;

    public GetInferenceFromModel _getInferenceFromModel;

    private int predicted_value;

    private int i = 0;

    private int[] trueOrder = { 3, 2, 5 };
    public bool isDigitsMatched;

    // UI Elements
    public List<TextMeshProUGUI> outputTexts;

    void Start()
    {
        _getInferenceFromModel = inference.GetComponent<GetInferenceFromModel>();
    }

    void Update()
    {
        predicted_value = _getInferenceFromModel.prediction.predictedValue;
    }
    public void Fill()
    {
        outputTexts[i].text = predicted_value.ToString();
        i = i + 1;

        if (i > outputTexts.Count) i = 0;

        if (outputTexts.Count == trueOrder.Length)
        {
            checkDigits();
        }
        
    }

    public void Reset()
    {
        foreach (var text in outputTexts)
        {
            text.text = " ";
            i = 0;
        }
    }

    public void checkDigits()
    {

        for (int j = 0; j < trueOrder.Length; j++)
        {
            if (outputTexts[j].text != trueOrder[j].ToString())
            {
                isDigitsMatched = false; 
                break;
            } 
            else
            {
                isDigitsMatched = true;
            }
        }

        Debug.Log(isDigitsMatched);
    }

}
