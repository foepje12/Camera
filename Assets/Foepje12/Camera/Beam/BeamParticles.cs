using UnityEngine;

public class BeamParticles : MonoBehaviour
{
    #region Variables

    private LineRenderer _lineRenderer;
    private Transform _transform;
    private ParticleSystem _particleSystem;

    #endregion

    #region Functions

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _particleSystem = GetComponent<ParticleSystem>();
        _transform = transform;
    }

    private void Update()
    {
        /*
        if (_lineRenderer == null)
            return;

        if (_lineRenderer.positionCount != 2)
            return;

        var pos1 = _lineRenderer.GetPosition(0);
        var pos2 = _lineRenderer.GetPosition(1);

        _transform.position = (pos1 - pos2) / 2;

        var distance = Vector2.Distance(pos1, pos2);

        var shape = _particleSystem.shape;
        shape.radius = distance / 2;
        */
    }

    #endregion
}
