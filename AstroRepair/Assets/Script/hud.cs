using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hud : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider _slider;
    public Text _object;
    public Text _porcent;
    public AirManager _airManager;
    public ShipPiecePlayer shipPiecePlayer;
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
        if (shipPiecePlayer.nbrPieces < 2)
        {
            _object.text = "Object : " + shipPiecePlayer.nbrPieces + " / 4";
        }
        if (shipPiecePlayer.nbrPieces >= 2)
        {
            _object.text = "Objects : " + shipPiecePlayer.nbrPieces + " / 4";
        }
    }
}
