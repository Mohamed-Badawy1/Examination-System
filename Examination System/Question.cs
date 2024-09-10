using Examination_System;
using System;

public abstract class Question
{
    public string Header { get; set; }
    public string Body { get; set; }
    public int Marks { get; set; }
    public Answer[] Answers { get; set; }

    public Question(string header, string body, int marks)
    {
        Header = header;
        Body = body;
        Marks = marks;
    }

    public abstract void ShowQuestion();


    public abstract bool CheckAnswer();

  
    public abstract void InputAnswer();
}

public class TrueFalseQuestion : Question
{
    public TrueFalseQuestion(string header, string body, int marks) : base(header, body, marks) { }

    public override void ShowQuestion()
    {
        Console.WriteLine($"{Header}: {Body} (True/False)");
    }
    public override void InputAnswer()
    {
        Console.WriteLine("Enter the correct answer (True/False):");
        string correctAnswer = Console.ReadLine().ToLower();

        Answers = new Answer[]
        {
            new Answer("True", correctAnswer == "true"),
            new Answer("False", correctAnswer == "false")
        };
    }
    public override bool CheckAnswer()
    {
        Console.WriteLine("Your answer (True/False):");
        string userAnswer = Console.ReadLine().ToLower();
        return (userAnswer == "true" && Answers[0].IsCorrect) || (userAnswer == "false" && Answers[1].IsCorrect);
    }
}


public class ChooseOneQuestion : Question
{
    public ChooseOneQuestion(string header, string body, int marks)
        : base(header, body, marks) { }

    public override void ShowQuestion()
    {
        Console.WriteLine($"{Header}: {Body} (Choose One)");
        for (int i = 0; i < Answers.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Answers[i].Text}");
        }
    }

    public override bool CheckAnswer()
    {
        Console.WriteLine("Your answer (choose the number):");
        int userAnswer = int.Parse(Console.ReadLine()) - 1;
        return Answers[userAnswer].IsCorrect;
    }

    public override void InputAnswer()
    {
        Console.WriteLine("Enter the number of options:");
        int optionCount = int.Parse(Console.ReadLine());
        Answers = new Answer[optionCount];

        for (int i = 0; i < optionCount; i++)
        {
            Console.WriteLine($"Enter option {i + 1}:");
            string option = Console.ReadLine();
            Answers[i] = new Answer(option, false);
        }

        Console.WriteLine("Enter the correct option number:");
        int correctOption = int.Parse(Console.ReadLine()) - 1;
        Answers[correctOption].IsCorrect = true;
    }
}


public class ChooseAllQuestion : Question
{
    public ChooseAllQuestion(string header, string body, int marks)
        : base(header, body, marks) { }

    public override void ShowQuestion()
    {
        Console.WriteLine($"{Header}: {Body} (Choose All)");
        for (int i = 0; i < Answers.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Answers[i].Text}");
        }
    }

    public override bool CheckAnswer()
    {
        Console.WriteLine("Your answers (choose the numbers separated by space):");
        string[] userAnswers = Console.ReadLine().Split(' ');
        bool isCorrect = true;

        foreach (string answer in userAnswers)
        {
            int index = int.Parse(answer) - 1;
            if (!Answers[index].IsCorrect)
            {
                isCorrect = false;
                break;
            }
        }

       
        return isCorrect && Array.TrueForAll(Answers, a => !a.IsCorrect || userAnswers.Contains(Array.IndexOf(Answers, a) + 1.ToString()));
    }

    public override void InputAnswer()
    {
        Console.WriteLine("Enter the number of options:");
        int optionCount = int.Parse(Console.ReadLine());
        Answers = new Answer[optionCount];

        for (int i = 0; i < optionCount; i++)
        {
            Console.WriteLine($"Enter option {i + 1}:");
            string option = Console.ReadLine();
            Answers[i] = new Answer(option, false);
        }

        Console.WriteLine("Enter the correct option numbers separated by space:");
        string[] correctOptions = Console.ReadLine().Split(' ');
        foreach (string correctOption in correctOptions)
        {
            Answers[int.Parse(correctOption) - 1].IsCorrect = true;
        }
    }
}
