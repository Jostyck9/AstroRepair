using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initPos : MonoBehaviour
{
    public Slider _slider;
    public Text _textOxygen;
    public Text _textPorcent;
    public Text _textObjet;
    public Text _textIndice;
    private int _largeurEcran;
    private int _hauteurEcran;
    private Camera _cam;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        _largeurEcran = Screen.width;
        _hauteurEcran = Screen.height;
        Vector3 size = _cam.ScreenToWorldPoint(new Vector3(_largeurEcran, _hauteurEcran,  0));

        Vector3 posSlider = new Vector3(0.7f * size.x, 1.4f * size.y, -5);
        Vector3 posTextOxygen = new Vector3(0.6f * size.x, 1.2f * size.y, -5);
        Vector3 posTextPorcent = new Vector3(-0.40f * size.x, 1.35f * size.y, -5);
        Vector3 posTextIndice = new Vector3(0.25f * size.x, 1.45f * size.y, -5);
        Vector3 posTextObject = new Vector3(3.3f * size.x, -1.5f * size.y, -5);

        _slider.transform.localPosition = posSlider;
        _textOxygen.transform.localPosition = posTextOxygen;
        _textIndice.transform.localPosition = posTextIndice;
        _textPorcent.transform.localPosition = posTextPorcent;
        _textObjet.transform.localPosition = posTextObject;
        _slider.transform.localScale = new Vector3(0.025f * size.x, 0.04f * size.y, 1);
        _textOxygen.transform.localScale = new Vector3(0.04f * size.x, 0.04f * size.y, 1);
        _textIndice.transform.localScale = new Vector3(0.03f * size.x, 0.03f * size.y, 1);
        _textPorcent.transform.localScale = new Vector3(0.01f * size.x, 0.01f * size.y, 1);
        _textObjet.transform.localScale = new Vector3(0.015f * size.x, 0.015f * size.y, 1);
    }
}
