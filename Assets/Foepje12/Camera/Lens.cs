
namespace Foepje12.Camera
{    
    public class Lens : BaseBeamHandler
    {
        #region Variables

        private bool _beamIn;
        
        #endregion

        #region Functions


        protected void Update()
        {
            if (_beamIn)
            {
                FireBeam();
            }
        }


        public virtual void BeamIn()
        {
            beamLine.positionCount = 2;
            beamLine.SetPosition(0, transform.position);
            _beamIn = true;
        }


        public virtual void BeamOut()
        {
            _beamIn = false;
            beamLine.positionCount = 0;
        }

        #endregion
    }
}
