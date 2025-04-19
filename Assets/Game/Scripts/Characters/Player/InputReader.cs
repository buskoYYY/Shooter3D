using System;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const string MoseX = "Mouse X";
    private const string MoseY = "Mouse Y";

    [SerializeField] private List<KeyCode> _jumpKeys;
    [SerializeField] private List<KeyCode> _shootKeys;
    [SerializeField] private List<KeyCode> _firstWeaponKeys;
    [SerializeField] private List<KeyCode> _secondWeaponKeys;
    [SerializeField] private List<KeyCode> _reloadKeys;
    [SerializeField] private List<KeyCode> _pauseKeys;

    public event Action<float, float> Moved;
    public event Action<float, float> Looked;
    public event Action<int> WeaponSwitched;
    public event Action Jumped;
    public event Action Shot;
    public event Action Reloaded;
    public event Action Paused;

    private void Update()
    {
        if (TimeManager.IsPaused)
            return;

        float horizontal = Input.GetAxisRaw(Horizontal);
        float vertical = Input.GetAxisRaw(Vertical);
        Moved?.Invoke(horizontal, vertical);

        float mousex = Input.GetAxis(MoseX);
        float mousey = Input.GetAxis(MoseY);
        Looked?.Invoke(mousex, mousey);

        foreach (KeyCode key in _jumpKeys)
        {
            if (Input.GetKeyDown(key))
            {
                Jumped?.Invoke();
            }
        }

        foreach (KeyCode key in _shootKeys)
        {
            if (Input.GetKeyDown(key))
            {
                Shot?.Invoke();
            }
        }

        foreach (KeyCode key in _firstWeaponKeys)
        {
            if (Input.GetKeyDown(key))
            {
                WeaponSwitched?.Invoke(1);
            }
        }

        foreach (KeyCode key in _secondWeaponKeys)
        {
            if (Input.GetKeyDown(key))
            {
                WeaponSwitched?.Invoke(2);
            }
        } 
        
        foreach (KeyCode key in _reloadKeys)
        {
            if (Input.GetKeyDown(key))
            {
                Reloaded?.Invoke();
            }
        } 
        
        foreach (KeyCode key in _pauseKeys)
        {
            if (Input.GetKeyDown(key))
            {
                Paused?.Invoke();
            }
        }
    }
}
