// Yüz Tanıma - Simülasyon: kayıtlı "yüz" ID'leri ile eşleştirme
using System;
using System.Collections.Generic;

namespace YuzTanima;

class Program
{
    static Dictionary<string, string> kayitliYuzler = new(StringComparer.OrdinalIgnoreCase)
    {
        ["user1"] = "Ahmet",
        ["user2"] = "Ayşe",
        ["user3"] = "Mehmet",
    };

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== Yüz Tanıma (Simülasyon) ===\n");
        Console.WriteLine("Kayıtlı ID'ler: user1, user2, user3");
        Console.WriteLine("Tanıma için ID girin (veya 'kaydet id isim' / 'cikis').");

        while (true)
        {
            Console.Write("\nGiriş: ");
            var giris = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(giris) || giris.Equals("cikis", StringComparison.OrdinalIgnoreCase)) break;

            var parcalar = giris.Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);
            if (parcalar.Length >= 2 && parcalar[0].Equals("kaydet", StringComparison.OrdinalIgnoreCase))
            {
                var id = parcalar[1];
                var isim = parcalar.Length >= 3 ? parcalar[2] : "Bilinmeyen";
                kayitliYuzler[id] = isim;
                Console.WriteLine($"Kaydedildi: {id} -> {isim}");
                continue;
            }

            var arananId = parcalar.Length > 0 ? parcalar[0] : "";
            if (kayitliYuzler.TryGetValue(arananId, out var isim2))
                Console.WriteLine($"Tanındı: {isim2}");
            else
                Console.WriteLine("Tanınmadı. Kayıtlı değil veya geçersiz ID.");
        }
    }
}
