
using Foepje12.Camera.Lenses;
using UnityEngine;

namespace Foepje12.Camera
{
    public class BaseBeamHandler : MonoBehaviour
    {
        #region Variables

        [SerializeField] protected LineRenderer beamLine;

        protected BaseLens _receivingLens;

        #endregion

        #region Functions

        public RaycastHit2D FireBeam()
        {
            var direction = GetBeamDirection();
            var mask = LayerMask.GetMask("Default");
            return Physics2D.Raycast(transform.position, direction, 100, mask);
        }


        public void HandleBeam(RaycastHit2D hit)
        {
            if (hit == false)
                return;

            if (hit.transform.GetComponent<BaseLens>() == null && _receivingLens != null)
            {
                _receivingLens.BeamOut();
                _receivingLens = null;
            }
        }


        public void EmitBeam(RaycastHit2D hit)
        {
            var point = (Vector3)hit.point;
            point.z = .1f;

            beamLine.SetPosition(1, point);

            if (hit.transform.TryGetComponent(out BaseLens lens))
            {
                if (_receivingLens != lens && BeamPathHandler.AddHandler(lens))
                {
                    if (_receivingLens != null)
                        _receivingLens.BeamOut();

                    _receivingLens = lens;
                    _receivingLens.BeamIn(transform.position);
                }
            }
        }


        protected virtual Vector2 GetBeamDirection()
        {
            return transform.right;
        }


        private void OnDrawGizmos()
        {
            var hit = FireBeam();

            var lens = hit.transform.GetComponent<BaseLens>();

            Gizmos.color = lens == null ? Color.red : Color.green;
            Gizmos.DrawLine(transform.position, hit.point);
        }

        #endregion
    }
}
