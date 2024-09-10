using Examination_System;
using System;

public abstract class Exam
{
    public string Title { get; set; }
    public Question[] Questions { get; set; }
    public Subject Subject { get; set; }

    public Exam(string title, Subject subject)
    {
        Title = title;
        Subject = subject;
    }

    public abstract void ShowExam();

    public int TakeExam()
    {
        int totalScore = 0;
        foreach (var question in Questions)
        {
            question.ShowQuestion();
            bool isCorrect = question.CheckAnswer();
            if (isCorrect)
            {
                Console.WriteLine("Correct!");
                totalScore += question.Marks;
            }
            else
            {
                Console.WriteLine("Wrong.");
            }
        }
        return totalScore;
    }

    public void ShowRightAnswers()
    {
        Console.WriteLine("\nCorrect Answers:");
        foreach (var question in Questions)
        {
            foreach (var answer in question.Answers)
            {
                if (answer.IsCorrect)
                {
                    Console.WriteLine($"- {answer.Text}");
                }
            }
        }
    }
}

public class FinalExam : Exam
{
    public FinalExam(string title, Subject subject) : base(title, subject) { }

    public override void ShowExam()
    {
        Console.WriteLine($"Exam:");
        Console.WriteLine($"Subject:{Subject.name}");
    }
}
