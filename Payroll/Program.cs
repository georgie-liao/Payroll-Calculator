using System;
using System.IO;

/************************ Good Kiwi Garage Payroll System ************************/

/* STUDENT ID: S00019838 / STUDENT NAME: GEORGE LIAO */


namespace PayrollSystem  // This namespace is called PayrollSystem
{
    class program // This class is a program
    {

        class main // Main class
        {
            static void Main(string[] args) 
            {
                Static.runner();
            }
        } // End of Main


        struct Employee // This is Employee Structure
        {
            // Declare variables
            public int ID;
            public string FirstName;
            public string LastName;
            public double AnnualSalary;
            public double KiwiSaverPercentage;
            public double Payroll;
            public double HourlyRate;
            public double WorkedHours;
            public double FortnightGrossPay;
            public double FortnightNetPayroll;
            public double Tax;
            public double KiwiSaver;

            
            public Employee(int employeeId, string employeeFirstName, string employeeLastName, double employeeAnnualSalary, double employeeKiwiSaverPercentage) // Emplpoyee constructor
            {
                this.ID = employeeId;
                this.FirstName = employeeFirstName;
                this.LastName = employeeLastName;
                this.AnnualSalary = employeeAnnualSalary;
                this.KiwiSaverPercentage = employeeKiwiSaverPercentage;
                this.Payroll = this.HourlyRate = this.WorkedHours = 0;
                this.FortnightGrossPay = this.FortnightNetPayroll = this.Tax = this.KiwiSaver = 0;
                payrollCalculation();
            } // End of Emplpoyee constructor

            public void payrollCalculation() // This calculates the employee's fortnight payroll
            {
                this.HourlyRate = (this.AnnualSalary / 52 / 40); // Employee's hourly rate calculation
                this.FortnightGrossPay = this.HourlyRate * 80; // Employee's fornight gross pay calculation
                this.KiwiSaver = this.FortnightGrossPay * this.KiwiSaverPercentage / 100; // Employee's KiwiSaver calculation
                this.WorkedHours = 80; // Employee fornight worked hours 

                // Employee's tax calculaiton with tax rate based on their annual salary
                if (this.AnnualSalary <= 14000)
                    this.Tax = this.FortnightGrossPay * 0.105;
                else if (this.AnnualSalary <= 48000)
                    this.Tax = this.FortnightGrossPay * 0.175;
                else if (this.AnnualSalary <= 70000)
                    this.Tax = this.FortnightGrossPay * 0.3;
                else if (this.AnnualSalary <= 180000)
                    this.Tax = this.FortnightGrossPay * 0.33;
                else
                    Tax = this.FortnightGrossPay * 0.39;

                this.FortnightNetPayroll = this.FortnightGrossPay - KiwiSaver - Tax;  // Employee's fortnite net pay calculation
            } // End of payrollCalculation

            public string employeeRecords() // This is the record of employee
            {
                return String.Format("|{0,-7}\t|{1,-10}\t|{2,-10}\t|{3,-10}\t|{4,-15}|", // The array to put employee records

               this.ID, 
               this.FirstName, 
               this.LastName, 
               this.AnnualSalary, 
               this.KiwiSaverPercentage + "%");
            } // End of employeeRecords


            public string printPayrollStatment() // This prints employee's payroll statement
            {
                return
                    "\n\n" + // Next lines to make space
                    "\t"  + "*** Employee Payroll Statement ***" + "\t" + "\n"+ // Print title
                    new string('.', 50) + "\n\n" + // Print line 
                    "Employee ID : " + this.ID + "\n" +  // Print Employee ID
                    "First Name : " + this.FirstName + "\n" +  // Print Employee firt name
                    "Last Name : " + this.LastName + "\n" +  // // Print Employee last name
                    "Annual Salary : " + "$" + this.AnnualSalary + "\n" + // Print employee annual salary
                    "KiwiSaver Percentage : " + this.KiwiSaverPercentage + "%" + "\n" + // print employee KiwiSaver percentage
                    "\n" + // Make space
                    new string('.', 50) + "\n\n" + // Print line
                    "Fortnight calculation:" + "\n" + // Print fornight title
                    "Hourly Rate : " + "$" + (float)Math.Round(this.HourlyRate) + "\n" + // Print employee hourly rate
                    "Worked Hours : " + this.WorkedHours + "hours" + "\n" + // Print employee fortnight worked hours
                    "Gross Pay : " + "$" + (float)Math.Round(this.FortnightGrossPay) + "\n" + "\n" + // Print fornight gross pay

                    "Deducations :" + "\n" + //Print decucaiton title
                    "Tax : " + "$"  + (float)Math.Round(this.Tax) + "\n" + // Print fornight tax
                    "KiwiSaver :" + "$" + (float)Math.Round(this.KiwiSaver) + "\n" + "\n" + // print fornight KiwiSaver

                    new string('.', 50) + "\n\n" + // Print line

                    "Fortnight Net Payroll: " + "$" + (float)Math.Round(this.FortnightNetPayroll) + "\n" +"\n"; // Print fornight net payroll
            }// End of printPayrollStatment

        } // End of Employee Structure

        struct Static // This is Static structure
        {
            public static Employee[] Employees = new Employee[5];

            public static void runner() // Start of Runner
            {
                Static.readEmployeeFile(); // Read the employee file and import the value 
                bool quit = false;
                do
                {
                    OperationMenu(); // Display the Operation Menu 
                    int option = int.Parse(Console.ReadLine()); // Read user input
                    OperationOutput(option, ref quit); // Display output 
                } while (!quit);
            } // End of Runner


            public static void OperationMenu() // This is the operation menu for user
            {
                Console.WriteLine("\n\n"); // Next lines to make sapce
                Console.WriteLine("*** New Kiwi Garage Payroll System ***"); // Heading
                Console.WriteLine("\n"); // Next line to make sapce
                Console.WriteLine("-------------Operation Menu---------------"); // title
                Console.WriteLine("\n");  // Next line to make sapce
                Console.WriteLine("1. Fortnight payroll calculation"); // Option 1 for fortnight payroll calculation
                Console.WriteLine("2. Sort and display employee records"); // Option 2 for Sort and Display employee records
                Console.WriteLine("3. Search for an employee"); // Option 3 for searching for an employee
                Console.WriteLine("4. Save into a text file"); // Option 4 for saving the payroll information into a text file
                Console.WriteLine("0. Exit"); // Option 0 for exit 
                Console.WriteLine("\n"); // Next line to make sapce
                Console.WriteLine("------------------------------------------"); // Print line 
                Console.WriteLine("Please enter one of above operation number"); // Display for instruction for user
            } // End of OperationMenu

            public static void OperationOutput(int option, ref bool quit) // This is the output of operation 
            {
                Console.Clear();
                switch (option)
                {
                    case 1: // When user enter the Key is "1"
                        Static.listOfEmployees(); // Print a list of all employees 
                        Static.searchEmployee(); // User enter an employee ID to get payroll calculation
                        break;
                    case 2: // When user enter the Key is "2"
                        Static.sortEmployees(); // Sort employee by ID order
                        Static.printEmployees(); // Display all employees information 
                        break;
                    case 3: // When user enter the Key is "3"
                        Static.searchEmployee(); // User enter en employee ID to get the matched emplpoyee information 
                        break;
                    case 4: // When user enter the Key is "4"
                        Static.saveFile(); // Save information into a text file 
                        break;
                    case 0:
                        quit = true; // Exit the program
                        break;
                    default: // When user enter any other key 
                        Console.WriteLine("Invalid number!");
                        break;
                        return;
                }
                Console.WriteLine("Please press any key to continue...."); // Print instruction for user
                Console.ReadKey(); // Read the key which is entered by the user
                Console.Clear(); // Clear the console
            } // End of OperationOutput

            public static void readEmployeeFile() // This reads the employee file and store the value into Emplpoyees
            {
                int index = 0;
                FileStream fileStream = new FileStream("employees.txt", FileMode.Open, FileAccess.Read); // Create the file stream object
                StreamReader streamReader = new StreamReader(fileStream); // Create file reader object
                streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                for (string line = streamReader.ReadLine(); line != null; line = streamReader.ReadLine()) //Read the lines one the employee file and store in the string
                {
                    string[] employee = line.Split(' ');// Split the value from the employee file by spaces and put it into the array
                    int employeeId = int.Parse(employee[0]);
                    string employeeFirstName = employee[1];
                    string employeeLastName = employee[2];
                    double employeeAnnualSalary = double.Parse(employee[3]);
                    double employeeKiwiSaverPercentage = double.Parse(employee[4]);
                    Employee Employee = new Employee(employeeId, employeeFirstName, employeeLastName, employeeAnnualSalary, employeeKiwiSaverPercentage);
                    Static.Employees[index] = Employee; // Fetch the value from the file and store it into the Employees
                    index++;
                }
                streamReader.Close(); //Close the reader 
                fileStream.Close(); //Close the employee file
            } // End of readEmployeeFile

            public static void sortEmployees() // This sorts the employees by rearranging ID order
            {

                for (int i = 0; i < Employees.Length - 1; i++) //Bubble Sort
                {
                    for (int j = i + 1; j < Employees.Length; j++)
                    {
                        if (Employees[i].ID > Employees[j].ID) // Check if id (i) is greater than (j), if yes sawp their order 
                        {
                            Employee temporaryEmployee = Employees[i]; // temporaryEmpployee is for storing emplpoyee order temporarily
                            Employees[i] = Employees[j];
                            Employees[j] = temporaryEmployee;
                        }
                    }
                }
            } // End of sortEmployees 

            public static void listOfEmployees() // This prints a list of all employees
            {
                Console.WriteLine("\n\n"); // Next lines to make sapce
                Console.WriteLine("\t\t\t\t***** List of Employees *****\t\t\t\t"); // Print heading
                Console.WriteLine(new String('.', 81));//Print repeated string'-' 81 times
                Console.WriteLine("|Employee ID\t|First Name\t|Last Name\t|Annual Salary\t|KiwiSaver\t|");//Print table title
                Console.WriteLine(new String('.', 81));//Print repeated string'-' 81 times
                foreach (Employee employee in Employees)  // Get all employee on the employee file
                    Console.WriteLine(employee.employeeRecords()); // Print a list of all employees with their records
                Console.WriteLine(new String('.', 81));//Print repeated string'-' 81 times

            } // End of print All employees
            public static void printEmployees() // This prints all employee information
            {

                foreach (Employee employee in Employees) // Get all employee on the employee file

                    Console.WriteLine(employee.printPayrollStatment()); // Print all employee information with payroll information
            } // End of print employee


            public static void searchEmployee() // This searchs for the employees by ID
            {

                int inputID, idCount;
                Console.WriteLine("Please enter an employee ID: "); // Print instruction for user
                inputID = int.Parse(Console.ReadLine()); // Read the ID that user has input
                Console.Clear(); //Clears the console

                bool contains = false;
                for (idCount = 0; idCount < Employees.Length; idCount++) // for loop 
                {
                    if (Employees[idCount].ID == inputID) // If input ID matches the employee ID 
                    {
                        contains = true;
                        break;
                    }
                }
                if (contains == true)
                {
                    Console.WriteLine(Employees[idCount].printPayrollStatment()); // Print employee records and their payroll statment 
                }
                else
                {
                    Console.WriteLine("Employee ID error, please enter a valid ID"); // else, print the error meessage
                }

            } // End of search employee 

            public static void saveFile() // This saves the payroll result into a text file
            {
                FileStream fileStream = new FileStream("weekly_payroll.txt", FileMode.OpenOrCreate, FileAccess.Write); //Create the weekly_payroll.txt file
                StreamWriter streamWriter = new StreamWriter(fileStream); // Create the file writer
                foreach (Employee employee in Employees) // Get all employee information in Employees 
                {
                    streamWriter.Write(employee.printPayrollStatment() + "\n"); // Write all employee information onto the file
                }
                streamWriter.Close(); // Close the writer
                fileStream.Close(); // Close the file
                Console.Clear(); // Clear the console
                Console.WriteLine("File saved successfully!\nFile Name: weekly_payroll.txt\nFile Location: E drive -> Payroll -> Payroll -> bin -> Debug -> net6.0 "); //Print message
            } // End of saveFile


        } // End of Static Structure

    } // End of Program Class


} // End of namespace


        
   

   
