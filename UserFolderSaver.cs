using System;



public class UserFolderSaver : Saver    //a child class
          // : Saver means inheritance(It gets all the feilds and methods of Saver for free, including Save)
{

    public UserFolderSaver() : base()    //: base() means "first run the constructor of the parent class
    {
        // Source - https://stackoverflow.com/a/19329696
        // Posted by xxbbcc, modified by community. See post 'Timeline' for change history
        // Retrieved 2026-10-18, License - CC BY-SA 3.0

        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
       //string path = "C:\\Users\\rika";
        this.savePath = path;

            //This finds the user's Documents folder and saves the path in the feild savePath
            //(which comes from the parent, and thats why it must be protected)
    }
}

public class ProjectFolderSaver : Saver    //another child class
{
    public override void Save(string content)  //override means "I replace the parent's Save with my own version".
                                               //It only works because the parent wrote virtual.
    {
        string path = @"../../../";          /* The @ before a text means backlashes are not special,
                                                so you don't need to double them ../../../ means "go up 3 folders",
                                              from the build folder to your project folder. */


       // string filename = "typedemo_03.txt";

        path = Path.GetFullPath(path);
        string path_file = Path.Combine(path, this.filename);

        Console.WriteLine($"Gemmer {content} i {path_file}");
        File.WriteAllText(path + filename, content);
    }
}

