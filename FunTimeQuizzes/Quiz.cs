using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FunTimeQuizzes
{
    public class Quiz
    {
        private bool showAnswer = false;
        private int numberOfAnswerOptions = 6;
        private decimal questionsAnswered = 0;
        private decimal redemptionsAnswered = 0;
        private decimal correctAnswers = 0;
        private decimal redeemedQuestions = 0;
        private DateTime quizStart = DateTime.Now;
        private List<int> failedQuestions = new List<int>();

        public Quiz()
        {
        }

        public int GetNumFailedQuestions()
        {
            return failedQuestions.Count;
        }

        public void UpdateStats(string userScored)
        {
            questionsAnswered += 1;
            correctAnswers += (userScored == "correct") ? 1 : 0;
        }
        public void UpdateRedemptionStats(string userScored)
        {
            redemptionsAnswered += 1;
            redeemedQuestions += (userScored == "correct") ? 1 : 0;
        }

        public void DisplayStats(int timeout = 500)
        {
            DateTime now = DateTime.Now;
            Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(now);
            Console.WriteLine($"Quizzing Time: {Math.Round(Convert.ToDecimal(now.Subtract(quizStart).TotalMinutes), 2)} minutes");
            Console.WriteLine($"Total  Questions Answered: {questionsAnswered}");
            Console.WriteLine($"Total   Correct   Answers: {correctAnswers + redeemedQuestions}");
            Console.WriteLine($"Overall FunTimeQuiz Score: {((questionsAnswered < 1) ? 0 : Math.Round(Convert.ToDecimal(((correctAnswers + redeemedQuestions) / questionsAnswered) * 100), 2))}%");
            Console.WriteLine("-----------------------------------");
            Thread.Sleep(timeout);
        }

        public void DisplayRedemptionStats(int timeout = 500)
        {
            DateTime now = DateTime.Now;
            Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(now);
            Console.WriteLine($"Quizzing Time: {Math.Round(Convert.ToDecimal(now.Subtract(quizStart).TotalMinutes), 2)} minutes");
            Console.WriteLine($"Total  Incorrect Answered: {questionsAnswered - correctAnswers}");
            Console.WriteLine($"Total   Redeemed  Answers: {redeemedQuestions}");
            Console.WriteLine($"Total  Redemption   Score: {Math.Round(Convert.ToDecimal((redeemedQuestions / (questionsAnswered - correctAnswers)) * 100), 2)}%");
            Console.WriteLine("-----------------------------------");
            Thread.Sleep(timeout);
        }

        public List<int> DisplayQuestion(int num)
        {
            string questionAndAnswers;
            string correctLabel = (showAnswer) ? " * correct * " : "";
            List<int> correctAnswers = new List<int>();
            switch (num)
            {
                case 1:
                    questionAndAnswers = $"\nWhat type of Version Control System is git?" +
                    $"\n 1: Distributed{correctLabel}" +
                    $"\n 2: Centralized" +
                    $"\n 3: Intrinsic";
                    correctAnswers.Add(1);
                    break;

                case 2:
                    questionAndAnswers = $"\nWhich of the following commands will create a new branch called new_work and also check it out?" +
                    $"\n 1: git checkout -b new_work{correctLabel}" +
                    $"\n 2: git branch new_work" +
                    $"\n 3: git checkout new_work";
                    correctAnswers.Add(1);
                    break;

                case 3:
                    questionAndAnswers = $"\nIn order to merge a new branch into main, you have to add and commit changes to that branch first" +
                    $"\n 1: True{correctLabel}" +
                    $"\n 2: False";
                    correctAnswers.Add(1);
                    break;

                case 4:
                    questionAndAnswers = $"\nNow we want to merge new_work into main. Which branch should we be on when we execute git merge new_work?" +
                    $"\n 1: new_workIn{correctLabel}" +
                    $"\n 2: main";
                    correctAnswers.Add(1);
                    break;

                case 5:
                    questionAndAnswers = $"\nIf we wanted to add ALL modified files to the staging area, what git command would we use?" +
                    $"\n 1: git add" +
                    $"\n 2: git add .{correctLabel}" +
                    $"\n 3: git add <filename>" +
                    $"\n 4: git log";
                    correctAnswers.Add(2);
                    break;

                case 6:
                    questionAndAnswers = $"\nwhich git command will list the branches in your repository?" +
                    $"\n 1: git checkout" +
                    $"\n 2: git commit" +
                    $"\n 3: git branch{correctLabel}" +
                    $"\n 4: git branch <BranchName>";
                    correctAnswers.Add(3);
                    break;

                case 7:
                    questionAndAnswers = $"\nA ______ is the Git equivalent of a \"save\"" +
                    $"\n 1: commit{correctLabel}" +
                    $"\n 2: push" +
                    $"\n 3: remote";
                    correctAnswers.Add(1);
                    break;

                case 8:
                    questionAndAnswers = $"\nWhich command pulls the latest version of the remote repository to our machine?" +
                    $"\n 1: git push" +
                    $"\n 2: git commit" +
                    $"\n 3: git remote - v" +
                    $"\n 4: git pull{correctLabel}";
                    correctAnswers.Add(4);
                    break;

                case 9:
                    questionAndAnswers = $"\nWhich of the following commands will allow you to abort a merge?" +
                    $"\n 1: git merge --abort{correctLabel}" +
                    $"\n 2: git abort" +
                    $"\n 3: git merge --abort --conflict";
                    correctAnswers.Add(1);
                    break;

                case 10:
                    questionAndAnswers = $"\nThe command ______ is a combination of fetch and merge." +
                    $"\n 1: git pull{correctLabel}" +
                    $"\n 2: git commit" +
                    $"\n 3: none of the above";
                    correctAnswers.Add(1);
                    break;

                case 11:
                    questionAndAnswers = $"\n_________ enables you to compare changes in the working directory against a previously committed version." +
                    $"\n 1: git diff{correctLabel}" +
                    $"\n 2: git compare" +
                    $"\n 3: git previous" +
                    $"\n 4: None of the above";
                    correctAnswers.Add(1);
                    break;

                case 12:
                    questionAndAnswers = $"\n_______________ files contain all the source code that are compiled. It also contains compiler settings and other configuration files" +
                    $"\n 1: project{correctLabel}" +
                    $"\n 2: solution" +
                    $"\n 3: source code file";
                    correctAnswers.Add(1);
                    break;

                case 13:
                    questionAndAnswers = $"\nThis command creates a new console project for us:" +
                    $"\n 1: dotnet new console{correctLabel}" +
                    $"\n 2: dotnet new" +
                    $"\n 3: dotnet console" +
                    $"\n 4: mkdir console";
                    correctAnswers.Add(1);
                    break;

                case 14:
                    questionAndAnswers = $"\nThis command is used to execute unit tests in a given project" +
                    $"\n 1: dotnet test{correctLabel}" +
                    $"\n 2: dotnet run test";
                    correctAnswers.Add(1);
                    break;

                case 15:
                    questionAndAnswers = $"\nAll external dependencies used in your app are stored in what folder?" +
                    $"\n 1: Packages{correctLabel}" +
                    $"\n 2: Dependencies{correctLabel}" +
                    $"\n 3: DLC Folder" +
                    $"\n 4: Nuget";
                    correctAnswers.Add(1);
                    correctAnswers.Add(2);
                    break;

                case 16:
                    questionAndAnswers = $"\nWhat is the most popular package manager for .NET development?" +
                    $"\n 1: DLC" +
                    $"\n 2: Nuget{correctLabel}" +
                    $"\n 3: OpenPKG" +
                    $"\n 4: Zero Install";
                    correctAnswers.Add(2);
                    break;

                case 17:
                    questionAndAnswers = $"\nWhile you're debugging, you can use what window to track variables and expressions?" +
                    $"\n 1: Solution explorer" +
                    $"\n 2: Watch window{correctLabel}" +
                    $"\n 3: Intellisense" +
                    $"\n 4: Call Stack" +
                    $"\n 5: Task List";
                    correctAnswers.Add(2);
                    break;

                case 18:
                    questionAndAnswers = $"\nWhere can you view the function or procedure calls that are currently on the stack?" +
                    $"\n 1: Solution explorer" +
                    $"\n 2: Watch window" +
                    $"\n 3: Task list" +
                    $"\n 4: Call stack{correctLabel}";
                    correctAnswers.Add(4);
                    break;

                case 19:
                    questionAndAnswers = $"\nTrue or False: The debugger can break execution at the point where an exception is thrown, so you may examine the exception before a handler is invoked" +
                    $"\n 1: True{correctLabel}" +
                    $"\n 2: False";
                    correctAnswers.Add(1);
                    break;

                case 20:
                    questionAndAnswers = $"\nThis is a storage location used by computer memory to store data for usage by an application" +
                    $"\n 1: Constants" +
                    $"\n 2: Variables{correctLabel}" +
                    $"\n 3: Datatypes" +
                    $"\n 4: None of the above";
                    correctAnswers.Add(2);
                    break;

                case 21:
                    questionAndAnswers = $"\nWhich is a valid C# variable name?" +
                    $"\n 1: 1car" +
                    $"\n 2: #LastStudent#" +
                    $"\n 3: wrongOne{correctLabel}";
                    correctAnswers.Add(3);
                    break;

                case 22:
                    questionAndAnswers = $"\n 1: Which of the following is a correct example of how to initialize a variable" +
                    $"\n 2: int = 42;" +
                    $"\n 3: STRING myString = \"Hello!\";" +
                    $"\n 4: int 1number = 1;" +
                    $"\n 5: bool isParsed = false;{correctLabel}";
                    correctAnswers.Add(5);
                    break;

                case 23:
                    questionAndAnswers = "\nWhat are the 3 parts to a variable?" +
                    $"\n 1: name, value, semicolon" +
                    $"\n 2: datatype, name, value{correctLabel}" +
                    $"\n 3: public, static, int" +
                    $"\n 4: datatype, static, value";
                    correctAnswers.Add(2);
                    break;

                case 24:
                    questionAndAnswers = "\nTrue/False. You can use a variable before it is declared." +
                    $"\n 1: True" +
                    $"\n 2: False{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 25:
                    questionAndAnswers = "\nC# is strongly-typed." +
                    $"\n 1: True{correctLabel}" +
                    $"\n 2: False";
                    correctAnswers.Add(1);
                    break;

                case 26:
                    questionAndAnswers = "\nChoose the correct definition of strongly typed" +
                    $"\n 1: Once an object has a type, that type will NEVER change{correctLabel}" +
                    $"\n 2: Every object MUST have a type before the program will compile";
                    correctAnswers.Add(1);
                    break;

                case 27:
                    questionAndAnswers = "\nChoose the correct definition of statically typed" +
                    $"\n 1: Once an object has a type, that type will NEVER change" +
                    $"\n 2: Every object MUST have a type before the program will compile{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 28:
                    questionAndAnswers = "\nTo initialize a variable, you do not need to assign it a value." +
                    $"\n 1: True" +
                    $"\n 2: False{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 29:
                    questionAndAnswers = "\nTo declare a variable, you do not need to assign it a value." +
                    $"\n 1: True{correctLabel}" +
                    $"\n 2: False";
                    correctAnswers.Add(1);
                    break;

                case 30:
                    questionAndAnswers = "\n____________ types in C# automatically support being set null" +
                    $"\n 1: Value" +
                    $"\n 2: Reference{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 31:
                    questionAndAnswers = "\nThe _________ is a FIRST IN, FIRST OUT collection of elements" +
                    $"\n 1: stack" +
                    $"\n 2: queue{correctLabel}" +
                    $"\n 3: heap";
                    correctAnswers.Add(2);
                    break;

                case 32:
                    questionAndAnswers = "\nThe ________ utilizes a LAST IN, FIRST OUT procedure" +
                    $"\n 1: stack{correctLabel}" +
                    $"\n 2: heap" +
                    $"\n 3: queue";
                    correctAnswers.Add(1);
                    break;

                case 33:
                    questionAndAnswers = "\n__________ types do NOT automatically support being set to null and require an actual value" +
                    $"\n 1: Value{correctLabel}" +
                    $"\n 2: Reference";
                    correctAnswers.Add(1);
                    break;

                case 34:
                    questionAndAnswers = "\nThese types are stored in memory in a location called the stack" +
                    $"\n 1: Value{correctLabel}" +
                    $"\n 2: Reference";
                    correctAnswers.Add(1);
                    break;

                case 35:
                    questionAndAnswers = "\nA value type, followed by a ? is shorthand syntax for ________________" +
                    $"\n 1: nullable{correctLabel}" +
                    $"\n 2: expendable" +
                    $"\n 3: this is not allowed" +
                    $"\n 4: intrinsic";
                    correctAnswers.Add(1);
                    break;

                case 36:
                    questionAndAnswers = "\nOf the types below, select all that are reference types:" +
                    $"\n 1: int" +
                    $"\n 2: string{correctLabel}" +
                    $"\n 3: array{correctLabel}" +
                    $"\n 4: char";
                    correctAnswers.Add(2);
                    correctAnswers.Add(3);
                    break;

                case 37:
                    questionAndAnswers = "\nEvery C# program has this method:" +
                    $"\n 1: Main{correctLabel}" +
                    $"\n 2: Program" +
                    $"\n 3: Start" +
                    $"\n 4: Console";
                    correctAnswers.Add(1);
                    break;

                case 38:
                    questionAndAnswers = "\nDo methods have to return information" +
                    $"\n 1: No{correctLabel}" +
                    $"\n 2: Yes";
                    correctAnswers.Add(1);
                    break;

                case 39:
                    questionAndAnswers = "\nin \"public bool SendEmail(string emailAddress)\" what is \"(string emailAddress)\"" +
                    $"\n 1: Attribute" +
                    $"\n 2: Return Type" +
                    $"\n 3: Modifier" +
                    $"\n 4: Parameter{correctLabel}";
                    correctAnswers.Add(4);
                    break;

                case 40:
                    questionAndAnswers = "\nOptional keywords that give certain qualities to a method" +
                    $"\n 1: return type" +
                    $"\n 2: privacy attributes" +
                    $"\n 3: parameters" +
                    $"\n 4: modifiers{correctLabel}";
                    correctAnswers.Add(4);
                    break;

                case 41:
                    questionAndAnswers = "\nWhich operator is used to determine the remainder?" +
                    $"\n 1: *" +
                    $"\n 2: /" +
                    $"\n 3: %{correctLabel}";
                    correctAnswers.Add(3);
                    break;

                case 42:
                    questionAndAnswers = "\nOperators that require two operands are called:" +
                    $"\n 1: Unary Operator" +
                    $"\n 2: Ternary Operator" +
                    $"\n 3: Binary Operator{correctLabel}";
                    correctAnswers.Add(3);
                    break;

                case 43:
                    questionAndAnswers = $"\n(a += b) is the same as:" +
                    $"\n 1: a = a + b{correctLabel}" +
                    $"\n 2: a = (a+=b)" +
                    $"\n 3: a == b";
                    correctAnswers.Add(1);
                    break;

                case 44:
                    questionAndAnswers = "\nWhat is the output of this code?" +
                    $"\n using System;" +
                    $"\n  namespace SpringClean" +
                    "\n  {" +
                    $"\n     class Program" +
                    "\n     {" +
                    $"\n         static void Main(string[] args)" +
                    "\n         {" +
                    $"\n             int kidToysToKeep;" +
                    $"\n             int kidToysToDonate;" +
                    $"\n " +
                    $"\n             kidToysToDonate = 12;" +
                    $"\n             kidToysToKeep = 7;" +
                    $"\n " +
                    $"\n             int kidToysToBeginwith = KidToysToKeep + kidToysToDonate;" +
                    $"\n             Console.WriteLine(kidToystoBeginWith);" +
                    "\n         }" +
                    "\n     }" +
                    "\n }" +
                    $"\n 1: \"kidsToysToBeginWith\" " +
                    $"\n 2: 12" +
                    $"\n 3: 19{correctLabel}";
                    correctAnswers.Add(3);
                    break;

                case 45:
                    questionAndAnswers = $"\n'=' means equal to." +
                    $"\n 1: True" +
                    $"\n 2: False{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 46:
                    questionAndAnswers = "\n5 >= 5 returns true." +
                    $"\n 1: True{correctLabel}" +
                    $"\n 2: False";
                    correctAnswers.Add(1);
                    break;

                case 47:
                    questionAndAnswers = "\n40 <= 39 evaluates to:" +
                    $"\n 1: True" +
                    $"\n 2: False{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 48:
                    questionAndAnswers = "\nWhat does CCR stand for?" +
                    $"\n 1: Clean, Concise, Readable" +
                    $"\n 2: Concise, Clean, Readable" +
                    $"\n 3: Clear, Concise, Readable{correctLabel}";
                    correctAnswers.Add(3);
                    break;

                case 49:
                    questionAndAnswers = "\nC# was developed by:" +
                    $"\n 1: Apple" +
                    $"\n 2: Google" +
                    $"\n 3: Microsoft's Anders Hejlsberg{correctLabel}" +
                    $"\n 4: IBM" +
                    $"\n 5: Amazon";
                    correctAnswers.Add(3);
                    break;

                case 50:
                    questionAndAnswers = "\nType Inference uses which syntax?" +
                    $"\n 1: string" +
                    $"\n 2: bool" +
                    $"\n 3: var{correctLabel}" +
                    $"\n 4: object";
                    correctAnswers.Add(3);
                    break;

                case 51:
                    questionAndAnswers = "\nC# is a:" +
                    $"\n 1: Strongly-Typed Language{correctLabel}" +
                    $"\n 2: Weakly-Typed Language" +
                    $"\n 3: Dynamically-Typed Language" +
                    $"\n 4: Syntax-Typed Language";
                    correctAnswers.Add(1);
                    break;

                case 52:
                    questionAndAnswers = "\nWhat character allows us to use string interpolation?" +
                    $"\n 1: !" +
                    $"\n 2: ${correctLabel}" +
                    $"\n 3: %" +
                    $"\n 4: :" +
                    $"\n 5: ()";
                    correctAnswers.Add(2);
                    break;

                case 53:
                    questionAndAnswers = "\nAn \"if\" statement must contain an \"else\"." +
                    $"\n 1: True" +
                    $"\n 2: False{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 54:
                    questionAndAnswers = "\nWill the scope of this \"if\" statement execute?" +
                    "\n\"if (5 > 10 || \"Hey\" == \"Hey\") {//some code here}\"" +
                    $"\n 1: Yes{correctLabel}" +
                    $"\n 2: No" +
                    $"\n 3: Unable to be determined";
                    correctAnswers.Add(1);
                    break;

                case 55:
                    questionAndAnswers = "\nWill the scope of this \"if\" statement execute?" +
                    "\n\"if (myInt > 10 && \"Hey\" == \"Hey\") {//some code here}\"" +
                    $"\n 1: Yes" +
                    $"\n 2: No" +
                    $"\n 3: Unable to be determined{correctLabel}";
                    correctAnswers.Add(3);
                    break;

                case 56:
                    questionAndAnswers = "\nWhy do we use Switch Statements instead of else-if statements?" +
                    $"\n 1: else-if statements can only be used for 2 conditions." +
                    $"\n 2: switch statements increase readability and are more optimized for a larger number of conditions.{correctLabel}" +
                    $"\n 3: else-if and switch statements are exactly the same, so it doesn't matter.";
                    correctAnswers.Add(2);
                    break;

                case 57:
                    questionAndAnswers = "\nC# is case sensitive." +
                    $"\n 1: True{correctLabel}" +
                    $"\n 2: False";
                    correctAnswers.Add(1);
                    break;

                case 58:
                    questionAndAnswers = "\nIn a switch statement, multiple default statements are allowed." +
                    $"\n 1: True" +
                    $"\n 2: False{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 59:
                    questionAndAnswers = "\nWhat are the 4 Iteration Statements we've discussed in class?" +
                    $"\n 1: for{correctLabel}" +
                    $"\n 2: do" +
                    $"\n 3: do-while{correctLabel}" +
                    $"\n 4: while-do" +
                    $"\n 5: foreach{correctLabel}" +
                    $"\n 6: while{correctLabel}";
                    correctAnswers.Add(1);
                    correctAnswers.Add(3);
                    correctAnswers.Add(5);
                    correctAnswers.Add(6);
                    break;

                case 60:
                    questionAndAnswers = "\nTrue or False: foreach can only be used with a collection?" +
                    $"\n 1: True{correctLabel}" +
                    $"\n 2: False";
                    correctAnswers.Add(1);
                    break;

                case 61:
                    questionAndAnswers = "\nWhat is the maximum number of times a loop can execute?" +
                    $"\n 1: 2" +
                    $"\n 2: 5" +
                    $"\n 3: 7" +
                    $"\n 4: 1" +
                    $"\n 5: Infinitely or until there is no more space on the hard drive{correctLabel}";
                    correctAnswers.Add(5);
                    break;

                case 62:
                    questionAndAnswers = "\nWhich part of this for loop is the Conditional?" +
                    $"\n 1: for (" +
                    $"\n 2: int i = 0;" +
                    $"\n 3: i < 13;{correctLabel}" +
                    $"\n 4: i++; )" +
                    "\n 5: { Console.WriteLine(numbers[i]); }";
                    correctAnswers.Add(3);
                    break;

                case 63:
                    questionAndAnswers = "\nWhat is the namespace needed to use List<T>?" +
                    $"\n 1: System.List.Generic" +
                    $"\n 2: System.Collections" +
                    $"\n 3: System.List" +
                    $"\n 4: System.Collections.Generic{correctLabel}";
                    correctAnswers.Add(4);
                    break;

                case 64:
                    questionAndAnswers = "\nWhich of these is used to identify the amount of elements in a List<T>?" +
                    $"\n 1: .Length" +
                    $"\n 2: .Count{correctLabel}" +
                    $"\n 3: .Max" +
                    $"\n 4: .MaxNumber";
                    correctAnswers.Add(2);
                    break;

                case 65:
                    questionAndAnswers = "\nHow many elements are in this array?" +
                    "\nint[] weekDays = new int[7];" +
                    $"\n 1: 4" +
                    $"\n 2: 6" +
                    $"\n 3: 3" +
                    $"\n 4: 7{correctLabel}";
                    correctAnswers.Add(4);
                    break;

                case 66:
                    questionAndAnswers = "\nTrue or False: To use Arrays, you first need to use the System.Collections.Generic; namespace" +
                    $"\n 1: True" +
                    $"\n 2: False{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 67:
                    questionAndAnswers = "\nWhich of these is used to identify the number of elements in an Array?" +
                    $"\n 1: .Count" +
                    $"\n 2: .Max" +
                    $"\n 3: .Length{correctLabel}" +
                    $"\n 4: .MaxNumber";
                    correctAnswers.Add(3);
                    break;

                case 68:
                    questionAndAnswers = "\nMethod overloading is when multiple methods have the same _______, but different ___________." +
                    $"\n 1: parameters, name" +
                    $"\n 2: syntax, variables" +
                    $"\n 3: name, parameters{correctLabel}";
                    correctAnswers.Add(3);
                    break;

                case 69:
                    questionAndAnswers = "\nTrue or False: This won't compile because it has the same signature:" +
                    "\nstatic int Multiply(int a, int b)" +
                    "\n{" +
                    $"\n    return a *b;" +
                    "\n}" +
                    "\nstatic int Multiply(int c, int d)" +
                    "\n{" +
                    $"\n    return c * d;" +
                    "\n}" +
                    $"\n 1: True{correctLabel}" +
                    $"\n 2: False";
                    correctAnswers.Add(1);
                    break;

                case 70:
                    questionAndAnswers = "\nWhen overloading methods, the definitions of the methods must differ from each other by the parameter types and/or number of parameters" +
                    $"\n 1: True{correctLabel}" +
                    $"\n 2: False";
                    correctAnswers.Add(1);
                    break;

                case 71:
                    questionAndAnswers = "\nWhat are the 3 **Required** parts of a Class?" +
                    $"\n 1: Static" +
                    $"\n 2: Name{correctLabel}" +
                    $"\n 3: Class Keyword{correctLabel}" +
                    $"\n 4: Parameters" +
                    $"\n 5: Scope{correctLabel}";
                    correctAnswers.Add(2);
                    correctAnswers.Add(3);
                    correctAnswers.Add(5);
                    break;

                case 72:
                    questionAndAnswers = "\nWhich of the following are items you may find IN a Class?" +
                    $"\n 1: Methods{correctLabel}" +
                    $"\n 2: Namespace" +
                    $"\n 3: Properties{correctLabel}" +
                    $"\n 4: Constructors{correctLabel}" +
                    $"\n 5: Fields{correctLabel}";
                    correctAnswers.Add(1);
                    correctAnswers.Add(3);
                    correctAnswers.Add(4);
                    correctAnswers.Add(5);
                    break;

                case 73:
                    questionAndAnswers = "\nWhat part of this class instantiation is circled in red?" +
                    "\nDog myFirstDog() = new Dog()" +
                    "\nwhere \"Dog()\" is circled in red" +
                    $"\n 1: Name" +
                    $"\n 2: Type" +
                    $"\n 3: Property" +
                    $"\n 4: Constructor{correctLabel}" +
                    $"\n 5: Field";
                    correctAnswers.Add(4);
                    break;

                case 74:
                    questionAndAnswers = "\nYou can only have 1 constructor per class?" +
                    $"\n 1: True" +
                    $"\n 2: False{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 75:
                    questionAndAnswers = "\nWhich of the following is a correctly created class?" +
                    "\nOption1:" +
                    "\nDog class{" +
                    $"\n    private int _numberOfLefts;" +
                    $"\n    public int Age;" +
                    "\n    public string Name {get; set;}" +
                    "\n}" +
                    $"\n" +
                    "\nOption2:" +
                    "\npublic Dog()" +
                    "\n{" +
                    "\n    private int _numberOfLegs;" +
                    $"\n    public int Age;" +
                    "\n    public string Name {get; set;}" +
                    "\n}" +
                    $"\n" +
                    "\nOption3:" +
                    "\nclass Dog" +
                    "\n{" +
                    $"\n    private int _numberOfLegs;" +
                    $"\n    public int Age;" +
                    "\n    public string Name {get; set;};" +
                    "\n}" +
                    $"\n" +
                    "\nOption4:" +
                    "\nnew class God" +
                    "\n{" +
                    $"\n    private int _numberOfLegs;" +
                    $"\n    public int Age;" +
                    "\n    public string Name {get; set;}" +
                    "\n}" +
                    $"\n" +
                    $"\n 1: Option 1" +
                    $"\n 2: Option 2" +
                    $"\n 3: Option 3{correctLabel}" +
                    $"\n 4: Option 4";
                    correctAnswers.Add(3);
                    break;

                case 76:
                    questionAndAnswers = "\nWhat symbol do you use to access class members?" +
                    $"\n 1: ;" +
                    $"\n 2: ," +
                    $"\n 3: \" " +
                    $"\n 4: .{correctLabel}" +
                    $"\n 5: ()";
                    correctAnswers.Add(4);
                    break;

                case 77:
                    questionAndAnswers = "\nWhich of the following demonstrates object initializer syntax?" +
                    $"\n" +
                    "\nOption1:" +
                    "\nDog d = new Dog()" +
                    "\n{" +
                    $"\n    int Age = 5;" +
                    $"\n    string Name = \"Spot\";" +
                    "\n}" +
                    $"\n" +
                    "\nOption2:" +
                    "\nDog d = new Dog();" +
                    "\nd.Age = 5;" +
                    "\nd.Name = \"Spot\";" +
                    $"\n" +
                    "\nOption3:" +
                    "\nDog d = new Dog()" +
                    $"\n(" +
                    $"\n    Age = 5," +
                    $"\n    Name = \"Spot\"" +
                    $"\n)" +
                    $"\n" +
                    "\nOption4:" +
                    "\nDog d = new Dog()" +
                    "\n{" +
                    $"\n    Age = 5," +
                    $"\n    Name = \"Spot\"" +
                    "\n};" +
                    $"\n" +
                    $"\n 1: Option 1" +
                    $"\n 2: Option 2" +
                    $"\n 3: Option 3" +
                    $"\n 4: Option 4{correctLabel}";
                    correctAnswers.Add(4);
                    break;

                case 78:
                    questionAndAnswers = "\nHow many class members does this have?" +
                    $"\n" +
                    "\nclass Dog" +
                    "\n{" +
                    $"\n    private int _numberOfLegs;" +
                    "\n    public int Age {get; set;}" +
                    "\n    public string Name {get; set;}" +
                    $"\n    public Dog(string numberOfLegs)" +
                    "\n    {" +
                    $"\n        _numberOfLegs = numberOfLegs;" +
                    "\n    }" +
                    $"\n    public void Bark()" +
                    "\n    {" +
                    $"\n        // method logic" +
                    "\n    }" +
                    $"\n    public void WagTail()" +
                    "\n    {" +
                    $"\n        // method logic" +
                    "\n    }" +
                    "\n}" +
                    $"\n" +
                    $"\n 1: 6{correctLabel}" +
                    $"\n 2: 1" +
                    $"\n 3: 5" +
                    $"\n 4: 3";
                    correctAnswers.Add(1);
                    break;

                case 79:
                    questionAndAnswers = "\nCreating a class file is the same as instantiating a class?" +
                    $"\n 1: True" +
                    $"\n 2: False{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 80:
                    questionAndAnswers = "\nWhat is the default access modifier for a class member?" +
                    $"\n 1: internal" +
                    $"\n 2: private{correctLabel}" +
                    $"\n 3: public" +
                    $"\n 4: protected";
                    correctAnswers.Add(2);
                    break;

                case 81:
                    questionAndAnswers = "\nConstructors are special types of methods of a class that get executed when its object is created" +
                    $"\n 1: True{correctLabel}" +
                    $"\n 2: False";
                    correctAnswers.Add(1);
                    break;

                case 82:
                    questionAndAnswers = "\nHow many types of constructors are there in C#?" +
                    $"\n 1: 10" +
                    $"\n 2: 9" +
                    $"\n 3: 20" +
                    $"\n 4: 5{correctLabel}";
                    correctAnswers.Add(4);
                    break;

                case 83:
                    questionAndAnswers = "\nConstructor without a parameter is called" +
                    $"\n 1: static constructor" +
                    $"\n 2: Null Constructor" +
                    $"\n 3: Default Constructor{correctLabel}";
                    correctAnswers.Add(3);
                    break;

                case 84:
                    questionAndAnswers = "\nHow many constructors can be defined in a class?" +
                    $"\n 1: 9000" +
                    $"\n 2: An optional no-argument constructor plus ‘n’ number of parameterized constructors.{correctLabel}" +
                    $"\n 3: One no-argument constructor";
                    correctAnswers.Add(2);
                    break;

                case 85:
                    questionAndAnswers = "\nWe cannot create instances of static classes. Can we have constructors for static classes?" +
                    $"\n 1: Yes{correctLabel}" +
                    $"\n 2: No";
                    correctAnswers.Add(1);
                    break;

                case 86:
                    questionAndAnswers = "\nCan you prevent a class from being instantiated?" +
                    $"\n 1: Yes{correctLabel}" +
                    $"\n 2: No";
                    correctAnswers.Add(2);
                    break;

                case 87:
                    questionAndAnswers = "\nWhat is the syntax for inheritance?" +
                    $"\n 1: semicolon ;" +
                    $"\n 2: colon :{correctLabel}" +
                    $"\n 3: dot ." +
                    $"\n 4: comma ,";
                    correctAnswers.Add(2);
                    break;

                case 88:
                    questionAndAnswers = "\nWhich class is the base class?" +
                    $"\n" +
                    "\nclass Truck : Vehicle" +
                    $"\n" +
                    $"\n 1: class" +
                    $"\n 2: Truck" +
                    $"\n 3: Vehicle{correctLabel}";
                    correctAnswers.Add(3);
                    break;

                case 89:
                    questionAndAnswers = "\nTrue or False : The derived class implicitly gains all the members of the base class" +
                    $"\n 1: True{correctLabel}" +
                    $"\n 2: False";
                    correctAnswers.Add(1);
                    break;

                case 90:
                    questionAndAnswers = "\nTrue or False: Constructors are inherited" +
                    $"\n 1: True" +
                    $"\n 2: False{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 91:
                    questionAndAnswers = "\nWhich class is the derived class?" +
                    $"\n" +
                    "\nclass AI : Human" +
                    $"\n" +
                    $"\n 1: class" +
                    $"\n 2: Human" +
                    $"\n 3: AI{correctLabel}";
                    correctAnswers.Add(3);
                    break;

                case 92:
                    questionAndAnswers = "\nHow many classes can a single class inherit from?" +
                    $"\n 1: 1{correctLabel}" +
                    $"\n 2: 2" +
                    $"\n 3: 3" +
                    $"\n 4: 4" +
                    $"\n 5: Infinite";
                    correctAnswers.Add(1);
                    break;

                case 93:
                    questionAndAnswers = "\nInheritance allows the ______ class to reuse the code in the ________ class without having to rewrite it." +
                    $"\n 1: derived , base{correctLabel}" +
                    $"\n 2: base, derived" +
                    $"\n 3: none of the above";
                    correctAnswers.Add(1);
                    break;

                case 94:
                    questionAndAnswers = "\nWhich of the following statements are true about static classes?" +
                    $"\n 1: Static classes CAN be instantiated" +
                    $"\n 2: Static classes CANNOT be instantiated{correctLabel}" +
                    $"\n 3: Static classes CAN have non-static members" +
                    $"\n 4: Another class CANNOT inherit from a static class{correctLabel}";
                    correctAnswers.Add(2);
                    correctAnswers.Add(4);
                    break;

                case 95:
                    questionAndAnswers = "\nHow many times does the constructor get called for a static class?" +
                    $"\n 1: 2 times" +
                    $"\n 2: 1 time{correctLabel}" +
                    $"\n 3: 0 times (it never gets called)";
                    correctAnswers.Add(1);
                    break;

                case 96:
                    questionAndAnswers = "\nWhich of the following demonstrates how you would invoke a static method" +
                    "\nOption1:" +
                    "\nnew Dog.Bark();" +
                    $"\n" +
                    "\nOption2:" +
                    "\nDog pupper = new Dog();" +
                    "\npupper.Bark();" +
                    $"\n" +
                    "\nOption3:" +
                    "\nDog.Bark();" +
                    $"\n" +
                    "\nOption4:" +
                    "\nstatic Dog.Bark();" +
                    $"\n" +
                    $"\n 1: Option 1" +
                    $"\n 2: Option 2" +
                    $"\n 3: Option 3{correctLabel}" +
                    $"\n 4: Option 4";
                    correctAnswers.Add(3);
                    break;

                case 97:
                    questionAndAnswers = "\nHow many copies of static members are there per class?" +
                    $"\n 1: 2" +
                    $"\n 2: 1{correctLabel}" +
                    $"\n 3: undefined";
                    correctAnswers.Add(2);
                    break;

                case 98:
                    questionAndAnswers = "\nOnly the methods in a static class need to be made static" +
                    $"\n 1: True" +
                    $"\n 2: False{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 99:
                    questionAndAnswers = "\nWhy would you use an abstract class?" +
                    $"\n 1: To enable multiple inheritance" +
                    $"\n 2: To create a partial class that serves as a template for its derived classes{correctLabel}" +
                    $"\n 3: When you want have a base class to instantiate";
                    correctAnswers.Add(2);
                    break;

                case 100:
                    questionAndAnswers = "\nWhich of the following describes Abstract Classes?" +
                    $"\n 1: It is an example of static polymorphism" +
                    $"\n 2: It is an example of dynamic polymorphism{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 101:
                    questionAndAnswers = "\nWhich of the following describes Polymorphism" +
                    $"\n 1: Combining similar properties and characteristics into a common object" +
                    $"\n 2: Information hiding" +
                    $"\n 3: One thing having many forms{correctLabel}";
                    correctAnswers.Add(3);
                    break;

                case 102:
                    questionAndAnswers = "\nWhat is dynamic polymorphism?" +
                    $"\n 1: Objects of a derived class may be treated as objects of a base class{correctLabel}" +
                    $"\n 2: Method overloading";
                    correctAnswers.Add(1);
                    break;

                case 103:
                    questionAndAnswers = "\nWhen would you want to use the abstract keyword for a method in an abstract class?" +
                    $"\n 1: When you want the derived class to define the method implementation or accessor{correctLabel}" +
                    $"\n 2: When you want the abstract class to define the method or accessor" +
                    $"\n 3: When you want the abstract class to define the method or accessor and give the derived class the ability to override the implementation";
                    correctAnswers.Add(1);
                    break;

                case 104:
                    questionAndAnswers = "\nWhen would you want to use the virtual keyword in an abstract class?" +
                    $"\n 1: When you want the derived class to define the method or accessor" +
                    $"\n 2: When you want the abstract class to define the method or accessor" +
                    $"\n 3: When you want the abstract class to define the method or accessor and give the derived class the ability to override the implementation{correctLabel}";
                    correctAnswers.Add(3);
                    break;

                case 105:
                    questionAndAnswers = "\nWhat is an abstract class?" +
                    $"\n 1: An abstract class is one without any child classes" +
                    $"\n 2: An abstract class is any parent class with more than one child class" +
                    $"\n 3: An abstract class is class which cannot be instantiated, but can be a base class{correctLabel}" +
                    $"\n 4: abstract class is another name for \"base class\"";
                    correctAnswers.Add(3);
                    break;

                case 106:
                    questionAndAnswers = "\nWhat is an advantage of polymorphism?" +
                    $"\n 1: The same program logic can be used with objects of several related types{correctLabel}" +
                    $"\n 2: Variables can be re-used in order to save memory" +
                    $"\n 3: Constructing new objects from old objects of a similar type saves time" +
                    $"\n 4: Polymorphism is a dangerous aspect of inheritance and should be avoided";
                    correctAnswers.Add(1);
                    break;

                case 107:
                    questionAndAnswers = "\nAn interface does not care about the _________________. It merely requires that it is implemented." +
                    $"\n 1: Base class" +
                    $"\n 2: Implementation{correctLabel}" +
                    $"\n 3: Properties" +
                    $"\n 4: Methods";
                    correctAnswers.Add(2);
                    break;

                case 108:
                    questionAndAnswers = "\nWhat is the correct Interface naming convention of the following:" +
                    $"\n 1: IsampleInterface" +
                    $"\n 2: IOtherinterface" +
                    $"\n 3: ISampleInterface{correctLabel}";
                    correctAnswers.Add(3);
                    break;

                case 109:
                    questionAndAnswers = "\nTrue or False: Classes can implement multiple interfaces?" +
                    $"\n 1: True{correctLabel}" +
                    $"\n 2: False";
                    correctAnswers.Add(1);
                    break;

                case 110:
                    questionAndAnswers = "\nWhat is the syntax to implement an interface?" +
                    $"\n 1: semicolon ;" +
                    $"\n 2: colon :{correctLabel}" +
                    $"\n 3: comma ," +
                    $"\n 4: dot .";
                    correctAnswers.Add(2);
                    break;

                case 111:
                    questionAndAnswers = "\nHow many times can you implement the same Interface?" +
                    $"\n 1: 1" +
                    $"\n 2: 2" +
                    $"\n 3: 3" +
                    $"\n 4: 4" +
                    $"\n 5: As many times as you have classes{correctLabel}";
                    correctAnswers.Add(5);
                    break;

                case 112:
                    questionAndAnswers = "\nTrue or False: You must use an interface if you want to simulate inheritance for structs" +
                    $"\n 1: True{correctLabel}" +
                    $"\n 2: False";
                    correctAnswers.Add(1);
                    break;

                case 113:
                    questionAndAnswers = "\nWhen a class or struct implements an interface, the class or struct must provide the _____________." +
                    $"\n 1: Base Class" +
                    $"\n 2: Implementation{correctLabel}" +
                    $"\n 3: Abstraction";
                    correctAnswers.Add(2);
                    break;

                case 114:
                    questionAndAnswers = "\nFactory Pattern is:" +
                    $"\n 1: A design pattern that ensures only one instance of a given object exists" +
                    $"\n 2: A design pattern in which one class copies other instances of objects" +
                    $"\n 3: A design pattern that utilizes one class to handle object creation at Runtime{correctLabel}" +
                    $"\n 4: A design pattern where an object bridges the gap between two objects";
                    correctAnswers.Add(3);
                    break;

                case 115:
                    questionAndAnswers = "\nFactory Pattern can only be achieved by using an interface?" +
                    $"\n 1: True" +
                    $"\n 2: False{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 116:
                    questionAndAnswers = "\nDoes factory pattern utilize polymorphism?" +
                    $"\n 1: Yes{correctLabel}" +
                    $"\n 2: No";
                    correctAnswers.Add(1);
                    break;

                case 117:
                    questionAndAnswers = "\nWhen the client passes the information to the program to create the class, where is the class instantiated?" +
                    $"\n 1: In the concrete class" +
                    $"\n 2: In the factory{correctLabel}" +
                    $"\n 3: In the interface/abstract class" +
                    $"\n 4: On the client side";
                    correctAnswers.Add(2);
                    break;

                case 118:
                    questionAndAnswers = "\nWhat does LINQ stand for?" +
                    $"\n 1: Language Interpreted Query" +
                    $"\n 2: Linq Integrated Query" +
                    $"\n 3: Language Integrated Query{correctLabel}" +
                    $"\n 4: Liskovs Inversion Query";
                    correctAnswers.Add(3);
                    break;

                case 119:
                    questionAndAnswers = "\nSelect the two types of syntax used in LINQ" +
                    $"\n 1: Query Syntax{correctLabel}" +
                    $"\n 2: LINQ Syntax" +
                    $"\n 3: SQL Syntax" +
                    $"\n 4: Method Syntax{correctLabel}";
                    correctAnswers.Add(1);
                    correctAnswers.Add(4);
                    break;

                case 120:
                    questionAndAnswers = "\nWhat namespace is needed to access LINQ?" +
                    $"\n 1: System.Collection.Linq" +
                    $"\n 2: System.Collection.Generic" +
                    $"\n 3: Linq.Collection" +
                    $"\n 4: System.Linq{correctLabel}";
                    correctAnswers.Add(4);
                    break;

                case 121:
                    questionAndAnswers = "\nWhat does the Where() method do?" +
                    $"\n 1: Gets a single element from the sequence" +
                    $"\n 2: Filters a sequence of values based on a predicate.{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 122:
                    questionAndAnswers = "\nWhat concept does Generics bring to the .NET Framework?" +
                    $"\n 1: System.Collections.Generics;" +
                    $"\n 2: Type Parameters{correctLabel}" +
                    $"\n 3: ArrayLists";
                    correctAnswers.Add(2);
                    break;

                case 123:
                    questionAndAnswers = "\nTrue or False: The elements in a list cannot be inserted and removed dynamically." +
                    $"\n 1: True" +
                    $"\n 2: False{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 124:
                    questionAndAnswers = "\nWhat are the 3 types of errors?" +
                    $"\n 1: Debugging Error" +
                    $"\n 2: Compile Time Error{correctLabel}" +
                    $"\n 3: Interface Error" +
                    $"\n 4: Runtime Error{correctLabel}" +
                    $"\n 5: Logical Error{correctLabel}";
                    correctAnswers.Add(3);
                    correctAnswers.Add(4);
                    correctAnswers.Add(5);
                    break;

                case 125:
                    questionAndAnswers = "\nWhat is an Exception?" +
                    $"\n 1: An error that will only show up at compile-time" +
                    $"\n 2: An error that occurs during runtime of an application{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 126:
                    questionAndAnswers = "\nWill this line of code throw an exception?" +
                    $"\n" +
                    "\nint i = 10 / 0;" +
                    $"\n" +
                    $"\n 1: Yes{correctLabel}" +
                    $"\n 2: No" +
                    $"\n 3: Not enough information";
                    correctAnswers.Add(1);
                    break;

                case 127:
                    questionAndAnswers = "\nWill this cause an error?" +
                    $"\n" +
                    "\nint[] numbers = new int[5] {11,32,43,65,3};" +
                    "\nConsole.WriteLine(numbers[5]);" +
                    $"\n" +
                    $"\n 1: Yes{correctLabel}" +
                    $"\n 2: No" +
                    $"\n 3: Not enough information";
                    correctAnswers.Add(1);
                    break;

                case 128:
                    questionAndAnswers = "\nTesting your app is a good way to prevent debugging altogether" +
                    $"\n 1: True{correctLabel}" +
                    $"\n 2: False";
                    correctAnswers.Add(1);
                    break;

                case 129:
                    questionAndAnswers = "\nTrue or False: A try block is used by C# programmers to partition code that might be affected by an exception." +
                    $"\n 1: True{correctLabel}" +
                    $"\n 2: False";
                    correctAnswers.Add(1);
                    break;

                case 130:
                    questionAndAnswers = "\nHow many catch blocks can a try block have with it?" +
                    $"\n 1: No more than 3" +
                    $"\n 2: 2 or more" +
                    $"\n 3: 1 or more{correctLabel}" +
                    $"\n 4: none";
                    correctAnswers.Add(3);
                    break;

                case 131:
                    questionAndAnswers = "\nTrue or False: A finally block does not always run" +
                    $"\n 1: True" +
                    $"\n 2: False{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 132:
                    questionAndAnswers = "\nUsing Exception in the exception filter of a catch is considered to be the most specific and thus should be the first catch block?" +
                    $"\n 1: True" +
                    $"\n 2: False{correctLabel}";
                    correctAnswers.Add(2);
                    break;

                case 133:
                    questionAndAnswers = "\nUsing TDD (Test Driven Development) what is the first step after writing just enough code to complete the test?" +
                    $"\n 1: Run the Test and watch it fail{correctLabel}" +
                    $"\n 2: Implement the feature";
                    correctAnswers.Add(1);
                    break;

                case 134:
                    questionAndAnswers = "\nThis is where we actually call the method you want to test" +
                    $"\n 1: Act{correctLabel}" +
                    $"\n 2: Arrange" +
                    $"\n 3: Assert";
                    correctAnswers.Add(1);
                    break;

                case 135:
                    questionAndAnswers = "\nA ________ is the smallest testable part of any software" +
                    $"\n 1: method" +
                    $"\n 2: unit{correctLabel}" +
                    $"\n 3: test";
                    correctAnswers.Add(2);
                    break;

                case 136:
                    questionAndAnswers = "\nThis is where we check against a constant (check against what is expected)" +
                    $"\n 1: Arrange" +
                    $"\n 2: Act" +
                    $"\n 3: Assert{correctLabel}";
                    correctAnswers.Add(3);
                    break;

                case 137:
                    questionAndAnswers = "\nWhen we change code without changing how the code behaves" +
                    $"\n 1: instantiation" +
                    $"\n 2: inheritance" +
                    $"\n 3: refactoring{correctLabel}" +
                    $"\n 4: initialization";
                    correctAnswers.Add(3);
                    break;

                case 138:
                    questionAndAnswers = "\nThis is where we prepare the code in order to call the method you need to test" +
                    $"\n 1: Act" +
                    $"\n 2: Arrange{correctLabel}" +
                    $"\n 3: Assert";
                    correctAnswers.Add(2);
                    break;
                default:
                    questionAndAnswers = "\nwe done made a mistake";
                    correctAnswers.Add(0);
                    break;
            }
            Console.WriteLine(questionAndAnswers);
            return correctAnswers;
        }

        public string AskQuestion(int forcedQuestion = 0)
        {
            bool acceptableInput = false;
            bool gotInt = false;
            int userAnswerInput;
            int questionNum;
            if (forcedQuestion == 0)
            {
                Random rand = new Random();
                questionNum = rand.Next(1, 139);
            }
            else
                questionNum = forcedQuestion;
            List<int> userAnswersSelected = new List<int>();
            var correctAnswerChoice = DisplayQuestion(questionNum);
            for (int i = 0; i < correctAnswerChoice.Count; i++)
            {
                do
                {
                    Console.WriteLine($"please enter your answer ({i + 1} of {correctAnswerChoice.Count}) enter 0 to exit");
                    gotInt = int.TryParse(Console.ReadLine(), out userAnswerInput);
                    acceptableInput = (gotInt && 0 <= userAnswerInput && userAnswerInput <= numberOfAnswerOptions) ? true : false;
                } while (!acceptableInput);
                userAnswersSelected.Add(userAnswerInput);
            }
            if (userAnswersSelected.Contains(0))
                return "exit";
            foreach (var userAnswer in userAnswersSelected)
            {
                if (!correctAnswerChoice.Contains(userAnswer))
                {
                    if (!failedQuestions.Contains(questionNum))
                        failedQuestions.Add(questionNum);
                    return "incorrect";
                }
            }
            return "correct";
        }

        public void RedeemYourself()
        {
            bool continueRedemption = true;
            Random rand = new Random();
            int redemptionQuestionIndex;
            int redemptionQuestionNumber;
            do
            {
                if (failedQuestions.Count == 0)
                {
                    Console.WriteLine("you have redeemed yourself! youve answered all previously incorrect answers. great jorb!");
                    continueRedemption = false;
                    Thread.Sleep(3000);
                }
                else
                {
                    DisplayRedemptionStats();
                    redemptionQuestionIndex = rand.Next(0, failedQuestions.Count);
                    redemptionQuestionNumber = failedQuestions[redemptionQuestionIndex];
                    var userAnswer = AskQuestion(redemptionQuestionNumber);
                    if (userAnswer != "exit")
                    {
                        Console.WriteLine($"{userAnswer}!");
                        if (userAnswer == "correct")
                        {
                            Console.WriteLine("redemption question correct!");
                            if (failedQuestions.Contains(redemptionQuestionNumber))
                            {
                                failedQuestions.Remove(redemptionQuestionNumber);
                                Console.WriteLine($"removing {redemptionQuestionNumber} from failedQuestions!");
                            }
                        }
                        Thread.Sleep(1000);
                        UpdateRedemptionStats(userAnswer);
                    }
                    else
                        continueRedemption = false;
                }
            } while (continueRedemption);
        }

        public int AskForInt(string msg = "please enter a number", int lowerLimit = 0, int upperLimit = 1000)
        {
            bool gotInt = false;
            bool intOkay = false;
            int userInput;
            do
            {
                Console.Clear();
                Console.WriteLine(msg);
                gotInt = int.TryParse(Console.ReadLine(), out userInput);
                intOkay = (gotInt && lowerLimit <= userInput && userInput <= upperLimit) ? true : false;
            } while (!intOkay);
            return userInput;
        }

        public void UpdateConfiguration()
        {
            bool updatingConfig = true;
            int userSelection;
            int showAnswerSelection;
            do
            {
                userSelection = AskForInt("please select option to view/edit:\n0: cancel/return\n1: toggle showAnswer", 0,1);
                switch (userSelection)
                {
                    case 1:
                        showAnswerSelection = AskForInt($"show answer currently set as {showAnswer}\nenter 0: set to false\nenter 1: set to true", 0, 1);
                        showAnswer = (showAnswerSelection == 1) ? true : false;
                        Console.WriteLine($"show answer = {showAnswer}");
                        Thread.Sleep(500);
                        break;
                    case 0:
                    default:
                        Console.WriteLine("returning...");
                        updatingConfig = false;
                        Thread.Sleep(500);
                        break;
                }
            } while (updatingConfig);
        }

    public void Run()
        {
            bool iLoveFunTimeQuizzes = true;
            string userAnswer;
            Console.Clear();
            for (int t = 3; t > 0; t--)
            {
                Console.WriteLine($"starting fun time quiz in {t}!");
                Thread.Sleep(1000);
                Console.Clear();
            }
            do
            {
                DisplayStats();
                userAnswer = AskQuestion();
                if (userAnswer != "exit")
                {
                    Console.WriteLine($"{userAnswer}!");
                    Thread.Sleep(500);
                    UpdateStats(userAnswer);
                }
                else
                {
                    iLoveFunTimeQuizzes = false;
                    Thread.Sleep(500);
                }
            } while (iLoveFunTimeQuizzes);
            Console.WriteLine("goodbye my friend\n");
        }
    }
}
