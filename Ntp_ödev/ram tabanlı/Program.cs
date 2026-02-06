// RAM Tabanlı - Bellekte veri saklama ve listeleme (in-memory store)
using System;
using System.Collections.Generic;

namespace RamTabanli;

class Program
{
    static Dictionary<string, string> depo = new(StringComparer.OrdinalIgnoreCase);

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== RAM Tabanlı Veri Deposu ===\n");
        Console.WriteLine("Komutlar: ekle <anahtar> <değer>, getir <anahtar>, listele, sil <anahtar>, cikis");

        while (true)
        {
            Console.Write("\n> ");
            var giris = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(giris) || giris.Equals("cikis", StringComparison.OrdinalIgnoreCase)) break;

            var parcalar = giris.Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);
            var komut = parcalar.Length > 0 ? parcalar[0].ToLowerInvariant() : "";

            switch (komut)
            {
                case "ekle" when parcalar.Length >= 3:
                    depo[parcalar[1]] = parcalar[2];
                    Console.WriteLine("Eklendi.");
                    break;
                case "getir" when parcalar.Length >= 2:
                    Console.WriteLine(depo.TryGetValue(parcalar[1], out var v) ? v : "(yok)");
                    break;
                case "listele":
                    foreach (var kv in depo) Console.WriteLine($"  {kv.Key} = {kv.Value}");
                    if (depo.Count == 0) Console.WriteLine("  (boş)");
                    break;
                case "sil" when parcalar.Length >= 2:
                    if (depo.Remove(parcalar[1])) Console.WriteLine("Silindi."); else Console.WriteLine("Anahtar yok.");
                    break;
                default:
                    Console.WriteLine("Bilinmeyen veya eksik komut.");
                    break;
            }
        }
    }
}
