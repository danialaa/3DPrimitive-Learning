using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public ShapePanelView shapePanelView;

    GameObject primitive;

    public static GameController instance { private set; get; }

    void Awake()
    {
        shapePanelView.Init(editShape);
        shapePanelView.gameObject.SetActive(true);

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

}
