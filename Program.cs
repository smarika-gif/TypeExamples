namespace ConsoleApp_typedemo_01
{
    internal class Program
    {

        public class Result<T>
        {
            public bool Success;
            public T Value;
            public string FejlForkommer = "";
        }
        static void Main(string[] args)
        {
            Console.Write("Hvilket ord skal der søges efter: ");
            var soegeWord = Console.ReadLine();

            Console.Write("Hvilket tekst skal der søges i: ");
            string hoestakTekst = Console.ReadLine();

            Result<int> result = WordCount(soegeWord, hoestakTekst);

            // If there was an error show it and stop
            if (result.Success == false)
            {
                Console.WriteLine($"Fejl:" + result.FejlForkommer);
                return;
            }
            int antalForekomster = result.Value;

            bool? countState = checkCount(antalForekomster);

            if (countState == null)
            {
                Console.WriteLine("Det søgte ord findes ikke i den angivne tekst.");
            }
            else
            {
                Console.WriteLine($"Ordet ‘{soegeWord}’ forekommer {antalForekomster} gange.");
                if ((bool)countState)
                {
                    // Source - https://stackoverflow.com/a/19329696
                    // Posted by xxbbcc, modified by community. See post 'Timeline' for change history
                    // Retrieved 2026-10-18, License - CC BY-SA 3.0

                    //string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    //string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

                    //string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
                    //string fileName = Path.Combine(path, @"..\..\..\typedemo_02.txt");

                    //System.IO.File.WriteAllText(fileName, soegeWord);

                    // Saver saver = new Saver(@"..\..\..\typedemo_02.txt");

                    Saver saver = new UserFolderSaver();
                    saver.Save(soegeWord);

                    Saver project = new ProjectFolderSaver();
                    project.Save(hoestakTekst);
                }
            }
        }

        private static bool? checkCount(int antalForekomster)
        {
            throw new NotImplementedException();
        }

        static Result<int> WordCount(string ord, string tekst)
        {
            Result<int> result = new Result<int>();
            // Error: no word to search for
            if (string.IsNullOrEmpty(ord))
            {
                result.Success = false;
                result.FejlForkommer = "Du skal skrive et ord at søge efter.";
                return result;
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

                while ((index = tekst.IndexOf(ord, index, StringComparison.OrdinalIgnoreCase)) != -1)
                {
                    count++;
                    index += ord.Length;
                }

            result.Success = true;
            result.Value = count;
                return result;
            
            static bool? checkCount(int count)
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
