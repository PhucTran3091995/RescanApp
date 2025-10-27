using HSEVIMES_PCBA_Config.Data;
using HSEVIMES_PCBA_Config.Models;
using HSEVIMES_PCBA_Config.UI;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEVIMES_PCBA_Config.UI
{
    internal class DrawLabel
    {
        public void RenderLabel(PrintPageEventArgs ev, TbRescan data)
        {

            var g = ev.Graphics;
            g.PageUnit = GraphicsUnit.Pixel;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int margin = 10;
            int width = ev.PageBounds.Width - margin;
            Console.WriteLine("WIDTH: " + width);
            int x = margin;
            int y = margin;
            int cellHeight = 70;
            int labelWidth = width / 3;

            int boxQty = 0;
            if (!string.IsNullOrEmpty(data?.Pba))
            {
                using (var db = new AppDbContext())
                {
                    // synchronous query is fine inside printing routine
                    boxQty = db.TbRescan
                        .Where(r => r.Pba == data.Pba)
                        .Select(r => r.Qty)
                        .Sum();
                }
            }

            var fontTitle = new Font("Arial", 14, FontStyle.Bold);
            var fontNormal = new Font("Arial", 10);
            var fontBold = new Font("Arial", 11, FontStyle.Bold);
            var formatCenter = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            // === 1️⃣ Header ===
            y += 8;
            g.DrawString("Material Tag", fontTitle, Brushes.Black, x + width / 2 + 100, y, formatCenter);
            y += 35;

            // === 2️⃣ Table layout ===
            // Mỗi hàng có 3 cột: [label, value, label/value phải]
            string yearPba = data.Pba?.Length >= 6 ? data.Pba.Substring(3, 2) : "";
            string monthPba = data.Pba?.Length >= 8 ? data.Pba.Substring(5, 2) : "";

            void DrawRow(string leftLabel, string leftValue, string rightLabel, string rightValue)
            {
                int rowY = y;
                int colWidth = width / 3;
                int bolderWidth = 360;

                // Cột 1 label
                g.DrawRectangle(Pens.Black, x, rowY, bolderWidth, cellHeight);
                g.DrawString(leftLabel, fontNormal, Brushes.Black, x, rowY + 8);

                int middleRectX = x + 150;
                g.DrawRectangle(Pens.Black, middleRectX, rowY, bolderWidth, cellHeight);
                g.DrawString(leftValue, fontBold, Brushes.Black, middleRectX + 20, rowY + 8);

                int rightRectX = x + 360;
                g.DrawRectangle(Pens.Black, rightRectX, rowY, bolderWidth, cellHeight);
                if (!string.IsNullOrEmpty(rightLabel))
                    g.DrawString($"{rightLabel}: {rightValue}", fontBold, Brushes.Black, rightRectX + 30, rowY + 8);

                y += cellHeight;
            }

            // === Hàng 1 → 4 ===
            DrawRow("Model Name: ", data.Model_Name, "Year", yearPba);
            DrawRow("Model Suffix: ", data.Model_Suffix, "Month", monthPba);
            DrawRow("Part No: ", data.Part_No, "", "");
            DrawRow("W/O: ", data.Work_Order, "", "");

            // === Hàng 5: Box Qty ===
            int colWidth = width / 3;
            g.DrawRectangle(Pens.Black, x - 10, y, 360, cellHeight * 2);
            g.DrawString("Box Qty:", fontNormal, Brushes.Black, x - 10, y + 50);

            g.DrawRectangle(Pens.Black, x + colWidth, y, 360, cellHeight * 2);
            g.DrawString(boxQty.ToString(), new Font("Arial", 26, FontStyle.Bold),
                Brushes.Black, x + colWidth + 40, y + 10);

            // === Hàng 6: Prod Date ===
            g.DrawRectangle(Pens.Black, x - 10, y + cellHeight * 2, 360, cellHeight);
            g.DrawString("Prod Date:", fontNormal, Brushes.Black, x - 10, y + cellHeight * 2 + 10);

            int prodDateRectX = x + 150;
            g.DrawRectangle(Pens.Black, x + colWidth, y + cellHeight * 2, 360, cellHeight);
            g.DrawString(DateTime.Now.ToString("yyyy-MM-dd"), fontBold, Brushes.Black,
                prodDateRectX + 20, y + cellHeight * 2 + 10);

            // === Ô QR Code (phải cùng dòng với Box Qty & ProdDate) ===
            // Tạo khoảng cách (gutter) giữa cột Qty và khung QR:
            int gutter = 24; // tăng/giảm để chỉnh khoảng hở giữa Qty và QR
            int qrRectX = x + (colWidth * 2) + gutter; // dời cả khung QR sang phải
            int qrRectY = y;
            int qrRectW = 560;           // giữ nguyên
            int qrRectH = cellHeight * 3;

            // Padding bên trong khung để QR không dính mép trái/phải:
            int qrInnerPad = 14;

            // Kích thước QR (cao bằng 2 hàng, trừ đi padding trên/dưới):
            int qrSize = (cellHeight * 2) - (qrInnerPad + 6);

            // Tọa độ ảnh QR bên trong khung:
            int qrX = qrRectX + qrInnerPad;
            int qrY = qrRectY + 10;

            using (var qrGen = new QRCoder.QRCodeGenerator())
            using (var qrData = qrGen.CreateQrCode(data.Pba ?? "N/A", QRCoder.QRCodeGenerator.ECCLevel.Q))
            using (var qr = new QRCoder.QRCode(qrData))
            using (var bmp = qr.GetGraphic(5))
            {
                // Vẽ khung QR đã dời sang phải
                g.DrawRectangle(Pens.Black, qrRectX, qrRectY, qrRectW, qrRectH);
                // Vẽ ảnh QR với padding bên trong
                g.DrawImage(bmp, qrX, qrY, qrSize, qrSize);
            }

            y += cellHeight * 3 + 50;


            // === Footer ===

            ev.HasMorePages = false;
        }



    }
}
