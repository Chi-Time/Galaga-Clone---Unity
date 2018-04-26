using UnityEngine;

namespace Assets.Code.Classes.Enemies
{
    class Terran : Jelly
    {
        protected Weapons.Weapon _CurrentWeapon = null;

        protected override void AssignReferences ()
        {
            base.AssignReferences ();

            ChooseWeapon ();
        }

        protected void ChooseWeapon ()
        {
            int numberOfWeaponTypes = System.Enum.GetValues (typeof (Enums.EnemyWeaponType)).Length;
            var weaponType = (Enums.EnemyWeaponType)Random.Range (0, numberOfWeaponTypes);

            switch (weaponType)
            {
                case Enums.EnemyWeaponType.TripleShot:
                    _CurrentWeapon = GetComponent<Weapons.EnemyTripleShotWeapon> ();
                    break;
                case Enums.EnemyWeaponType.HelixShot:
                    _CurrentWeapon = GetComponent<Weapons.EnemyHelixShotWeapon> ();
                    break;
                case Enums.EnemyWeaponType.ScatterShot:
                    _CurrentWeapon = GetComponent<Weapons.EnemyScatterShotWeapon> ();
                    break;
            }
        }

        protected override void FixedUpdate ()
        {
            base.FixedUpdate ();

            if (_CurrentWeapon != null)
                _CurrentWeapon.Fire ();
        }
    }
}
