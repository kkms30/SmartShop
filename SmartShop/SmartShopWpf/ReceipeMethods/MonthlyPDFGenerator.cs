﻿using SmartShopWebApp.Persistance.Mappers;
using SmartShopWpf.Data;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SmartShopWpf.ReceipeMethods
{
    public class MonthlyPdfGenerator
    {
        private List<Report> _listOfObjects;

        public MonthlyPdfGenerator(List<Report> listOfObjects)
        {
            _listOfObjects = listOfObjects;
        }

        public void GeneratePdf()
        {
            decimal totale = 0;
            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A6);
            PdfPageBase page2 = null;
            PdfPageBase page3 = null;
            PdfPageBase page4 = null;
            PdfPageBase[] pages = new PdfPageBase[] {page, page2, page3, page4};

            //save graphics state
            PdfGraphicsState state = page.Canvas.Save();

            //Draw the text - alignment
            PdfFont font = new PdfFont(PdfFontFamily.Courier, 6f);
            PdfFont font2 = new PdfFont(PdfFontFamily.Courier, 4f);
            PdfFont font3 = new PdfFont(PdfFontFamily.Courier, 4f, PdfFontStyle.Strikeout);
            PdfSolidBrush brush = new PdfSolidBrush(System.Drawing.Color.Black);

            PdfStringFormat leftAlignment = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            page.Canvas.DrawString(DateTime.Now.Year + " Miesiac: " + DateTime.Now.Month, font, brush, 0, 40,
                leftAlignment);

            PdfStringFormat rightAlignment = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);

            PdfStringFormat centerAlignment
                = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            page.Canvas.DrawString(Receipe.Name,
                font, brush, page.Canvas.ClientSize.Width / 2, 20, centerAlignment);
            PdfStringFormat centerAlignment2
                = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            page.Canvas.DrawString(Receipe.Address,
                font, brush, page.Canvas.ClientSize.Width / 2, 30, centerAlignment2);
            PdfStringFormat centerAlignment3
                = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            page.Canvas.DrawString("PODSUMOWANIE MIESIACA",
                font, brush, page.Canvas.ClientSize.Width / 2, 50, centerAlignment3);

            PdfPath path = new PdfPath();

            path.AddLine(new PointF(10, 55), new PointF(page.Canvas.ClientSize.Width - 10, 55));

            PdfPen pen = new PdfPen(System.Drawing.Color.Black, 0.8f);
            page.Canvas.DrawPath(pen, path);

            float pageoneh = 60;
            float pagetwoh = 20;
            float pagethreeh = 20;
            float pagefourh = 20;
            //_recp.listOfBoughtProducts.RemoveRange(24, _recp.listOfBoughtProducts.Count-24);
            foreach (var x in _listOfObjects)
            {
                if (x.Name != null)
                {
                    totale += x.TotalPrice;
                    string ilosc = "Ilosc sprzedanych: " + x.Sum.ToString();
                    string cena = "Suma cenowa: " + x.TotalPrice.ToString();
                    string nazwa = x.Name.Substring(0, x.Name.Length > 45 ? 45 : x.Name.Length) + " " + ilosc;

                    if (pageoneh < 310)
                    {
                        page.Canvas.DrawString(nazwa, font2, brush, 0, pageoneh, leftAlignment);
                        page.Canvas.DrawString(cena, font2, brush, page.Canvas.ClientSize.Width, pageoneh,
                            rightAlignment);
                        pageoneh += 10;
                    }
                    if (pageoneh == 310)
                    {
                        if (page2 == null)
                            page2 = doc.Pages.Add(PdfPageSize.A6);
                    }
                    if (pageoneh == 310 && pagetwoh < 310)
                    {
                        page2.Canvas.DrawString(nazwa, font2, brush, 0, pagetwoh, leftAlignment);
                        page2.Canvas.DrawString(cena, font2, brush, page.Canvas.ClientSize.Width, pagetwoh,
                            rightAlignment);
                        pagetwoh += 10;
                    }
                    if (pagetwoh == 310)
                    {
                        if (page3 == null)
                            page3 = doc.Pages.Add(PdfPageSize.A6);
                    }
                    if (pagetwoh == 310 && pagethreeh < 310)
                    {
                        page3.Canvas.DrawString(nazwa, font2, brush, 0, pagethreeh, leftAlignment);
                        page3.Canvas.DrawString(cena, font2, brush, page.Canvas.ClientSize.Width, pagethreeh,
                            rightAlignment);
                        pagethreeh += 10;
                    }
                    if (pagethreeh == 310)
                    {
                        if (page4 == null)
                            page4 = doc.Pages.Add(PdfPageSize.A6);
                    }
                    if (pagethreeh == 310 && pagefourh < 310)
                    {
                        page4.Canvas.DrawString(nazwa, font2, brush, 0, pagefourh, leftAlignment);
                        page4.Canvas.DrawString(cena, font2, brush, page.Canvas.ClientSize.Width, pagefourh,
                            rightAlignment);
                        pagefourh += 10;
                    }
                }
            }

            PdfPath path2 = null;
            PdfPen pen2 = null;
            if (page4 != null)
            {
                path2 = new PdfPath();

                path2.AddLine(new PointF(10, pagefourh + 5),
                    new PointF(page.Canvas.ClientSize.Width - 10, pagefourh + 5));

                pen2 = new PdfPen(System.Drawing.Color.Black, 0.8f);
                page4.Canvas.DrawPath(pen2, path2);

                page4.Canvas.DrawString("UTARG PLN MIESIECZNY: " + totale, font2, brush, page.Canvas.ClientSize.Width,
                    pagefourh + 10, rightAlignment);
            }
            else if (page4 == null && page3 != null)
            {
                path2 = new PdfPath();

                path2.AddLine(new PointF(10, pagethreeh + 5),
                    new PointF(page.Canvas.ClientSize.Width - 10, pagethreeh + 5));

                pen2 = new PdfPen(System.Drawing.Color.Black, 0.8f);
                page3.Canvas.DrawPath(pen2, path2);

                page3.Canvas.DrawString("UTARG PLN MIESIECZNY: " + totale, font2, brush, page.Canvas.ClientSize.Width,
                    pagethreeh + 10, rightAlignment);
            }
            else if (page3 == null && page2 != null)
            {
                path2 = new PdfPath();

                path2.AddLine(new PointF(10, pagetwoh + 5),
                    new PointF(page.Canvas.ClientSize.Width - 10, pagetwoh + 5));

                pen2 = new PdfPen(System.Drawing.Color.Black, 0.8f);
                page2.Canvas.DrawPath(pen2, path2);

                page2.Canvas.DrawString("UTARG PLN MIESIECZNY: " + totale, font2, brush, page.Canvas.ClientSize.Width,
                    pagetwoh + 10, rightAlignment);
            }
            else if (page2 == null && page != null)
            {
                path2 = new PdfPath();

                path2.AddLine(new PointF(10, pageoneh + 5),
                    new PointF(page.Canvas.ClientSize.Width - 10, pageoneh + 5));

                pen2 = new PdfPen(System.Drawing.Color.Black, 0.8f);
                page.Canvas.DrawPath(pen2, path2);

                page.Canvas.DrawString("UTARG PLN MIESIECZNY: " + totale, font2, brush, page.Canvas.ClientSize.Width,
                    pageoneh + 10, rightAlignment);
            }

            //restor graphics
            page.Canvas.Restore(state);
            //Save doc file.
            string fileName = "RaportMiesieczny.pdf";

            doc.SaveToFile(fileName);
            doc.Close();

            //Launching the Pdf file.
            System.Diagnostics.Process.Start(fileName);
        }
    }
}