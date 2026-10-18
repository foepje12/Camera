using Foepje12.Camera.Lenses;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Foepje12.Camera
{
    public class BeamReceiver : BaseLens
    {
        #region Variables

        [SerializeField] private Animator _levelAnimator;

        private float _counter;
        private List<FocalPoint> _focalPoints = new();
        private bool _finishedLevel;

        #endregion

        #region Functions

        private void Start()
        {
            var objects = GameObject.FindGameObjectsWithTag("Focal Point");
            _focalPoints.AddRange(objects.Select(obj => obj.GetComponent<FocalPoint>()));
        }


        protected new void Update()
        {
            if (ReceivesBeam == false || _finishedLevel)
                return;
                        
            // Check if all Focal Points are hit
            var hit = _focalPoints.Where(x => x.ReceivesBeam == false);

            if (hit.Any())
            {
                _counter = 0;
                return;
            }            

            _counter += Time.deltaTime;

            if (_counter > 3)
            {
                _finishedLevel = true;
                _levelAnimator.SetTrigger("Level Finish");
            }
        }


        public override void BeamIn(Vector2 beamOrigin)
        {
            ReceivesBeam = true;
        }


        public override void BeamOut()
        {
            ReceivesBeam = false;
            _counter = 0;
            BeamPathHandler.RemoveHandler(this);
        }

        #endregion
    }
}
