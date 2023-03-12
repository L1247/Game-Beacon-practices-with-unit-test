#region

using System;
using NUnit.Framework;
using Script.Practice1;

#endregion

public class DamageCalculatorTests
{
#region Test Methods

    [Test(Description = "計算暴擊傷害")]
    [Category("CalculateCriticalDamage")]
    [TestCase(10 , 150 , Description = "計算暴擊傷害_觸發暴擊_正常範圍")]
    [TestCase(15 , 150 , Description = "計算暴擊傷害_觸發暴擊_上限")]
    [TestCase(0 , 100 , Description = "計算暴擊傷害_沒觸發暴擊_下限")]
    [TestCase(16 , 100 , Description = "計算暴擊傷害_沒觸發暴擊")]
    public void _01_CalculateCriticalDamage(int rand , int expectedCalculatedDamage)
    {
        // arrange
        var damage           = 100;
        var critRate         = 15;
        var damageCalculator = new DamageCalculator();
        // act
        var calculatedDamage = damageCalculator.CalculateCriticalDamage(damage , critRate , rand);
        // assert
        Assert.AreEqual(expectedCalculatedDamage , calculatedDamage);
    }

    [Test(Description = "計算暴擊傷害_參數錯誤")]
    [Category("CalculateCriticalDamage")]
    [TestCase(-1 , 15 , 10 , "Damage_Less_Than_0" , Description = "攻擊力小於0")]
    [TestCase(15 , -1 , 10 , "Crit_Less_Than_0" , Description = "暴擊率小於0")]
    [TestCase(15 , 10 , -1 , "Rand_Less_Than_0" , Description = "隨機值小於0")]
    public void _02_CalculateCriticalDamage_Error_Cases(int damage , int critRate , int rand , string expectedErrorMessage)
    {
        // arrange
        var damageCalculator = new DamageCalculator();
        // act
        var argumentException =
                Assert.Throws<ArgumentException>(() => damageCalculator.CalculateCriticalDamage(damage , critRate , rand));
        // assert
        Assert.AreEqual(expectedErrorMessage , argumentException.Message);
    }

    [Test(Description = "計算迴避")]
    [Category("CalculateDodge")]
    [TestCase(10 , true , Description = "計算迴避_觸發迴避_正常範圍")]
    [TestCase(15 , true , Description = "計算迴避_觸發迴避_上限")]
    [TestCase(1 , true , Description = "計算迴避_觸發迴避_下限")]
    [TestCase(0 , false , Description = "計算迴避_沒觸發迴避_下限之外")]
    [TestCase(16 , false , Description = "計算迴避_沒觸發迴避")]
    public void _03_CalculateDodge(int rand , bool expectedDodge)
    {
        // arrange
        var damageCalculator = new DamageCalculator();
        var doggeRate        = 15;
        // act
        var dodgeResult = damageCalculator.CalculateDodge(doggeRate , rand);
        // assert
        Assert.AreEqual(expectedDodge , dodgeResult);
    }

    [Test(Description = "計算隔檔")]
    [Category("CalculateBlock")]
    [TestCase(10 , true , Description = "計算k62;3_觸發隔檔_正常範圍")]
    [TestCase(15 , true , Description = "計算隔檔_觸發隔檔_上限")]
    [TestCase(1 , true , Description = "計算隔檔_觸發隔檔_下限")]
    [TestCase(0 , false , Description = "計算隔檔_沒觸發隔檔_下限之外")]
    [TestCase(16 , false , Description = "計算隔檔_沒觸發迴避")]
    public void _04_CalculateBlock(int rand , bool expectedBlock)
    {
        // arrange
        var damageCalculator = new DamageCalculator();
        var blockRate        = 15;
        // act
        var blockResult = damageCalculator.CalculateBlock(blockRate , rand);
        // assert
        Assert.AreEqual(expectedBlock , blockResult);
    }

#endregion
}