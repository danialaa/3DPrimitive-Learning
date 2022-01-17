using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public ShapePanelView shapePanelView;
    public Button editButton;
    public float rotationSpeed;

    GameObject primitive;

    public static GameController instance { private set; get; }

    void Awake()
    {
        shapePanelView.Init(editShape);
        shapePanelView.gameObject.SetActive(true);

        editButton.onClick.AddListener(openEditPanel);
    }

    void Start()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    void openEditPanel()
    {
        shapePanelView.gameObject.SetActive(true);
    }

    private void editShape()
    {
        shapePanelView.gameObject.SetActive(false);
        Destroy(primitive);

        switch(shapePanelView.selectedType)
        {
            case ShapeTypes.Cube:
                primitive = GameObject.CreatePrimitive(PrimitiveType.Cube);
                break;

            case ShapeTypes.Cylinder:
                primitive = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                break;

            case ShapeTypes.Sphere:
                primitive = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                break;
        }

        primitive.GetComponent<Renderer>().material.color = shapePanelView.selectedColor;
        primitive.transform.SetParent(gameObject.transform);
        primitive.transform.position = Vector3.zero;
        primitive.transform.localRotation = Quaternion.Euler(-20, 45, -20);
        //primitive.transform.localScale = new Vector3(2, 2, 2);
        primitive.AddComponent<PrimitiveController>();
        primitive.SetActive(true);
    }
}
