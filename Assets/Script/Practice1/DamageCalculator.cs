#region

using System;

#endregion

namespace Script.Practice1
{
    public class DamageCalculator
    {
    #region Public Methods

        public bool CalculateBlock(int blockRate , int rand)
        {
            return CalculateRandomResult(blockRate , rand);
        }

        public int CalculateCriticalDamage(int damage , int critRate , int rand)
        {
            if (damage < 0) throw new ArgumentException("Damage_Less_Than_0");
            if (critRate < 0) throw new ArgumentException("Crit_Less_Than_0");
            if (rand < 0) throw new ArgumentException("Rand_Less_Than_0");

            return CalculateRandomResult(critRate , rand) switch
            {
                // rand 等於0不暴擊
                // 沒有隨機到，不暴擊
                false => damage ,
                // 會暴擊
                true => (int)(damage * 1.5f)
            };
        }

        public bool CalculateDodge(int dodgeRate , int rand)
        {
            return CalculateRandomResult(dodgeRate , rand);
        }

    #endregion

    #region Private Methods

        private static bool CalculateRandomResult(int rate , int rand)
        {
            if (rand == 0) return false;
            return rand <= rate;
        }

    #endregion
    }
}