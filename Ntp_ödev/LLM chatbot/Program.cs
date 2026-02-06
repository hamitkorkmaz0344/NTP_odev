// LLM Chatbot - Basit kural tabanlı bot simülasyonu (gerçek LLM API'si yok)
using System;
using System.Collections.Generic;

namespace LLMChatbot;

class Program
{
    static Dictionary<string, string> yanitlar = new(StringComparer.OrdinalIgnoreCase)
    {
        ["merhaba"] = "Merhaba! Size nasıl yardımcı olabilirim?",
        ["nasılsın"] = "Teşekkürler, iyiyim. Siz nasılsınız?",
        ["adın ne"] = "Ben basit bir chatbot örneğiyim.",
        ["görüşürüz"] = "Görüşürüz, iyi günler!",
    };

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== LLM Chatbot (Simülasyon) ===\n");
        Console.WriteLine("Merhaba, ne sormak istersiniz? (çıkmak için: cikis)");

        while (true)
        {
            Console.Write("\nSiz: ");
            var giris = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(giris) || giris.Equals("cikis", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Görüşürüz!");
                break;
            }

            var cevap = yanitlar.GetValueOrDefault(giris)
                ?? "Bu konuda bilgim yok, ama öğrenmeye açığım.";
            Console.WriteLine("Bot: " + cevap);
        }
    }
}
