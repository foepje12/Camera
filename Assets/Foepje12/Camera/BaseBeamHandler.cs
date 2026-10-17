
using UnityEngine;

namespace Foepje12.Camera
{
    [RequireComponent(typeof(LineRenderer))]
    public class BaseBeamHandler : MonoBehaviour
    {
        #region Variables

        protected LineRenderer beamLine;
        protected Lens currentLens;


        #endregion


        #region Functions

        protected void Start()
        {
            beamLine = GetComponent<LineRenderer>();
        }


        public void FireBeam()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);

            if (hit)
            {
                beamLine.SetPosition(1, hit.point);

                if (hit.transform.TryGetComponent<Lens>(out var lens))
                {
                    if (currentLens != lens)
                    {
                        currentLens = lens;
                        currentLens.BeamIn();
                    }

                }
                else if (currentLens != null)
                {
                    currentLens.BeamOut();
                    currentLens = null;
                }

                #endregion
            }
        }
    }
}
