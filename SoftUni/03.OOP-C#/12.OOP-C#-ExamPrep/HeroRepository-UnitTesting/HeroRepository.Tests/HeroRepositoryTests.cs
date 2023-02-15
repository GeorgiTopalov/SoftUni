using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]

    public void TestHeroClass_Constructor()
    {
        Hero hero = new Hero("Gosho", 20);

        Assert.AreEqual("Gosho", hero.Name);
        Assert.AreEqual(20, hero.Level);
    }

    [Test]

    public void TestHeroRepository_ShouldInitializeCollection()
    {
        HeroRepository heroRepository = new HeroRepository();

        Assert.AreEqual(0, heroRepository.Heroes.Count);
    }

    [Test]

    public void TestCreateMethod()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Gosho", 20);

        string expectedMessage = $"Successfully added hero {hero.Name} with level {hero.Level}";
        Assert.AreEqual(expectedMessage, heroRepository.Create(hero));
        Assert.AreEqual(1, heroRepository.Heroes.Count);
    }

    [Test]

    public void TestCreateMethod_Exceptions()
    {
        HeroRepository heroRepository = new HeroRepository();
        
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Create(null);
        });

        Hero heroTwo = new Hero("Gosho", 19);
        Hero heroThree = new Hero("Gosho", 22);

        heroRepository.Create(heroTwo);

        Assert.Throws<InvalidOperationException>(() =>
        {
            heroRepository.Create(heroThree);
        });
    }

    [Test]

    public void TestRemoveMethod()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Gosho", 19);
        Hero heroTwo = new Hero("Pesho", 22);

        heroRepository.Create(hero);
        heroRepository.Create(heroTwo);

        Assert.IsTrue(heroRepository.Remove(hero.Name));
        Assert.AreEqual(1, heroRepository.Heroes.Count);
    }

    [TestCase(null)]
    [TestCase(" ")]
    [TestCase("")] 

    public void TestRemoveMethod_Exceptions(string name)
    {
        HeroRepository heroRepository = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Remove(name);
        });
    }

    [Test]
    public void TestGetHeroWithHighestLevel_Method()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Gosho", 19);
        Hero heroTwo = new Hero("Pesho", 22);
        Hero heroThree = new Hero("Ivan", 24);

        heroRepository.Create(hero);
        heroRepository.Create(heroTwo);
        heroRepository.Create(heroThree);

        Assert.AreEqual(heroThree, heroRepository.GetHeroWithHighestLevel());

        heroRepository.Remove(heroThree.Name);

        Assert.AreEqual(heroTwo, heroRepository.GetHeroWithHighestLevel());

    }

    [Test]

    public void TestGetHero_Method()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Gosho", 19);
        Hero heroTwo = new Hero("Pesho", 22);

        heroRepository.Create(hero);
        heroRepository.Create(heroTwo);

        Assert.AreEqual(hero, heroRepository.GetHero("Gosho"));

        Assert.AreEqual(heroTwo, heroRepository.GetHero("Pesho"));
    }
}