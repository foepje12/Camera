using System.Collections.Generic;

namespace Foepje12.Camera
{
    /// <summary>
    /// A simple static list to avoid infinite loops
    /// </summary>
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


        public static void ClearList() =>
            handlers.Clear();

        #endregion
    }
}
