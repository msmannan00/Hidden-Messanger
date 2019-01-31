using System;
using System.IO;

public class helperMethods
{
    /*shared instances*/
    static helperMethods manager = new helperMethods();

    public static helperMethods sharedInstance()
    {
        return manager;
    }

    public String readTextFile(string file_path)
    {
        StreamReader inp_stm = new StreamReader(file_path);

        string inp_ln = "";
        while (!inp_stm.EndOfStream)
        {
            inp_ln += inp_stm.ReadLine()+" ";
            // Do Something with the input. 
        }

        inp_stm.Close();
        return inp_ln;
    }
}
