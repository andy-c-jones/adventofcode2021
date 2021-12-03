using System;

namespace sonar;

public interface IOutputWriter
{
    void WriteLine(string output);
}

public class ConsoleWriter : IOutputWriter
{
    public void WriteLine(string output) => Console.WriteLine(output);
}