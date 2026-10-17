using Foepje12.Camera.Lenses;
using UnityEngine;

namespace Foepje12.Camera
{
    public class Lens : BaseLens
    {
        #region Functions

        protected override Vector2 GetBeamDirection()
        {
            //Angle = Vector3.Angle(_beamOrigin, transform.right);
            //Angle = Vector3.SignedAngle(beamOrigin - (Vector2)transform.position, transform.up, transform.forward);
            //return Quaternion.AngleAxis((Angle + 180) / Angle, transform.up) * transform.forward;

            return -Vector2.Reflect(beamOrigin - (Vector2)transform.position, transform.up);
        }

        #endregion
    }
}
