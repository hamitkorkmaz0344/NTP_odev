// Chat Uygulaması - Basit konsol tabanlı sohbet simülasyonu
using System;
using System.Collections.Generic;

namespace ChatUygulamasi;

class Program
{
    static List<string> mesajlar = new();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== Chat Uygulaması ===\n");
        Console.WriteLine("Komutlar: /gonder <mesaj>, /liste, /cikis");

        while (true)
        {
            Console.Write("\nSiz: ");
            var giris = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(giris)) continue;

            if (giris.StartsWith("/cikis")) break;
            if (giris.StartsWith("/gonder "))
            {
                var msg = giris.Substring(8).Trim();
                if (!string.IsNullOrEmpty(msg))
                {
                    mesajlar.Add($"[{DateTime.Now:HH:mm}] {msg}");
                    Console.WriteLine("Mesaj gönderildi.");
                }
            }
            else if (giris == "/liste")
            {
                Console.WriteLine("\n--- Mesaj Geçmişi ---");
                foreach (var m in mesajlar) Console.WriteLine(m);
            }
            else
                Console.WriteLine("Bilinmeyen komut. /gonder, /liste veya /cikis kullanın.");
        }
        Console.WriteLine("Çıkılıyor...");
    }
}
