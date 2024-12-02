# 📝 **Questionnaire Game - C# Windows Forms Application**

## 📖 **Overview**

The **Questionnaire Game** is an interactive quiz app built using **C#** and **Windows Forms**. It allows users to answer multiple-choice questions within a specified time limit, track their current and high scores, and use various utilities such as **50/50**, **Skip**, and more. The game provides an engaging experience with different game modes and customizable features.

---

## 🚀 **Features**

- **Timed Quiz**: Players must answer each question within a set amount of time.
- **Scoring System**:
  - **Current Score**: Tracks your score during the session.
  - **High Score**: Keeps track of your best score across sessions.
- **Game Utilities**:
  - **50/50**: Removes two incorrect answers.
  - **Skip Question**: Skip the current question and move to the next.
  - **Plus Time**: Adds more time to the clock.
  - **Audience Help**: Gets help from the audience.

---

## 🖼 **App UI Overview**

The **Windows Forms** interface is designed to be user-friendly and intuitive.

### **Main Window**

- **Start Button**: Begins the game.
- **Ranking Button**: Checks the rankings.
- **Current Score**: Displays the score for the current session.
- **High Score**: Displays the highest score achieved.
- **Timer**: A countdown timer that tracks the time remaining to answer a question.

### **Game Window**

- **Question Display**: Shows the current question.
- **Answer Options**: Displays multiple-choice answers for the user to select from.
- **Use Utilities**: Buttons for utilities like **50/50**, **Skip Question**, **Plus Time**,**Ask Audience**

---

## ⚙️ **How It Works**

### **1. Setup the Game**

When the player clicks "Start," the following steps occur:

1. The **Question Timer** begins.
2. A **random question** is selected from a pool of questions.
3. The user has **15 seconds** to answer the question.

### **2. Answering Questions**

- The player selects one of the four multiple-choice answers.
- If the answer is **correct**, the player gains points and moves to the next question.
- If the answer is **incorrect**, the timer stops, and the current score becomes zero.

### **3. Using Utilities**

During the game, players can use the following utilities:

- **50/50**: Removes two wrong answers, leaving only two possible choices.
- **Skip Question**: Skips the current question and moves to the next one.
- **Plus Time**: Adds extra time to the timer, giving more time to answer.
- **Ask Audience**: Asks the audience for help and they give a feedback in percentages.

---

## 🏆 **Scoring System**

- **Correct Answer**: +1 points
- **Time Bonus**: Extra points based on remaining time.

## 🧑‍💻 **How to Use**

1. **Download the Game**:

   - Download the project using the `git clone` command.

2. **Running the Game**:

   - Double-click on the game executable to start the application.
   - Click the **Start Button** to begin the game.

3. **Playing the Game**:

   - Answer the questions within the time limit.
   - Use utilities as needed to help you with the game.
   - Keep an eye on the **Timer** and **Score**!

---

## 🛠 **Development Notes**

### **Technologies Used**:

- **C#**: Programming language used for the game logic and application.
- **Windows Forms**: For the graphical user interface (GUI).
- **Timer**: To manage the time limits for each question.
- **Event Handlers**: For handling button clicks, question answering, and timer updates.

### **Code Snippets**:

**Language Logic**:

```csharp
            string selectedLanguage = Language.SelectedItem.ToString();

            switch (selectedLanguage)
            {
                case "English":
                    ChangeLanguage("en-US");
                    Properties.Settings.Default.Language = "en-US";
                    break;

                case "French":
                    ChangeLanguage("fr-FR");
                    Properties.Settings.Default.Language = "fr-FR";
                    break;

                default:
                    break;
            }

            Properties.Settings.Default.Save();

            ApplyLocalization();
```

**Countdown Logic**:

```csharp
int remainingTime = Time;

            while (remainingTime >= 0 && timer_run)
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke(new Action(() =>
                    {
                countdown_label.Text =
                TimeSpan.FromSeconds(remainingTime).ToString(@"mm\:ss");
                    }));
                }

                remainingTime--;

                Thread.Sleep(1000);
            }

            if (remainingTime < 0 && timer_run)
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Time's up!");
                        CurrentScore = 0;
                        CurrentText.Text = $"Current Score: {CurrentScore}";
                        Timer_Reset();
                    }));
                }
            }

```
