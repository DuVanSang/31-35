using System;

public class Student : Person, KPI
{
    public string Major { get; set; }

    public void kpi()
    {
        // Thực hiện logic cho phương thức kpi
        Console.WriteLine("Calculating KPI for student.");
    }
}