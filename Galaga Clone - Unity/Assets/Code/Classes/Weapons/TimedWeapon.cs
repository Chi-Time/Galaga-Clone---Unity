using UnityEngine;

namespace Assets.Code.Classes.Weapons
{
    abstract class TimedWeapon : Weapon
    {
        [Tooltip ("How long this timed weapon will last for before defaulting.")]
        [SerializeField] protected float _Length = 3.0f;

        protected float _LengthTimer = 0.0f;

        protected override void Update ()
        {
            base.Update ();

            if (HasRunOut ())
                RemoveWeapon ();
        }

        protected bool HasRunOut ()
        {
            _LengthTimer += Time.deltaTime;

            if (_LengthTimer > _Length)
                return true;

            return false;
        }

        protected void RemoveWeapon ()
        {
            GetComponentInParent<PlayerController> ().SwitchWeapon (Enums.WeaponType.Default);
            Destroy (this.gameObject);
        }
    }
}
