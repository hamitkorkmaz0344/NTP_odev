// MI_math - Matematik işlemleri (hesap makinesi)
using System;

namespace MI_math;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== MI Math - Matematik ===\n");
        Console.WriteLine("İşlemler: + - * / üs kök");
        Console.WriteLine("Örnek: 5 + 3  veya  2 üs 10");

        while (true)
        {
            Console.Write("\nİfade (veya cikis): ");
            var giris = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(giris) || giris.Equals("cikis", StringComparison.OrdinalIgnoreCase)) break;

            try
            {
                var parcalar = giris.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parcalar.Length < 3)
                {
                    Console.WriteLine("En az: sayi islem sayi");
                    continue;
                }

                if (!double.TryParse(parcalar[0], out var a) || !double.TryParse(parcalar[2], out var b))
                {
                    Console.WriteLine("Geçerli sayı girin.");
                    continue;
                }

                var op = parcalar[1].ToLowerInvariant();
                double sonuc = op switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "*" => a * b,
                    "/" => b != 0 ? a / b : double.NaN,
                    "üs" => Math.Pow(a, b),
                    "kök" => b >= 0 ? Math.Pow(b, 1.0 / a) : double.NaN,
                    _ => double.NaN
                };

                if (double.IsNaN(sonuc)) Console.WriteLine("Geçersiz işlem veya bölme/kök hatası.");
                else Console.WriteLine("Sonuç: " + sonuc);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }
        }
    }
}
