using StarCatcher.Game.Services;
using UnityEngine;

namespace StarCatcher.Game.PickUps
{
    public class ChangeHpPickUp: PickUp
    {
        #region Variables

        [SerializeField] private int _hpToChange = 1;

        #endregion

        #region Protected methods

        protected override void PerformActions(GameObject otherColider)
        {
            base.PerformActions(otherColider);
            GameService.Instance.ChangeHP(_hpToChange);
        }

        #endregion
    }
}
 