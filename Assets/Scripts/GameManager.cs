using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public DroneController _DroneController;
    public Button _FlyButton;

    void Start()
    {
        _FlyButton.onClick.AddListener(EventClickFlyButton);
    }

    void Update()
    {
        float speedX = Input.GetAxis("Horizontal");
        float speedZ = Input.GetAxis("Vertical");

        _DroneController.Move(speedX, speedZ);
    }

    void EventClickFlyButton()
    {
        if(_DroneController.IsIdle())
        {
            _DroneController.TakeOff();
            _FlyButton.gameObject.SetActive(false);
        }
    }
}
