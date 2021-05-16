using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
/// <summary>
/// Created By Rahul Parewa
/// Dated: 16 May 2021
/// Version 1.0.0
/// </summary>
namespace pdfMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To PDF Merger");
            Console.WriteLine("Created by Rahul Parewa");
            Console.WriteLine("Press 1 to select");
            Console.WriteLine("Press any other key to exit");
            var a = Console.ReadLine();
            while (a == "1")
            {
                Console.WriteLine("Press 1 to select");
                Console.WriteLine("Press any other key to exit");
                a = Console.ReadLine();
                if (a == "1")
                {
                    Console.WriteLine("Enter address of dir");
                    var dir = Console.ReadLine();

                    Console.WriteLine("Enter filname of pdf");
                    var address1 = Console.ReadLine();
                    List<string> fileList = new List<string>();
                    fileList.Add(dir + address1 + ".pdf");

                    Console.WriteLine("add new address");
                    var address2 = Console.ReadLine();
                    while (address2 != "x")
                    {
                        fileList.Add(dir + address2 + ".pdf");
                        Console.WriteLine("Enter address of pdf");
                        address2 = Console.ReadLine();


                    }
                    Console.WriteLine("Add the address to which new merge will save");
                    var finalAddress = Console.ReadLine();
                    MergePDF(fileList, dir + finalAddress + ".pdf");




                }

            }
        }
        private static void MergePDF(List<string> fileArray, string outputPdfPath)
        {
            PdfImportedPage importedPage;

            Document sourceDocument = new Document();
            PdfCopy pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

            sourceDocument.Open();

            foreach (var fil in fileArray)
            {
                
                PdfReader reader = new PdfReader(fil);
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                    pdfCopyProvider.AddPage(importedPage);
                }

                reader.Close();
            }
            sourceDocument.Close();
        }
    }
}
