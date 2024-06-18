using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private Rigidbody playerRb;

    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _curb;

    [SerializeField] private float _speed = 10.0f;
    private float _oldMousePositionX;
    private float _eulerY;
    private float _border;
    void Start()
    {
        _border = _curb.transform.position.x - 1;
        //playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _oldMousePositionX = Input.mousePosition.x;
            _animator.SetBool("Run", true);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = transform.position + transform.forward * _speed * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, -_border, _border);
            transform.position = newPosition;

            float deltaX = Input.mousePosition.x - _oldMousePositionX;
            _oldMousePositionX = Input.mousePosition.x;

            _eulerY += deltaX;
            _eulerY = Mathf.Clamp(_eulerY, -80, 80);
            transform.eulerAngles = new Vector3(0, _eulerY, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetBool("Run", false);
        }
    }
}
