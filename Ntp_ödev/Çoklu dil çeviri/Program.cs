// Çoklu Dil Çeviri - Basit sözlük tabanlı çeviri örneği
using System;
using System.Collections.Generic;

namespace CokluDilCeviri;

class Program
{
    static Dictionary<string, Dictionary<string, string>> sozluk = new()
    {
        ["tr"] = new() { { "merhaba", "merhaba" }, { "evet", "evet" }, { "hayır", "hayır" }, { "teşekkür", "teşekkür" } },
        ["en"] = new() { { "merhaba", "hello" }, { "evet", "yes" }, { "hayır", "no" }, { "teşekkür", "thanks" } },
        ["de"] = new() { { "merhaba", "hallo" }, { "evet", "ja" }, { "hayır", "nein" }, { "teşekkür", "danke" } },
    };

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== Çoklu Dil Çeviri ===\n");
        Console.WriteLine("Diller: tr, en, de");
        Console.WriteLine("Örnek: merhaba tr en");

        while (true)
        {
            Console.Write("\nÇevrilecek kelime ve diller (kelime kaynak hedef): ");
            var giris = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(giris) || giris.Equals("cikis", StringComparison.OrdinalIgnoreCase)) break;

            var parcalar = giris.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parcalar.Length < 3)
            {
                Console.WriteLine("Kullanım: kelime kaynak_dil hedef_dil");
                continue;
            }

            var kelime = parcalar[0].ToLowerInvariant();
            var kaynak = parcalar[1].ToLowerInvariant();
            var hedef = parcalar[2].ToLowerInvariant();

            if (!sozluk.ContainsKey(kaynak) || !sozluk.ContainsKey(hedef))
            {
                Console.WriteLine("Desteklenen diller: tr, en, de");
                continue;
            }

            // Önce kaynak dilde kelimeyi bulup Türkçe anahtar kelimeyi bul
            string? turkceAnahtar = null;
            if (kaynak == "tr")
                turkceAnahtar = kelime;
            else
            {
                foreach (var kv in sozluk[kaynak])
                    if (kv.Value.Equals(kelime, StringComparison.OrdinalIgnoreCase)) { turkceAnahtar = kv.Key; break; }
            }

            if (turkceAnahtar == null || !sozluk[hedef].TryGetValue(turkceAnahtar, out var ceviri))
                Console.WriteLine("Kelime sözlükte bulunamadı.");
            else
                Console.WriteLine("Çeviri: " + ceviri);
        }
    }
}
