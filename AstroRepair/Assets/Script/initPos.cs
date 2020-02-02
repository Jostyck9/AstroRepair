using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initPos : MonoBehaviour
{
    public Slider _slider;
    public GameObject _bottle;
    public Text _textPorcent;
    public Text _textObjet;
    private Camera _cam;

    void Start()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        Vector3 position1 = _cam.transform.position;
        float _largeur = Screen.width;
        float _hauteur = Screen.height;

        _slider.transform.localPosition = new Vector3(0, 7.1f, -5);
        _textPorcent.transform.localPosition = new Vector3(17, 6.8f, -5);
        _textObjet.transform.localPosition = new Vector3(30, -8, -5);
        _bottle.transform.localPosition = new Vector3(-20, 7, 0);
        _slider.transform.localScale = new Vector3(0.2f, 0.2f, 1);
        _textObjet.transform.localScale = new Vector3(0.1f, 0.1f, 1);
        _bottle.transform.localScale = new Vector3(0.7f, 0.5f, 1);
    }
}
