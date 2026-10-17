using UnityEngine;

namespace Foepje12.Camera.Lenses
{
    public class LensSlot : MonoBehaviour
    {
        #region Variables

        
        private GameObject _holdingLens;

        #endregion

        #region Functions

        public bool AddLens(GameObject lensPrefab)
        {
            if (_holdingLens != null)
                return false;

            _holdingLens = Instantiate(lensPrefab, transform.position, Quaternion.identity);
            return true;
        }


        public void RemoveLens()
        {
            if (_holdingLens != null)
                Destroy(_holdingLens);
            _holdingLens = null;
        }              

        #endregion
    }
}
