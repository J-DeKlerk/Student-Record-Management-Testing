// ============================================================================
// SECTION C: PRACTICAL SCENARIO — STUDENT RECORD MANAGEMENT APPLICATION
// ============================================================================
// This file demonstrates a complete Windows Forms application with:
//   - Properly named controls
//   - Add, Delete, and Find record functionality
//   - Input validation and error handling
//   - Button click event handlers
//   - Functional and non-functional test cases
//   - A professional software testing report
//   - GitHub workflow guidance
// ============================================================================

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SectionC_PracticalApplication
{
    // ========================================================================
    // 1. THE MAIN APPLICATION FORM
    // ========================================================================
    // CONTROL NAMING CONVENTIONS (memorise these!):
    //   btn  = Button         (btnAdd, btnDelete, btnFind, btnClear)
    //   txt  = TextBox        (txtStudentNumber, txtFirstName, txtSurname)
    //   lbl  = Label          (lblTitle, lblStudentNumber, lblStatus)
    //   lst  = ListBox        (lstStudents)
    //   cmb  = ComboBox       (cmbCourse)
    //   chk  = CheckBox       (chkActive)
    //   rb   = RadioButton    (rbMale, rbFemale)
    //   grp  = GroupBox       (grpStudentDetails)
    //   dgv  = DataGridView   (dgvStudents)
    //   pic  = PictureBox     (picLogo)
    //   rtb  = RichTextBox    (rtbNotes)
    // ========================================================================

    public class StudentRecordForm : Form
    {
        // ====================================================================
        // CONTROL DECLARATIONS — All controls declared with correct prefixes
        // ====================================================================
        private Label lblTitle;
        private Label lblStudentNumber;
        private Label lblFirstName;
        private Label lblSurname;
        private Label lblAge;
        private Label lblCourse;
        private Label lblStatus;

        private TextBox txtStudentNumber;
        private TextBox txtFirstName;
        private TextBox txtSurname;
        private TextBox txtAge;
        private ComboBox cmbCourse;

        private Button btnAdd;
        private Button btnDelete;
        private Button btnFind;
        private Button btnClear;
        private Button btnExit;

        private ListBox lstStudents;
        private GroupBox grpStudentDetails;

        // ====================================================================
        // DATA STORAGE — Using a List of a custom Student class
        // ====================================================================
        private List<Student> students = new List<Student>();

        // ====================================================================
        // CONSTRUCTOR — Sets up the form and all controls
        // ====================================================================
        public StudentRecordForm()
        {
            InitializeFormProperties();
            InitializeControls();
            AddControlsToForm();
            WireUpEvents();
        }

        private void InitializeFormProperties()
        {
            this.Text = "Student Record Management System";
            this.Size = new Size(750, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void InitializeControls()
        {
            // === Title ===
            lblTitle = new Label
            {
                Text = "Student Record Management",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(20, 10),
                AutoSize = true,
                ForeColor = Color.FromArgb(0, 102, 153)
            };

            // === GroupBox for student details ===
            grpStudentDetails = new GroupBox
            {
                Text = "Student Details",
                Location = new Point(20, 50),
                Size = new Size(350, 280),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            // Controls INSIDE the GroupBox
            Font normalFont = new Font("Segoe UI", 10, FontStyle.Regular);

            lblStudentNumber = new Label { Text = "Student No:", Location = new Point(15, 30), AutoSize = true, Font = normalFont };
            txtStudentNumber = new TextBox { Name = "txtStudentNumber", Location = new Point(140, 27), Size = new Size(180, 25), Font = normalFont };

            lblFirstName = new Label { Text = "First Name:", Location = new Point(15, 65), AutoSize = true, Font = normalFont };
            txtFirstName = new TextBox { Name = "txtFirstName", Location = new Point(140, 62), Size = new Size(180, 25), Font = normalFont };

            lblSurname = new Label { Text = "Surname:", Location = new Point(15, 100), AutoSize = true, Font = normalFont };
            txtSurname = new TextBox { Name = "txtSurname", Location = new Point(140, 97), Size = new Size(180, 25), Font = normalFont };

            lblAge = new Label { Text = "Age:", Location = new Point(15, 135), AutoSize = true, Font = normalFont };
            txtAge = new TextBox { Name = "txtAge", Location = new Point(140, 132), Size = new Size(80, 25), Font = normalFont };

            lblCourse = new Label { Text = "Course:", Location = new Point(15, 170), AutoSize = true, Font = normalFont };
            cmbCourse = new ComboBox
            {
                Name = "cmbCourse",
                Location = new Point(140, 167),
                Size = new Size(180, 25),
                Font = normalFont,
                DropDownStyle = ComboBoxStyle.DropDownList  // Prevents typing custom values
            };
            cmbCourse.Items.AddRange(new object[] { "IT", "Business", "Engineering", "Science", "Arts" });

            // Add controls to the GroupBox (not the form!)
            grpStudentDetails.Controls.AddRange(new Control[]
            {
                lblStudentNumber, txtStudentNumber,
                lblFirstName, txtFirstName,
                lblSurname, txtSurname,
                lblAge, txtAge,
                lblCourse, cmbCourse
            });

            // === Buttons ===
            int btnX = 20;
            int btnY = 345;
            int btnW = 100;
            int btnH = 40;
            int gap = 10;

            btnAdd = new Button
            {
                Name = "btnAdd", Text = "Add",
                Location = new Point(btnX, btnY), Size = new Size(btnW, btnH),
                BackColor = Color.FromArgb(40, 167, 69), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnDelete = new Button
            {
                Name = "btnDelete", Text = "Delete",
                Location = new Point(btnX + (btnW + gap), btnY), Size = new Size(btnW, btnH),
                BackColor = Color.FromArgb(220, 53, 69), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnFind = new Button
            {
                Name = "btnFind", Text = "Find",
                Location = new Point(btnX + 2 * (btnW + gap), btnY), Size = new Size(btnW, btnH),
                BackColor = Color.FromArgb(0, 123, 255), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnClear = new Button
            {
                Name = "btnClear", Text = "Clear",
                Location = new Point(btnX + 3 * (btnW + gap), btnY), Size = new Size(btnW, btnH),
                FlatStyle = FlatStyle.Flat
            };

            btnExit = new Button
            {
                Name = "btnExit", Text = "Exit",
                Location = new Point(620, 460), Size = new Size(90, 35),
                FlatStyle = FlatStyle.Flat
            };

            // === ListBox for displaying students ===
            lstStudents = new ListBox
            {
                Name = "lstStudents",
                Location = new Point(390, 70),
                Size = new Size(330, 260),
                Font = new Font("Consolas", 9)
            };

            // === Status label ===
            lblStatus = new Label
            {
                Name = "lblStatus", Text = "Ready.",
                Location = new Point(20, 470),
                AutoSize = true,
                ForeColor = Color.Gray
            };
        }

        private void AddControlsToForm()
        {
            this.Controls.AddRange(new Control[]
            {
                lblTitle, grpStudentDetails,
                btnAdd, btnDelete, btnFind, btnClear, btnExit,
                lstStudents, lblStatus
            });
        }

        // ====================================================================
        // WIRING UP EVENTS
        // ====================================================================
        // This connects each button to its event handler method.
        // Format: controlName.EventName += HandlerMethodName;
        // ====================================================================

        private void WireUpEvents()
        {
            btnAdd.Click    += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnFind.Click   += BtnFind_Click;
            btnClear.Click  += BtnClear_Click;
            btnExit.Click   += BtnExit_Click;
        }

        // ====================================================================
        // EVENT HANDLER: ADD — Validates input and adds a student record
        // ====================================================================

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // ── VALIDATION STEP 1: Check for empty fields ──
            if (string.IsNullOrWhiteSpace(txtStudentNumber.Text))
            {
                MessageBox.Show("Student Number is required.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentNumber.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                MessageBox.Show("Surname is required.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSurname.Focus();
                return;
            }

            // ── VALIDATION STEP 2: Check data types ──
            if (!int.TryParse(txtStudentNumber.Text, out int studentNumber) || studentNumber <= 0)
            {
                MessageBox.Show("Student Number must be a positive whole number.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStudentNumber.Focus();
                return;
            }

            if (!int.TryParse(txtAge.Text, out int age) || age < 16 || age > 99)
            {
                MessageBox.Show("Age must be a number between 16 and 99.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAge.Focus();
                return;
            }

            // ── VALIDATION STEP 3: Check ComboBox selection ──
            if (cmbCourse.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a course.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCourse.Focus();
                return;
            }

            // ── VALIDATION STEP 4: Check for duplicate student number ──
            foreach (Student s in students)
            {
                if (s.StudentNumber == studentNumber)
                {
                    MessageBox.Show($"Student Number {studentNumber} already exists.",
                        "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // ── ALL VALIDATION PASSED — Create and add the student ──
            Student newStudent = new Student
            {
                StudentNumber = studentNumber,
                FirstName = txtFirstName.Text.Trim(),
                Surname = txtSurname.Text.Trim(),
                Age = age,
                Course = cmbCourse.SelectedItem.ToString()
            };

            students.Add(newStudent);
            RefreshListBox();
            ClearFields();

            lblStatus.Text = $"Student {newStudent.FirstName} {newStudent.Surname} added successfully.";
            lblStatus.ForeColor = Color.Green;
        }

        // ====================================================================
        // EVENT HANDLER: DELETE — Removes selected student with confirmation
        // ====================================================================

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            // Check if a student is selected in the listbox
            if (lstStudents.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a student to delete.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // CONFIRMATION DIALOG — Always confirm before deleting!
            Student selectedStudent = students[lstStudents.SelectedIndex];
            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete:\n{selectedStudent.FirstName} {selectedStudent.Surname} ({selectedStudent.StudentNumber})?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                students.RemoveAt(lstStudents.SelectedIndex);
                RefreshListBox();
                ClearFields();

                lblStatus.Text = "Student record deleted.";
                lblStatus.ForeColor = Color.Red;
            }
        }

        // ====================================================================
        // EVENT HANDLER: FIND — Searches for a student by number or name
        // ====================================================================

        private void BtnFind_Click(object sender, EventArgs e)
        {
            // Can search by student number OR by name
            string searchTerm = txtStudentNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // If student number is empty, try searching by name
                searchTerm = txtFirstName.Text.Trim();
            }

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show("Enter a Student Number or First Name to search.",
                    "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Search through all students
            bool found = false;
            for (int i = 0; i < students.Count; i++)
            {
                Student s = students[i];

                // Case-insensitive comparison using ToLower()
                bool matchByNumber = s.StudentNumber.ToString() == searchTerm;
                bool matchByName = s.FirstName.ToLower().Contains(searchTerm.ToLower())
                                || s.Surname.ToLower().Contains(searchTerm.ToLower());

                if (matchByNumber || matchByName)
                {
                    // Populate the fields with found student's data
                    txtStudentNumber.Text = s.StudentNumber.ToString();
                    txtFirstName.Text = s.FirstName;
                    txtSurname.Text = s.Surname;
                    txtAge.Text = s.Age.ToString();
                    cmbCourse.SelectedItem = s.Course;

                    // Highlight the student in the listbox
                    lstStudents.SelectedIndex = i;

                    lblStatus.Text = $"Student found: {s.FirstName} {s.Surname}";
                    lblStatus.ForeColor = Color.Blue;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show($"No student found matching '{searchTerm}'.",
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblStatus.Text = "Student not found.";
                lblStatus.ForeColor = Color.Orange;
            }
        }

        // ====================================================================
        // EVENT HANDLER: CLEAR — Resets all input fields
        // ====================================================================

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            lstStudents.ClearSelected();
            lblStatus.Text = "Fields cleared.";
            lblStatus.ForeColor = Color.Gray;
        }

        // ====================================================================
        // EVENT HANDLER: EXIT — Closes the application with confirmation
        // ====================================================================

        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit Application",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // ====================================================================
        // HELPER METHODS
        // ====================================================================

        private void ClearFields()
        {
            txtStudentNumber.Clear();
            txtFirstName.Clear();
            txtSurname.Clear();
            txtAge.Clear();
            cmbCourse.SelectedIndex = -1;
            txtStudentNumber.Focus();
        }

        private void RefreshListBox()
        {
            lstStudents.Items.Clear();
            foreach (Student s in students)
            {
                // Format: "12345 | Thabo Molefe | IT | Age: 21"
                lstStudents.Items.Add(
                    $"{s.StudentNumber,-8} | {s.FirstName} {s.Surname,-15} | {s.Course,-12} | Age: {s.Age}");
            }
        }
    }

    // ========================================================================
    // 2. STUDENT CLASS — Data model
    // ========================================================================
    // A class to represent a student record. This keeps data organised
    // and is better practice than using parallel arrays.
    // ========================================================================

    public class Student
    {
        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }

        // Override ToString for easy display
        public override string ToString()
        {
            return $"{StudentNumber} - {FirstName} {Surname} ({Course}, Age {Age})";
        }
    }

    // ========================================================================
    // 3. COMPREHENSIVE FUNCTIONAL TEST CASES
    // ========================================================================
    // These test cases follow the proper structure:
    //   Test ID, Description, Pre-conditions, Steps, Test Data,
    //   Expected Result, Actual Result, Status, Type
    // ========================================================================

    public class TestCaseDefinitions
    {
        public static void DisplayAllTestCases()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║           FUNCTIONAL & NON-FUNCTIONAL TEST CASES                       ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝\n");

            // ================================================================
            // FUNCTIONAL TEST CASES
            // ================================================================
            Console.WriteLine("──────── FUNCTIONAL TEST CASES ────────\n");

            Console.WriteLine("TC-F01: Add a valid student record");
            Console.WriteLine("  Type:           Functional");
            Console.WriteLine("  Pre-conditions: Application is running, no records exist");
            Console.WriteLine("  Steps:          1. Enter Student No: 1001");
            Console.WriteLine("                  2. Enter First Name: Thabo");
            Console.WriteLine("                  3. Enter Surname: Molefe");
            Console.WriteLine("                  4. Enter Age: 21");
            Console.WriteLine("                  5. Select Course: IT");
            Console.WriteLine("                  6. Click 'Add' button");
            Console.WriteLine("  Expected:       Student appears in ListBox, status shows success");
            Console.WriteLine("  Actual:         Student appeared in ListBox correctly");
            Console.WriteLine("  Status:         PASS\n");

            Console.WriteLine("TC-F02: Add student with empty Student Number");
            Console.WriteLine("  Type:           Functional (Error-case / Negative test)");
            Console.WriteLine("  Pre-conditions: Application is running");
            Console.WriteLine("  Steps:          1. Leave Student No field EMPTY");
            Console.WriteLine("                  2. Fill in all other fields");
            Console.WriteLine("                  3. Click 'Add' button");
            Console.WriteLine("  Expected:       Error message: 'Student Number is required'");
            Console.WriteLine("  Actual:         Error message displayed correctly");
            Console.WriteLine("  Status:         PASS\n");

            Console.WriteLine("TC-F03: Add student with non-numeric Student Number");
            Console.WriteLine("  Type:           Functional (Error-case)");
            Console.WriteLine("  Pre-conditions: Application is running");
            Console.WriteLine("  Steps:          1. Enter Student No: 'ABC'");
            Console.WriteLine("                  2. Fill in other fields correctly");
            Console.WriteLine("                  3. Click 'Add' button");
            Console.WriteLine("  Expected:       Error message: 'Student Number must be a positive whole number'");
            Console.WriteLine("  Actual:         Error message displayed correctly");
            Console.WriteLine("  Status:         PASS\n");

            Console.WriteLine("TC-F04: Add duplicate Student Number");
            Console.WriteLine("  Type:           Functional (Error-case)");
            Console.WriteLine("  Pre-conditions: Student 1001 already exists");
            Console.WriteLine("  Steps:          1. Enter Student No: 1001 (duplicate)");
            Console.WriteLine("                  2. Fill in other fields");
            Console.WriteLine("                  3. Click 'Add' button");
            Console.WriteLine("  Expected:       Error message: 'Student Number 1001 already exists'");
            Console.WriteLine("  Actual:         Error message displayed correctly");
            Console.WriteLine("  Status:         PASS\n");

            Console.WriteLine("TC-F05: Add student with invalid age (boundary — below minimum)");
            Console.WriteLine("  Type:           Functional (Boundary Value Analysis)");
            Console.WriteLine("  Test Data:      Age = 15 (below minimum of 16)");
            Console.WriteLine("  Expected:       Error message: 'Age must be between 16 and 99'");
            Console.WriteLine("  Actual:         Error message displayed correctly");
            Console.WriteLine("  Status:         PASS\n");

            Console.WriteLine("TC-F06: Add student with valid age at lower boundary");
            Console.WriteLine("  Type:           Functional (Boundary Value Analysis)");
            Console.WriteLine("  Test Data:      Age = 16 (AT the lower boundary)");
            Console.WriteLine("  Expected:       Student added successfully");
            Console.WriteLine("  Actual:         Student added successfully");
            Console.WriteLine("  Status:         PASS\n");

            Console.WriteLine("TC-F07: Delete a student record with confirmation");
            Console.WriteLine("  Type:           Functional");
            Console.WriteLine("  Pre-conditions: At least one student exists");
            Console.WriteLine("  Steps:          1. Select a student in the ListBox");
            Console.WriteLine("                  2. Click 'Delete' button");
            Console.WriteLine("                  3. Click 'Yes' in confirmation dialog");
            Console.WriteLine("  Expected:       Student removed from list, status updated");
            Console.WriteLine("  Actual:         Student removed, status shows 'deleted'");
            Console.WriteLine("  Status:         PASS\n");

            Console.WriteLine("TC-F08: Delete with no student selected");
            Console.WriteLine("  Type:           Functional (Error-case)");
            Console.WriteLine("  Pre-conditions: Application is running");
            Console.WriteLine("  Steps:          1. Do NOT select any student");
            Console.WriteLine("                  2. Click 'Delete' button");
            Console.WriteLine("  Expected:       Message: 'Please select a student to delete'");
            Console.WriteLine("  Actual:         Message displayed correctly");
            Console.WriteLine("  Status:         PASS\n");

            Console.WriteLine("TC-F09: Find an existing student by Student Number");
            Console.WriteLine("  Type:           Functional");
            Console.WriteLine("  Pre-conditions: Student 1001 (Thabo) exists");
            Console.WriteLine("  Steps:          1. Enter Student No: 1001");
            Console.WriteLine("                  2. Click 'Find' button");
            Console.WriteLine("  Expected:       Fields populated with Thabo's details");
            Console.WriteLine("  Actual:         All fields populated correctly");
            Console.WriteLine("  Status:         PASS\n");

            Console.WriteLine("TC-F10: Find a student that does not exist");
            Console.WriteLine("  Type:           Functional (Error-case)");
            Console.WriteLine("  Steps:          1. Enter Student No: 9999");
            Console.WriteLine("                  2. Click 'Find'");
            Console.WriteLine("  Expected:       Message: 'No student found matching 9999'");
            Console.WriteLine("  Actual:         Message displayed correctly");
            Console.WriteLine("  Status:         PASS\n");

            Console.WriteLine("TC-F11: Find student using case-insensitive name search");
            Console.WriteLine("  Type:           Functional");
            Console.WriteLine("  Pre-conditions: Student 'Thabo' exists");
            Console.WriteLine("  Steps:          1. Enter First Name: 'thabo' (lowercase)");
            Console.WriteLine("                  2. Click 'Find'");
            Console.WriteLine("  Expected:       Student found (case-insensitive match)");
            Console.WriteLine("  Actual:         Student found correctly");
            Console.WriteLine("  Status:         PASS\n");

            Console.WriteLine("TC-F12: Clear all fields");
            Console.WriteLine("  Type:           Functional");
            Console.WriteLine("  Steps:          1. Enter data in all fields");
            Console.WriteLine("                  2. Click 'Clear' button");
            Console.WriteLine("  Expected:       All fields cleared, cursor in Student No field");
            Console.WriteLine("  Actual:         All fields cleared correctly");
            Console.WriteLine("  Status:         PASS\n");

            // ================================================================
            // NON-FUNCTIONAL TEST CASES
            // ================================================================
            Console.WriteLine("──────── NON-FUNCTIONAL TEST CASES ────────\n");

            Console.WriteLine("TC-NF01: Application loads within 3 seconds");
            Console.WriteLine("  Type:           Non-functional (Performance)");
            Console.WriteLine("  Steps:          1. Launch the application");
            Console.WriteLine("                  2. Measure time until form is fully displayed");
            Console.WriteLine("  Expected:       Form loads in under 3 seconds");
            Console.WriteLine("  Actual:         Form loaded in 0.8 seconds");
            Console.WriteLine("  Status:         PASS\n");

            Console.WriteLine("TC-NF02: All controls are correctly labelled and visible");
            Console.WriteLine("  Type:           Non-functional (Usability)");
            Console.WriteLine("  Steps:          1. Open the application");
            Console.WriteLine("                  2. Verify all labels, buttons, and fields are visible");
            Console.WriteLine("                  3. Verify controls have descriptive text");
            Console.WriteLine("  Expected:       All controls visible with clear labels");
            Console.WriteLine("  Actual:         All controls visible and labelled correctly");
            Console.WriteLine("  Status:         PASS\n");

            Console.WriteLine("TC-NF03: Tab order is logical (top-to-bottom, left-to-right)");
            Console.WriteLine("  Type:           Non-functional (Usability)");
            Console.WriteLine("  Steps:          1. Click in Student Number field");
            Console.WriteLine("                  2. Press Tab repeatedly");
            Console.WriteLine("  Expected:       Focus moves logically through all fields");
            Console.WriteLine("  Actual:         Tab order follows expected sequence");
            Console.WriteLine("  Status:         PASS\n");

            Console.WriteLine("TC-NF04: Error messages are user-friendly and descriptive");
            Console.WriteLine("  Type:           Non-functional (Usability)");
            Console.WriteLine("  Steps:          1. Trigger each validation error");
            Console.WriteLine("                  2. Check that messages are clear and helpful");
            Console.WriteLine("  Expected:       Messages explain what went wrong and what to do");
            Console.WriteLine("  Actual:         All messages are clear and descriptive");
            Console.WriteLine("  Status:         PASS\n");

            Console.WriteLine("TC-NF05: Application handles 100 records without performance issues");
            Console.WriteLine("  Type:           Non-functional (Load testing)");
            Console.WriteLine("  Steps:          1. Add 100 student records");
            Console.WriteLine("                  2. Verify Find and Delete still respond quickly");
            Console.WriteLine("  Expected:       Operations complete within 1 second");
            Console.WriteLine("  Actual:         Find completed in 0.1 seconds with 100 records");
            Console.WriteLine("  Status:         PASS\n");
        }
    }

    // ========================================================================
    // 4. IDENTIFYING DEFECTS AND WRITING RECOMMENDATIONS
    // ========================================================================
    // A DEFECT (BUG) is any behaviour that does not match the requirements.
    //
    // When documenting a defect, include:
    //   - Defect ID
    //   - Severity: Critical / High / Medium / Low
    //   - Description: What went wrong
    //   - Steps to reproduce: How to trigger the bug
    //   - Expected vs Actual behaviour
    //   - Recommendation: How to fix it
    //
    // SEVERITY LEVELS:
    //   Critical — System crashes, data loss, security breach
    //   High     — Major feature broken, no workaround
    //   Medium   — Feature partially works, has a workaround
    //   Low      — Cosmetic issue, spelling error, minor UI problem
    // ========================================================================

    public class DefectReportExamples
    {
        public static void ShowDefectReport()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              DEFECT REPORT WITH RECOMMENDATIONS                        ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝\n");

            Console.WriteLine("DEFECT-001");
            Console.WriteLine("  Severity:      CRITICAL");
            Console.WriteLine("  Description:   Application accepts empty Student Number and adds a record");
            Console.WriteLine("  Steps:         1. Leave Student Number empty");
            Console.WriteLine("                 2. Fill in other fields");
            Console.WriteLine("                 3. Click Add");
            Console.WriteLine("  Expected:      Error message displayed, record NOT added");
            Console.WriteLine("  Actual:        Record added with blank Student Number");
            Console.WriteLine("  Recommendation: Add validation check:");
            Console.WriteLine("                  if (string.IsNullOrWhiteSpace(txtStudentNumber.Text))");
            Console.WriteLine("                  { MessageBox.Show(\"Student Number required\"); return; }");
            Console.WriteLine();

            Console.WriteLine("DEFECT-002");
            Console.WriteLine("  Severity:      HIGH");
            Console.WriteLine("  Description:   Delete button removes record without confirmation");
            Console.WriteLine("  Steps:         1. Select a student");
            Console.WriteLine("                 2. Click Delete");
            Console.WriteLine("  Expected:      Confirmation dialog appears before deletion");
            Console.WriteLine("  Actual:        Record deleted immediately without confirmation");
            Console.WriteLine("  Recommendation: Add confirmation dialog:");
            Console.WriteLine("                  DialogResult result = MessageBox.Show(");
            Console.WriteLine("                    \"Are you sure?\", \"Confirm\", MessageBoxButtons.YesNo);");
            Console.WriteLine("                  if (result == DialogResult.Yes) { /* delete */ }");
            Console.WriteLine();

            Console.WriteLine("DEFECT-003");
            Console.WriteLine("  Severity:      MEDIUM");
            Console.WriteLine("  Description:   Find function is case-sensitive");
            Console.WriteLine("  Steps:         1. Add student 'Thabo'");
            Console.WriteLine("                 2. Search for 'thabo' (lowercase)");
            Console.WriteLine("  Expected:      Student found (case-insensitive match)");
            Console.WriteLine("  Actual:        'No student found' message displayed");
            Console.WriteLine("  Recommendation: Use .ToLower() for comparison:");
            Console.WriteLine("                  if (s.FirstName.ToLower().Contains(search.ToLower()))");
            Console.WriteLine();

            Console.WriteLine("DEFECT-004");
            Console.WriteLine("  Severity:      LOW");
            Console.WriteLine("  Description:   Button text 'Delet' has a spelling error");
            Console.WriteLine("  Steps:         1. Open the application");
            Console.WriteLine("                 2. Observe the Delete button");
            Console.WriteLine("  Expected:      Button text reads 'Delete'");
            Console.WriteLine("  Actual:        Button text reads 'Delet'");
            Console.WriteLine("  Recommendation: Correct the Text property: btnDelete.Text = \"Delete\";");
            Console.WriteLine();
        }
    }

    // ========================================================================
    // 5. PROFESSIONAL SOFTWARE TESTING REPORT
    // ========================================================================
    // This is the complete test summary report structure you need for exams.
    // ========================================================================

    public class TestReportGenerator
    {
        public static void GenerateReport()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                  SOFTWARE TESTING REPORT                                ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║ Project:        Student Record Management System                       ║");
            Console.WriteLine("║ Version:        1.0                                                    ║");
            Console.WriteLine("║ Tester:         [Your Full Name]                                       ║");
            Console.WriteLine("║ Date:           27 May 2026                                            ║");
            Console.WriteLine("║ Environment:    Windows 11, Visual Studio 2022, .NET Framework 4.8     ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                                                        ║");
            Console.WriteLine("║ 1. SCOPE OF TESTING                                                    ║");
            Console.WriteLine("║    The following features were tested:                                  ║");
            Console.WriteLine("║    - Add student record (with validation)                               ║");
            Console.WriteLine("║    - Delete student record (with confirmation)                          ║");
            Console.WriteLine("║    - Find student record (by number and name)                           ║");
            Console.WriteLine("║    - Clear input fields                                                 ║");
            Console.WriteLine("║    - Input validation (empty fields, invalid data, boundaries)          ║");
            Console.WriteLine("║    - UI layout, control naming, and usability                           ║");
            Console.WriteLine("║                                                                        ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                                                        ║");
            Console.WriteLine("║ 2. TEST RESULTS SUMMARY                                                ║");
            Console.WriteLine("║                                                                        ║");
            Console.WriteLine("║    Test Type       │ Total │ Passed │ Failed │ Pass Rate                ║");
            Console.WriteLine("║    ────────────────┼───────┼────────┼────────┼───────────               ║");
            Console.WriteLine("║    Functional      │   12  │   10   │    2   │  83.3%                   ║");
            Console.WriteLine("║    Non-functional  │    5  │    5   │    0   │ 100.0%                   ║");
            Console.WriteLine("║    ────────────────┼───────┼────────┼────────┼───────────               ║");
            Console.WriteLine("║    TOTAL           │   17  │   15   │    2   │  88.2%                   ║");
            Console.WriteLine("║                                                                        ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                                                        ║");
            Console.WriteLine("║ 3. DEFECTS FOUND                                                       ║");
            Console.WriteLine("║                                                                        ║");
            Console.WriteLine("║    ID        │ Severity │ Description                                   ║");
            Console.WriteLine("║    ──────────┼──────────┼────────────────────────────────────            ║");
            Console.WriteLine("║    DEF-001   │ CRITICAL │ Empty Student Number accepted                  ║");
            Console.WriteLine("║    DEF-002   │ HIGH     │ No delete confirmation dialog                  ║");
            Console.WriteLine("║                                                                        ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                                                        ║");
            Console.WriteLine("║ 4. RECOMMENDATIONS                                                     ║");
            Console.WriteLine("║                                                                        ║");
            Console.WriteLine("║    1. [CRITICAL] Add required-field validation for Student Number.      ║");
            Console.WriteLine("║       Use: if (string.IsNullOrWhiteSpace(txtStudentNumber.Text))        ║");
            Console.WriteLine("║                                                                        ║");
            Console.WriteLine("║    2. [HIGH] Implement confirmation dialog before deletion.             ║");
            Console.WriteLine("║       Use: MessageBox.Show with MessageBoxButtons.YesNo                 ║");
            Console.WriteLine("║                                                                        ║");
            Console.WriteLine("║    3. [GENERAL] Add try-catch blocks around all event handlers          ║");
            Console.WriteLine("║       to prevent unhandled exceptions from crashing the app.            ║");
            Console.WriteLine("║                                                                        ║");
            Console.WriteLine("║    4. [GENERAL] Retest all failed test cases after fixes are applied.   ║");
            Console.WriteLine("║                                                                        ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                                                        ║");
            Console.WriteLine("║ 5. CONCLUSION                                                          ║");
            Console.WriteLine("║                                                                        ║");
            Console.WriteLine("║    The application is NOT ready for release.                            ║");
            Console.WriteLine("║    1 critical and 1 high-severity defect must be resolved.              ║");
            Console.WriteLine("║    After fixes, a full regression test is recommended before            ║");
            Console.WriteLine("║    deployment. Non-functional testing passed all criteria.              ║");
            Console.WriteLine("║                                                                        ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝\n");
        }
    }

    // ========================================================================
    // 6. GITHUB WORKFLOW — BASIC COMMANDS AND CONCEPTS
    // ========================================================================
    // This section covers the essential GitHub workflow you need to know.
    //
    // KEY CONCEPTS:
    //   Repository (Repo)  — A project folder tracked by Git
    //   Commit             — A saved snapshot of your changes (like a save point)
    //   Branch             — A parallel version of your code
    //   Merge              — Combining one branch's changes into another
    //   Push               — Uploading your local commits to GitHub
    //   Pull               — Downloading changes from GitHub to your computer
    //   Clone              — Copying a remote repo to your local machine
    //
    // BASIC WORKFLOW:
    //   1. Create a repository on GitHub
    //   2. Clone it to your computer
    //   3. Create a branch for your work
    //   4. Make changes and commit them
    //   5. Push your branch to GitHub
    //   6. Create a Pull Request to merge into main
    //   7. Merge the branch
    //   8. Share the repository link
    // ========================================================================

    public class GitHubWorkflowGuide
    {
        public static void DisplayWorkflow()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    GITHUB WORKFLOW GUIDE                                ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝\n");

            Console.WriteLine("──── STEP 1: INITIAL SETUP (one-time) ────");
            Console.WriteLine("  Command: git config --global user.name \"Your Name\"");
            Console.WriteLine("  Command: git config --global user.email \"your.email@example.com\"\n");

            Console.WriteLine("──── STEP 2: CREATE & CLONE REPOSITORY ────");
            Console.WriteLine("  1. Go to github.com → New Repository");
            Console.WriteLine("  2. Name it (e.g., 'StudentRecordApp')");
            Console.WriteLine("  3. Add a README and .gitignore for C#");
            Console.WriteLine("  4. Clone to your computer:");
            Console.WriteLine("  Command: git clone https://github.com/YourUsername/StudentRecordApp.git");
            Console.WriteLine("  Command: cd StudentRecordApp\n");

            Console.WriteLine("──── STEP 3: CREATE A BRANCH ────");
            Console.WriteLine("  WHY: Branches let you work on features without affecting the main code.");
            Console.WriteLine("  Command: git branch develop              (create the branch)");
            Console.WriteLine("  Command: git checkout develop            (switch to the branch)");
            Console.WriteLine("  Or in one step:");
            Console.WriteLine("  Command: git checkout -b develop         (create AND switch)\n");

            Console.WriteLine("──── STEP 4: ADD YOUR PROJECT FILES ────");
            Console.WriteLine("  1. Copy your C# project files into the repo folder");
            Console.WriteLine("  2. Stage the files:");
            Console.WriteLine("  Command: git add .                       (stages ALL changes)");
            Console.WriteLine("  Command: git add Form1.cs                (stages a specific file)\n");

            Console.WriteLine("──── STEP 5: COMMIT YOUR CHANGES ────");
            Console.WriteLine("  WHY: A commit saves a snapshot of your work with a description.");
            Console.WriteLine("  Command: git commit -m \"Add student record form with CRUD operations\"");
            Console.WriteLine("  TIP: Write clear, descriptive commit messages!\n");
            Console.WriteLine("  Good messages:  'Add input validation for student number'");
            Console.WriteLine("                  'Fix delete button to include confirmation dialog'");
            Console.WriteLine("                  'Add find functionality with case-insensitive search'");
            Console.WriteLine("  Bad messages:   'update', 'fix stuff', 'asdfgh'\n");

            Console.WriteLine("──── STEP 6: PUSH TO GITHUB ────");
            Console.WriteLine("  Command: git push origin develop         (pushes the develop branch)\n");

            Console.WriteLine("──── STEP 7: MERGE INTO MAIN ────");
            Console.WriteLine("  Option A — Via GitHub website:");
            Console.WriteLine("    1. Go to your repo on GitHub");
            Console.WriteLine("    2. Click 'Pull Requests' → 'New Pull Request'");
            Console.WriteLine("    3. Set base: main ← compare: develop");
            Console.WriteLine("    4. Click 'Create Pull Request'");
            Console.WriteLine("    5. Click 'Merge Pull Request'\n");
            Console.WriteLine("  Option B — Via command line:");
            Console.WriteLine("  Command: git checkout main               (switch to main)");
            Console.WriteLine("  Command: git merge develop                (merge develop into main)");
            Console.WriteLine("  Command: git push origin main             (push to GitHub)\n");

            Console.WriteLine("──── STEP 8: SHARE YOUR REPOSITORY LINK ────");
            Console.WriteLine("  Your repo URL: https://github.com/YourUsername/StudentRecordApp");
            Console.WriteLine("  Include this link in your submission.\n");

            Console.WriteLine("──── COMMON GIT COMMANDS REFERENCE ────");
            Console.WriteLine("  git status                — See which files have changed");
            Console.WriteLine("  git log                   — View commit history");
            Console.WriteLine("  git log --oneline         — Compact commit history");
            Console.WriteLine("  git diff                  — See what has changed in files");
            Console.WriteLine("  git branch                — List all branches (* = current)");
            Console.WriteLine("  git branch -d branchname  — Delete a branch (after merging)");
            Console.WriteLine("  git pull origin main      — Download latest changes from GitHub");
            Console.WriteLine("  git stash                 — Temporarily save uncommitted changes");
            Console.WriteLine();

            Console.WriteLine("──── .GITIGNORE FOR C# PROJECTS ────");
            Console.WriteLine("  Your .gitignore should exclude build files:");
            Console.WriteLine("    bin/");
            Console.WriteLine("    obj/");
            Console.WriteLine("    *.user");
            Console.WriteLine("    *.suo");
            Console.WriteLine("    .vs/");
            Console.WriteLine("  GitHub provides a ready-made C# .gitignore template!\n");
        }
    }

    // ========================================================================
    // 7. SUBMISSION EVIDENCE CHECKLIST
    // ========================================================================

    public class SubmissionChecklist
    {
        public static void DisplayChecklist()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                  SUBMISSION EVIDENCE CHECKLIST                          ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝\n");

            Console.WriteLine("Check each item before submitting:\n");
            Console.WriteLine("  [ ] Screenshots showing the application running correctly");
            Console.WriteLine("  [ ] Screenshots of each feature working (Add, Delete, Find)");
            Console.WriteLine("  [ ] Screenshots of validation messages (error cases)");
            Console.WriteLine("  [ ] Screenshots of test results (which tests passed/failed)");
            Console.WriteLine("  [ ] Complete C# project files (.cs, .csproj, .sln)");
            Console.WriteLine("  [ ] Software Testing Report (with test cases and recommendations)");
            Console.WriteLine("  [ ] GitHub repository link (https://github.com/username/repo)");
            Console.WriteLine("  [ ] Evidence of branching (screenshot of branches or commit history)");
            Console.WriteLine("  [ ] Evidence of commits with meaningful messages");
            Console.WriteLine("  [ ] Evidence of merge (pull request or merge commit)");
            Console.WriteLine("  [ ] Defect report with severity levels and recommendations");
            Console.WriteLine("  [ ] All controls use correct naming conventions (btn, txt, lbl, etc.)");
            Console.WriteLine();
        }
    }

    // ========================================================================
    // MAIN PROGRAM — Run Section C
    // ========================================================================

    class SectionCProgram
    {
        /*
        // CONSOLE MODE — Display test cases, defect report, and guides
        static void Main(string[] args)
        {
            TestCaseDefinitions.DisplayAllTestCases();
            DefectReportExamples.ShowDefectReport();
            TestReportGenerator.GenerateReport();
            GitHubWorkflowGuide.DisplayWorkflow();
            SubmissionChecklist.DisplayChecklist();
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        */

        /*
        // WINDOWS FORMS MODE — Launch the Student Record Management app
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StudentRecordForm());
        }
        */
    }
}
