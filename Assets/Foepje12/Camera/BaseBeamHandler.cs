
using Foepje12.Camera.Lenses;
using UnityEngine;

namespace Foepje12.Camera
{
    [RequireComponent(typeof(LineRenderer))]
    public class BaseBeamHandler : MonoBehaviour
    {
        #region Variables

        protected LineRenderer beamLine;

        protected BaseLens _receivingLens;

        #endregion


        #region Functions

        protected void Start()
        {
            beamLine = GetComponent<LineRenderer>();
        }


        public void FireBeam()
        {
            var direction = GetBeamDirection();
            var mask = LayerMask.GetMask("Default");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 100, mask);

            if (hit)
            {
                beamLine.SetPosition(1, hit.point);

                if (hit.transform.TryGetComponent<BaseLens>(out var lens))
                {
                    if (_receivingLens != lens)
                    {
                        _receivingLens = lens;
                        _receivingLens.BeamIn(transform.position);
                    }

                }
                else if (_receivingLens != null)
                {
                    _receivingLens.BeamOut();
                    _receivingLens = null;
                }

                #endregion
            }
        }


        protected virtual Vector2 GetBeamDirection()
        {
            return transform.right;
        }
    }
}
