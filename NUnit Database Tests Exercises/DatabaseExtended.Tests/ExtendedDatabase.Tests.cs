namespace Tests
{
    using NUnit.Framework; 
    using System;
    
    [TestFixture]
    public class DatabaseExtendedTests
    {
        private const int DatabaseCapacity = 16;
        private ExtendedDatabase DatabaseExtended;
        private Person[] people;

        [SetUp]
        public void Setup()
        {
            this.DatabaseExtended = new ExtendedDatabase();
            people = new Person[]
            {
                new Person(20214141421, "qwerty"),
                new Person(21412412412, "xyz"),
                new Person(22646567658, "rng"),
                new Person(23141252366, "yeet"),
                new Person(24634634634, "l337"),
                new Person(25234234234, "memeDominator"),
                new Person(26546457777, "arrayExcavator"),
                new Person(27867999567, "Ivan_The_Destroyer"),
                new Person(28375478842, "OnModelDegrading"),
                new Person(29539859900, "BugFirstDevelopment"),
                new Person(30236534765, "asdf4"),
                new Person(31131245555, "Nero_The_Firefighter"),
                new Person(32004280552, "TransperentBoardMarker"),
                new Person(33087057979, "DelusionalMind"),
                new Person(34698759251, "Dr.Marcus"),
                new Person(35000583882, "Lazko_Lazkov"),
            };
        }

     
        [Test]
        public void ConstructorShouldInitializeDatabaseWithExactly16People()
        {
             
            this.DatabaseExtended = new ExtendedDatabase(this.people);

             

             
            Assert.AreEqual(DatabaseCapacity, this.DatabaseExtended.Count);
        }

        [Test]
        public void ConstructorShouldInitializeDatabasePeopleCorrectly()
        {
             
            this.DatabaseExtended = new ExtendedDatabase(this.people);

             

             
            for (int i = 0; i < this.DatabaseExtended.Count; i++)
            {
                Person person = this.DatabaseExtended.FindById(this.people[i].Id);
                long id = person.Id;

                Assert.AreEqual(this.people[i].Id, id);
            }
        }

        [Test]
        public void ConstructorShouldThrowArgumentExceptionWhenPassedMoreThan16People()
        {
             
            Person[] people = new Person[17];
            this.people.CopyTo(people, 0);
            people[16] = new Person(36065884445, "JustIvan");

             

             
            Assert.That(() => this.DatabaseExtended = new ExtendedDatabase(people), Throws.ArgumentException
                                                                                          .With.Message
                                                                                          .EqualTo("Provided data length should be in range [0..16]!"));
        }

        
        [Test]
        public void AddOperationExceeding16ElementsShouldThrowInvalidOperationException()
        {
             
            this.DatabaseExtended = new ExtendedDatabase(this.people);

             

             
            Assert.That(() => this.DatabaseExtended.Add(new Person(35000583882, "Shifty")), Throws.InvalidOperationException
                                                                                                  .With.Message 
                                                                                                  .EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddOperationShouldThrowInvalidOperationExceptionInAttemptToAddAlreadyExistingUsername()
        {
             
            this.DatabaseExtended.Add(new Person(35000583882, "Lazko_Lazkov"));

             

             
            Assert.That(() => this.DatabaseExtended.Add(new Person(00141241241, "Lazko_Lazkov")), Throws.InvalidOperationException
                                                                                                        .With.Message
                                                                                                        .EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddOperationShouldThrowInvalidOperationExceptionInAttemptToAddAlreadyExistingUserWithSameId()
        {
             
            this.DatabaseExtended.Add(new Person(35000583882, "Lazko_Lazkov"));

             

             
            Assert.That(() => this.DatabaseExtended.Add(new Person(35000583882, "Shifty")), Throws.InvalidOperationException
                                                                                                  .With.Message
                                                                                                  .EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void RemoveOperationShouldThrowInvalidOperationException()
        {
             
            this.DatabaseExtended = new ExtendedDatabase();

             

             
            Assert.Throws<InvalidOperationException>(() => this.DatabaseExtended.Remove());
        }

        [Test]
        public void RemoveOperationShouldRemoveElementAtLastIndex()
        {
             
            this.DatabaseExtended = new ExtendedDatabase(new Person(35000583882, "Lazko_Lazkov"));

             
            this.DatabaseExtended.Remove();

             
            Assert.AreEqual(0, this.DatabaseExtended.Count, "The collection is empty!");
        }

        [Test]
        public void FindByUsernameOperationShouldReturnMatchingUsername()
        {
             
            this.DatabaseExtended = new ExtendedDatabase(this.people);

             
            Person lazko = people[15];
            Person expected = this.DatabaseExtended.FindByUsername("Lazko_Lazkov");

             
            Assert.AreEqual(lazko.UserName, expected.UserName);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsernameOperationShouldThrowArgumentNullExceptionWhenPassingNullOrEmptyValue(string name)
        {
             

             

           

            Assert.That(() => this.DatabaseExtended.FindByUsername(name), Throws.Exception
                                                                                .TypeOf<ArgumentNullException>()
                                                                                .With.Property("ParamName")
                                                                                .EqualTo("Username parameter is null!"));
        }

        [Test]
        [TestCase("Lazko_Lazkov")]
        [TestCase("Unexisting_username")]
        public void FindByUsernameOperationShouldThrowInvalidOperationExceptionInAttemptToFindUserWithNoSuchUsername(string name)
        {
             

             

             
            Assert.That(() => this.DatabaseExtended.FindByUsername(name), Throws.InvalidOperationException
                                                                                .With.Message
                                                                                .EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindByIdOperationShouldReturnMatchingUserWithGivenId()
        {
             
            this.DatabaseExtended = new ExtendedDatabase(this.people);

             
            Person lazko = people[15];
            Person expected = this.DatabaseExtended.FindById(35000583882);

             
            Assert.AreEqual(lazko.Id, expected.Id);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(long.MinValue)]
        public void FindByIdOperationShouldThrowArgumentOutOfRangeExceptionWhenPassingNegativeId(long id)
        {
             

             

             
            Assert.That(() => this.DatabaseExtended.FindById(id), Throws.Exception
                                                                        .TypeOf<ArgumentOutOfRangeException>()
                                                                        .With.Property("ParamName")
                                                                        .EqualTo("Id should be a positive number!"));
        }

        [Test]
        [TestCase(666)]
        [TestCase(long.MaxValue)]
        public void FindByIdOperationShouldThrowInvalidOperationExceptionInAttemptToFindUserWithNoSuchId(long id)
        {
             

             

             
            Assert.That(() => this.DatabaseExtended.FindById(id), Throws.InvalidOperationException
                                                                        .With.Message
                                                                        .EqualTo("No user is present by this ID!"));
        }
    }
}