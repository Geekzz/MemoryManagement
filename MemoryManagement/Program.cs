namespace MemoryManagement
{
    internal class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            /*
             * F2: Den ökar varje fjärde element (första element också, då capacity är 0 från början)
             * F3: 4
             * F4: Om listan skulle växa med 1 element varje gång du lägger till något,
             * skulle datorn behöva göra om minnet ofta, och det skulle bli långsamt och ineffektivt
             * F5: Capacity storlek stannar oförändrad
             * F6: När du vet i förväg exakt hur många element du kommer behöva, så datorn behöver inte 
             * göra om minnet flera gånger
            */

            List<string> theList = new List<string>();

            while (true)
            {
                Console.WriteLine("\nEnter +[name] to add, -[name] to remove, or 'exit' to return to the main menu:");
                string? input = Console.ReadLine();

                if (input == "exit")
                {
                    break; 
                }

                char nav = input[0]; // '+' or '-'
                string value = input.Substring(1); 

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"'{value}' has been added to the list");
                        break;

                    case '-':
                        if (theList.Remove(value))
                        {
                            Console.WriteLine($"'{value}' has been removed from the list");
                        }
                        else
                        {
                            Console.WriteLine($"'{value}' is not in the list");
                        }
                        break;

                    default:
                        Console.WriteLine("Use only +[name] or -[name] to add or remove");
                        break;
                }

                Console.WriteLine($"Number of elements in the list: {theList.Count}");
                Console.WriteLine($"Capacity of the list: {theList.Capacity}");
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> theQueue = new Queue<string>();

            while (true)
            {
                Console.WriteLine("\nEnter +[name] to enqueue ICA shop queue, - to dequeue, or 'exit' to return to the main menu:");
                string? input = Console.ReadLine();

                if (input == "exit")
                {
                    break; 
                }

                char nav = input[0]; // '+' or '-'
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theQueue.Enqueue(value);
                        Console.WriteLine($"'{value}' is getting in line");
                        break;

                    case '-':
                        if (theQueue.Count > 0)
                        {
                            string dequeuedValue = theQueue.Dequeue();
                            Console.WriteLine($"{dequeuedValue} is being served and leaving the line");
                        }
                        else
                        {
                            Console.WriteLine("The queue is empty. Nothing to dequeue");
                        }
                        break;

                    default:
                        Console.WriteLine("Use only +[name] or - to enqueue or dequeue");
                        break;
                }

                // Display queue's info
                Console.WriteLine("Current queue contents: " + string.Join(", ", theQueue));
                Console.WriteLine($"Number of elements in the queue: {theQueue.Count}");
            }
        }


        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            /* F1: För att stack är Först In Sist Ut (FILO), vilket gör att den som kom in först i ICA kön
             * går ut sist, vilket inte är hur en kö fungerar i verkligheten
            */

            Stack<string> theStack = new Stack<string>();

            while (true)
            {
                Console.WriteLine("\nEnter +[name] to push ICA shop, - to pop, or 'exit' to return to the main menu:");
                string? input = Console.ReadLine();

                if (input == "exit")
                {
                    break; 
                }

                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theStack.Push(value);
                        Console.WriteLine($"'{value}' has been pushed onto the ICA shop stack");
                        break;

                    case '-':
                        if (theStack.Count > 0)
                        {
                            string poppedValue = theStack.Pop();
                            Console.WriteLine($"'{poppedValue}' has been popped from the ICA shop stack");
                        }
                        else
                        {
                            Console.WriteLine("The stack is empty. Nothing to pop.");
                        }
                        break;

                    default:
                        Console.WriteLine("Use only +[name] to push or '-' to pop.");
                        break;
                }

                // Display stack's info
                Console.WriteLine("Current stack contents: " + string.Join(", ", theStack));
                Console.WriteLine($"Number of elements in the stack: {theStack.Count}");
            }

            // Reverse after ICA shop stack finshes, you can comment out this if you wish
            ReverseText();
        }

        static void ReverseText()
        {
            Console.WriteLine("Enter a string to reverse: ");
            string? input = Console.ReadLine();

            Stack<char> charStack = new Stack<char>();

            foreach (char ch in input)
            {
                charStack.Push(ch);
            }

            string reversedString = string.Empty;
            while (charStack.Count > 0)
            {
                reversedString += charStack.Pop();
            }
            Console.WriteLine("Reversed string: " + reversedString);
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }
    }
}
