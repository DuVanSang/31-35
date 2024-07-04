using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class SinhVien
{
    public string MSSV { get; set; }
    public string HoTen { get; set; }
    public double DiemToan { get; set; }
    public double DiemLy { get; set; }
    public double DiemHoa { get; set; }

    public double DiemTrungBinh
    {
        get { return (DiemToan + DiemLy + DiemHoa) / 3; }
    }
}

class Bai31
{
    static void Main(string[] args)
    {
        
        List<SinhVien> danhSachSinhVien = new List<SinhVien>();

        try
        {
            int soLuongSinhVien = NhapSoLuongSinhVien();
            NhapThongTinSinhVien(danhSachSinhVien, soLuongSinhVien);
            TinhDiemTrungBinh(danhSachSinhVien);
            HienThiThongTinSinhVien(danhSachSinhVien);
            HienThiSinhVienDiemTrungBinhCao(danhSachSinhVien);
            DemSinhVienDiemTrungBinhLonHon5(danhSachSinhVien);
            SapXepSinhVienTheoDiemTrungBinh(danhSachSinhVien);
            SapXepSinhVienTheoTen(danhSachSinhVien);

            Console.WriteLine("Nhap ten file de ghi thong tin sinh vien:");
            string fileName = Console.ReadLine();
            GhiThongTinSinhVienVaoFile(danhSachSinhVien, fileName);

            Console.WriteLine("Doc thong tin sinh vien tu file:");
            string readFileName = Console.ReadLine();
            DocThongTinSinhVienTuFile(readFileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Loi: {ex.Message}");
        }
    }

    static int NhapSoLuongSinhVien()
    {
        int soLuong;
        while (true)
        {
            Console.WriteLine("Nhap so luong sinh vien:");
            if (int.TryParse(Console.ReadLine(), out soLuong) && soLuong > 0)
                break;
            else
                Console.WriteLine("So luong sinh vien phai la so nguyen duong. Vui long nhap lai.");
        }
        return soLuong;
    }

    static void NhapThongTinSinhVien(List<SinhVien> danhSach, int soLuong)
    {
        for (int i = 0; i < soLuong; i++)
        {
            SinhVien sv = new SinhVien();
            Console.WriteLine($"Nhap thong tin cho sinh vien thu {i + 1}:");

            Console.Write("MSSV: ");
            sv.MSSV = Console.ReadLine();

            Console.Write("Ho ten: ");
            sv.HoTen = Console.ReadLine();

            sv.DiemToan = NhapDiem("Diem Toan");
            sv.DiemLy = NhapDiem("Diem Ly");
            sv.DiemHoa = NhapDiem("Diem Hoa");

            danhSach.Add(sv);
        }
    }

    static double NhapDiem(string monHoc)
    {
        double diem;
        while (true)
        {
            Console.Write($"{monHoc}: ");
            if (double.TryParse(Console.ReadLine(), out diem) && diem >= 0 && diem <= 10)
                break;
            else
                Console.WriteLine("Diem phai la so thuc tu 0 den 10. Vui long nhap lai.");
        }
        return diem;
    }

    static void TinhDiemTrungBinh(List<SinhVien> danhSach)
    {
        foreach (var sv in danhSach)
        {
            // Diem trung binh duoc tinh trong property DiemTrungBinh, khong can tinh o day
        }
    }

    static void HienThiThongTinSinhVien(List<SinhVien> danhSach)
    {
        Console.WriteLine("Thong tin sinh vien:");
        foreach (var sv in danhSach)
        {
            Console.WriteLine($"MSSV: {sv.MSSV}, Ho ten: {sv.HoTen}, Diem trung binh: {sv.DiemTrungBinh:F2}");
        }
    }

    static void HienThiSinhVienDiemTrungBinhCao(List<SinhVien> danhSach)
    {
        foreach (var sv in danhSach)
        {
            if (sv.DiemTrungBinh > 9.5)
            {
                Console.WriteLine($"Sinh vien co diem trung binh > 9.5 dau tien: MSSV: {sv.MSSV}, Ho ten: {sv.HoTen}, Diem trung binh: {sv.DiemTrungBinh:F2}");
                break;
            }
        }
    }

    static void DemSinhVienDiemTrungBinhLonHon5(List<SinhVien> danhSach)
    {
        int count = 0;
        foreach (var sv in danhSach)
        {
            if (sv.DiemTrungBinh > 5.0)
            {
                count++;
                continue;
            }
        }
        Console.WriteLine($"So sinh vien co diem trung binh > 5.0: {count}");
    }

    static void SapXepSinhVienTheoDiemTrungBinh(List<SinhVien> danhSach)
    {
        danhSach.Sort((sv1, sv2) => sv1.DiemTrungBinh.CompareTo(sv2.DiemTrungBinh));
        Console.WriteLine("Danh sach sinh vien sau khi sap xep theo diem trung binh tang dan:");
        HienThiThongTinSinhVien(danhSach);
    }

    static void SapXepSinhVienTheoTen(List<SinhVien> danhSach)
    {
        danhSach.Sort((sv1, sv2) => string.Compare(sv1.HoTen, sv2.HoTen));
        Console.WriteLine("Danh sach sinh vien sau khi sap xep theo ten:");
        HienThiThongTinSinhVien(danhSach);
    }

    static void GhiThongTinSinhVienVaoFile(List<SinhVien> danhSach, string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var sv in danhSach)
            {
                writer.WriteLine($"{sv.MSSV},{sv.HoTen},{sv.DiemToan},{sv.DiemLy},{sv.DiemHoa},{sv.DiemTrungBinh:F2}");
            }
        }
    }

    static void DocThongTinSinhVienTuFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    Console.WriteLine($"MSSV: {data[0]}, Ho ten: {data[1]}, Diem Toan: {data[2]}, Diem Ly: {data[3]}, Diem Hoa: {data[4]}, Diem trung binh: {data[5]}");
                }
            }
        }
        else
        {
            Console.WriteLine("File khong ton tai.");
        }
    }
}

