using UnityEngine;

namespace StarCatcher.Game.PickUps
{
    public class ChangeScalePlatformPickUp : PickUp
    {
        #region Variables

        [SerializeField] private float _percentToChange = 10f;

        #endregion

        #region Protected methods

        protected override void PerformActions(GameObject otherColider) //?????
        {
            base.PerformActions(otherColider);
            FindObjectOfType<Platform>().ChangeScale(_percentToChange);
        }

        #endregion

        //private Ball _ball;
    }
}