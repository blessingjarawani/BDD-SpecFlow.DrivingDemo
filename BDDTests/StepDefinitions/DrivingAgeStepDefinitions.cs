using SpecFlow.DrivingDemo;
using System;
using TechTalk.SpecFlow;

namespace BDDTests.StepDefinitions
{
    [Binding]
    public class DrivingAgeStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IDrivingRegulations _driverRegulations;

        public DrivingAgeStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driverRegulations = new DrivingRegulations();
        }

        [Given(@"Driver is (\d+) years old")]
        public void GivenDriverIsYearsOld(int age)
        {
            _scenarioContext["Person"] = new Person { FirstName = "", Age = age };
        }

        [When(@"They live in (.*)")]
        public void WhenTheyLiveInSwitzerland(string countryName)
        {
            var country = Enum.Parse<Country>(countryName);
            var person = (Person)_scenarioContext["Person"];
            _scenarioContext["Result"] = _driverRegulations.IsAllowedToDrive(person, country);
        }

        [Then(@"They are permitted to drive")]
        public void ThenTheyArePermittedToDrive()
        {
            var result = (bool)_scenarioContext["Result"];
            Assert.IsTrue(result);
        }

        [Then(@"They are not permitted to drive")]
        public void ThenTheyAreNotPermittedToDrive()
        {
            var result = (bool)_scenarioContext["Result"];
            Assert.IsFalse(result);
        }
    }
}
