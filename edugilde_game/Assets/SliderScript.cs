using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        SetNumberText(slider.value);
    }
    public void SetNumberText(float value) 
    {
        numberText.text = value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
