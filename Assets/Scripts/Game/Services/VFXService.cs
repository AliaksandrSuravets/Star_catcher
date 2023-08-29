using StarCatcher.Utility;
using UnityEngine;

namespace StarCatcher.Game.Services
{
    public class VFXService : SingletonMonoBehaviour<VFXService>
    {
        #region Public methods

        public void InstantiateVFX(GameObject vfx, Vector3 positionForCreat)
        {
            if (vfx == null)
            {
                return;
            }

            Instantiate(vfx, positionForCreat, Quaternion.identity);
        }

        #endregion
    }
}