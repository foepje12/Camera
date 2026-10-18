using UnityEngine;

namespace Foepje12.Camera.Lenses
{
    public class BaseLens : BaseBeamHandler
    {
        #region Variables

        public bool ReceivesBeam { get; protected set; }

        protected Vector2 beamOrigin;
        protected float Angle;        

        #endregion

        #region Functions


        protected void Update()
        {
            var hit = FireBeam();

            HandleBeam(hit);

            if (ReceivesBeam)
                EmitBeam(hit);
        }


        public virtual void BeamIn(Vector2 _beamOrigin)
        {
            beamOrigin = _beamOrigin;

            beamLine.positionCount = 2;
            beamLine.SetPosition(0, transform.position);
            ReceivesBeam = true;
        }


        public virtual void BeamOut()
        {
            ReceivesBeam = false;
            beamLine.positionCount = 0;
            BeamPathHandler.RemoveHandler(this);


            if (_receivingLens != null)
            {
                _receivingLens.BeamOut();
                _receivingLens = null;
            }
        }
        #endregion
    }
}
