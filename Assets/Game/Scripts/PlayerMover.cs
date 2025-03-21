using UnityEngine;

[ RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _speed;

    private CharacterController _controller;
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        _inputReader.Moved += Move;
    }
    private void OnDisable()
    {
        _inputReader.Moved -= Move;
    }

    private void Move(float horizontal, float vertical)
    {
        Vector3 direction = transform.forward * vertical + transform.right * horizontal;
        direction.Normalize();
        _controller.Move(direction * _speed * Time.deltaTime);
    }

}
