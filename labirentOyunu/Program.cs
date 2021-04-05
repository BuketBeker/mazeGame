using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace labirentOyunu
{
    //Camel Case kullandim.
    //Bombanin nerede oldugunu kullanici oyunun basinda G/g harfine basarak gorebilmektedir.
    class Program
    {
        public static string[,] bomba = new string[10, 10];
        public static string[,] karakter = new string[10, 10];
        public static bool goster = false;
        public static string giris, yon;

        static void Main(string[] args)
        {
            string[,] labirent = new string[10, 10];

            labirentYolu(labirent);
            labirentInsaEt(labirent);

        bastan:
            labirentiYaz(labirent);
            Console.WriteLine("--Bombali labirenti gorebilmek icin lutfen G/g giriniz--");
            Console.Write("Lutfen labirentten bir yol seciniz 1/2/3 veya G/g giriniz:");
            giris = Console.ReadLine();

            if (goster == false)
            {
                if (giris == "G" || giris == "g")
                {
                    Console.Clear();
                    goster = true;
                    bombaYaz();
                    Console.Write("Labirente tekrar donmek icin G/g yaziniz:");
                    giris = Console.ReadLine();
                }
            }
            if (goster == true)
            {
                if (giris == "G" || giris == "g")
                {
                    Console.Clear();
                    goster = false;
                    goto bastan;
                }
            }
            if (giris == "1" && goster == false)
            {
                Console.Clear();
                gez(labirent);
            }
            else if (giris == "2" && goster == false)
            {
                Console.Clear();
                gez(labirent);
            }
            else if (giris == "3" && goster == false)
            {
                Console.Clear();
                gez(labirent);
            }
            Console.ReadKey();
        }
        public static void labirentYolu(string[,] labirent)
        {
            int satir1 = 1;
            int satir2 = 1;
            int satir3 = 1;

            int yol1 = 2, yol2 = 5, yol3 = 8;

            bool sagKontrol1 = true;
            bool sagKontrol2 = true;
            bool sagKontrol3 = true;

            bool solKontrol1 = true;
            bool solKontrol2 = true;
            bool solKontrol3 = true;

            bool bomba1Ekle = true;
            bool bomba2Ekle = true;

            bool hak1 = true;
            bool hak2 = true;
            bool hak3 = true;

            Random rnd = new Random();

            labirent[0, 2] = "1";
            labirent[0, 5] = "1";
            labirent[0, 8] = "1";

            labirent[1, 2] = "1";
            labirent[1, 5] = "1";
            labirent[1, 8] = "1";

            int bombaYol1 = rnd.Next(0, 3);
        tekrar:
            int bombaYol2 = rnd.Next(0, 3);
            while (bombaYol1 == bombaYol2)
            {
                goto tekrar;
            }
            int bombaSatir1 = rnd.Next(2, 9);
            int bombaSatir2 = rnd.Next(2, 9);

            while (satir1 < 9)
            {
                //YOL1
                int sagSolYukari1 = rnd.Next(0, 3);
                if (sagSolYukari1 == 0 && solKontrol1 == true)
                {
                    yol1--;
                    if (yol1 > 0)
                    {
                        labirent[satir1, yol1] = "1";
                        sagKontrol1 = false;
                    }
                    else
                    {
                        satir1++;
                        if (satir1 < 10)
                        {
                            if (yol1 < 1)
                            {
                                yol1 = 1;
                            }
                            labirent[satir1, yol1] = "1";
                            sagKontrol1 = true;
                            solKontrol1 = false;
                        }
                    }
                }
                else if (sagSolYukari1 == 1 && sagKontrol1 == true)
                {
                    yol1++;
                    if (yol1 < 4)
                    {
                        labirent[satir1, yol1] = "1";
                        solKontrol1 = false;
                    }
                    else
                    {
                        satir1++;
                        if (satir1 < 10)
                        {
                            if (yol1 > 3)
                            {
                                yol1 = 3;
                            }
                            labirent[satir1, yol1] = "1";
                            solKontrol1 = true;
                            sagKontrol1 = false;
                        }
                    }
                }
                else if (sagSolYukari1 == 2)
                {
                    satir1++;
                    if (satir1 < 10)
                    {
                        if (yol1 < 1)
                        {
                            yol1 = 1;
                        }
                        if (yol1 > 3)
                        {
                            yol1 = 3;
                        }
                        labirent[satir1, yol1] = "1";
                        if (yol1 > 1)
                        {
                            solKontrol1 = true;
                        }
                        if (yol1 < 3)
                        {
                            sagKontrol1 = true;
                        }
                    }
                }
                //Bomba
                if (labirent[bombaSatir1, yol1] == "1" && bombaYol1 == 0 && bomba1Ekle == true && hak1 == true)
                {
                    bomba[bombaSatir1, yol1] = "2";
                    bomba1Ekle = false;
                    hak1 = false;
                }
                else if (labirent[bombaSatir2, yol1] == "1" && bombaYol2 == 0 && bomba2Ekle == true && hak1 == true)
                {
                    bomba[bombaSatir2, yol1] = "2";
                    bomba2Ekle = false;
                    hak1 = false;
                }
                //Bomba
                //YOL1
            }
            while (satir2 < 9)
            {
                //YOL2
                int sagSolYukari2 = rnd.Next(0, 3);
                if (sagSolYukari2 == 0 && solKontrol2 == true)
                {
                    yol2--;
                    if (yol2 > 3)
                    {
                        labirent[satir2, yol2] = "1";
                        sagKontrol2 = false;
                    }
                    else
                    {
                        satir2++;
                        if (satir2 < 10)
                        {
                            if (yol2 < 4)
                            {
                                yol2 = 4;
                            }
                            labirent[satir2, yol2] = "1";
                            sagKontrol2 = true;
                            solKontrol2 = false;
                        }
                    }
                }
                else if (sagSolYukari2 == 1 && sagKontrol2 == true)
                {
                    yol2++;
                    if (yol2 < 7)
                    {
                        labirent[satir2, yol2] = "1";
                        solKontrol2 = false;
                    }
                    else
                    {
                        satir2++;
                        if (satir2 < 10)
                        {
                            if (yol2 > 6)
                            {
                                yol2 = 6;
                            }
                            labirent[satir2, yol2] = "1";
                            solKontrol2 = true;
                            sagKontrol2 = false;
                        }
                    }
                }
                else if (sagSolYukari2 == 2)
                {
                    satir2++;
                    if (satir2 < 10)
                    {
                        if (yol2 < 4)
                        {
                            yol2 = 4;
                        }
                        if (yol2 > 6)
                        {
                            yol2 = 6;
                        }
                        labirent[satir2, yol2] = "1";
                        if (yol2 > 4)
                        {
                            solKontrol2 = true;
                        }
                        if (yol2 < 6)
                        {
                            sagKontrol2 = true;
                        }
                    }
                }
                //Bomba
                if (labirent[bombaSatir1, yol2] == "1" && bombaYol1 == 1 && bomba1Ekle == true && hak2 == true)
                {
                    bomba[bombaSatir1, yol2] = "2";
                    bomba1Ekle = false;
                    hak2 = false;
                }
                else if (labirent[bombaSatir2, yol2] == "1" && bombaYol2 == 1 && bomba2Ekle == true && hak2 == true)
                {
                    bomba[bombaSatir2, yol2] = "2";
                    bomba2Ekle = false;
                    hak2 = false;
                }
                //Bomba
                //YOL2
            }
            while (satir3 < 9)
            {
                //YOL3
                int sagSolYukari3 = rnd.Next(0, 3);
                if (sagSolYukari3 == 0 && solKontrol3 == true)
                {
                    yol3--;
                    if (yol3 > 6)
                    {
                        labirent[satir3, yol3] = "1";
                        sagKontrol3 = false;
                    }
                    else
                    {
                        satir3++;
                        if (satir3 < 10)
                        {
                            if (yol3 < 7)
                            {
                                yol3 = 7;
                            }
                            labirent[satir3, yol3] = "1";
                            sagKontrol3 = true;
                            solKontrol3 = false;
                        }
                    }
                }
                else if (sagSolYukari3 == 1 && sagKontrol3 == true)
                {
                    yol3++;
                    if (yol3 < 10)
                    {
                        labirent[satir3, yol3] = "1";
                        solKontrol3 = false;
                    }
                    else
                    {
                        satir3++;
                        if (satir3 < 10)
                        {
                            if (yol3 > 9)
                            {
                                yol3 = 9;
                            }
                            labirent[satir3, yol3] = "1";
                            solKontrol3 = true;
                            sagKontrol3 = false;
                        }
                    }
                }
                else if (sagSolYukari3 == 2)
                {
                    satir3++;
                    if (satir3 < 10)
                    {
                        if (yol3 < 7)
                        {
                            yol3 = 7;
                        }
                        if (yol3 > 9)
                        {
                            yol3 = 9;
                        }
                        labirent[satir3, yol3] = "1";
                        if (yol3 > 7)
                        {
                            solKontrol3 = true;
                        }
                        if (yol3 < 9)
                        {
                            sagKontrol3 = true;
                        }
                    }
                }
                //Bomba
                if (labirent[bombaSatir1, yol3] == "1" && bombaYol1 == 2 && bomba1Ekle == true && hak3 == true)
                {
                    bomba[bombaSatir1, yol3] = "2";
                    bomba1Ekle = false;
                    hak3 = false;
                }
                else if (labirent[bombaSatir2, yol3] == "1" && bombaYol2 == 2 && bomba2Ekle == true && hak3 == true)
                {
                    bomba[bombaSatir2, yol3] = "2";
                    bomba2Ekle = false;
                    hak3 = false;
                }
                //Bomba
                //YOL3
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (labirent[i, j] == null)
                    {
                        labirent[i, j] = "0";
                    }
                }
            }
        }
        public static void labirentInsaEt(string[,] labirent)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (bomba[i, j] == null)
                    {
                        bomba[i, j] = "0";
                    }
                    if (labirent[i, j] == "1" && bomba[i, j] == "0")
                    {
                        bomba[i, j] = "1";
                    }
                }
            }
        }
        public static void bombaYaz()
        {
            Console.WriteLine("    1     2     3");
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    Console.Write(bomba[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void labirentiYaz(string[,] labirent)
        {
            Console.WriteLine("    1     2     3");
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    Console.Write(labirent[i, j] + " ");
                    karakter[i, j] = labirent[i, j];
                }
                Console.WriteLine();
            }
        }
        public static void karakterHareket(string[,] labirent)
        {
            Console.WriteLine("    1     2     3");
            for(int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(karakter[i, j] + " ");
                }
                Console.WriteLine();
            }
        } 
        public static void gez(string[,] labirent)
        {
            int x = 0, y = 0, puan = 0;
            if (giris == "1")
            {
                x = 0;
                y = 2;
                karakter[x, y] = "K";
            }
            if (giris == "2")
            {
                x = 0;
                y = 5;
                karakter[x, y] = "K";
            }
            if (giris == "3")
            {
                x = 0;
                y = 8;
                karakter[x, y] = "K";
            }
            Console.Clear();
            karakterHareket(labirent);
        tekrarDene:
            Console.Write("Lutfen gitmek istediginiz yonu giriniz:");
            yon = Console.ReadLine();
            if (yon == "s" || yon == "S")
            {
                if (x > 8)
                {
                    Console.WriteLine("-----TEBRIKLER KAZANDINIZ-----");
                    Console.Write("Tekrar oynamak ister misiniz? (E/H):");
                    string yeniden = Console.ReadLine();
                    if (yeniden == "e" || yeniden == "E")
                    {
                        puan = 0;
                        Console.Clear();
                        labirentiYaz(labirent);
                        Console.Write("Lutfen labirentten bir yol seciniz:");
                        giris = Console.ReadLine();
                        gez(labirent);
                    }
                    else Environment.Exit(0);
                }
                karakter[x, y] = "1";
                x++;
                karakter[x, y] = "K";
                Console.Clear();
                karakterHareket(labirent);
                if (bomba[x, y] == "2")
                {
                    Console.Write("YANDINIZ!!\nBastan baslamak ister misiniz? (E/H):");
                    string cevap = Console.ReadLine();
                    if (cevap == "e" || cevap == "E")
                    {
                        puan = 0;
                        Console.Clear();
                        labirentiYaz(labirent);
                        Console.Write("Lutfen labirentten bir yol seciniz:");
                        giris = Console.ReadLine();
                        gez(labirent);
                    }
                    else Environment.Exit(0);
                }
                else if (bomba[x, y] == "0")
                {
                    puan--;
                    karakter[x, y] = "0";
                    x--;
                    karakter[x, y] = "K";
                    Console.Clear();
                    karakterHareket(labirent);
                    Console.WriteLine("Duvara carptiniz!!");
                    Console.WriteLine("Puaniniz: {0}", puan);
                    goto tekrarDene;
                }
                else
                {
                    puan++;
                    Console.WriteLine("Puaniniz: {0}", puan);
                    goto tekrarDene;
                }
            }
            else if (yon == "w" || yon == "W")
            {
                if (x < 1)
                {
                    puan = 0;
                    Console.Clear();
                    labirentiYaz(labirent);
                    Console.Write("Lutfen labirentten bir yol seciniz:");
                    giris = Console.ReadLine();
                    gez(labirent);
                    x = 0;
                }
                karakter[x, y] = "1";
                x--;
                karakter[x, y] = "K";
                Console.Clear();
                karakterHareket(labirent);
                if (bomba[x, y] == "2")
                {
                    Console.Write("YANDINIZ!!");
                }
                else if (bomba[x, y] == "0")
                {
                    puan--;
                    karakter[x, y] = "0";
                    x++;
                    karakter[x, y] = "K";
                    Console.Clear();
                    karakterHareket(labirent);
                    Console.WriteLine("Duvara carptiniz.!!");
                    Console.WriteLine("Puaniniz: {0}", puan);
                    goto tekrarDene;
                }
                else
                {
                    puan++;
                    Console.WriteLine("Puaniniz: {0}", puan);
                    goto tekrarDene;
                }
            }
            else if (yon == "a" || yon == "A")
            {
                karakter[x, y] = "1";
                y--;
                karakter[x, y] = "K";
                Console.Clear();
                karakterHareket(labirent);
                if (bomba[x, y] == "2")
                {
                    Console.Write("YANDINIZ!!\nBastan baslamak ister misiniz? (E/H):");
                    string cevap = Console.ReadLine();
                    if (cevap == "e" || cevap == "E")
                    {
                        puan = 0;
                        Console.Clear();
                        labirentiYaz(labirent);
                        Console.Write("Lutfen labirentten bir yol seciniz:");
                        giris = Console.ReadLine();
                        gez(labirent);
                    }
                    else Environment.Exit(0);
                }
                else if (bomba[x, y] == "0")
                {
                    puan--;
                    karakter[x, y] = "0";
                    y++;
                    karakter[x, y] = "K";
                    Console.Clear();
                    karakterHareket(labirent);
                    Console.WriteLine("Duvara carptiniz!!");
                    Console.WriteLine("Puaniniz: {0}", puan);
                    goto tekrarDene;
                }
                else
                {
                    puan++;
                    Console.WriteLine("Puaniniz: {0}", puan);
                    goto tekrarDene;
                }
            }
            else if (yon == "d" || yon == "D")
            {
                karakter[x, y] = "1";
                y++;
                if (y > 9)
                {
                    puan--;
                    y--;
                    karakter[x, y] = "K";
                    Console.Clear();
                    karakterHareket(labirent);
                    Console.WriteLine("Duvara carptiniz!!");
                    Console.WriteLine("Puaniniz: {0}", puan);
                    goto tekrarDene;
                }
                karakter[x, y] = "K";
                Console.Clear();
                karakterHareket(labirent);
                if (bomba[x, y] == "2")
                {
                    Console.Write("YANDINIZ!!\nBastan baslamak ister misiniz? (E/H):");
                    string cevap = Console.ReadLine();
                    if (cevap == "e" || cevap == "E")
                    {
                        puan = 0;
                        Console.Clear();
                        labirentiYaz(labirent);
                        Console.Write("Lutfen labirentten bir yol seciniz:");
                        giris = Console.ReadLine();
                        gez(labirent);
                    }
                    else Environment.Exit(0);
                }
                else if (bomba[x, y] == "0")
                {
                    puan--;
                    karakter[x, y] = "0";
                    y--;
                    karakter[x, y] = "K";
                    Console.Clear();
                    karakterHareket(labirent);
                    Console.WriteLine("Duvara carptiniz.!!");
                    Console.WriteLine("Puaniniz: {0}", puan);
                    goto tekrarDene;
                }
                else
                {
                    puan++;
                    Console.WriteLine("Puaniniz: {0}", puan);
                    goto tekrarDene;
                }
            }
            else
            {
                Console.WriteLine("Yanlis girdiniz! Tekrar deneyiniz.");
                goto tekrarDene;
            }
        }
    }
}
