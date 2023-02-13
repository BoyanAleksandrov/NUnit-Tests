using NUnit.Framework;
 using P04_FightingArena;
 
namespace Tests
{
    
    using System;
 
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }
 
       
 
        [Test]
        public void Warrior_Constructor()
        {
            Warrior warrior = new Warrior("Ahil", 25, 50);
            var expectedName = "Ahil";
            var expectedDmg = 25;
            var expectedHp = 50;
            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDmg, warrior.Damage);
            Assert.AreEqual(expectedHp, warrior.HP);
        }
 
        [Test]
        [TestCase(null)]
        public void WarriorTest_ArguemtException_NameNullEmptyOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>
                (() => new Warrior(name, 6, 6));
        }
 
        [Test]
        [TestCase(-1)]  
        [TestCase(0)]
        [TestCase(-11)]
        [TestCase(-22)]
        public void WarriorTest_ArguemtException_DamageZeroOrNegative(int damage)
        {
            Assert.Throws<ArgumentException>
                (() => new Warrior("Bai Ivan", damage, 6));
        }
 
        [Test]
        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-11)]
        [TestCase(-22)]
        public void WarriorTest_ArguemtException_HpNegative(int hp)
        {
            Assert.Throws<ArgumentException>
                (() => new Warrior("Ahil", 11, hp));
        }
 
        [Test]
        [TestCase(28)]
        [TestCase(29)]
        [TestCase(20)]
        [TestCase(10)]
        [TestCase(30)]
        public void WarriorTest_ArguemtException_WarriorCantAttackWithLessThan30Hp(int hp)
        {
            Warrior attacker = new Warrior("Ahil", 10, hp);
            Warrior defender = new Warrior("Hektor", 10, 40);
 
            Assert.Throws<InvalidOperationException>
                (() => attacker.Attack(defender));
 
            Assert.Throws<InvalidOperationException>
                (() => attacker.Attack(defender));
        }
 
        [Test]
        [TestCase(28)]
        [TestCase(29)]
        [TestCase(20)]
        [TestCase(10)]
        [TestCase(30)]
        public void WarriorTest_ArguemtException_WarriorCantBeAttackedWhenLessThan30Hp(int hp)
        {
            Warrior attacker = new Warrior("Ahil", 10, 40);
            Warrior defender = new Warrior("Hektor", 10, hp);
 
            Assert.Throws<InvalidOperationException>
                (() => attacker.Attack(defender));
        }
 
        [Test]
        [TestCase(58)]
        [TestCase(59)]
        [TestCase(50)]
        [TestCase(41)]
        public void WarriorTest_ArguemtException_AtackingStrongerOpponent(int dmg)
        {
            Warrior attacker = new Warrior("Ahil", 10, 40);
            Warrior defender = new Warrior("Hektor", dmg, 40);
 
            Assert.Throws<InvalidOperationException>
                (() => attacker.Attack(defender));
        }
 
        [Test]
        [TestCase(22, 40)]
        [TestCase(49, 40)]
        [TestCase(50, 40)]
        public void WarriorTest_Atacks_Correctly(int dmg, int hp)
        {
            Warrior attacker = new Warrior("Ahil", dmg, hp);
            Warrior defender = new Warrior("Hektor", 20, 50);
 
            attacker.Attack(defender);
 
            int expected = 50 - dmg;
            int actual = defender.HP;
 
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        [TestCase(51, 40)]
        [TestCase(52, 40)]
        [TestCase(120, 40)]
        public void WarriorTest_Atacks_Correctly_WithMoreDamage(int dmg, int hp)
        {
            Warrior attacker = new Warrior("Ahil", dmg, hp);
            Warrior defender = new Warrior("Hektor", 20, 50);
 
            attacker.Attack(defender);
 
            int expected = 0;
            int actual = defender.HP;
 
            Assert.AreEqual(expected, actual);
        }
    }
}