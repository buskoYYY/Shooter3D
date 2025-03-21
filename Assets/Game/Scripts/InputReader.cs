using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const string MoseX = "Mouse X";
    private const string MoseY = "Mouse Y";

    public event Action<float, float> Moved;
    public event Action<float, float> Looked;
    void Update()
    {
        float horizontal = Input.GetAxisRaw(Horizontal);
        float vertical = Input.GetAxisRaw(Vertical);
        Moved?.Invoke(horizontal, vertical);

        float mousex = Input.GetAxis(MoseX);
        float mousey = Input.GetAxis(MoseY);
        Looked?.Invoke(mousex, mousey);
    }
}
