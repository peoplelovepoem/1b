using System;

namespace DuongTron
{
    class Diem
    {
        private int x;
        private int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Diem() { x = 0; y = 0; }
        public Diem(int _x, int _y) { x = _x; y = _y; }
        public Diem(Diem p) { X = p.X; Y = p.Y; }

        public void Nhap()
        {
            Console.Write("Nhap hoanh do x: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("Nhap tung do y: ");
            y = int.Parse(Console.ReadLine());
        }

        public double KhoangCach(Diem b)
        {
            return Math.Sqrt(Math.Pow(this.x - b.X, 2) + Math.Pow(this.y - b.Y, 2));
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
    }
}

namespace DuongTron
{
    class DuongTron
    {
        private Diem tam;
        private int banKinh;

        public Diem Tam
        {
            get { return tam; }
            set { tam = value; }
        }

        public int BanKinh
        {
            get { return banKinh; }
            set { banKinh = value; }
        }

        public DuongTron()
        {
            tam = new Diem();
            banKinh = 0;
        }

        public DuongTron(Diem t, int r)
        {
            Tam = t;
            BanKinh = r;
        }

        public DuongTron(DuongTron dt)
        {
            Tam = new Diem(dt.Tam);
            BanKinh = dt.BanKinh;
        }

        public void Nhap()
        {
            Console.WriteLine("- Nhap toa do tam:");
            tam.Nhap();
            Console.Write("- Nhap ban kinh: ");
            banKinh = int.Parse(Console.ReadLine());
        }

        public void Xuat()
        {
            Console.WriteLine("Tam " + tam.ToString() + ", r = " + banKinh);
        }

        public double ChuVi()
        {
            return 2 * Math.PI * BanKinh;
        }

        public double DienTich()
        {
            return Math.PI * Math.Pow(BanKinh, 2);
        }

        public void KiemTraViTriTuongDoi(Diem p)
        {
            double d = tam.KhoangCach(p);
            if (d < banKinh)
                Console.WriteLine("=> Diem nam TRONG duong tron.");
            else if (d == banKinh)
                Console.WriteLine("=> Diem nam TREN duong tron.");
            else
                Console.WriteLine("=> Diem nam NGOAI duong tron.");
        }

        public void KiemTraViTriTuongDoi(DuongTron dtKhac)
        {
            double d = tam.KhoangCach(dtKhac.Tam);
            double r1 = this.BanKinh;
            double r2 = dtKhac.BanKinh;

            if (d > r1 + r2)
                Console.WriteLine("=> Hai duong tron NGOAI nhau.");
            else if (d == r1 + r2)
                Console.WriteLine("=> Hai duong tron TIEP XUC NGOAI.");
            else if (d < r1 + r2 && d > Math.Abs(r1 - r2))
                Console.WriteLine("=> Hai duong tron CAT NHAU.");
            else if (d == Math.Abs(r1 - r2) && d != 0)
                Console.WriteLine("=> Hai duong tron TIEP XUC TRONG.");
            else if (d == 0 && r1 == r2)
                Console.WriteLine("=> Hai duong tron TRUNG NHAU.");
            else
                Console.WriteLine("=> Hai duong tron CHUA NHAU.");
        }
    }
}

namespace DuongTron
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- NHAP DUONG TRON 1 ---");
            DuongTron dt1 = new DuongTron();
            dt1.Nhap();

            Console.WriteLine("\n--- THONG TIN DUONG TRON 1 ---");
            dt1.Xuat();
            Console.WriteLine("Chu vi: " + dt1.ChuVi());
            Console.WriteLine("Dien tich: " + dt1.DienTich());

            Console.WriteLine("\n--- KIEM TRA VOI 1 DIEM ---");
            Diem p = new Diem();
            p.Nhap();
            dt1.KiemTraViTriTuongDoi(p);

            Console.WriteLine("\n--- KIEM TRA VOI DUONG TRON 2 ---");
            DuongTron dt2 = new DuongTron();
            dt2.Nhap();
            dt1.KiemTraViTriTuongDoi(dt2);

            Console.ReadLine();
        }
    }
}