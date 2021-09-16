using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SliderOption : MonoBehaviour
{
    public Slider slider;
    public InputField inputField;

    private bool fromSlider = false;
    private bool fromInput = false;
    void Start()
    {
        fromSlider = false;
        fromInput = false;

        inputField.onValueChanged.AddListener(delegate { InputToSlider(); });
        inputField.onEndEdit.AddListener(delegate { if (inputField.text == "") inputField.text = slider.value.ToString(); });
        slider.onValueChanged.AddListener(delegate { SliderToInput(); });

    }
    void SliderToInput()
    {
        if (!fromInput)
        {
            fromSlider = true;
            inputField.text = slider.value.ToString("0");
            //Debug.Log("SliderToInput");
        }
        else fromInput = false;
    }
    void InputToSlider()
    {
        if (!fromSlider)
        {
            fromInput = true;
            int value;
            if(int.TryParse(inputField.text, out value)) slider.value = InputLimit(value);
            else
            {
                value = 1;
                inputField.text = "";
                slider.value = value;
            }
            //Debug.Log("InputToSlider");
        }
        else fromSlider = false;
    }
    int InputLimit(int value)
    {
        if (value > 500)
        {
            value = 500;
            inputField.text = value.ToString();
        }
        else
        {
            value = value < 1 ? 1 : value;
            inputField.text = value.ToString();
        }
        return value;
    }
}
