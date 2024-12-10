using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWritterEffect : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Referensi ke TextMeshPro
    public float typingSpeed = 0.03f;   // Kecepatan mengetik

    private string[] paragraphs = new string[]
    {
        "Di seluruh dunia, kelaparan merupakan salah satu masalah global yang terus menjadi perhatian besar, baik di negara berkembang maupun negara maju. Menurut laporan PBB dan organisasi-organisasi kemanusiaan lainnya, lebih dari 800 juta orang di dunia mengalami kelaparan kronis.",
        "Ketimpangan distribusi makanan, bencana alam, konflik, dan ketidakstabilan ekonomi merupakan beberapa faktor yang menyebabkan ketidakmampuan akses terhadap makanan yang bergizi.",
        "Game \"Saviour Chef\" hadir untuk menggambarkan peran penting yang dapat dilakukan oleh siapa saja, yang ingin membantu mengatasi masalah kelaparan, tidak hanya dalam konteks memasak, tetapi juga dalam membantu menciptakan solusi berkelanjutan dan memperkenalkan nilai-nilai solidaritas, kesadaran sosial, dan kreativitas dalam berbagi makanan."
    };

    private int currentParagraph = 0; // Indeks paragraf saat ini
    private string currentText = "";

    void Start()
    {
        StartCoroutine(ShowParagraph());
    }

    IEnumerator ShowParagraph()
    {
        while (currentParagraph < paragraphs.Length)
        {
            string fullText = paragraphs[currentParagraph];
            currentText = "";

            // Efek typewriter untuk setiap paragraf
            for (int i = 0; i <= fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i);
                textMeshPro.text = currentText;
                yield return new WaitForSeconds(typingSpeed);
            }

            // Tunggu sebelum menampilkan paragraf berikutnya
            yield return new WaitForSeconds(2.0f); // Delay antara paragraf
            currentParagraph++;
        }
    }
}
