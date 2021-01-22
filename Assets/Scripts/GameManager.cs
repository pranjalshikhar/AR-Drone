using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public DroneController _DroneController;
    
    public Button _FlyButton;
    public Button _LandButton;

    public GameObject _Controls;

    struct DroneAnimationControls
    {
        public bool _moving;
        public bool _interpolatingAsc;
        public bool _interpolatingDesc;
        public float _axis;
        public float _direction;
    }

    DroneAnimationControls _MovingLeft;
    // DroneAnimationControls _MovingRight;
    DroneAnimationControls _MovingBack;
    // DroneAnimationControls _MovingForward;

    void Start()
    {
        _FlyButton.onClick.AddListener(EventClickFlyButton);
        _LandButton.onClick.AddListener(EventOnClickLandButton);
    }

    void UpdateControls(ref DroneAnimationControls _controls)
    {
        if(_controls._moving || _controls._interpolatingAsc || _controls._interpolatingDesc)
        {
            if(_controls._interpolatingAsc)
            {
                _controls._axis += 0.05f;

                if(_controls._axis >= 1.0f)
                {
                    _controls._axis = 1.0f;
                    _controls._interpolatingAsc = false;
                    _controls._interpolatingDesc = true;
                }
            }
            else if(!_controls._moving)
            {
                _controls._axis -= 0.05f;

                if (_controls._axis <= 0.0f)
                {
                    _controls._axis = 0.0f;
                    _controls._interpolatingDesc = false;
                    /*_controls._interpolatingAsc = true;*/
                }
            }
        }
    }

    void Update()
    {
        // float speedX = Input.GetAxis("Horizontal");
        // float speedZ = Input.GetAxis("Vertical");

        UpdateControls(ref _MovingLeft);
        // UpdateControls(ref _MovingRight);
        UpdateControls(ref _MovingBack);
        // UpdateControls(ref _MovingForward);

        _DroneController.Move(_MovingLeft._axis * _MovingLeft._direction, _MovingBack._axis * _MovingBack._direction);
    }

    void EventClickFlyButton()
    {
        if(_DroneController.IsIdle())
        {
            _DroneController.TakeOff();
            _FlyButton.gameObject.SetActive(false);
            _Controls.SetActive(true); 
        }
    }

    void EventOnClickLandButton()
    {
        if(_DroneController.IsFlying())
        {
            _DroneController.Land();
            _LandButton.gameObject.SetActive(true);
            _Controls.SetActive(false);
            _FlyButton.gameObject.SetActive(true);
        }
    }
    
    // Left Button
    public void EventOnLeftButtonPressed()
    {
        _MovingLeft._moving = true;
        _MovingLeft._interpolatingAsc = true;
        _MovingLeft._direction = -1.0f;
    }

    public void EventOnLeftButtonReleased()
    {
        _MovingLeft._moving = false;
    }


    // Right Button
    public void EventOnRightButtonPressed()
    {
        _MovingLeft._moving = true;
        _MovingLeft._interpolatingAsc = true;
        _MovingLeft._direction = 1.0f;
    }

    public void EventOnRightButtonReleased()
    {
        _MovingLeft._moving = false;
    }


    // Back Button
    public void EventOnBackButtonPressed()
    {
        _MovingBack._moving = true;
        _MovingBack._interpolatingAsc = true;
        _MovingBack._direction = -1.0f;
    }

    public void EventOnBackButtonReleased()
    {
        _MovingBack._moving = false;
    }


    // Forward Button
    public void EventOnForwardButtonPressed()
    {
        _MovingBack._moving = true;
        _MovingBack._interpolatingAsc = true;
        _MovingBack._direction = 1.0f;
    }

    public void EventOnForwardButtonReleased()
    {
        _MovingBack._moving = false;
    }

}
