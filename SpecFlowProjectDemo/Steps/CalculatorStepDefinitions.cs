using TechTalk.SpecFlow;
using System;
using UIDeskAutomationLib;
using System.Diagnostics;
using System.Threading;
using NUnit;
using NUnit.Framework;

namespace DesktopUIautomationCsharp.Steps
{
        [Binding]
    public sealed class CalculatorStepDefinitions
    {

        public static void InitializeTest()
        {

            Engine engine = new Engine();
            engine.LogFile = "C:\\Users\\klamnlo\\Downloads\\Draft23\\log.txt";

            int procId = engine.StartProcess("C:\\Windows\\System32\\calc.exe");
            UIDA_Window window = engine.GetTopLevel("Calculator");

            UIDA_Button OpenNavigation = window.Button("Open Navigation", true);
            OpenNavigation.Press();
            Thread.Sleep(2000);

            UIDA_ListItem ProgrammerCalculator = window.ListItem("Standard Calculator", true);
            ProgrammerCalculator.Click();
            Thread.Sleep(2000);
        }

        public static void FinalizeTest()
        {
            Engine engine = new Engine();
            var windows = engine.GetTopLevelWindows("Calculator");
            foreach (UIDA_Window window in windows)
            {
                window.Close();
            }
        }

        [Given(@"Launch calc")]
        public void GivenLaunchCalc()
        {
            FinalizeTest();
            Thread.Sleep(2000);
            InitializeTest();
            Thread.Sleep(2000);
        }

        [Then(@"close calc")]
        public void ThenCloseCalc()
        {
            Thread.Sleep(2000);
            FinalizeTest();
        }

[Given(@"I navigate to programmer mode")]
        public void GivenINavigateToProgrammerMode()
        {
            Engine engine = new Engine();
            UIDA_Window window = engine.GetTopLevel("Calculator");
            UIDA_Button OpenNavigation = window.Button("Open Navigation", true);
            OpenNavigation.Press();
            Thread.Sleep(2000);

            UIDA_ListItem ProgrammerCalculator = window.ListItem("Programmer Calculator", true);
            ProgrammerCalculator.Click();
            Thread.Sleep(2000);

        }

        [When(@"I enter a value")]
        public void WhenIEnterAValue()
        {
            Engine engine = new Engine();
            UIDA_Window window = engine.GetTopLevel("Calculator");

            UIDA_Button buttonValue1 = window.Button("Five", true);
            buttonValue1.Press();
            Thread.Sleep(2000);
            UIDA_Button buttonValue2 = window.Button("Eight", true);
            buttonValue2.Press();
            Thread.Sleep(2000);

        }

        [Then(@"I verify HEX value is correct")]
        public void ThenIVerifyHEXValueIsCorrect()
        {
            Engine engine = new Engine();
            UIDA_Window window = engine.GetTopLevel("Calculator");

            UIDA_RadioButton HexaDecimal = engine.GetTopLevel("Calculator").WindowAt("Calculator", 2)
                                            .Group("").Group("Radix selection").RadioButton("HexaDecimal 3 A ");
            HexaDecimal.Click();
            Thread.Sleep(2000);

            UIDA_Button MemoryStore = window.Button("Memory Store", true);
            MemoryStore.Press();
            Thread.Sleep(2000);

            UIDA_Label MemoryLabel = engine.GetTopLevel("Calculator").WindowAt("Calculator", 2).Group("").
                                     Group("Memory list").TabCtrl("").TabItem("Memory").List("").ListItem("").Label("3A");
            string actualValue = MemoryLabel.GetText();
            Thread.Sleep(2000);

            string expectedValue = "3A";
            Assert.AreEqual(actualValue, expectedValue);
            UIDA_Button ClearAllMemory = engine.GetTopLevel("Calculator").WindowAt("Calculator", 2).Group("").Group("Memory list").TabCtrl("").TabItem("Memory").Button("Clear all memory");
            ClearAllMemory.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I verify DEC value is correct")]
        public void ThenIVerifyDECValueIsCorrect()
        {
            Engine engine = new Engine();
            UIDA_Window window = engine.GetTopLevel("Calculator");

            UIDA_RadioButton HexaDecimal = engine.GetTopLevel("Calculator").WindowAt("Calculator", 2)
                                            .Group("").Group("Radix selection").RadioButton("Decimal 58");
            HexaDecimal.Click();
            Thread.Sleep(2000);

            UIDA_Button MemoryStore = window.Button("Memory Store", true);
            MemoryStore.Press();
            Thread.Sleep(2000);

            UIDA_Label MemoryLabel = engine.GetTopLevel("Calculator").WindowAt("Calculator", 2).Group("").
                                     Group("Memory list").TabCtrl("").TabItem("Memory").List("").ListItem("").Label("58");
            string actualValue = MemoryLabel.GetText();
            Thread.Sleep(2000);

            string expectedValue = "58";
            Assert.AreEqual(actualValue, expectedValue);
            UIDA_Button ClearAllMemory = engine.GetTopLevel("Calculator").WindowAt("Calculator", 2).Group("").Group("Memory list").TabCtrl("").TabItem("Memory").Button("Clear all memory");
            ClearAllMemory.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I verify OCT value is correct")]
        public void ThenIVerifyOCTValueIsCorrect()
        {
            Engine engine = new Engine();
            UIDA_Window window = engine.GetTopLevel("Calculator");

            UIDA_RadioButton HexaDecimal = engine.GetTopLevel("Calculator").WindowAt("Calculator", 2)
                                            .Group("").Group("Radix selection").RadioButton("Octal 7 2 ");
            HexaDecimal.Click();
            Thread.Sleep(2000);

            UIDA_Button MemoryStore = window.Button("Memory Store", true);
            MemoryStore.Press();
            Thread.Sleep(2000);

            UIDA_Label MemoryLabel = engine.GetTopLevel("Calculator").WindowAt("Calculator", 2).Group("").
                                     Group("Memory list").TabCtrl("").TabItem("Memory").List("").ListItem("").Label("72");
            string actualValue = MemoryLabel.GetText();
            Thread.Sleep(2000);

            string expectedValue = "72";
            Assert.AreEqual(actualValue, expectedValue);
            UIDA_Button ClearAllMemory = engine.GetTopLevel("Calculator").WindowAt("Calculator", 2).Group("").Group("Memory list").TabCtrl("").TabItem("Memory").Button("Clear all memory");
            ClearAllMemory.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I verify BIN value is correct")]
        public void ThenIVerifyBINValueIsCorrect()
        {
            Engine engine = new Engine();
            UIDA_Window window = engine.GetTopLevel("Calculator");

            UIDA_RadioButton HexaDecimal = engine.GetTopLevel("Calculator").WindowAt("Calculator", 2)
                                            .Group("").Group("Radix selection").RadioButton("Binary 0 0 1 1  1 0 1 0 ");
            HexaDecimal.Click();
            Thread.Sleep(2000);

            UIDA_Button MemoryStore = window.Button("Memory Store", true);
            MemoryStore.Press();
            Thread.Sleep(2000);

            UIDA_Label MemoryLabel = engine.GetTopLevel("Calculator").WindowAt("Calculator", 2).Group("").
                                     Group("Memory list").TabCtrl("").TabItem("Memory").List("").ListItem("").Label("11 1010");
            string actualValue = MemoryLabel.GetText();
            Thread.Sleep(2000);

            string expectedValue = "11 1010";
            Assert.AreEqual(actualValue, expectedValue);
            UIDA_Button ClearAllMemory = engine.GetTopLevel("Calculator").WindowAt("Calculator", 2).Group("").Group("Memory list").TabCtrl("").TabItem("Memory").Button("Clear all memory");
            ClearAllMemory.Click();
            Thread.Sleep(2000);
        }

[Given(@"I navigate to scientific mode")]
        public void GivenINavigateToScientificMode()
        {
            Thread.Sleep(2000);
            Engine engine = new Engine();
            UIDA_Window window = engine.GetTopLevel("Calculator");
            UIDA_Button OpenNavigation = window.Button("Open Navigation", true);
            OpenNavigation.Press();
            Thread.Sleep(2000);

            UIDA_ListItem ScientificCalculator = window.ListItem("Scientific Calculator", true);
            ScientificCalculator.Click();
            Thread.Sleep(2000);
        }

        [When(@"perform some calculations")]
        public void WhenPerformSomeCalculations()
        {
            Engine engine = new Engine();
            UIDA_Window window = engine.GetTopLevel("Calculator");

            //1st Step: Square root of X
            UIDA_Button buttonTwo = window.Button("Two", true);
            buttonTwo.Press();
            Thread.Sleep(2000);
            UIDA_Button buttonFive = window.Button("Five", true);
            buttonFive.Press();
            Thread.Sleep(2000);
            UIDA_Button SquareRoot = window.Button("Square root", true);
            SquareRoot.Press();
            Thread.Sleep(2000);
            engine.GetTopLevel("Calculator").WindowAt("Calculator", 2).Group("").Group("History and Memory lists").TabCtrl("").TabItem("Memory").Click();
            Thread.Sleep(2000);
            UIDA_Button MemoryStore = window.Button("Memory Store", true);
            MemoryStore.Press();
            Thread.Sleep(2000);
            
            // 2nd Step: 10 exponent X
            buttonTwo.Press();
            Thread.Sleep(2000);
            UIDA_Button TenToExponent = window.Button("Ten to the exponent", true);
            TenToExponent.Press();
            Thread.Sleep(2000);
            MemoryStore = engine.GetTopLevel("Calculator").WindowAt("Calculator", 2).Group("").Group("Memory controls").Button("Memory Store");
            MemoryStore.Press();
            Thread.Sleep(2000);
            
        }

        [Then(@"verify the results")]
        public void ThenVerifyTheResults()
        {
            Engine engine = new Engine();

            //Verify 1st Step: Square root of X
            UIDA_Label MemoryLabel = engine.GetTopLevel("Calculator").WindowAt("Calculator", 2).Group("").Group("History and Memory lists").TabCtrl("").TabItem("Memory").List("").ListItemAt("", 2).Label("5");
            string actualValue = MemoryLabel.GetText();
            Thread.Sleep(2000);
            string expectedValue = "5";
            Assert.AreEqual(actualValue, expectedValue);
            Thread.Sleep(2000);

            //Verify 2nd Step: 10 exponent X
            UIDA_Label MemoryLabel2 = engine.GetTopLevel("Calculator").WindowAt("Calculator", 2).Group("").Group("History and Memory lists").TabCtrl("").TabItem("Memory").List("").ListItem("").Label("100");
            string actualValue2 = MemoryLabel2.GetText();
            Thread.Sleep(2000);
            string expectedValue2 = "100";
            Assert.AreEqual(actualValue2, expectedValue2);

            UIDA_Button ClearAllMemory = engine.GetTopLevel("Calculator").WindowAt("Calculator", 2).Group("").Group("History and Memory lists").TabCtrl("").TabItem("Memory").Button("Clear all memory");
            ClearAllMemory.Click();
            Thread.Sleep(2000);
            
        }

 [Given(@"I navigate to date calculation mode")]
        public void GivenINavigateToDateCalculationMode()
        {
            Engine engine = new Engine();
            UIDA_Window window = engine.GetTopLevel("Calculator");
            UIDA_Button OpenNavigation = window.Button("Open Navigation", true);
            OpenNavigation.Press();
            Thread.Sleep(2000);
            UIDA_ListItem DateCalculationCalculator = engine.GetTopLevel("Calculator").WindowAt("Calculator", 2).Custom("").Window("").Pane("").Group("").ListItem("Date Calculation Calculator");
            DateCalculationCalculator.Click();
            Thread.Sleep(5000);
        }

        [When(@"enter dates")]
        public void WhenEnterDates()
        {
            Engine engine = new Engine();
            UIDA_Window window = engine.GetTopLevel("Calculator");

            UIDA_Button DateFrom = engine.GetTopLevel("Calculator").WindowAt("Calculator", 2).Group("").Button("From");
            DateFrom.Press();
            //UIDA_DataItem DataItem  = engine.GetTopLevel("Calculator").WindowAt("Calculator", 2).Window("Popup").Pane("").Calendar("").Pane("").DataItem("22");
            //DataItem.Click();
        }

        [Then(@"verify day results")]
        public void ThenVerifyDayResults()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"verify week results")]
        public void ThenVerifyWeekResults()
        {
            //ScenarioContext.Current.Pending();
        }

[Given(@"I navigate to standard mode")]
        public void GivenINavigateToStandardMode()
        {
            //ScenarioContext.Current.Pending();
            Thread.Sleep(5000);
        }

        [When(@"perform some calculations for standard")]
        public void WhenPerformSomeCalculationsForStandard()
        {
           
        }

        [Then(@"verify the results for standard")]
        public void ThenVerifyTheResultsForStandard()
        {
            
        }


        [Then(@"cancel")]
        public void ThenCancel()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"retrieve")]
        public void ThenRetrieve()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"validate from history")]
        public void ThenValidateFromHistory()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"Verify some memory additional and retrieval")]
        public void ThenVerifySomeMemoryAdditionalAndRetrieval()
        {
            //ScenarioContext.Current.Pending();
        }

    }
}
