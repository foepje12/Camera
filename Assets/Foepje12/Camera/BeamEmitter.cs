using Foepje12.Camera;

public class BeamEmitter : BaseBeamHandler
{
    #region Variables


    #endregion

    #region Functions

    new void Start()
    {
        base.Start();

        beamLine.positionCount = 2;
        beamLine.SetPosition(0, transform.position);
        beamLine.SetPosition(1, transform.position);
    }

    private void Update()
    {
        FireBeam();
    }

    #endregion
}
