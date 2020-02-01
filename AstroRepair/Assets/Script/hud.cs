using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hud : MonoBehaviour
{
    // Start is called before the first frame update
    public float _currentO2 = 100;
    public float _maxO2 = 100;
    public float _currentObject= 0;
    public float _maxObject = 5;
    public Slider _slider;
    public Text _object;
    public Text _porcent;
    public float _speed = 0.01f;
    void Start()
    {
        
    }

    // FicedUpdate is called once per frame
    void FixedUpdate()
    {
        if (_currentO2 != 0)
        {
            _currentO2 -= 1 * _speed;
            float progress = Mathf.Clamp01(_currentO2 / _maxO2);
            _slider.value = progress;
            _porcent.text = Mathf.Round(progress * 100) + "%";
        }
        if (Input.GetKeyUp(KeyCode.P))
            {
            _currentObject += 1;
            if (_currentObject < 2)
            {
                _object.text = "Object : " + _currentObject + " / 4";

            }
            if (_currentObject >= 2)
            {
                _object.text = "Objects : " + _currentObject + " / 5";
            }
        }
    }
}
