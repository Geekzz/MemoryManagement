namespace MemoryManagement
{
    internal class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>

        /* ------------------------------------------------------------------------------------------------------------------
         * F1: 
         * Stacken: Lagrar värdetyper och referenser, snabb och automatisk frigöring när en metod avslutas
         * Heapen: Lagrar objekt, kräver garbage collection för att frigöra minne, långsammare men flexibel med större minnesutrymme
         * till exempel:
         * int x = 10; <--- x lagras på stacken
         * MyClass obj = new MyClass(); <--- obj referens på stacken, själva objektet på heapen
         * 
         * F2:
         * Value types är nåt som lagrar själva värdet på stacken, och när en value type kopieras, dupliceras värdet. 
         * Värdet påverkar inte den ursprugliga variabeln, tex:
         * int a = 10;
         * int b = a; <--- b får en kopia av värdet, ändrar inte a
         * Reference types är däremot nåt som lagrar en referens på stacken men själva objektet finns på heapen.
         * När en reference type kopieras, delas referensen till objektet, dvs ändringar på en referens påverkar alla som
         * pekar på samma objekt, tex:
         * MyClass obj1 = new MyClass();
         * MyClass obj2 = obj1; <--- obj2 pekar på samma objekt, ändringar påverkar båda
         * 
         * F3:
         * Den första metoden returnerar 3 eftersom int är en value type, vilket innebär att när y kopieras från x,
         * skapas en separat kopia, och ändringar i y påverkar inte x. Den andra metoden returnerar 4 eftersom 
         * MyInt är en reference type, och både x och y pekar på samma objekt, så en ändring via y påverkar också x.
         * Kortfattat: Value types != Reference types
        */
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

            /* ------------------------------------------------------------------------------------------------------------------
             * F2: Den ökar varje fjärde element (första element också, då capacity är 0 från början)
             * F3: 4
             * F4: Om listan skulle växa med 1 element varje gång du lägger till något,
             * skulle datorn behöva göra om minnet ofta, och det skulle bli långsamt och ineffektivt
             * F5: Capacity storlek stannar oförändrad
             * F6: När du vet i förväg exakt hur många element du kommer behöva, så datorn behöver inte 
             * göra om minnet flera gånger
             * ------------------------------------------------------------------------------------------------------------------
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

            /* ------------------------------------------------------------------------------------------------------------------
             * F1: För att stack är Först In Sist Ut (FILO), vilket gör att den som kom in först i ICA kön
             * går ut sist, vilket inte är hur en kö fungerar i verkligheten
             * ------------------------------------------------------------------------------------------------------------------
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

            /* ------------------------------------------------------------------------------------------------------------------
             * F1: Jag använder en stack eftersom den låter mig hantera öppnings och stängningsparenteser i 
             * rätt ordning genom att lägga till dem när de öppnas och ta bort dem när de stängs, 
             * vilket gör så att att strängen är välformad
             * ------------------------------------------------------------------------------------------------------------------
            */

            Console.WriteLine("Enter a string with parentheses to check: ");
            string? input = Console.ReadLine();

            Stack<char> charStack = new Stack<char>();

            foreach (char c in input)
            {
                // if its an opening bracket, push it on the stack
                if (c == '(' || c == '{' || c == '[')
                {
                    charStack.Push(c);
                }
                // if its a closing bracket, check if the stack is empty or if the top doesnt match
                else if (c == ')' || c == '}' || c == ']')
                {
                    // if stack is empty, then its incorrect
                    if (charStack.Count == 0)
                    {
                        Console.WriteLine("The parentheses are not well formed");
                        return;
                    }

                    char lastOpened = charStack.Pop();

                    // check if the popped character matches the opening bracket
                    if ((c == ')' && lastOpened != '(') ||
                        (c == '}' && lastOpened != '{') ||
                        (c == ']' && lastOpened != '['))
                    {
                        Console.WriteLine("The parentheses are not well formed");
                        return;
                    }
                }
            }

            // if stack is empty, then its correct
            if (charStack.Count == 0)
            {
                Console.WriteLine("The parentheses are well formed");
                return;
            }
            else
            {
                Console.WriteLine("The parentheses are not well formed");
                return;
            }
        }
        static int RecursiveOdd(int n)
        {
            // Console.WriteLine("N: " + n);
            if(n == 1)
                return 1;
            return RecursiveOdd(n - 1) + 2;
        }

        static int RecursiveEven(int n)
        {
            Console.WriteLine("N: " + n);
            if (n == 1)
                return 0;
            if (n % 2 != 0)
                n -= 1;
            return n + RecursiveEven(n - 1);
        }

        static int FibonacciRecursive(int n)
        {
            if (n == 0)
                return 0; // fibonacciRecursive(0) = 0
            if (n == 1)
                return 1; // fibonacciRecursive(1) = 1
            return fibonacciRecursive(n - 1) + fibonacciRecursive(n - 2);
        }

        static int IterativeOdd(int n)
        {
            int result = 1;

            for(int i = 0; i < n - 1; i++)
            {
                result += 2;
            }
            return result;
        }

        static int IterativeEven(int n)
        {
            int result = 0;
            for(int i = 0; i <= n; i++)
            {
                if(i % 2 == 0)
                    result += i;
            }
            return result;
        }

        static int FibonacciInterative(int n)
        {
            int result = 0;
            int a = 0;
            int b = 1;

            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            for(int i = 2; i <= n; i++)
            {
                result = a + b;
                a = b; // update a to previous fibonacci number
                b = result; // update b to current fibonacci number
            }

            return result;
        }
    }

}
