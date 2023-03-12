#region

using System;

#endregion

namespace Script.Practice1
{
    public class DamageCalculator
    {
    #region Public Methods

        public int CalculateCriticalDamage(int damage , int critRate , int rand)
        {
            if (damage < 0) throw new ArgumentException("Damage_Less_Than_0");
            if (critRate < 0) throw new ArgumentException("Crit_Less_Than_0");
            if (rand < 0) throw new ArgumentException("Rand_Less_Than_0");

            // rand 等於0不暴擊
            if (rand == 0) return damage;
            // 會暴擊
            if (rand <= critRate) return (int)(damage * 1.5f);
            // 沒有隨機到，不暴擊
            return damage;
        }

        public bool CalculateDodge(int dodgeRate , int rand)
        {
            if (rand == 0) return false;
            return rand <= dodgeRate;
        }

    #endregion
    }
}