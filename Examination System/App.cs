using System;
namespace Examination_System;
public class App
{
    public static void Run(string[] args)
    {
        Console.WriteLine("Welcome in My Examination System");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Please select the exam subject");
        string s=Console.ReadLine();
        Subject sub = new Subject(s);

        
        Console.WriteLine("Enter the number of questions:");
        int questionCount = int.Parse(Console.ReadLine());
        Question[] questionArray = new Question[questionCount];

        for (int i = 0; i < questionCount; i++)
        {
            Console.WriteLine($"Enter Question {i + 1} Type ([1]: True/False, [2]: Choose One, [3]: Choose All):");
            int type = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Question Header:");
            string header = Console.ReadLine();
            Console.WriteLine("Enter Question Body:");
            string body = Console.ReadLine();
            Console.WriteLine("Enter Marks:");
            int marks = int.Parse(Console.ReadLine());

            Question question = null;

            if (type == 1)
            {
                question = new TrueFalseQuestion(header, body, marks);
            }
            else if (type == 2)
            {
                question = new ChooseOneQuestion(header, body, marks);
            }
            else if (type == 3)
            {
                question = new ChooseAllQuestion(header, body, marks);
            }

            question.InputAnswer();
            questionArray[i] = question;
        }
        FinalExam Exam = new FinalExam($"Final Exam", sub);
        Exam.Questions = questionArray;

 
        Exam.ShowExam();
        int totalScore = Exam.TakeExam();

        
        Console.WriteLine($"\nYour total score is: {totalScore}/{questionCount * 10}");
        Exam.ShowRightAnswers();
    }
}
