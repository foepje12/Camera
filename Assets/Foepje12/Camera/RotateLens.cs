using UnityEngine;
using UnityEngine.InputSystem;

public class RotateLens : MonoBehaviour
{
    #region Variables

    [SerializeField] private Collider2D _collider;

    private Camera _camera;
    private Vector3 _screenPosition;
    private float _angleOffset;

    private bool _isDragging;

    #endregion

    #region Functions

    private void Start()
    {
        _camera = Camera.main;
    }


    private void Update()
    {
        var mousePos = Mouse.current.position.ReadValue();
        var mousePosition = _camera.ScreenToWorldPoint(mousePos);

        if (_collider == Physics2D.OverlapPoint(mousePosition))
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                _isDragging = true;
                _screenPosition = _camera.WorldToScreenPoint(transform.position);
                var offset = mousePos - (Vector2)_screenPosition;
                _angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(offset.y, offset.x)) * Mathf.Rad2Deg;
            }
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
            _isDragging = false;

        if (_isDragging)
        {
            Vector3 offset = mousePos - (Vector2)_screenPosition;
            var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle + _angleOffset);
        }
    }

    #endregion
}
