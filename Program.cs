using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Person obs = new Student { Name = "Nguyễn Văn Nam", Major = "ICT" };

        if (obs is Student student)
        {
            student.kpi();
            Console.WriteLine($"Student Name: {student.Name}, Major: {student.Major}");
        }
        else
        {
            Console.WriteLine("The object is not a Student.");
        }
    }
}

//Nếu Name và Major không hỗ trợ get, set thì điều gì xảy ra?
//Nếu thuộc tính Name và Major không có getter và setter, bạn sẽ không thể truy cập hoặc gán giá trị cho chúng từ bên ngoài lớp. Điều này sẽ dẫn đến lỗi biên dịch khi bạn cố gắng thiết lập hoặc lấy giá trị của các thuộc tính này trong Program.cs. Ví dụ, dòng sau sẽ gây lỗi:


//obs.Name = "Nguyễn Văn Nam"; // Sẽ gây lỗi nếu Name không có set
//string major = student.Major; // Sẽ gây lỗi nếu Major không có get