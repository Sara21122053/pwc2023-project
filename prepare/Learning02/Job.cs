using System;

public class Job
{
    public string _jobTitule;
    public string _companyName;
    public int _startYear;
    public int _endYear;
    public void Display()
    {
        Console.WriteLine($"{_jobTitule} ({_companyName}) {_startYear} - {_endYear}");
    }
}