// Sesli Asistan - Metin komutları ile asistan simülasyonu (ses girişi konsol üzerinden)
using System;
using System.Collections.Generic;

namespace SesliAsistan;

class Program
{
    static Dictionary<string, Action> komutlar = new(StringComparer.OrdinalIgnoreCase);

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        komutlar["saat"] = () => Console.WriteLine("Saat: " + DateTime.Now.ToString("HH:mm"));
        komutlar["tarih"] = () => Console.WriteLine("Tarih: " + DateTime.Now.ToString("dd.MM.yyyy"));
        komutlar["merhaba"] = () => Console.WriteLine("Merhaba! Ben sesli asistan simülasyonuyum.");
        komutlar["yardım"] = () =>
        {
            Console.WriteLine("Komutlar: saat, tarih, merhaba, yardım, cikis");
        };

        Console.WriteLine("=== Sesli Asistan (Metin Komut) ===\n");
        Console.WriteLine("Komut yazın: saat, tarih, merhaba, yardım. Çıkmak için: cikis");

        while (true)
        {
            Console.Write("\nKomut: ");
            var giris = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(giris) || giris.Equals("cikis", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Görüşürüz.");
                break;
            }

            if (komutlar.TryGetValue(giris, out var aksiyon))
                aksiyon();
            else
                Console.WriteLine("Bilinmeyen komut. 'yardım' yazın.");
        }
    }
}
