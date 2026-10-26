using System;

public class Saver     // its a parent class
{
    protected string savePath;
    protected string filename = "typedemo_03.txt";

    public Saver()
    {
        // empty constructor because the default one gets deleted

    }

    public Saver(string savePath)
    {
        this.savePath = savePath;     // constructor due to which the default one gets deleted
        
    }

    public virtual void Save(string content)   // virtual: "A child class is allowed to replace this method
    {
        System.IO.File.WriteAllText(this.savePath + "\\" + this.filename, content);
        
    }

    
}