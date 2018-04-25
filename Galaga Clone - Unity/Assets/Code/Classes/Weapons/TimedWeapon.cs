using UnityEngine;

namespace Assets.Code.Classes.Weapons
{
    abstract class TimedWeapon : Weapon
    {
        [Tooltip ("How long this timed weapon will last for before defaulting.")]
        [SerializeField] protected float _Length = 3.0f;

        protected float _LengthTimer = 0.0f;

        protected virtual void Awake ()
        {
            this.enabled = false;
        }

        protected override void Update ()
        {
            base.Update ();

            if (HasRunOut ())
                Disable ();
        }

        protected bool HasRunOut ()
        {
            _LengthTimer += Time.deltaTime;

            if (_LengthTimer > _Length)
                return true;

            return false;
        }

        /// <summary>Enable the weapon and set it up for use.</summary>
        public override void Enable ()
        {
            // Reset the timer so that we count from the start again, then activate.
            _LengthTimer -= _LengthTimer;
            this.enabled = true;
        }

        /// <summary>Disable the weapon as it's no longer being used.</summary>
        public override void Disable ()
        {
            // Inform the player to switch back to their default weapon and reset our timer, then de-activate.
            GetComponent<PlayerController> ().SwitchWeapon (Enums.WeaponType.Default);
            _LengthTimer -= _LengthTimer;
            this.enabled = false;
        }
    }
}
