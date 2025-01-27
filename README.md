# University Marks Management System

## 📝 Overview
The **University Marks Management System** is a C# console application built using Object-Oriented Programming (OOP) principles. It is designed for managing student records at a university. The system allows users to create student records, enter and update marks, calculate averages, and determine pass/fail status.

## 🚀 Features
- **Create Student Record**: Generate unique student IDs and store student details.
- **Enter Marks**: Input marks, calculate average, and determine pass/fail status.
- **Update Marks**: Append new marks to an existing record, preserving the history.
- **View Records**: Retrieve and display student records and mark history.
- **Validation**: Ensure marks are between 0 and 100.
- **Data Persistence**: Save and load student records from files to maintain data across sessions.

## 📋 Usage

### Menu Options:
1. **Create Student Record**: 
   - Generate a unique student ID and store the student's name.
2. **Enter Marks**: 
   - Add marks for a student and calculate their average.
   - If average >= 40, the student "Passes". If average < 40, the student "Fails".
3. **Update Marks**: 
   - Add new marks without overwriting previous records, showing a history of attempts.
4. **View Student Record**: 
   - Retrieve a student's details and marks history.
5. **Quit**: 
   - Exit the program.

### Example Interaction:
- **Create Student Record**: 
   - Input: "John Doe"
   - Output: "Student record created for John Doe with ID: 12345678"
- **Enter Marks**: 
   - Input: 6 marks (e.g., 60, 70, 80, 90, 50, 75)
   - Output: "Average: 75, Status: Passed"
- **Update Marks**: 
   - Input: New marks (e.g., 80, 85, 70, 90, 65, 75)
   - Output: "New average: 78.5, Status: Passed (History updated)"

## 💻 Installation

### 1. Open the solution:
- Open the project in **Visual Studio** or any C# compatible IDE.

### 2. Build and run:
- Build the solution and run the application to start interacting with the system.

## 🛠️ Technologies Used
- **C#**: Object-Oriented Programming principles
- **File Handling**: For data persistence (storing and reading student records)
- **Git**: For version control
- **UML**: Class diagrams for system design

## 📐 UML Class Diagram
A UML class diagram is provided in the `/UML_Diagrams` folder to visualize the system's design. The diagram includes key classes such as:
- `Student`: Represents a student record.
- `Marks`: Manages marks and calculations.
- `FileHandler`: Handles file operations for saving/loading records.

## 👥 Contributions
Contributions are welcome! Feel free to fork this repository, make your changes, and open a pull request. Please ensure your code is well-documented, follows proper coding conventions, and includes tests (if applicable).

---

## 📧 Contact
For any questions or feedback, feel free to reach out to the project owner:
- [Your Name](https://github.com/walidgrw)

---

### 🏷️ Tags
`C#`, `Object-Oriented Programming`, `Student Management`, `Console App`, `UML`, `Marks Management`, `GitHub`
