namespace ConsoleApp_typedemo_01
{
    internal class Program
    {

        public class Result<T>
        {

            // a class with 3 fields, and no constructor(so c# uses the default one)
            public bool Success;
            public T Value;
            public string FejlForkommer = "";
        }
        static void Main(string[] args)
        {
            Console.Write("Hvilket ord skal der søges efter: ");
            var soegeWord = Console.ReadLine();     // var means (C#, you figure out the type yourself)

            Console.Write("Hvilket tekst skal der søges i: ");
            string hoestakTekst = Console.ReadLine();

            Result<int> result = WordCount(soegeWord, hoestakTekst);    // calling the method WordCount with 2 parameters)

            // If there was an error show it and stop
            if (result.Success == false)
            {
                Console.WriteLine($"Fejl:" + result.FejlForkommer);
                return;     // inside a void method means "stop the method now"
            }
            int antalForekomster = result.Value;

            bool? countState = checkCount(antalForekomster);   // bool? is a nullable bool (normal bool is only true or false,
                                                               // with the ? it can also be null, which means "no value")

            if (countState == null)
            {
                Console.WriteLine("Det søgte ord findes ikke i den angivne tekst.");
            }
            else
            {
                Console.WriteLine($"Ordet ‘{soegeWord}’ forekommer {antalForekomster} gange.");
                if ((bool)countState)    // (bool) is a cast. A bool? can't be used directly in an if.
                {
                    
                    /*Both variables have the type Saver, but the objects are different children. 
                     * Both call Save(...), but each one runs its own version. Its called Polymorphism */

                    Saver saver = new UserFolderSaver();    
                    saver.Save(soegeWord);

                    Saver project = new ProjectFolderSaver();  
                    project.Save(hoestakTekst);
                }
            }




            static Result<int> WordCount(string ord, string tekst)
            {
                Result<int> result = new Result<int>();
                // Error: no word to search for
                if (string.IsNullOrEmpty(ord))   // it checks if a text is null or "" empty. 
                                                 

                {
                    result.Success = false;      // It returns a bool, if its empty the method sets Success = false
                    result.FejlForkommer = "Du skal skrive et ord at søge efter.";    // writes the error message
                    return result;                        // uses return result to stop early.
                }

                // Error: no text to search in
                if (string.IsNullOrEmpty(tekst))
                {
                    result.Success = false;
                    result.FejlForkommer = "Teksten er tom.";
                    return result;
                }


                int count = 0;
                int index = 0;


                // while is a loop, it repeats the code until the condition is true 
                while ((index = tekst.IndexOf(ord, index, StringComparison.OrdinalIgnoreCase)) != -1)
                /* tekst.IndexOf(ord, index...) searches for the word in the text starting at the position index.
                    it returns the position where it found the word. if it finds nothing it returns -1. 

                    StringComparison.OrdinalIgnoreCase means "ignore big and small letters"
                    (index = ...) != -1 does 2 things at once, it saves the position in index, and checks if its not -1.

                */
                {
                    count++;
                    index += ord.Length;    // it moves the search position past the word we just found, so we dont find it again.
                }

                result.Success = true;
                result.Value = count;
                return result;
            }

                static bool? checkCount(int count)    // its a method 
                {
                    if (count == 0)
                    {
                        return null;
                    }
                    else if (count < 10)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                
            }
        }
    }
}

