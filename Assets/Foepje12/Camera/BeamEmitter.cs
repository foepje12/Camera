using Foepje12.Camera;

public class BeamEmitter : BaseBeamHandler
{
    #region Variables


    #endregion

    #region Functions

    private void Start()
    {
        beamLine.positionCount = 2;
        beamLine.SetPosition(0, transform.position);
        beamLine.SetPosition(1, transform.position);
    }

    private void Update()
    {
        var hit = FireBeam();

        if (hit == false)
            return;

        HandleBeam(hit);
        EmitBeam(hit);
    }

    #endregion
}
