using UnityEngine;

namespace Foepje12.Camera.Lenses
{
    public class FocalPoint : BaseLens
    {
        #region Variables



        #endregion

        #region Functions

        protected override Vector2 GetBeamDirection()
        {
            return -(beamOrigin - (Vector2)transform.position);
        }

        #endregion
    }
}