using System;

public class Saver
{
    protected string savePath;
    protected string filename = "typedemo_03.txt";

    public Saver()
    {

    }

    public Saver(string savePath)
    {
        this.savePath = savePath;
        
    }

    public virtual void Save(string content)
    {
        System.IO.File.WriteAllText(this.savePath + "\\" + this.filename, content);
        
    }

    
}