using System.Collections.Generic;

namespace Foepje12.Camera
{
    public static class BeamPathHandler
    {
        #region Variables

        private static List<BaseBeamHandler> handlers = new();

        #endregion

        #region Functions

        public static bool AddHandler(BaseBeamHandler handler)
        {
            if (handlers.Contains(handler))
                return false;

            handlers.Add(handler);
            return true;
        }


        public static bool RemoveHandler(BaseBeamHandler handler)
        {
            if (handlers.Contains(handler))
            {
                handlers.Remove(handler);
                return true;
            }

            return false;
        }

        #endregion
    }
}
