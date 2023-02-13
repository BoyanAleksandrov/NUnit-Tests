using NUnit.Framework;
 
namespace Tests
{
    using P04_FightingArena;
    using System;
    using System.Collections.Generic;
 
    public class ArenaTests
    {
        private Warrior Ahil;
        private Warrior Hektor;
 
        [SetUp]
        public void Setup()
        {
            Ahil = new Warrior("Ahil", 25, 35);
            Hektor = new Warrior("Hektor", 20, 60);
        }
 
        [Test]
        public void Arena_Constr()
        {
            Arena arena = new Arena();
            var list = new List<Warrior>();
            CollectionAssert.AreEqual(list, arena.Warriors);
        }
 
        [Test]
        public void Arena_Enroll_InvalidOperationException_WarriorAlreadyEnrolled()
        {
            Arena arena = new Arena();
            arena.Enroll(Ahil);
            Assert.Throws<InvalidOperationException>
                (() => arena.Enroll(Ahil));
        }
 
        [Test]
        public void Arena_Enroll_CorrectList()
        {
            Arena arena = new Arena();
            arena.Enroll(Ahil);
            arena.Enroll(Hektor);
 
            var expected = new List<Warrior> { Ahil, Hektor };
 
            CollectionAssert.AreEqual(expected, arena.Warriors);
        }
 
        [Test]
        public void Arena_Enroll_CorrectList_Count()
        {
            Arena arena = new Arena();
            arena.Enroll(Ahil);
            arena.Enroll(Hektor);
 
            var expected = new List<Warrior> { Ahil, Hektor }.Count;
            var actual = arena.Count;
            Assert.AreEqual(expected, actual);
        }
 
        [Test]
        public void Arena_Fight_InvalidOperationException_DefenderNotEnrolled()
        {
            Arena arena = new Arena();
            arena.Enroll(Ahil);
            Assert.Throws<InvalidOperationException>
                (() => arena.Fight("Gosho", "Pesho"));
        }
 
        [Test]
        public void Arena_Fight_InvalidOperationException_AttackerNotEnrolled()
        {
            Arena arena = new Arena();
            arena.Enroll(Hektor);
            Assert.Throws<InvalidOperationException>
                (() => arena.Fight("Gosho", "Pesho"));
        }
 
        [Test]
        public void Fight_Correctly()
        {
            Arena arena = new Arena();
            arena.Enroll(Ahil);
            arena.Enroll(Hektor);
 
            arena.Fight("Gosho", "Pesho");
 
            var expectedPeshoHp = 35;
            var actual = Hektor.HP;
            Assert.AreEqual(expectedPeshoHp, actual);
        }
    }
}