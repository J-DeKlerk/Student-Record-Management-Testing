// ============================================================================
// SECTION B: BASIC C# PROGRAMS — CONSOLE APPS & WINDOWS FORMS
// ============================================================================
// This file covers writing basic C# programs in Console Applications and
// Windows Forms Applications. Focus areas: displaying output, accepting
// user input, using controls, and event-driven functionality.
// ============================================================================

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace SectionB_BasicCSharp
{
    // ========================================================================
    // PART 1: CONSOLE APPLICATION EXAMPLES
    // ========================================================================

    // ========================================================================
    // 1.1 DISPLAYING OUTPUT CORRECTLY
    // ========================================================================
    // Console.WriteLine() — prints text and moves to the NEXT line
    // Console.Write()     — prints text and stays on the SAME line
    // String interpolation ($"...{variable}...") — embeds variables in text
    // Escape characters: \n = new line, \t = tab
    // ========================================================================

    public class ConsoleOutputExamples
    {
        public static void DemonstrateOutput()
        {
            Console.WriteLine("=== 1.1 DISPLAYING OUTPUT ===\n");

            // WriteLine — prints and moves to the next line
            Console.WriteLine("This is on line 1");
            Console.WriteLine("This is on line 2");

            // Write — prints and stays on the same line
            Console.Write("First part... ");
            Console.Write("Second part... ");
            Console.WriteLine("Third part (then new line).");

            // String interpolation — embedding variables in strings
            string name = "Thabo";
            int age = 22;
            Console.WriteLine($"\nHello, my name is {name} and I am {age} years old.");

            // Formatting numbers
            double price = 1299.5;
            Console.WriteLine($"Price: R{price:F2}");       // F2 = 2 decimal places → R1299.50
            Console.WriteLine($"Percentage: {0.875:P1}");    // P1 = percentage with 1 decimal → 87.5%

            // Escape characters
            Console.WriteLine("\nUsing escape characters:");
            Console.WriteLine("Tab separated:\tColumn1\tColumn2\tColumn3");
            Console.WriteLine("New line inside a string:\nThis is on a new line.");
            Console.WriteLine();
        }
    }

    // ========================================================================
    // 1.2 ACCEPTING USER INPUT
    // ========================================================================
    // Console.ReadLine() — reads a line of text (always returns a string)
    // int.Parse()        — converts string to integer (crashes if invalid)
    // int.TryParse()     — safely converts string to integer (returns bool)
    // double.Parse()     — converts string to double
    // Convert.ToInt32()  — another way to convert to integer
    //
    // IMPORTANT: Console.ReadLine() ALWAYS returns a string.
    // You must CONVERT it to the correct type (int, double, etc.)
    // ========================================================================

    public class ConsoleInputExamples
    {
        public static void DemonstrateInput()
        {
            Console.WriteLine("=== 1.2 ACCEPTING USER INPUT ===\n");

            // --- Reading a string input ---
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}!\n");

            // --- Reading an integer with Parse (simple but can crash) ---
            Console.Write("Enter your age: ");
            string ageInput = Console.ReadLine();
            // int.Parse will CRASH if the user types something that is not a number
            // Only use this when you KNOW the input will be valid
            // int age = int.Parse(ageInput);

            // --- Reading an integer with TryParse (SAFER — recommended) ---
            // TryParse returns true/false and doesn't crash on bad input
            bool isValid = int.TryParse(ageInput, out int age);
            if (isValid)
            {
                Console.WriteLine($"Your age is: {age}");
                Console.WriteLine($"In 10 years you will be: {age + 10}");
            }
            else
            {
                Console.WriteLine("That is not a valid number for age.");
            }

            // --- Reading a double ---
            Console.Write("\nEnter a price: R");
            string priceInput = Console.ReadLine();
            bool priceValid = double.TryParse(priceInput, out double price);
            if (priceValid)
            {
                double vat = price * 0.15;
                double total = price + vat;
                Console.WriteLine($"Price: R{price:F2}");
                Console.WriteLine($"VAT (15%): R{vat:F2}");
                Console.WriteLine($"Total: R{total:F2}");
            }
            else
            {
                Console.WriteLine("Invalid price entered.");
            }
            Console.WriteLine();
        }
    }

    // ========================================================================
    // 1.3 VARIABLES, DATA TYPES, AND OPERATORS
    // ========================================================================
    // Common data types:
    //   int     — whole numbers (e.g., 42)
    //   double  — decimal numbers (e.g., 3.14)
    //   string  — text (e.g., "Hello")
    //   char    — single character (e.g., 'A')
    //   bool    — true or false
    //
    // Operators:
    //   Arithmetic: +  -  *  /  % (modulus/remainder)
    //   Comparison: ==  !=  <  >  <=  >=
    //   Logical:    && (AND)  || (OR)  ! (NOT)
    //   Assignment: =  +=  -=  *=  /=
    // ========================================================================

    public class VariablesAndOperators
    {
        public static void Demonstrate()
        {
            Console.WriteLine("=== 1.3 VARIABLES, DATA TYPES, AND OPERATORS ===\n");

            // Declaring variables of different types
            int studentNumber = 2024001;
            double averageMark = 72.5;
            string studentName = "Lerato Molefe";
            char grade = 'B';
            bool hasPassed = true;

            Console.WriteLine($"Student: {studentName}");
            Console.WriteLine($"Number:  {studentNumber}");
            Console.WriteLine($"Average: {averageMark:F1}%");
            Console.WriteLine($"Grade:   {grade}");
            Console.WriteLine($"Passed:  {hasPassed}\n");

            // Arithmetic operators
            int a = 17;
            int b = 5;
            Console.WriteLine($"Arithmetic with a={a}, b={b}:");
            Console.WriteLine($"  a + b = {a + b}");    // Addition: 22
            Console.WriteLine($"  a - b = {a - b}");    // Subtraction: 12
            Console.WriteLine($"  a * b = {a * b}");    // Multiplication: 85
            Console.WriteLine($"  a / b = {a / b}");    // Integer division: 3 (not 3.4!)
            Console.WriteLine($"  a % b = {a % b}");    // Modulus (remainder): 2

            // IMPORTANT: Integer division truncates — use double for decimals
            double result = (double)a / b;
            Console.WriteLine($"  (double)a / b = {result:F2}");  // 3.40

            // Comparison operators
            Console.WriteLine($"\nComparison operators:");
            Console.WriteLine($"  a == b: {a == b}");  // false
            Console.WriteLine($"  a != b: {a != b}");  // true
            Console.WriteLine($"  a > b:  {a > b}");   // true
            Console.WriteLine($"  a < b:  {a < b}");   // false

            // Logical operators
            bool x = true;
            bool y = false;
            Console.WriteLine($"\nLogical operators (x=true, y=false):");
            Console.WriteLine($"  x && y (AND): {x && y}");  // false — both must be true
            Console.WriteLine($"  x || y (OR):  {x || y}");  // true  — at least one true
            Console.WriteLine($"  !x (NOT):     {!x}");      // false — opposite
            Console.WriteLine();
        }
    }

    // ========================================================================
    // 1.4 SELECTION STRUCTURES (IF / ELSE IF / ELSE / SWITCH)
    // ========================================================================
    // if          — executes code if a condition is true
    // else if     — checks another condition if the previous was false
    // else        — executes if NO conditions were true
    // switch/case — selects one of many code blocks based on a value
    // ========================================================================

    public class SelectionStructures
    {
        public static void Demonstrate()
        {
            Console.WriteLine("=== 1.4 SELECTION STRUCTURES ===\n");

            // --- IF / ELSE IF / ELSE ---
            int mark = 67;
            string gradeResult;

            if (mark >= 75)
            {
                gradeResult = "Distinction (A)";
            }
            else if (mark >= 60)
            {
                gradeResult = "Merit (B)";
            }
            else if (mark >= 50)
            {
                gradeResult = "Pass (C)";
            }
            else
            {
                gradeResult = "Fail (F)";
            }

            Console.WriteLine($"Mark: {mark}% → Grade: {gradeResult}\n");

            // --- SWITCH / CASE ---
            // Best used when comparing ONE variable against specific values
            string dayOfWeek = "Wednesday";

            switch (dayOfWeek)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    Console.WriteLine($"{dayOfWeek} is a weekday.");
                    break;
                case "Saturday":
                case "Sunday":
                    Console.WriteLine($"{dayOfWeek} is a weekend day.");
                    break;
                default:
                    Console.WriteLine("Invalid day.");
                    break;
            }
            Console.WriteLine();
        }
    }

    // ========================================================================
    // 1.5 ITERATION / LOOPS (FOR, WHILE, DO-WHILE, FOREACH)
    // ========================================================================
    // for      — used when you know HOW MANY times to loop
    // while    — loops WHILE a condition is true (checks BEFORE looping)
    // do-while — loops at least ONCE, then checks the condition
    // foreach  — loops through each item in a collection/array
    // ========================================================================

    public class LoopExamples
    {
        public static void Demonstrate()
        {
            Console.WriteLine("=== 1.5 LOOP / ITERATION EXAMPLES ===\n");

            // --- FOR LOOP ---
            // Use when you know exactly how many iterations
            Console.WriteLine("For loop — counting 1 to 5:");
            for (int i = 1; i <= 5; i++)
            {
                Console.Write($"  {i}");
            }
            Console.WriteLine("\n");

            // --- WHILE LOOP ---
            // Use when the number of iterations depends on a condition
            Console.WriteLine("While loop — doubling until > 100:");
            int value = 1;
            while (value <= 100)
            {
                Console.Write($"  {value}");
                value *= 2;  // Double the value each time
            }
            Console.WriteLine("\n");

            // --- DO-WHILE LOOP ---
            // Always executes at least once
            Console.WriteLine("Do-while loop — menu simulation:");
            int choice = 0;
            int iteration = 0;
            do
            {
                iteration++;
                // Simulating user picking option 3 on second try
                choice = (iteration == 2) ? 3 : 1;
                Console.WriteLine($"  Iteration {iteration}: User selected option {choice}");
            } while (choice != 3);
            Console.WriteLine();

            // --- FOREACH LOOP ---
            // Best for iterating through collections/arrays
            Console.WriteLine("Foreach loop — iterating through a list:");
            string[] students = { "Thabo", "Lerato", "Sipho", "Naledi", "James" };
            foreach (string student in students)
            {
                Console.WriteLine($"  Student: {student}");
            }
            Console.WriteLine();
        }
    }

    // ========================================================================
    // 1.6 ARRAYS AND LISTS
    // ========================================================================
    // Array — fixed-size collection of items of the same type
    // List  — dynamic-size collection (can add/remove items)
    //
    // Arrays:  string[] names = new string[5];   or   = {"A","B","C"};
    // Lists:   List<string> names = new List<string>();
    //
    // IMPORTANT: Arrays and Lists are ZERO-INDEXED (first item is index 0)
    // ========================================================================

    public class ArraysAndLists
    {
        public static void Demonstrate()
        {
            Console.WriteLine("=== 1.6 ARRAYS AND LISTS ===\n");

            // --- ARRAYS (fixed size) ---
            string[] subjects = { "Maths", "English", "Science", "IT", "Life Skills" };
            Console.WriteLine($"Array has {subjects.Length} items.");
            Console.WriteLine($"First item (index 0): {subjects[0]}");
            Console.WriteLine($"Last item (index {subjects.Length - 1}): {subjects[subjects.Length - 1]}\n");

            // Looping through an array
            Console.WriteLine("All subjects:");
            for (int i = 0; i < subjects.Length; i++)
            {
                Console.WriteLine($"  [{i}] {subjects[i]}");
            }

            // --- LISTS (dynamic size) ---
            Console.WriteLine("\nList — dynamic size:");
            List<string> studentList = new List<string>();

            // Adding items
            studentList.Add("Thabo");
            studentList.Add("Lerato");
            studentList.Add("Sipho");
            Console.WriteLine($"After adding 3 students: Count = {studentList.Count}");

            // Removing items
            studentList.Remove("Lerato");
            Console.WriteLine($"After removing Lerato: Count = {studentList.Count}");

            // Checking if item exists
            bool found = studentList.Contains("Sipho");
            Console.WriteLine($"Contains 'Sipho': {found}");

            // Finding index
            int index = studentList.IndexOf("Thabo");
            Console.WriteLine($"Index of 'Thabo': {index}");

            // Looping through a list
            Console.WriteLine("\nRemaining students:");
            foreach (string s in studentList)
            {
                Console.WriteLine($"  - {s}");
            }
            Console.WriteLine();
        }
    }

    // ========================================================================
    // 1.7 METHODS / FUNCTIONS
    // ========================================================================
    // A method is a reusable block of code that performs a specific task.
    //
    // Method signature:
    //   [access modifier] [return type] MethodName([parameters])
    //   e.g.:  public static double CalculateAverage(int[] marks)
    //
    // void   — the method does NOT return a value
    // return — sends a value back to the caller
    //
    // Parameters — values passed INTO the method
    // Return value — the value sent BACK from the method
    // ========================================================================

    public class MethodExamples
    {
        // A void method — does something but returns nothing
        public static void DisplayGreeting(string name)
        {
            Console.WriteLine($"  Welcome, {name}! Good luck with your studies.");
        }

        // A method that returns a value
        public static double CalculateAverage(int[] marks)
        {
            int total = 0;
            foreach (int mark in marks)
            {
                total += mark;
            }
            return (double)total / marks.Length;
        }

        // A method with multiple parameters and a return value
        public static string DetermineResult(string studentName, double average)
        {
            string result = average >= 50 ? "PASSED" : "FAILED";
            return $"{studentName} has {result} with an average of {average:F1}%.";
        }

        public static void Demonstrate()
        {
            Console.WriteLine("=== 1.7 METHODS / FUNCTIONS ===\n");

            // Calling a void method
            DisplayGreeting("Thabo");
            DisplayGreeting("Lerato");

            // Calling a method that returns a value
            int[] marks = { 78, 65, 82, 90, 55 };
            double avg = CalculateAverage(marks);
            Console.WriteLine($"\n  Marks: {string.Join(", ", marks)}");
            Console.WriteLine($"  Average: {avg:F1}%");

            // Using the return value of a method
            string outcome = DetermineResult("Thabo", avg);
            Console.WriteLine($"  {outcome}");
            Console.WriteLine();
        }
    }

    // ========================================================================
    // PART 2: WINDOWS FORMS APPLICATION EXAMPLES
    // ========================================================================
    // Windows Forms (WinForms) is a GUI framework for building desktop
    // applications with visual controls like buttons, textboxes, labels, etc.
    //
    // KEY CONCEPTS:
    //   - Controls: Visual elements (Button, TextBox, Label, ListBox, etc.)
    //   - Properties: Settings of controls (Text, Name, Size, Location, etc.)
    //   - Events: Actions that trigger code (Click, TextChanged, Load, etc.)
    //   - Event Handlers: Methods that run when an event occurs
    //
    // NAMING CONVENTIONS (VERY IMPORTANT FOR EXAMS):
    //   Prefix + PurposeName in camelCase or PascalCase:
    //   - Button:    btnSave, btnDelete, btnSearch
    //   - TextBox:   txtName, txtAge, txtStudentNumber
    //   - Label:     lblTitle, lblResult, lblError
    //   - ListBox:   lstStudents, lstResults
    //   - ComboBox:  cmbCourse, cmbYear
    //   - CheckBox:  chkAgree, chkActive
    //   - RadioButton: rbMale, rbFemale
    //   - GroupBox:  grpPersonalInfo, grpOptions
    //   - PictureBox: picLogo, picProfile
    //   - DataGridView: dgvStudents, dgvResults
    // ========================================================================

    // ========================================================================
    // 2.1 BASIC WINDOWS FORM — Greeting Application
    // ========================================================================
    // This demonstrates: creating a form, adding controls programmatically,
    // handling button click events, reading input, and displaying output.
    // ========================================================================

    public class GreetingForm : Form
    {
        // Step 1: Declare controls with CORRECT naming conventions
        private Label lblTitle;
        private Label lblName;
        private TextBox txtName;
        private Button btnGreet;
        private Button btnClear;
        private Label lblResult;

        public GreetingForm()
        {
            // Step 2: Set up the form properties
            this.Text = "Greeting Application";     // Title bar text
            this.Size = new Size(420, 300);          // Width x Height in pixels
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);

            // Step 3: Create and configure controls

            // Title label
            lblTitle = new Label();
            lblTitle.Text = "Welcome to My Application";
            lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.AutoSize = true;

            // Name label
            lblName = new Label();
            lblName.Text = "Enter your name:";
            lblName.Location = new Point(20, 65);
            lblName.AutoSize = true;

            // Name textbox
            txtName = new TextBox();
            txtName.Name = "txtName";  // IMPORTANT: Set the Name property
            txtName.Location = new Point(170, 62);
            txtName.Size = new Size(200, 25);

            // Greet button
            btnGreet = new Button();
            btnGreet.Name = "btnGreet";
            btnGreet.Text = "Greet Me";
            btnGreet.Location = new Point(20, 110);
            btnGreet.Size = new Size(120, 35);
            btnGreet.BackColor = Color.FromArgb(0, 122, 204);
            btnGreet.ForeColor = Color.White;
            // Step 4: ATTACH EVENT HANDLER — this is what makes the button work!
            btnGreet.Click += BtnGreet_Click;

            // Clear button
            btnClear = new Button();
            btnClear.Name = "btnClear";
            btnClear.Text = "Clear";
            btnClear.Location = new Point(160, 110);
            btnClear.Size = new Size(120, 35);
            btnClear.Click += BtnClear_Click;

            // Result label
            lblResult = new Label();
            lblResult.Name = "lblResult";
            lblResult.Text = "";
            lblResult.Location = new Point(20, 170);
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 11);
            lblResult.ForeColor = Color.DarkGreen;

            // Step 5: Add all controls to the form
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(btnGreet);
            this.Controls.Add(btnClear);
            this.Controls.Add(lblResult);
        }

        // ====================================================================
        // EVENT HANDLERS
        // ====================================================================
        // An event handler is a method that runs when an event occurs.
        // The naming convention is: ControlName_EventName
        // e.g., btnGreet_Click, txtName_TextChanged, Form1_Load
        //
        // The method signature for a Click event is always:
        //   private void ButtonName_Click(object sender, EventArgs e)
        //
        // 'sender' = the control that triggered the event
        // 'e'      = additional event information
        // ====================================================================

        // Button click event — displays a greeting message
        private void BtnGreet_Click(object sender, EventArgs e)
        {
            // INPUT VALIDATION — always check before processing!
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                // Show an error message using MessageBox
                MessageBox.Show("Please enter your name.",
                                "Input Required",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtName.Focus(); // Put cursor back in the textbox
                return;          // Stop the method — don't continue
            }

            // Display the greeting
            string name = txtName.Text.Trim();
            lblResult.Text = $"Hello, {name}! Welcome to the application.";
        }

        // Clear button event — resets all controls
        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();     // Clear the textbox
            lblResult.Text = ""; // Clear the result label
            txtName.Focus();     // Put cursor back in the textbox
        }
    }

    // ========================================================================
    // 2.2 CALCULATOR FORM — Demonstrates multiple operations and validation
    // ========================================================================

    public class CalculatorForm : Form
    {
        private Label lblTitle;
        private Label lblNum1;
        private Label lblNum2;
        private TextBox txtNum1;
        private TextBox txtNum2;
        private Button btnAdd;
        private Button btnSubtract;
        private Button btnMultiply;
        private Button btnDivide;
        private Label lblResult;
        private Button btnClear;

        public CalculatorForm()
        {
            this.Text = "Simple Calculator";
            this.Size = new Size(400, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);

            // Title
            lblTitle = new Label { Text = "Simple Calculator", Font = new Font("Segoe UI", 14, FontStyle.Bold),
                                   Location = new Point(20, 10), AutoSize = true };

            // Number 1
            lblNum1 = new Label { Text = "Number 1:", Location = new Point(20, 55), AutoSize = true };
            txtNum1 = new TextBox { Name = "txtNum1", Location = new Point(120, 52), Size = new Size(220, 25) };

            // Number 2
            lblNum2 = new Label { Text = "Number 2:", Location = new Point(20, 95), AutoSize = true };
            txtNum2 = new TextBox { Name = "txtNum2", Location = new Point(120, 92), Size = new Size(220, 25) };

            // Operation buttons
            int btnY = 140;
            int btnW = 80;
            int btnH = 35;
            btnAdd      = new Button { Name = "btnAdd",      Text = "+", Location = new Point(20, btnY),  Size = new Size(btnW, btnH) };
            btnSubtract = new Button { Name = "btnSubtract", Text = "-", Location = new Point(110, btnY), Size = new Size(btnW, btnH) };
            btnMultiply = new Button { Name = "btnMultiply", Text = "×", Location = new Point(200, btnY), Size = new Size(btnW, btnH) };
            btnDivide   = new Button { Name = "btnDivide",   Text = "÷", Location = new Point(290, btnY), Size = new Size(btnW, btnH) };

            // Wire up events — each button calls the SAME handler with different logic
            btnAdd.Click      += (s, e) => Calculate('+');
            btnSubtract.Click += (s, e) => Calculate('-');
            btnMultiply.Click += (s, e) => Calculate('*');
            btnDivide.Click   += (s, e) => Calculate('/');

            // Result
            lblResult = new Label { Name = "lblResult", Text = "Result: ", Location = new Point(20, 200),
                                    AutoSize = true, Font = new Font("Segoe UI", 12, FontStyle.Bold) };

            // Clear
            btnClear = new Button { Name = "btnClear", Text = "Clear", Location = new Point(20, 250), Size = new Size(100, 35) };
            btnClear.Click += (s, e) => { txtNum1.Clear(); txtNum2.Clear(); lblResult.Text = "Result: "; txtNum1.Focus(); };

            // Add all controls
            this.Controls.AddRange(new Control[] {
                lblTitle, lblNum1, txtNum1, lblNum2, txtNum2,
                btnAdd, btnSubtract, btnMultiply, btnDivide,
                lblResult, btnClear
            });
        }

        // Shared calculation method — demonstrates input validation
        private void Calculate(char operation)
        {
            // VALIDATION: Check both inputs are valid numbers
            if (!double.TryParse(txtNum1.Text, out double num1))
            {
                MessageBox.Show("Please enter a valid number for Number 1.",
                                "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNum1.Focus();
                return;
            }

            if (!double.TryParse(txtNum2.Text, out double num2))
            {
                MessageBox.Show("Please enter a valid number for Number 2.",
                                "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNum2.Focus();
                return;
            }

            double result = 0;
            switch (operation)
            {
                case '+': result = num1 + num2; break;
                case '-': result = num1 - num2; break;
                case '*': result = num1 * num2; break;
                case '/':
                    // VALIDATION: Check for division by zero
                    if (num2 == 0)
                    {
                        MessageBox.Show("Cannot divide by zero!",
                                        "Math Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    result = num1 / num2;
                    break;
            }

            lblResult.Text = $"Result: {num1} {operation} {num2} = {result:F2}";
        }
    }

    // ========================================================================
    // 2.3 COMPREHENSIVE CONSOLE APPLICATION EXAMPLE
    // ========================================================================
    // This demonstrates a complete, structured console application with:
    //   - A menu system
    //   - User input and validation
    //   - Methods for each feature
    //   - Proper output formatting
    // ========================================================================

    public class StudentConsoleApp
    {
        // Parallel arrays to store student data
        static string[] studentNames = new string[100];
        static int[] studentNumbers = new int[100];
        static double[] studentAverages = new double[100];
        static int studentCount = 0;

        public static void RunConsoleApp()
        {
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║     Student Management Console App      ║");
            Console.WriteLine("╚══════════════════════════════════════════╝\n");

            bool running = true;
            while (running)
            {
                // Display menu
                Console.WriteLine("──── MAIN MENU ────");
                Console.WriteLine("1. Add a Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Search for a Student");
                Console.WriteLine("4. Calculate Class Average");
                Console.WriteLine("5. Exit");
                Console.Write("\nEnter your choice (1-5): ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": AddStudent(); break;
                    case "2": DisplayAllStudents(); break;
                    case "3": SearchStudent(); break;
                    case "4": CalculateClassAverage(); break;
                    case "5":
                        running = false;
                        Console.WriteLine("\nGoodbye! Thank you for using the app.\n");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice. Please enter 1-5.\n");
                        break;
                }
            }
        }

        static void AddStudent()
        {
            Console.WriteLine("\n── Add Student ──");

            if (studentCount >= 100)
            {
                Console.WriteLine("Error: Maximum capacity reached.\n");
                return;
            }

            // Get and validate student name
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Error: Name cannot be empty.\n");
                return;
            }

            // Get and validate student number
            Console.Write("Enter student number: ");
            if (!int.TryParse(Console.ReadLine(), out int number) || number <= 0)
            {
                Console.WriteLine("Error: Please enter a valid positive student number.\n");
                return;
            }

            // Get and validate average mark
            Console.Write("Enter average mark (0-100): ");
            if (!double.TryParse(Console.ReadLine(), out double average) || average < 0 || average > 100)
            {
                Console.WriteLine("Error: Average must be a number between 0 and 100.\n");
                return;
            }

            // Store the student
            studentNames[studentCount] = name;
            studentNumbers[studentCount] = number;
            studentAverages[studentCount] = average;
            studentCount++;

            Console.WriteLine($"\nStudent '{name}' added successfully! Total students: {studentCount}\n");
        }

        static void DisplayAllStudents()
        {
            Console.WriteLine("\n── All Students ──");
            if (studentCount == 0)
            {
                Console.WriteLine("No students recorded yet.\n");
                return;
            }

            Console.WriteLine($"{"No.",-5} {"Name",-20} {"Number",-12} {"Average",-10} {"Result",-10}");
            Console.WriteLine(new string('-', 57));

            for (int i = 0; i < studentCount; i++)
            {
                string result = studentAverages[i] >= 50 ? "PASS" : "FAIL";
                Console.WriteLine($"{i + 1,-5} {studentNames[i],-20} {studentNumbers[i],-12} {studentAverages[i],-10:F1} {result,-10}");
            }
            Console.WriteLine();
        }

        static void SearchStudent()
        {
            Console.WriteLine("\n── Search Student ──");
            Console.Write("Enter student name to search: ");
            string searchName = Console.ReadLine();

            bool found = false;
            for (int i = 0; i < studentCount; i++)
            {
                // Case-insensitive search using ToLower()
                if (studentNames[i].ToLower().Contains(searchName.ToLower()))
                {
                    Console.WriteLine($"\nFound: {studentNames[i]} | No: {studentNumbers[i]} | Average: {studentAverages[i]:F1}%");
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine($"No student matching '{searchName}' was found.");

            Console.WriteLine();
        }

        static void CalculateClassAverage()
        {
            Console.WriteLine("\n── Class Average ──");
            if (studentCount == 0)
            {
                Console.WriteLine("No students to calculate average for.\n");
                return;
            }

            double total = 0;
            for (int i = 0; i < studentCount; i++)
                total += studentAverages[i];

            double classAvg = total / studentCount;
            Console.WriteLine($"Class average: {classAvg:F1}%\n");
        }
    }

    // ========================================================================
    // MAIN — Entry point to run Section B examples
    // ========================================================================

    class SectionBProgram
    {
        // To run the console examples, uncomment the Main method below
        // and comment out the Windows Forms Main.

        /*
        // CONSOLE APP MAIN — Run this for console examples
        static void Main(string[] args)
        {
            ConsoleOutputExamples.DemonstrateOutput();
            VariablesAndOperators.Demonstrate();
            SelectionStructures.Demonstrate();
            LoopExamples.Demonstrate();
            ArraysAndLists.Demonstrate();
            MethodExamples.Demonstrate();
            
            // Interactive console examples (require user input):
            // ConsoleInputExamples.DemonstrateInput();
            // StudentConsoleApp.RunConsoleApp();
            
            Console.ReadKey();
        }
        */

        /*
        // WINDOWS FORMS MAIN — Run this to launch the Greeting Form
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Change the form class to launch different examples:
            Application.Run(new GreetingForm());       // Basic greeting app
            // Application.Run(new CalculatorForm());   // Calculator app
        }
        */
    }
}
