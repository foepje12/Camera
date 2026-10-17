using Foepje12.Camera.Lenses;
using UnityEngine;

namespace Foepje12.Camera
{
    public class Mirror : BaseLens
    {
        #region Variables


        #endregion

        #region Functions

        protected override Vector2 GetBeamDirection() =>
             Vector2.Reflect(beamOrigin - (Vector2)transform.position, transform.up);
        

        #endregion
    }
}
