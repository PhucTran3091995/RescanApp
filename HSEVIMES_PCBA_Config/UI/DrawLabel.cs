using HSEVIMES_PCBA_Config.Data;
using HSEVIMES_PCBA_Config.Models;
using QRCoder;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;

namespace HSEVIMES_PCBA_Config.UI
{
    internal class DrawLabel
    {
        // Kích thước thiết kế chuẩn (1/100 inch)
        private const float DesignW = 217f; // ~55mm
        private const float DesignH = 157f; // ~40mm

        public void RenderLabel(PrintPageEventArgs ev, TbRescan data)
        {
            if (data == null) return;

            var g = ev.Graphics;

            // Đảm bảo không bị transform cũ, dùng hệ 1/100 inch mặc định
            g.ResetTransform();
            g.PageUnit = GraphicsUnit.Display; // Display = 1/100 inch trong ngữ cảnh in
            g.PageScale = 1f;

            // Lấy Box Qty từ DB
            int boxQty = GetBoxQty(data.Pba);

            // Vẽ nội dung trong khổ 217 x 157 (tương ứng 55mm x 40mm)
            DrawContent(g, DesignW, DesignH, data, boxQty);

            ev.HasMorePages = false;
        }


        private int GetBoxQty(string? pba)
        {
            if (string.IsNullOrEmpty(pba)) return 0;
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.TbRescan
                        .Where(r => r.Pba == pba)
                        .Select(r => r.Qty)
                        .Sum();
                }
            }
            catch { return 0; }
        }

        private void DrawContent(Graphics g, float W, float H, TbRescan data, int boxQty)

        {
            // Setup bút và cọ
            using var pen = new Pen(Color.Black, 2);

            // ✅ Dùng SolidBrush riêng cho mỗi lần vẽ
            using var brush = new SolidBrush(Color.Black);

            // --- FONT SETTING (Đã điều chỉnh theo DPI) ---
            // Nhân size với fs (fontScaleCorrection) để chữ không bị phóng to quá khổ
            // Ví dụ: Máy in 203 DPI (Scale=2.03), thì fs = 0.49.
            // Font 9pt * 0.49 = 4.4pt (Code) -> In ra giấy được phóng to 2.03 lần -> Trở lại thành 9pt chuẩn.

            // Tăng size gốc lên một chút để bù trừ
            using var fTitle = new Font("Arial", 10, FontStyle.Bold);
            using var fLabel = new Font("Arial Narrow", 7, FontStyle.Regular);
            using var fVal = new Font("Arial", 8, FontStyle.Bold);
            using var fQty = new Font("Arial", 16, FontStyle.Bold);
            using var fDate = new Font("Arial Narrow", 6, FontStyle.Regular);

            // 1. VẼ KHUNG VIỀN
            g.DrawRectangle(pen, 1, 1, W - 2, H - 2);

            float padX = 5f;
            float y = 5f;

            // === HEADER ===
            var headerRect = new RectangleF(0, y, W, 20);
            var centerFmt = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString("Material Tag", fTitle, brush, headerRect, centerFmt);

            y += 20;
            g.DrawLine(pen, 2, y, W - 2, y);
            y += 4;

            // === BODY ===
            float rowH = 15f;

            void DrawRow(string lbl, string val)
            {
                // Vẽ Label
                g.DrawString(lbl, fLabel, brush, padX, y);

                // Vẽ Value
                float valX = padX + 45;
                float valW = W - valX - padX - 2;
                var rect = new RectangleF(valX, y, valW, rowH);

                DrawFitText(g, val ?? "", fVal, brush, rect, 6f);
                y += rowH;
            }

            DrawRow("Model:", data.Model_Name);
            DrawRow("Suffix:", data.Model_Suffix);
            DrawRow("Part No:", data.Part_No);
            DrawRow("W/O:", data.Work_Order);

            y += 3;

            // === FOOTER ===
            float footerY = y;
            float colSplit = W * 0.55f;

            // Q'TY
            g.DrawString("Q'ty:", fLabel, brush, padX, footerY);
            var qtyRect = new RectangleF(padX, footerY + 8, colSplit - padX, 28);
            g.DrawString(boxQty.ToString(), fQty, brush, qtyRect, new StringFormat { Alignment = StringAlignment.Near });

            // DATE
            float dateY = footerY + 38;
            string dateStr = DateTime.Now.ToString("yyyy-MM-dd");
            g.DrawString($"Date: {dateStr}", fDate, brush, padX, dateY);

            // QR CODE
            float qrSize = 60f;
            float qrX = colSplit + 5;
            float qrY = footerY;

            if (!string.IsNullOrEmpty(data?.Pba))
            {
                try
                {
                    using (var qrGen = new QRCodeGenerator())
                    using (var qrData = qrGen.CreateQrCode(data.Pba, QRCodeGenerator.ECCLevel.M))
                    using (var qrCode = new QRCode(qrData))
                    using (var bmp = qrCode.GetGraphic(20))
                    {
                        if (bmp != null)
                            g.DrawImage(bmp, new RectangleF(qrX, qrY, qrSize, qrSize));
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("QR Error: " + ex.Message);
                }
            }
        }

        private void DrawFitText(Graphics g, string text, Font baseFont, Brush brush, RectangleF rect, float minSize)
        {
            var fmt = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoWrap };

            // Giảm dần size font cho đến khi vừa khung
            // Bước giảm (step) cũng cần nhỏ theo scale, ví dụ 0.5 * fs
            float step = 0.5f * (baseFont.Size / 10f);
            if (step < 0.1f) step = 0.1f;

            for (float s = baseFont.Size; s >= minSize; s -= step)
            {
                using var f = new Font(baseFont.FontFamily, s, baseFont.Style);
                // Đo kích thước
                var size = g.MeasureString(text, f, (int)rect.Width + 100, fmt);

                if (size.Width <= rect.Width + 5)
                {
                    g.DrawString(text, f, brush, rect, fmt);
                    return;
                }
            }
            // Fallback
            using var fMin = new Font(baseFont.FontFamily, minSize, baseFont.Style);
            g.DrawString(text, fMin, brush, rect, fmt);
        }
    }
}