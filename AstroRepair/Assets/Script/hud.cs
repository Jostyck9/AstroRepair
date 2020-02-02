using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hud : MonoBehaviour
{
    // Start is called before the first frame update
    public float _currentObject= 0;
    public float _maxObject = 5;
    public Slider _slider;
    public Text _object;
    public Text _porcent;
    public AirManager _airManager;
    void Start()
    {
    }

    void FixedUpdate()
    {
        if (_airManager.currentAir != 0)
        {
            Debug.Log(_airManager.currentAir);
            float progress = Mathf.Clamp01(_airManager.currentAir / _airManager.maxAir);
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
