# Lotus Cybersecurity Awareness Bot

## PROG6221 – Part 3 POE

--------------------------------------------------------------------

# Project Overview

Lotus Cybersecurity Awareness Bot is a Windows Presentation Foundation (WPF) application developed in C#.

The chatbot educates users about cybersecurity while providing several interactive features including:

- Cybersecurity chatbot
- Sentiment detection
- User memory
- Follow-up conversations
- Task Assistant with reminders
- Cybersecurity Quiz
- Activity Log
- JSON task storage

This project combines the requirements of Parts 1, 2 and 3 into a single GUI application.

--------------------------------------------------------------------

# Features

## Part 1

- Cybersecurity chatbot
- Voice greeting
- Speech synthesis
- ASCII background
- Keyword recognition

## Part 2

- Memory of user name
- Favourite cybersecurity topic
- Follow-up conversations
- Sentiment detection
- Chat history saving
- Typing animation
- Improved GUI

## Part 3

### Task Assistant

- Add tasks
- View tasks
- Mark tasks complete
- Delete tasks
- Reminder support
- JSON file storage

### Cybersecurity Quiz

- More than 10 questions
- Multiple choice
- True/False questions
- Immediate feedback
- Score tracking
- Final results

### NLP Simulation

Recognises different user requests such as:

- Add task
- Create task
- Remind me
- Start quiz
- Show activity log
- Show more

### Activity Log

Records:

- Task creation
- Task completion
- Task deletion
- Reminder creation
- Quiz started
- Quiz completed
- Keyword matches
- NLP actions

--------------------------------------------------------------------


# Technologies Used

- C#
- WPF
- XAML
- .NET
- Newtonsoft.Json

--------------------------------------------------------------------


# Installing Newtonsoft.Json

1. Open the project in Visual Studio.

2. Right-click the project.

3. Select **Manage NuGet Packages**.

4. Search for:

--------------------------------------------------------------------
Newtonsoft.Json
--------------------------------------------------------------------


5. Install the latest stable version.

Or install using the Package Manager Console:

```powershell
Install-Package Newtonsoft.Json
```
--------------------------------------------------------------------

# Running the Project

1. Clone the repository.

2. Open the solution in Visual Studio.

3. Restore NuGet packages.

4. Build the solution.

5. Run the application.

--------------------------------------------------------------------

# JSON Storage

Tasks are stored automatically in:

```
tasks.json
```

The file is created automatically after the first task is added.

