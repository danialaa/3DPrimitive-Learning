using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShapePanelView : MonoBehaviour
{
    public Button submitButton;
    public Toggle cubeToggle;
    public Toggle cylinderToggle;
    public Toggle sphereToggle;
    public Toggle blueToggle;
    public Toggle greenToggle;
    public Toggle redToggle;

    [HideInInspector]
    public ShapeTypes selectedType;
    [HideInInspector]
    public Color selectedColor;

    UnityAction submitButtonFunction;

    public void Init(UnityAction submitButtonFunction)
    {
        this.submitButtonFunction = submitButtonFunction;
        submitButton.onClick.AddListener(onSubmitButtonClicked);

        cubeToggle.onValueChanged.AddListener(value => onTypeToggleSelected(ShapeTypes.Cube, value));
        cylinderToggle.onValueChanged.AddListener(value => onTypeToggleSelected(ShapeTypes.Cylinder, value));
        sphereToggle.onValueChanged.AddListener(value => onTypeToggleSelected(ShapeTypes.Sphere, value));

        blueToggle.onValueChanged.AddListener(value => onColorToggleSelected('b', value));
        greenToggle.onValueChanged.AddListener(value => onColorToggleSelected('g', value));
        redToggle.onValueChanged.AddListener(value => onColorToggleSelected('r', value));

        selectedType = ShapeTypes.Cube;
        selectedColor = blueToggle.gameObject.transform.Find("Background/Checkmark").GetComponent<Image>().color;
    }

    private void onSubmitButtonClicked()
    {
        submitButtonFunction();
    }

    private void onTypeToggleSelected(ShapeTypes type, bool isOn)
    {
        if (isOn)
        {
            switch(type)
            {
                case ShapeTypes.Cube:
                    cubeToggle.isOn = true;
                    cylinderToggle.isOn = false;
                    sphereToggle.isOn = false;

                    break;

                case ShapeTypes.Cylinder:
                    cubeToggle.isOn = false;
                    cylinderToggle.isOn = true;
                    sphereToggle.isOn = false;

                    break;

                case ShapeTypes.Sphere:
                    cubeToggle.isOn = false;
                    cylinderToggle.isOn = false;
                    sphereToggle.isOn = true;

                    break;
            }

            selectedType = type;
        }
    }

    private void onColorToggleSelected(char color, bool isOn)
    {
        if (isOn)
        {
            switch (color)
            {
                case 'b':
                    blueToggle.isOn = true;
                    greenToggle.isOn = false;
                    redToggle.isOn = false;
                    selectedColor = blueToggle.gameObject.transform.Find("Background/Checkmark").GetComponent<Image>().color;

                    break;

                case 'g':
                    blueToggle.isOn = false;
                    greenToggle.isOn = true;
                    redToggle.isOn = false;
                    selectedColor = greenToggle.gameObject.transform.Find("Background/Checkmark").GetComponent<Image>().color;

                    break;

                case 'r':
                    blueToggle.isOn = false;
                    greenToggle.isOn = false;
                    redToggle.isOn = true;
                    selectedColor = redToggle.gameObject.transform.Find("Background/Checkmark").GetComponent<Image>().color;

                    break;
            }
        }
    }
}
