using UnityEngine;

namespace Assets.Code.Classes.Weapons
{
    abstract class TimedWeapon : Weapon
    {
        [Tooltip ("How long this timed weapon will last for before defaulting.")]
        [SerializeField] protected float _Length = 3.0f;

        protected float _LengthTimer = 0.0f;

        protected override void Awake ()
        {
            base.Awake ();
            this.enabled = false;
        }

        protected override void Update ()
        {
            base.Update ();

            if (HasRunOut ())
                GetComponent<PlayerController> ().SwitchWeapon (Enums.WeaponType.Default);
        }

        protected bool HasRunOut ()
        {
            _LengthTimer += Time.deltaTime;

            if (_LengthTimer > _Length)
                return true;

            return false;
        }

        /// <summary>Disable the weapon as it's no longer being used.</summary>
        public override void Disable ()
        {
            base.Disable ();

            // Inform the player to switch back to their default weapon and reset our timer, then de-activate.
            _LengthTimer -= _LengthTimer;
        }
    }
}
