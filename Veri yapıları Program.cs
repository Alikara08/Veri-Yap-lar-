using System.ComponentModel.Design;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace veri_yapıları_proje_Linked_Lİst_Bağlı_listeler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Liste cydaListe = new Liste(); // Bağlı liste nesnesi oluşturuluyor
            int sayi, indis;
            int secim = menu(); // Menü fonksiyonu ile kullanıcıdan seçim alınıyor

            while (secim != 0) // Kullanıcı 0'ı seçene kadar menü tekrarlanır
            {
                switch (secim)
                {
                    case 1:
                        Console.Write("sayı: ");
                        sayi = int.Parse(Console.ReadLine()); // Kullanıcıdan sayı alınır
                        cydaListe.basaEkle(sayi); // Başta sayıyı ekler
                        cydaListe.yazdir(); // Listeyi yazdırır
                        break;

                    case 2:
                        Console.Write("sayı: ");
                        sayi = int.Parse(Console.ReadLine()); // Kullanıcıdan sayı alınır
                        cydaListe.sonaEkle(sayi); // Sona sayıyı ekler
                        cydaListe.yazdir(); // Listeyi yazdırır
                        break;

                    case 3:
                        Console.Write("indis: "); // Kullanıcıdan indis değeri alınır
                        indis = int.Parse(Console.ReadLine());
                        Console.Write("sayı: ");
                        sayi = int.Parse(Console.ReadLine()); // Kullanıcıdan sayı alınır
                        cydaListe.arayaEkle(indis, sayi); // Belirtilen indise sayıyı ekler
                        cydaListe.yazdir(); // Listeyi yazdırır
                        break;
                    case 4:
                        cydaListe.bastanSil(); // Başta bulunan sayıyı siler
                        cydaListe.yazdir(); // Listeyi yazdırır
                        break;
                    case 5:
                        cydaListe.sondanSil(); // Sondan sayıyı siler
                        cydaListe.yazdir(); // Listeyi yazdırır
                        break;
                    case 6:
                        Console.Write("indis:");
                        indis = int.Parse(Console.ReadLine()); // Kullanıcıdan silinecek elemanın indeksi alınır
                        cydaListe.aradanSil(indis); // Belirtilen indisteki sayıyı siler
                        cydaListe.yazdir(); // Listeyi yazdırır
                        break;
                    case 7:
                        cydaListe.terstenYazdir(); // Listeyi tersten yazdırır
                        break;
                    case 0:
                        break; // Programı sonlandırır

                    default:
                        Console.WriteLine("Geçersiz seçim. Tekrar deneyin."); // Geçersiz seçim durumunda kullanıcı uyarılır
                        break;
                }
                secim = menu(); // Yeni seçim alınır
                Console.Clear(); // Ekran temizlenir
            }
            Console.WriteLine("program kapatıldı"); // Program sonlanır
            Console.ReadKey(); // Kullanıcı bir tuşa basana kadar bekler
        }

        private static int menu() // Menü fonksiyonu
        {
            int secim; // Kullanıcının seçim yaptığı değişken
            Console.WriteLine("1-basa ekle");
            Console.WriteLine("2-sona ekle");
            Console.WriteLine("3-araya ekle");
            Console.WriteLine("4-bastan sil");
            Console.WriteLine("5-sondan sil");
            Console.WriteLine("6-aradan sil");
            Console.WriteLine("7-tersten yazdır");
            Console.WriteLine("0-programı kapat");
            Console.WriteLine("seçiminiz:");
            secim = int.Parse(Console.ReadLine()); // Kullanıcıdan seçim alınır
            return secim; // Seçim döndürülür
        }
    }

    class Node // Bağlı listenin düğüm (Node) yapısını tanımlar
    {
        public int data; // Düğümdeki veri
        public Node next; // Sonraki düğüme işaretçi
        public Node prev; // Önceki düğüme işaretçi

        public Node(int data)
        {
            this.data = data; // Düğüme veri atanır
            this.next = null; // Başlangıçta sonraki düğüm boş
            this.prev = null; // Başlangıçta önceki düğüm boş
        }
    }

    class Liste // Bağlı listeyi temsil eden sınıf
    {
        Node head; // Listenin başındaki düğüm
        Node tail; // Listenin sonundaki düğüm

        public Liste()
        {
            this.head = null; // Başlangıçta liste boştur
            this.tail = null; // Başlangıçta liste boştur
        }

        public void basaEkle(int data)
        {
            Node eleman = new Node(data); // Yeni düğüm oluşturulur

            if (head == null) // Liste boşsa
            {
                head = tail = eleman; // İlk eleman eklenir
                tail.next = head; // Kuyruğun sonu başa bağlanır
                tail.prev = head; // Başın önceki düğümü kuyruğa bağlanır
                head.next = tail; // Başın sonrakisi kuyruğa işaret eder
                head.prev = tail; // Kuyruğun önceki düğümü başa işaret eder
                Console.WriteLine("liste yapısı oluşturuldu,ilk eleman eklendi");
            }
            else // Liste doluysa
            {
                eleman.next = head; // Yeni düğüm başa bağlanır
                head.prev = eleman; // Başın önceki işaretçisi yeni düğüme yönlendirilir
                head = eleman; // Yeni düğüm baş düğüm olur
                head.prev = tail; // Başın önceki düğümü kuyruğa işaret eder
                tail.next = head; // Kuyruğun sonu başa bağlanır
                Console.WriteLine("başa eleman eklendi");
            }
        }

        public void sonaEkle(int data)
        {
            Node eleman = new Node(data); // Yeni düğüm oluşturulur

            if (head == null) // Liste boşsa
            {
                head = tail = eleman; // İlk eleman eklenir
                tail.next = head; // Kuyruğun sonu başa bağlanır
                tail.prev = head; // Başın önceki düğümü kuyruğa bağlanır
                head.next = tail; // Başın sonrakisi kuyruğa işaret eder
                head.prev = tail; // Kuyruğun önceki düğümü başa işaret eder
                Console.WriteLine("liste yapısı oluşturuldu,ilk eleman eklendi");
            }
            else // Liste doluysa
            {
                tail.next = eleman; // Kuyruğun sonuna eklenir
                eleman.prev = tail; // Yeni düğümün önceki işaretçisi kuyruğa yönlendirilir
                tail = eleman; // Kuyruk yeni düğüm olur
                tail.next = head; // Kuyruğun sonu başa bağlanır
                head.prev = tail; // Başın önceki düğümü kuyruğa işaret eder
                Console.WriteLine("sona eleman eklendi");
            }
        }

        public void arayaEkle(int indis, int data)
        {
            Node eleman = new Node(data); // Yeni düğüm oluşturulur

            if (head == null && indis == 0) // Liste boş ve indis sıfırsa
            {
                head = tail = eleman; // İlk eleman eklenir
                tail.next = head; // Kuyruğun sonu başa bağlanır
                tail.prev = head; // Başın önceki düğümü kuyruğa bağlanır
                head.next = tail; // Başın sonrakisi kuyruğa işaret eder
                head.prev = tail; // Kuyruğun önceki düğümü başa işaret eder
                Console.WriteLine("liste yapısı oluşturuldu,ilk eleman eklendi");
            }
            else if (head != null && indis == 0) // Liste dolu ve indis sıfırsa
            {
                basaEkle(data); // Başta ekleme fonksiyonu çağrılır
            }
            else
            {
                int i = 0; // İndis sayacı
                Node temp = head; // Başta başlayarak ilerleyen geçici düğüm
                Node temp2 = temp; // Önceki düğüm

                while (temp != tail) // Liste boyunca dönülerek doğru indisi buluruz
                {
                    if (i == indis)
                    {
                        temp2.next = eleman; // Önceki düğüm yeni düğümü işaret eder
                        eleman.prev = temp2; // Yeni düğümün önceki işaretçisi önceki düğümü işaret eder
                        eleman.next = temp; // Yeni düğüm mevcut düğümü işaret eder
                        temp.prev = eleman; // Mevcut düğüm yeni düğümü işaret eder
                        Console.WriteLine("araya eleman eklendi");
                        break;
                    }
                    temp2 = temp; // Bir sonraki düğüm için geçici düğüm güncellenir
                    temp = temp.next; // İlerleme sağlanır
                    i++;
                }
                if (i == indis) // İndis bulunmuşsa
                {
                    temp2.next = eleman; // Aynı işlemler tekrarlanır
                    eleman.prev = temp2;
                    eleman.next = temp;
                    temp.prev = eleman;
                    Console.WriteLine("araya eleman eklendi");
                }
            }
        }

        public void yazdir()
        {
            if (head == null) // Liste boşsa
                Console.WriteLine("liste boş");
            else
            {
                Node temp = head; // Baş düğümden başlayarak ilerleyen geçici düğüm
                Console.Write("baş->");
                while (temp != tail) // Son düğüme kadar ilerlenir
                {
                    Console.Write(temp.data + "->"); // Mevcut düğüm yazdırılır
                    temp = temp.next; // Bir sonraki düğüme geçilir
                }
                Console.WriteLine(temp.data + "son."); // Kuyruk düğümü yazdırılır
            }
        }

        public void terstenYazdir()
        {
            if (head == null) // Liste boşsa
                Console.WriteLine("liste boş");

            else
            {
                Node temp = tail; // Kuyruk düğümünden başlayarak ilerleyen geçici düğüm
                Console.Write("Son->");
                while (temp != head) // Baş düğümüne kadar ilerlenir
                {
                    Console.Write(temp.data + "->"); // Mevcut düğüm yazdırılır
                    temp = temp.prev; // Bir önceki düğüme geçilir
                }
                Console.WriteLine(temp.data + "baş."); // Baş düğümü yazdırılır
            }
        }

        public void bastanSil()
        {
            if (head == null) // Liste boşsa
            {
                Console.WriteLine("liste boş");
            }
            else if (head.next == head) // Listede tek düğüm varsa
            {
                head = tail = null; // Düğüm silinir ve liste boş olur
                Console.WriteLine("eleman silindi,listede eleman kalmadı");
            }
            else
            {
                head = head.next; // Baş düğüm silinir ve bir sonraki düğüm başa alınır
                head.prev = tail; // Yeni baş düğümün önceki düğümü kuyruğa işaret eder
                tail.next = head; // Kuyruğun sonu başa bağlanır
                Console.WriteLine("baştan eleman silindi");
            }
        }

        public void sondanSil()
        {
            if (head == null) // Liste boşsa
            {
                Console.WriteLine("liste boş");
            }
            else if (head.next == head) // Listede tek düğüm varsa
            {
                head = tail = null; // Düğüm silinir ve liste boş olur
                Console.WriteLine("eleman silindi,listede eleman kalmadı");
            }
            else
            {
                tail = tail.prev; // Kuyruk düğümü silinir ve bir önceki düğüm kuyruğa alınır
                tail.next = head; // Kuyruğun sonu başa bağlanır
                head.prev = tail; // Başın önceki düğümü kuyruğa işaret eder
                Console.WriteLine("sondan eleman silindi");
            }
        }

        public void aradanSil(int indis)
        {
            if (head == null) // Liste boşsa
            {
                Console.WriteLine("liste boş");
            }
            else if (head.next == head && indis == 0) // Listede tek düğüm varsa ve o düğüm silinecekse
            {
                head = tail = null; // Düğüm silinir ve liste boş olur
                Console.WriteLine("eleman silindi,listede eleman kalmadı");
            }
            else if (head.next != head && indis == 0) // Baş düğüm silinecekse
            {
                bastanSil();
            }
            else
            {
                Node temp = head; // Baş düğümden itibaren ilerleyen geçici düğüm
                Node temp2 = temp; // Önceki düğüm
                int i = 0; // Sayaç

                while (temp != tail)
                {
                    if (i == indis) // İstenilen indis bulunduğunda
                    {
                        temp2.next = temp.next; // Düğüm bağlantısı güncellenir
                        temp.next.prev = temp2; // Bir sonraki düğümün önceki işaretçisi güncellenir
                        Console.WriteLine("aradan eleman silindi");
                        break;
                    }
                    temp2 = temp; // Bir sonraki adım için geçici düğüm güncellenir
                    temp = temp.next; // Düğüme ilerlenir
                    i++;
                }
                if (i == indis) // Kuyruk düğümü silinecekse
                {
                    sondanSil();
                }
            }
        }
    }
}
