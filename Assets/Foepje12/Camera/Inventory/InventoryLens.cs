using Foepje12.Camera.Lenses;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryLens : MonoBehaviour
{
    #region Variables

    [SerializeField] private List<GameObject> LensImages;
    [SerializeField] private List<GameObject> _lensTypes;

    private GameObject _draggingLens;
    private int _draggingLensIndex = -1;

    private Camera _camera;
    private Vector2 _mousePosition = Vector2.zero;

    #endregion

    #region Functions

    private void Start()
    {
        _camera = Camera.main;
    }


    private void Update()
    {
        _mousePosition = Mouse.current.position.ReadValue();

        if (_draggingLens != null)
        {
            var position = _camera.ScreenToWorldPoint(_mousePosition);
            position.z = 0;
            _draggingLens.transform.position = position;

            if (Mouse.current.rightButton.wasReleasedThisFrame)
                DestroyDraggingLens();

            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                var collider = Physics2D.OverlapPoint(_camera.ScreenToWorldPoint(_mousePosition));

                if (collider != null && collider.TryGetComponent(out LensSlot slot))
                {
                    var success = slot.AddLens(_lensTypes[_draggingLensIndex]);

                    if (success)                    
                        DestroyDraggingLens();                    
                }
            }
        }

        // Destroy Lens on Right Click
        if (Mouse.current.rightButton.wasReleasedThisFrame)
        {
            var collider = Physics2D.OverlapPoint(_camera.ScreenToWorldPoint(_mousePosition));
            if (collider != null && collider.TryGetComponent(out BaseLens lens))
            {
                // Focal Points can not be destroyed
                if (lens.GetType() == typeof(FocalPoint))
                    return;

                lens.BeamOut();
                Destroy(lens.gameObject);
            }
        }
    }


    public void ClickLens(int index)
    {
        DestroyDraggingLens();

        _draggingLensIndex = index;
        var position = _camera.ScreenToWorldPoint(_mousePosition);
        position.z = 0;
        _draggingLens = Instantiate(LensImages[index], position, Quaternion.identity);
    }


    private void DestroyDraggingLens()
    {
        if (_draggingLens != null)
            Destroy(_draggingLens);

        _draggingLens = null;
        _draggingLensIndex = -1;
    }

    #endregion
}
