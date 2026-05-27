// ============================================================================
// MAIN PROGRAM — Runs ALL sections for study and revision
// ============================================================================
// This is the entry point. It runs all Section A, B, and C console examples
// in sequence so you can see every concept demonstrated.
//
// TO RUN WINDOWS FORMS EXAMPLES:
//   1. Create a Windows Forms App project in Visual Studio
//   2. Copy the relevant form class (GreetingForm, CalculatorForm,
//      or StudentRecordForm) into your project
//   3. Update Program.cs to use Application.Run(new FormName())
//
// TO RUN THIS CONSOLE VERSION:
//   1. Create a Console Application project in Visual Studio
//   2. Add all three .cs files to your project
//   3. Make sure this file has the only Main() method
//      (comment out any other Main methods in other files)
//   4. Press F5 to run
// ============================================================================

using System;

namespace SoftwareTestingStudyGuide
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Complete Software Testing & C# Study Guide";

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║        COMPLETE SOFTWARE TESTING & C# STUDY GUIDE          ║");
                Console.WriteLine("║                All Sections — All Topics                    ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║                                                            ║");
                Console.WriteLine("║  SECTION A: Software Testing Concepts                      ║");
                Console.WriteLine("║    1.  Functional Testing                                  ║");
                Console.WriteLine("║    2.  Non-Functional Testing                              ║");
                Console.WriteLine("║    3.  Load Testing                                        ║");
                Console.WriteLine("║    4.  Stress Testing                                      ║");
                Console.WriteLine("║    5.  Black-Box Testing                                   ║");
                Console.WriteLine("║    6.  White-Box Testing                                   ║");
                Console.WriteLine("║    7.  Equivalence Partitioning                            ║");
                Console.WriteLine("║    8.  Boundary Value Analysis                             ║");
                Console.WriteLine("║    9.  Error-Case Testing                                  ║");
                Console.WriteLine("║    10. Test Case Structure                                 ║");
                Console.WriteLine("║    11. Interpreting Test Results                           ║");
                Console.WriteLine("║    12. Test Summary Report                                 ║");
                Console.WriteLine("║                                                            ║");
                Console.WriteLine("║  SECTION B: Basic C# Programming                          ║");
                Console.WriteLine("║    13. Console Output                                      ║");
                Console.WriteLine("║    14. Variables, Data Types & Operators                    ║");
                Console.WriteLine("║    15. Selection Structures (if/switch)                    ║");
                Console.WriteLine("║    16. Loops (for/while/foreach)                           ║");
                Console.WriteLine("║    17. Arrays and Lists                                    ║");
                Console.WriteLine("║    18. Methods / Functions                                 ║");
                Console.WriteLine("║                                                            ║");
                Console.WriteLine("║  SECTION C: Practical Application                         ║");
                Console.WriteLine("║    19. Functional & Non-Functional Test Cases              ║");
                Console.WriteLine("║    20. Defect Report with Recommendations                  ║");
                Console.WriteLine("║    21. Professional Software Testing Report                ║");
                Console.WriteLine("║    22. GitHub Workflow Guide                               ║");
                Console.WriteLine("║    23. Submission Evidence Checklist                       ║");
                Console.WriteLine("║                                                            ║");
                Console.WriteLine("║    0.  Run ALL examples                                    ║");
                Console.WriteLine("║    99. Exit                                                ║");
                Console.WriteLine("║                                                            ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
                Console.Write("\nEnter your choice: ");

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    // Section A
                    case "1":  SectionA_SoftwareTesting.FunctionalTestingExamples.RunFunctionalTests(); break;
                    case "2":  SectionA_SoftwareTesting.NonFunctionalTestingExamples.RunPerformanceTest(); break;
                    case "3":  SectionA_SoftwareTesting.LoadTestingExample.RunLoadTest(); break;
                    case "4":  SectionA_SoftwareTesting.StressTestingExample.RunStressTest(); break;
                    case "5":  SectionA_SoftwareTesting.BlackBoxTestingExamples.RunBlackBoxTests(); break;
                    case "6":  SectionA_SoftwareTesting.WhiteBoxTestingExamples.RunWhiteBoxTests(); break;
                    case "7":  SectionA_SoftwareTesting.EquivalencePartitioningExample.RunEquivalenceTests(); break;
                    case "8":  SectionA_SoftwareTesting.BoundaryValueAnalysisExample.RunBoundaryTests(); break;
                    case "9":  SectionA_SoftwareTesting.ErrorCaseTestingExample.RunErrorCaseTests(); break;
                    case "10": SectionA_SoftwareTesting.TestCaseStructureExample.ShowTestCaseExamples(); break;
                    case "11": SectionA_SoftwareTesting.TestResultsInterpretation.InterpretResults(); break;
                    case "12": SectionA_SoftwareTesting.TestSummaryExample.GenerateTestSummary(); break;

                    // Section B
                    case "13": SectionB_BasicCSharp.ConsoleOutputExamples.DemonstrateOutput(); break;
                    case "14": SectionB_BasicCSharp.VariablesAndOperators.Demonstrate(); break;
                    case "15": SectionB_BasicCSharp.SelectionStructures.Demonstrate(); break;
                    case "16": SectionB_BasicCSharp.LoopExamples.Demonstrate(); break;
                    case "17": SectionB_BasicCSharp.ArraysAndLists.Demonstrate(); break;
                    case "18": SectionB_BasicCSharp.MethodExamples.Demonstrate(); break;

                    // Section C
                    case "19": SectionC_PracticalApplication.TestCaseDefinitions.DisplayAllTestCases(); break;
                    case "20": SectionC_PracticalApplication.DefectReportExamples.ShowDefectReport(); break;
                    case "21": SectionC_PracticalApplication.TestReportGenerator.GenerateReport(); break;
                    case "22": SectionC_PracticalApplication.GitHubWorkflowGuide.DisplayWorkflow(); break;
                    case "23": SectionC_PracticalApplication.SubmissionChecklist.DisplayChecklist(); break;

                    // Run everything
                    case "0":
                        Console.WriteLine("Running ALL examples...\n");
                        // Section A
                        SectionA_SoftwareTesting.FunctionalTestingExamples.RunFunctionalTests();
                        SectionA_SoftwareTesting.NonFunctionalTestingExamples.RunPerformanceTest();
                        SectionA_SoftwareTesting.LoadTestingExample.RunLoadTest();
                        SectionA_SoftwareTesting.StressTestingExample.RunStressTest();
                        SectionA_SoftwareTesting.BlackBoxTestingExamples.RunBlackBoxTests();
                        SectionA_SoftwareTesting.WhiteBoxTestingExamples.RunWhiteBoxTests();
                        SectionA_SoftwareTesting.EquivalencePartitioningExample.RunEquivalenceTests();
                        SectionA_SoftwareTesting.BoundaryValueAnalysisExample.RunBoundaryTests();
                        SectionA_SoftwareTesting.ErrorCaseTestingExample.RunErrorCaseTests();
                        SectionA_SoftwareTesting.TestCaseStructureExample.ShowTestCaseExamples();
                        SectionA_SoftwareTesting.TestResultsInterpretation.InterpretResults();
                        SectionA_SoftwareTesting.TestSummaryExample.GenerateTestSummary();
                        // Section B
                        SectionB_BasicCSharp.ConsoleOutputExamples.DemonstrateOutput();
                        SectionB_BasicCSharp.VariablesAndOperators.Demonstrate();
                        SectionB_BasicCSharp.SelectionStructures.Demonstrate();
                        SectionB_BasicCSharp.LoopExamples.Demonstrate();
                        SectionB_BasicCSharp.ArraysAndLists.Demonstrate();
                        SectionB_BasicCSharp.MethodExamples.Demonstrate();
                        // Section C
                        SectionC_PracticalApplication.TestCaseDefinitions.DisplayAllTestCases();
                        SectionC_PracticalApplication.DefectReportExamples.ShowDefectReport();
                        SectionC_PracticalApplication.TestReportGenerator.GenerateReport();
                        SectionC_PracticalApplication.GitHubWorkflowGuide.DisplayWorkflow();
                        SectionC_PracticalApplication.SubmissionChecklist.DisplayChecklist();
                        break;

                    case "99":
                        running = false;
                        Console.WriteLine("Good luck with your studies! You've got this! 🎓");
                        continue;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from the menu.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\n───────────────────────────────────────────");
                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}
