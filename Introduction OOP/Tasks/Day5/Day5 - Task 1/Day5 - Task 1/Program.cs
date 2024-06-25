namespace Day5___Task_1
{
    internal class Program
    {
        abstract class Question
        {
            public string Body { get; set; }
            public int Marks { get; set; }
            public string Header { get; set; }
            public Question(string body,int marks ,string header)
            {
                this.Body = body;
                this.Marks = marks;
                this.Header = header;
            }
            public abstract string GetString();


        }
        class TrueOrFalseQuestion : Question
        {
            public TrueOrFalseQuestion(string body, int marks, string header) :base(body,marks,header)
            {
                
            }

            public override string GetString()
            {
                return $"This is A true Or False Question :\n" +
                    $"{Header}\n" +
                    $"{Body}\n" +
                    $"The Marks on the Question: {Marks}\n" +
                    $"===========================================";
            }


        }
        class ChooseOneQuestion : Question
        {
            public ChooseOneQuestion(string body, int marks, string header) : base(body, marks, header)
            {
            }

            public override string GetString()
            {
                return $"This is A Choose One Question :\n" +
                    $"{Header}\n" +
                    $"{Body}\n" +
                    $"The Marks on the Question: {Marks}\n" +
                    $"===========================================";
            }
        }
        class ChooseAllQuestion : Question
        {
            public ChooseAllQuestion(string body, int marks, string header) : base(body, marks, header)
            {
            }

            public override string GetString()
            {
                return $"This is A Choose All Question :\n" +
                    $"{Header}\n" +
                    $"{Body}\n" +
                    $"The Marks on the Question: {Marks}\n" +
                    $"===========================================";
            }
        }
        static void Main(string[] args)
        {
            Question[] questions = new Question[5];
            questions[0] = new ChooseAllQuestion("this is a question body??",100,"Question number 1");
            questions[1] = new ChooseOneQuestion("this is a question body??", 100, "Question number 2");
            questions[2] = new TrueOrFalseQuestion("this is a question body??", 100, "Question number 3");
            questions[3] = new ChooseAllQuestion("this is a question body??", 100, "Question number 4");
            questions[4] = new ChooseOneQuestion("this is a question body??", 100, "Question number 5");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(questions[i].GetString());

            }
        }
    }
}
