using UnityEngine;

namespace Foepje12.Camera
{
    public class BeamReceiver : Lens
    {
        #region Variables



        #endregion

        #region Functions

        protected new void Update()
        {
            
        }


        public override void BeamIn()
        {
            Debug.Log("Level Finished!");
        }

        #endregion
    }
}
