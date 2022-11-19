using UnityEngine;
using Weapon;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "WeaponData")]
    public class WeaponData : ScriptableObject
    {
         public GameObject _bullet;
         public float _fireRate;
         public int Damage;
         public int FireForce;
         public bool IsMultiShot;
    }
}
