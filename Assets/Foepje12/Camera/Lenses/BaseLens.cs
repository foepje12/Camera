using UnityEngine;

namespace Foepje12.Camera.Lenses
{
    public class BaseLens : BaseBeamHandler
    {
        #region Variables

        protected Vector2 beamOrigin;
        protected float Angle;
                
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


        public virtual void BeamIn(Vector2 _beamOrigin)
        {
            beamOrigin = _beamOrigin;

            beamLine.positionCount = 2;
            beamLine.SetPosition(0, transform.position);
            _beamIn = true;
        }


        public virtual void BeamOut()
        {
            _beamIn = false;
            beamLine.positionCount = 0;
            BeamPathHandler.RemoveHandler(this);

            if(_receivingLens != null)
                _receivingLens.BeamOut();
        }


        #endregion
    }
}
