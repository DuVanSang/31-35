using System;
using System.Text;

public abstract class Shape
{
    private int _soDinh;

    public int so_dinh
    {
        get { return _soDinh; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Số đỉnh phải lớn hơn 0.");
            }
            _soDinh = value;
        }
    }

    protected Shape(int soDinh)
    {
        so_dinh = soDinh;
    }
}

public class tam_giac : Shape
{
    public tam_giac() : base(3)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        try
        {
            tam_giac tg = new tam_giac();
            Console.WriteLine($"Số đỉnh của tam giác: {tg.so_dinh}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Lỗi: {ex.Message}");
        }

        try
        {
            Shape shape = new tam_giac();
            shape.so_dinh = 4; // Dòng này sẽ gây lỗi vì tam giác phải có 3 đỉnh
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Lỗi: {ex.Message}");
        }
    }
}