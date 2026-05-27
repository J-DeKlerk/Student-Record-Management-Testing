// ============================================================================
// SECTION A: SOFTWARE TESTING CONCEPTS — COMPLETE STUDY GUIDE WITH C# EXAMPLES
// ============================================================================
// This file covers all testing theory with practical C# code demonstrations.
// Each concept is explained in comments, then shown in working code.
// ============================================================================

using System;
using System.Collections.Generic;

namespace SectionA_SoftwareTesting
{
    // ========================================================================
    // 1. FUNCTIONAL TESTING
    // ========================================================================
    // DEFINITION:
    // Functional testing verifies that the software does what it is supposed
    // to do according to the requirements/specifications. It tests the
    // FEATURES and BEHAVIOUR of the system — "Does it work correctly?"
    //
    // Examples: Does the login button log you in? Does the calculator add
    // two numbers correctly? Does the search return correct results?
    //
    // KEY POINT: Functional testing focuses on WHAT the system does,
    // not HOW it does it internally.
    // ========================================================================

    public class FunctionalTestingExamples
    {
        // A simple method we will functionally test
        public static double CalculateDiscount(double price, double discountPercent)
        {
            if (price < 0) throw new ArgumentException("Price cannot be negative.");
            if (discountPercent < 0 || discountPercent > 100)
                throw new ArgumentException("Discount must be between 0 and 100.");

            return price - (price * discountPercent / 100);
        }

        public static void RunFunctionalTests()
        {
            Console.WriteLine("=== FUNCTIONAL TESTING EXAMPLES ===\n");

            // Functional Test 1: Does the discount calculate correctly?
            // We only care about input → expected output (the WHAT, not the HOW)
            double result1 = CalculateDiscount(100, 10);
            Console.WriteLine($"Test 1 - 10% off R100: Expected R90, Got R{result1} → {(result1 == 90 ? "PASS" : "FAIL")}");

            // Functional Test 2: Zero discount should return full price
            double result2 = CalculateDiscount(200, 0);
            Console.WriteLine($"Test 2 - 0% off R200:  Expected R200, Got R{result2} → {(result2 == 200 ? "PASS" : "FAIL")}");

            // Functional Test 3: 100% discount should return 0
            double result3 = CalculateDiscount(150, 100);
            Console.WriteLine($"Test 3 - 100% off R150: Expected R0, Got R{result3} → {(result3 == 0 ? "PASS" : "FAIL")}");

            Console.WriteLine();
        }
    }

    // ========================================================================
    // 2. NON-FUNCTIONAL TESTING
    // ========================================================================
    // DEFINITION:
    // Non-functional testing checks HOW WELL the system performs, not whether
    // it works. It focuses on quality attributes like speed, usability,
    // reliability, security, and scalability.
    //
    // Examples: How fast does the page load? Can 1000 users log in at once?
    // Is the interface easy to use? Is data encrypted?
    //
    // KEY POINT: Non-functional testing answers "How good is it?" rather
    // than "Does it work?"
    //
    // Types include: Performance testing, usability testing, security
    // testing, compatibility testing, load testing, stress testing.
    // ========================================================================

    public class NonFunctionalTestingExamples
    {
        // Simulating a non-functional (performance) test
        public static void RunPerformanceTest()
        {
            Console.WriteLine("=== NON-FUNCTIONAL TESTING EXAMPLES ===\n");

            // Non-functional Test: How FAST does sorting complete?
            // We are not testing IF it sorts correctly (that's functional),
            // we are testing HOW QUICKLY it sorts (that's non-functional).
            List<int> data = new List<int>();
            Random rng = new Random(42);
            for (int i = 0; i < 10000; i++)
                data.Add(rng.Next(1, 100000));

            DateTime startTime = DateTime.Now;
            data.Sort();
            DateTime endTime = DateTime.Now;

            double elapsed = (endTime - startTime).TotalMilliseconds;
            bool passesPerformance = elapsed < 100; // Requirement: must sort in under 100ms

            Console.WriteLine($"Performance Test - Sort 10,000 items:");
            Console.WriteLine($"  Time taken: {elapsed:F2} ms");
            Console.WriteLine($"  Requirement: < 100 ms");
            Console.WriteLine($"  Result: {(passesPerformance ? "PASS" : "FAIL")}");
            Console.WriteLine();
        }
    }

    // ========================================================================
    // 3. LOAD TESTING
    // ========================================================================
    // DEFINITION:
    // Load testing checks how the system behaves under EXPECTED or NORMAL
    // levels of demand. For example, if a website is designed for 500
    // concurrent users, load testing simulates 500 users to verify
    // it handles that volume correctly.
    //
    // PURPOSE: To verify the system meets performance requirements under
    // its intended workload.
    //
    // KEY POINT: Load testing uses NORMAL/EXPECTED volumes, not extreme ones.
    // ========================================================================

    public class LoadTestingExample
    {
        // Simulating a method that processes user requests
        public static string ProcessRequest(int userId)
        {
            // Simulate some processing time
            System.Threading.Thread.Sleep(1); // 1ms per request
            return $"Response for user {userId}";
        }

        public static void RunLoadTest()
        {
            Console.WriteLine("=== LOAD TESTING EXAMPLE ===\n");

            // Simulate 100 concurrent users (the EXPECTED load)
            int expectedUsers = 100;
            int successCount = 0;
            DateTime start = DateTime.Now;

            for (int i = 1; i <= expectedUsers; i++)
            {
                string response = ProcessRequest(i);
                if (!string.IsNullOrEmpty(response))
                    successCount++;
            }

            double totalTime = (DateTime.Now - start).TotalMilliseconds;

            Console.WriteLine($"Load Test - {expectedUsers} concurrent users (expected load):");
            Console.WriteLine($"  Successful responses: {successCount}/{expectedUsers}");
            Console.WriteLine($"  Total time: {totalTime:F2} ms");
            Console.WriteLine($"  Avg response time: {totalTime / expectedUsers:F2} ms per user");
            Console.WriteLine($"  Result: {(successCount == expectedUsers ? "PASS" : "FAIL")}");
            Console.WriteLine();
        }
    }

    // ========================================================================
    // 4. STRESS TESTING
    // ========================================================================
    // DEFINITION:
    // Stress testing pushes the system BEYOND its normal capacity to see
    // how it handles extreme conditions and when/how it fails. The goal
    // is to find the breaking point and verify graceful failure.
    //
    // PURPOSE: To determine the system's limits and ensure it fails
    // gracefully (e.g., shows an error message instead of crashing).
    //
    // KEY DIFFERENCE FROM LOAD TESTING:
    //   Load testing  = normal expected volume  → should it handle this? YES
    //   Stress testing = extreme/beyond-capacity → where does it break?
    // ========================================================================

    public class StressTestingExample
    {
        private static int maxCapacity = 50; // System designed for max 50 items

        public static bool AddToQueue(List<string> queue, string item)
        {
            if (queue.Count >= maxCapacity)
                return false; // Graceful rejection when over capacity
            queue.Add(item);
            return true;
        }

        public static void RunStressTest()
        {
            Console.WriteLine("=== STRESS TESTING EXAMPLE ===\n");

            // Try to push 200 items into a queue that can only hold 50
            // This is STRESS testing — deliberately exceeding capacity
            List<string> queue = new List<string>();
            int attempted = 200;
            int accepted = 0;
            int rejected = 0;

            for (int i = 0; i < attempted; i++)
            {
                bool success = AddToQueue(queue, $"Item_{i}");
                if (success) accepted++;
                else rejected++;
            }

            Console.WriteLine($"Stress Test - {attempted} items into capacity-{maxCapacity} queue:");
            Console.WriteLine($"  Accepted: {accepted}");
            Console.WriteLine($"  Rejected gracefully: {rejected}");
            Console.WriteLine($"  System crashed: No");
            Console.WriteLine($"  Graceful degradation: {(rejected == attempted - maxCapacity ? "PASS" : "FAIL")}");
            Console.WriteLine();
        }
    }

    // ========================================================================
    // 5. BLACK-BOX TESTING
    // ========================================================================
    // DEFINITION:
    // Black-box testing treats the system as a "black box" — the tester
    // does NOT know or care about the internal code/logic. They only
    // test inputs and verify outputs against expected results.
    //
    // WHO DOES IT: Typically testers (not developers).
    // FOCUS: Requirements and specifications, not code.
    //
    // ANALOGY: Like testing a vending machine — you put in money and
    // press a button. You check if the right item comes out. You don't
    // care about the gears and motors inside.
    //
    // TECHNIQUES: Equivalence partitioning, boundary value analysis,
    // error-case testing (all covered below).
    // ========================================================================

    public class BlackBoxTestingExamples
    {
        // We test this method as a BLACK BOX — we don't look at the code,
        // we only know: "It should return a grade letter for a mark 0-100"
        public static string GetGrade(int mark)
        {
            if (mark < 0 || mark > 100) return "INVALID";
            if (mark >= 75) return "A";
            if (mark >= 60) return "B";
            if (mark >= 50) return "C";
            if (mark >= 40) return "D";
            return "F";
        }

        public static void RunBlackBoxTests()
        {
            Console.WriteLine("=== BLACK-BOX TESTING EXAMPLES ===\n");
            Console.WriteLine("We test based on SPECIFICATIONS only, not code:\n");

            // As a black-box tester, we know the spec says:
            // 75-100 = A, 60-74 = B, 50-59 = C, 40-49 = D, 0-39 = F
            // We test without looking at the code above.

            var tests = new (int input, string expected, string description)[]
            {
                (85, "A", "High A grade"),
                (60, "B", "Low B boundary"),
                (55, "C", "Mid C range"),
                (40, "D", "Low D boundary"),
                (25, "F", "Fail grade"),
                (-1, "INVALID", "Negative input"),
                (101, "INVALID", "Over maximum"),
            };

            foreach (var test in tests)
            {
                string actual = GetGrade(test.input);
                string status = actual == test.expected ? "PASS" : "FAIL";
                Console.WriteLine($"  Input: {test.input,4} | Expected: {test.expected,-7} | Got: {actual,-7} | {status} ({test.description})");
            }
            Console.WriteLine();
        }
    }

    // ========================================================================
    // 6. WHITE-BOX TESTING
    // ========================================================================
    // DEFINITION:
    // White-box testing (also called structural/glass-box testing) is
    // performed by someone who CAN SEE the internal code. The tester
    // designs tests to exercise specific code paths, branches, loops,
    // and conditions inside the program.
    //
    // WHO DOES IT: Typically developers.
    // FOCUS: Code coverage — making sure every line, branch, and path
    // is tested.
    //
    // ANALOGY: Like testing a vending machine by opening it up and
    // checking every gear, sensor, and motor individually.
    //
    // TECHNIQUES: Statement coverage, branch coverage, path coverage.
    // ========================================================================

    public class WhiteBoxTestingExamples
    {
        // Here is the code — as white-box testers, we CAN see it.
        // We design tests to cover every branch/path through the code.
        public static string ClassifyTriangle(int a, int b, int c)
        {
            // Branch 1: Invalid sides
            if (a <= 0 || b <= 0 || c <= 0)
                return "Invalid";

            // Branch 2: Triangle inequality check
            if (a + b <= c || a + c <= b || b + c <= a)
                return "Not a triangle";

            // Branch 3: Equilateral
            if (a == b && b == c)
                return "Equilateral";

            // Branch 4: Isosceles
            if (a == b || b == c || a == c)
                return "Isosceles";

            // Branch 5: Scalene
            return "Scalene";
        }

        public static void RunWhiteBoxTests()
        {
            Console.WriteLine("=== WHITE-BOX TESTING EXAMPLES ===\n");
            Console.WriteLine("We design tests to cover EVERY BRANCH in the code:\n");

            // We deliberately target each branch because we can see the code
            var tests = new (int a, int b, int c, string expected, string branch)[]
            {
                (0, 5, 5, "Invalid",          "Branch 1: Invalid sides (zero)"),
                (-1, 3, 4, "Invalid",          "Branch 1: Invalid sides (negative)"),
                (1, 2, 10, "Not a triangle",   "Branch 2: Triangle inequality fails"),
                (5, 5, 5, "Equilateral",       "Branch 3: All sides equal"),
                (5, 5, 3, "Isosceles",         "Branch 4: Two sides equal (a==b)"),
                (3, 5, 5, "Isosceles",         "Branch 4: Two sides equal (b==c)"),
                (5, 3, 5, "Isosceles",         "Branch 4: Two sides equal (a==c)"),
                (3, 4, 5, "Scalene",           "Branch 5: All sides different"),
            };

            foreach (var test in tests)
            {
                string actual = ClassifyTriangle(test.a, test.b, test.c);
                string status = actual == test.expected ? "PASS" : "FAIL";
                Console.WriteLine($"  ({test.a},{test.b},{test.c}) → {actual,-16} | {status} | {test.branch}");
            }
            Console.WriteLine();
        }
    }

    // ========================================================================
    // 7. EQUIVALENCE PARTITIONING
    // ========================================================================
    // DEFINITION:
    // Equivalence partitioning divides all possible inputs into GROUPS
    // (partitions) where every value in a group is expected to behave
    // the same way. You then test ONE value from each group, because
    // testing every value in the group would be redundant.
    //
    // PURPOSE: Reduces the number of test cases while maintaining good
    // coverage. Instead of testing every number 0-100, you test one
    // from each meaningful range.
    //
    // EXAMPLE: For a "valid age" field accepting 18-65:
    //   Partition 1 (Invalid low):  Any age < 18    → test with 10
    //   Partition 2 (Valid):        Any age 18-65   → test with 30
    //   Partition 3 (Invalid high): Any age > 65    → test with 80
    //   Instead of testing all 200+ possible ages, we test just 3.
    // ========================================================================

    public class EquivalencePartitioningExample
    {
        // Method: Validates a student's age for enrollment (must be 16-25)
        public static string ValidateEnrollmentAge(int age)
        {
            if (age < 16) return "Too young to enroll";
            if (age > 25) return "Exceeds age limit";
            return "Eligible";
        }

        public static void RunEquivalenceTests()
        {
            Console.WriteLine("=== EQUIVALENCE PARTITIONING EXAMPLES ===\n");

            // We identify THREE partitions:
            // Partition 1: age < 16   (invalid — too young)  → pick ANY value, e.g. 10
            // Partition 2: age 16-25  (valid — eligible)     → pick ANY value, e.g. 20
            // Partition 3: age > 25   (invalid — too old)    → pick ANY value, e.g. 40

            Console.WriteLine("Partitions identified:");
            Console.WriteLine("  Partition 1: age < 16  (Invalid - too young)");
            Console.WriteLine("  Partition 2: age 16-25 (Valid - eligible)");
            Console.WriteLine("  Partition 3: age > 25  (Invalid - exceeds limit)\n");

            var tests = new (int age, string partition, string expected)[]
            {
                (10, "Partition 1 (too young)", "Too young to enroll"),
                (20, "Partition 2 (valid)",     "Eligible"),
                (40, "Partition 3 (too old)",   "Exceeds age limit"),
            };

            foreach (var test in tests)
            {
                string actual = ValidateEnrollmentAge(test.age);
                string status = actual == test.expected ? "PASS" : "FAIL";
                Console.WriteLine($"  Age: {test.age,3} | {test.partition,-28} | Expected: {test.expected,-22} | {status}");
            }
            Console.WriteLine();
        }
    }

    // ========================================================================
    // 8. BOUNDARY VALUE ANALYSIS (BVA)
    // ========================================================================
    // DEFINITION:
    // Boundary value analysis tests the VALUES AT THE EDGES (boundaries)
    // of equivalence partitions. Bugs are most commonly found at boundaries,
    // so we focus testing there.
    //
    // For a valid range of 16–25, the boundaries are:
    //   15 (just below lower boundary — should be invalid)
    //   16 (lower boundary — first valid value)
    //   17 (just above lower boundary — should be valid)
    //   24 (just below upper boundary — should be valid)
    //   25 (upper boundary — last valid value)
    //   26 (just above upper boundary — should be invalid)
    //
    // KEY POINT: Always test the boundary value itself, one below it,
    // and one above it.
    // ========================================================================

    public class BoundaryValueAnalysisExample
    {
        public static void RunBoundaryTests()
        {
            Console.WriteLine("=== BOUNDARY VALUE ANALYSIS EXAMPLES ===\n");
            Console.WriteLine("Testing edges of valid range 16-25:\n");

            // Using the same ValidateEnrollmentAge method from above
            var tests = new (int age, string boundary, string expected)[]
            {
                (15, "Just BELOW lower boundary", "Too young to enroll"),
                (16, "AT lower boundary",         "Eligible"),
                (17, "Just ABOVE lower boundary", "Eligible"),
                (24, "Just BELOW upper boundary", "Eligible"),
                (25, "AT upper boundary",         "Eligible"),
                (26, "Just ABOVE upper boundary", "Exceeds age limit"),
            };

            foreach (var test in tests)
            {
                string actual = EquivalencePartitioningExample.ValidateEnrollmentAge(test.age);
                string status = actual == test.expected ? "PASS" : "FAIL";
                Console.WriteLine($"  Age: {test.age,3} | {test.boundary,-30} | Expected: {test.expected,-22} | {status}");
            }
            Console.WriteLine();
        }
    }

    // ========================================================================
    // 9. ERROR-CASE TESTING (NEGATIVE TESTING)
    // ========================================================================
    // DEFINITION:
    // Error-case testing (also called negative testing) deliberately
    // provides INVALID, UNEXPECTED, or WRONG inputs to verify the system
    // handles errors gracefully — showing proper error messages instead
    // of crashing.
    //
    // PURPOSE: To ensure the system is robust and doesn't break when
    // users make mistakes or provide bad data.
    //
    // EXAMPLES OF ERROR CASES:
    //   - Entering text where a number is expected
    //   - Leaving required fields empty
    //   - Entering special characters in a name field
    //   - Submitting a form with no data
    //   - Entering a date in the wrong format
    // ========================================================================

    public class ErrorCaseTestingExample
    {
        // Method that should handle all kinds of bad input gracefully
        public static string ParseAndValidateAge(string input)
        {
            // Error case: null or empty input
            if (string.IsNullOrWhiteSpace(input))
                return "Error: Age field cannot be empty.";

            // Error case: non-numeric input
            bool isNumber = int.TryParse(input, out int age);
            if (!isNumber)
                return "Error: Please enter a valid number.";

            // Error case: negative number
            if (age < 0)
                return "Error: Age cannot be negative.";

            // Error case: unrealistic age
            if (age > 150)
                return "Error: Please enter a realistic age.";

            return $"Valid age: {age}";
        }

        public static void RunErrorCaseTests()
        {
            Console.WriteLine("=== ERROR-CASE TESTING EXAMPLES ===\n");
            Console.WriteLine("Deliberately providing BAD inputs to test error handling:\n");

            var tests = new (string input, string errorType, bool shouldBeError)[]
            {
                (null,      "Null input",                true),
                ("",        "Empty string",              true),
                ("   ",     "Whitespace only",           true),
                ("abc",     "Text instead of number",    true),
                ("12.5",    "Decimal instead of integer", true),
                ("-5",      "Negative number",           true),
                ("200",     "Unrealistic age (>150)",    true),
                ("!@#",     "Special characters",        true),
                ("25",      "Valid input (for comparison)", false),
            };

            foreach (var test in tests)
            {
                string actual = ParseAndValidateAge(test.input);
                bool gotError = actual.StartsWith("Error:");
                string status = gotError == test.shouldBeError ? "PASS" : "FAIL";
                string displayInput = test.input == null ? "null" : $"\"{test.input}\"";
                Console.WriteLine($"  Input: {displayInput,-10} | {test.errorType,-28} | Result: {actual,-40} | {status}");
            }
            Console.WriteLine();
        }
    }

    // ========================================================================
    // 10. DEFINING AND STRUCTURING A TEST CASE
    // ========================================================================
    // DEFINITION:
    // A test case is a documented set of conditions and steps used to
    // verify that a specific feature or function works correctly.
    //
    // A WELL-STRUCTURED TEST CASE INCLUDES:
    //   - Test Case ID:      Unique identifier (e.g., TC001)
    //   - Test Description:  What is being tested
    //   - Pre-conditions:    What must be true before the test runs
    //   - Test Steps:        Step-by-step instructions to execute
    //   - Test Data:         The specific input values used
    //   - Expected Result:   What SHOULD happen
    //   - Actual Result:     What DID happen (filled in after running)
    //   - Status:            PASS or FAIL
    //   - Priority:          High / Medium / Low
    //   - Test Type:         Functional / Non-functional
    // ========================================================================

    public class TestCaseStructureExample
    {
        // A class to represent a formal test case
        public class TestCase
        {
            public string TestCaseId { get; set; }
            public string Description { get; set; }
            public string PreConditions { get; set; }
            public string TestSteps { get; set; }
            public string TestData { get; set; }
            public string ExpectedResult { get; set; }
            public string ActualResult { get; set; }
            public string Status { get; set; }   // PASS or FAIL
            public string Priority { get; set; }  // High, Medium, Low
            public string TestType { get; set; }  // Functional or Non-functional
        }

        public static void ShowTestCaseExamples()
        {
            Console.WriteLine("=== TEST CASE STRUCTURE EXAMPLES ===\n");

            // Example: Test cases for a Login feature
            List<TestCase> testCases = new List<TestCase>
            {
                new TestCase
                {
                    TestCaseId = "TC001",
                    Description = "Verify login with valid credentials",
                    PreConditions = "User account exists in the system",
                    TestSteps = "1. Open login page\n                           2. Enter valid username\n                           3. Enter valid password\n                           4. Click Login button",
                    TestData = "Username: 'admin', Password: 'Pass123'",
                    ExpectedResult = "User is redirected to the dashboard",
                    ActualResult = "User was redirected to the dashboard",
                    Status = "PASS",
                    Priority = "High",
                    TestType = "Functional"
                },
                new TestCase
                {
                    TestCaseId = "TC002",
                    Description = "Verify login with empty password",
                    PreConditions = "User is on the login page",
                    TestSteps = "1. Enter valid username\n                           2. Leave password field empty\n                           3. Click Login button",
                    TestData = "Username: 'admin', Password: ''",
                    ExpectedResult = "Error message: 'Password is required'",
                    ActualResult = "No error message displayed, form submitted",
                    Status = "FAIL",
                    Priority = "High",
                    TestType = "Functional"
                },
                new TestCase
                {
                    TestCaseId = "TC003",
                    Description = "Verify login page loads within 3 seconds",
                    PreConditions = "Stable network connection",
                    TestSteps = "1. Navigate to login page URL\n                           2. Measure load time",
                    TestData = "N/A",
                    ExpectedResult = "Page loads in under 3 seconds",
                    ActualResult = "Page loaded in 1.2 seconds",
                    Status = "PASS",
                    Priority = "Medium",
                    TestType = "Non-functional"
                }
            };

            foreach (var tc in testCases)
            {
                Console.WriteLine($"┌─────────────────────────────────────────────────────────");
                Console.WriteLine($"│ Test Case ID:    {tc.TestCaseId}");
                Console.WriteLine($"│ Description:     {tc.Description}");
                Console.WriteLine($"│ Pre-conditions:  {tc.PreConditions}");
                Console.WriteLine($"│ Test Data:       {tc.TestData}");
                Console.WriteLine($"│ Expected Result: {tc.ExpectedResult}");
                Console.WriteLine($"│ Actual Result:   {tc.ActualResult}");
                Console.WriteLine($"│ Status:          {tc.Status}");
                Console.WriteLine($"│ Priority:        {tc.Priority}");
                Console.WriteLine($"│ Test Type:       {tc.TestType}");
                Console.WriteLine($"└─────────────────────────────────────────────────────────\n");
            }
        }
    }

    // ========================================================================
    // 11. INTERPRETING TEST RESULTS
    // ========================================================================
    // DEFINITION:
    // Interpreting test results means analysing the outcomes of your tests
    // to determine:
    //   - How many tests passed vs failed
    //   - What the pass rate / failure rate is
    //   - Which defects were found and their severity
    //   - Whether the software is ready for release
    //
    // KEY METRICS:
    //   Pass Rate = (Passed Tests / Total Tests) × 100
    //   Fail Rate = (Failed Tests / Total Tests) × 100
    //   Defect Density = Number of defects / Size of software
    // ========================================================================

    public class TestResultsInterpretation
    {
        public static void InterpretResults()
        {
            Console.WriteLine("=== INTERPRETING TEST RESULTS ===\n");

            // Simulated test results
            int totalTests = 20;
            int passed = 16;
            int failed = 4;

            double passRate = (double)passed / totalTests * 100;
            double failRate = (double)failed / totalTests * 100;

            Console.WriteLine($"Total Tests Executed: {totalTests}");
            Console.WriteLine($"Tests Passed:        {passed}");
            Console.WriteLine($"Tests Failed:        {failed}");
            Console.WriteLine($"Pass Rate:           {passRate:F1}%");
            Console.WriteLine($"Fail Rate:           {failRate:F1}%\n");

            // Categorise defects by severity
            Console.WriteLine("Defects Found:");
            Console.WriteLine("  [CRITICAL] TC002 - Login allows empty password (Security risk)");
            Console.WriteLine("  [HIGH]     TC008 - Delete button does not confirm before deleting");
            Console.WriteLine("  [MEDIUM]   TC014 - Date format not validated (accepts 99/99/9999)");
            Console.WriteLine("  [LOW]      TC019 - Spelling error on About page\n");

            // Recommendation based on results
            Console.WriteLine("INTERPRETATION:");
            if (passRate >= 95)
                Console.WriteLine("  → Software is ready for release (pass rate >= 95%).");
            else if (passRate >= 80)
                Console.WriteLine("  → Software needs minor fixes before release.");
            else
                Console.WriteLine("  → Software is NOT ready for release. Critical defects must be fixed.");

            Console.WriteLine($"  → Current pass rate: {passRate:F1}% — Fix {failed} failing test(s) before release.\n");
        }
    }

    // ========================================================================
    // 12. WRITING A SHORT TEST SUMMARY WITH RECOMMENDATIONS
    // ========================================================================
    // DEFINITION:
    // A test summary is a brief professional report that communicates:
    //   1. What was tested
    //   2. How many tests passed/failed
    //   3. What defects were found
    //   4. Recommendations for fixing issues
    //
    // STRUCTURE OF A TEST SUMMARY:
    //   - Title / Project Name
    //   - Date and Tester Name
    //   - Scope (what was tested)
    //   - Summary of Results (pass/fail counts)
    //   - Defects Found (with severity)
    //   - Recommendations
    //   - Conclusion (ready for release or not)
    // ========================================================================

    public class TestSummaryExample
    {
        public static void GenerateTestSummary()
        {
            Console.WriteLine("=== TEST SUMMARY REPORT EXAMPLE ===\n");

            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║               SOFTWARE TESTING SUMMARY REPORT               ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║ Project:     Student Record Management System               ║");
            Console.WriteLine("║ Tester:      [Your Name]                                    ║");
            Console.WriteLine("║ Date:        2026-05-27                                     ║");
            Console.WriteLine("║ Version:     1.0                                            ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║ SCOPE                                                       ║");
            Console.WriteLine("║ Tested: Add, Delete, Find student record functionality      ║");
            Console.WriteLine("║ Tested: Input validation and error handling                  ║");
            Console.WriteLine("║ Tested: UI layout and control naming conventions             ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║ RESULTS SUMMARY                                             ║");
            Console.WriteLine("║ Total Test Cases:  15                                       ║");
            Console.WriteLine("║ Passed:            12 (80%)                                 ║");
            Console.WriteLine("║ Failed:             3 (20%)                                 ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║ DEFECTS FOUND                                               ║");
            Console.WriteLine("║ 1. [CRITICAL] No validation on Student Number — accepts     ║");
            Console.WriteLine("║    empty values (TC003)                                     ║");
            Console.WriteLine("║ 2. [HIGH] Delete does not confirm before removing record    ║");
            Console.WriteLine("║    (TC009)                                                  ║");
            Console.WriteLine("║ 3. [MEDIUM] Find function is case-sensitive — searching     ║");
            Console.WriteLine("║    'john' does not find 'John' (TC012)                      ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║ RECOMMENDATIONS                                             ║");
            Console.WriteLine("║ 1. Add required-field validation for Student Number field   ║");
            Console.WriteLine("║ 2. Add a confirmation dialog before deleting a record       ║");
            Console.WriteLine("║ 3. Make the Find function case-insensitive using ToLower()  ║");
            Console.WriteLine("║ 4. Retest all failed cases after fixes are applied          ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║ CONCLUSION                                                  ║");
            Console.WriteLine("║ The application is NOT ready for release due to 1 critical  ║");
            Console.WriteLine("║ defect. Once all defects are fixed and retested, the        ║");
            Console.WriteLine("║ application should be ready for deployment.                 ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝\n");
        }
    }

    // ========================================================================
    // MAIN PROGRAM — Run all Section A examples
    // ========================================================================
    class SectionAProgram
    {
        static void RunAllSectionA()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     SECTION A: SOFTWARE TESTING CONCEPTS — ALL EXAMPLES     ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝\n");

            FunctionalTestingExamples.RunFunctionalTests();
            NonFunctionalTestingExamples.RunPerformanceTest();
            LoadTestingExample.RunLoadTest();
            StressTestingExample.RunStressTest();
            BlackBoxTestingExamples.RunBlackBoxTests();
            WhiteBoxTestingExamples.RunWhiteBoxTests();
            EquivalencePartitioningExample.RunEquivalenceTests();
            BoundaryValueAnalysisExample.RunBoundaryTests();
            ErrorCaseTestingExample.RunErrorCaseTests();
            TestCaseStructureExample.ShowTestCaseExamples();
            TestResultsInterpretation.InterpretResults();
            TestSummaryExample.GenerateTestSummary();

            Console.WriteLine("=== END OF SECTION A ===");
        }
    }
}
