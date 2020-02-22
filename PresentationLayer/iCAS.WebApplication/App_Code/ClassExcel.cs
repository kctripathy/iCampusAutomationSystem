using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;

namespace TCon.iCAS.WebApplication
{
    class CExcel
    {
        Excel.Application xlApp;
        Excel.Workbook wb;
        int wsCount = 0;
        Excel.Worksheet sheet;
        object returnval = null;
        object xlCell1;
        object xlCell2;
        Excel.Range xlRange;

        public CExcel()
        {
        }

        public void copyWorkBook(CExcel XLS)
        {
            XLS.wb = wb;
        }

        public void AddSheet(string sSheetName, string sOrientation, double dLeftMargin, double dRightMargin, double dTopMargin, double dBottomMargin)
        {
            if (wsCount != 0)
                returnval = wb.Sheets.Add(Missing.Value, sheet, 1, Excel.XlSheetType.xlWorksheet);

            wsCount = wsCount + 1;
            sheet = (Excel.Worksheet)wb.Sheets[wsCount];

            if (sSheetName != string.Empty)
                sheet.Name = sSheetName;

            if (sOrientation == "L")
                sheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            else
                sheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;

            sheet.PageSetup.LeftMargin = dLeftMargin;
            sheet.PageSetup.RightMargin = dLeftMargin;
            sheet.PageSetup.TopMargin = dTopMargin;
            sheet.PageSetup.BottomMargin = dBottomMargin;


        }

        public void SetTitleRows(string sTitleRows)
        {
            sheet.PageSetup.PrintTitleRows = sTitleRows;
        }


        public void NewFile(bool bVisible)
        {
            xlApp = new Excel.Application();
            wb = xlApp.Workbooks.Add(Excel.XlSheetType.xlWorksheet);

            xlApp.Visible = bVisible;
            xlApp.DisplayAlerts = false;
        }

        public void OpenFile(string sFileName)
        {
            xlApp = new Excel.Application();
            wb = xlApp.Workbooks.Open(sFileName, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

        }


        public void SetActiveSheet(string sSheet)
        {
            if (sSheet == "") // open first worksheet 
                sheet = (Excel.Worksheet)wb.Worksheets.get_Item(1);
            else
                sheet = (Excel.Worksheet)wb.Sheets[sSheet];
        }


        public void WriteCell(int iRow, int iCol, string sData, string sFormat)
        {
            sheet.Cells[iRow, iCol] = sData;
        }

        public void Autofit(int iStartRow, int iStartCol, int iEndRow, int iEndCol)
        {
            xlCell1 = sheet.Cells[iStartRow, iStartCol];
            xlCell2 = sheet.Cells[iEndRow, iEndCol];

            xlRange = sheet.get_Range(xlCell1, xlCell2);
            xlRange.EntireColumn.AutoFit();

        }
        public void SetCellsFont(int iStartRow, int iStartCol, int iEndRow, int iEndCol, string sFont, int iSize, string sColor, bool bBold, bool bItalic, bool bUnderline)
        {
            xlCell1 = sheet.Cells[iStartRow, iStartCol];
            xlCell2 = sheet.Cells[iEndRow, iEndCol];

            xlRange = sheet.get_Range(xlCell1, xlCell2);
            //xlRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
            //xlRange.Font.ColorIndex = 123;
            xlRange.Font.Name = sFont;
            xlRange.Font.Size = iSize;
            xlRange.Font.Bold = bBold;
            xlRange.Font.Italic = bItalic;
            xlRange.Font.Underline = bUnderline;
        }

        public void MergeCells(int iStartRow, int iStartCol, int iEndRow, int iEndCol, string sHAllign, string sVAllign)
        {
            xlCell1 = sheet.Cells[iStartRow, iStartCol];
            xlCell2 = sheet.Cells[iEndRow, iEndCol];

            xlRange = sheet.get_Range(xlCell1, xlCell2);
            xlRange.Merge(false);
            if (sVAllign == "C")
                xlRange.get_Range("A1", "D1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            else if (sVAllign == "T")
                xlRange.get_Range("A1", "D1").VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
            else if (sVAllign == "B")
                xlRange.get_Range("A1", "D1").VerticalAlignment = Excel.XlVAlign.xlVAlignBottom;



            if (sHAllign == "C")
                xlRange.get_Range("A1", "D1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            else if (sHAllign == "L")
                xlRange.get_Range("A1", "D1").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            if (sHAllign == "R")
                xlRange.get_Range("A1", "D1").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;



        }


        public void SetColumnWidth(int iStartCol, int iEndCol, int iWidth)
        {
            xlCell1 = sheet.Cells[1, iStartCol];
            xlCell2 = sheet.Cells[1, iEndCol];
            xlRange = sheet.get_Range(xlCell1, xlCell2);
            xlRange.ColumnWidth = iWidth;


        }

        public void WrapText(int iStartRow, int iStartCol, int iEndRow, int iEndCol, bool bWrap)
        {
            xlCell1 = sheet.Cells[iStartRow, iStartCol];
            xlCell2 = sheet.Cells[iEndRow, iEndCol];

            xlRange = sheet.get_Range(xlCell1, xlCell2);
            xlRange.WrapText = bWrap;

        }

        public void SetCellsColor(int iStartRow, int iStartCol, int iEndRow, int iEndCol, string sColor, int iBorder)
        {
            xlCell1 = sheet.Cells[iStartRow, iStartCol];
            xlCell2 = sheet.Cells[iEndRow, iEndCol];

            xlRange = sheet.get_Range(xlCell1, xlCell2);

            //xlRange.Interior.Color=System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

            xlRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromName(sColor));

            if (iBorder > 0)
                xlRange.Borders.LineStyle = 1;
        }

        public void SetCellsBorder(int iStartRow, int iStartCol, int iEndRow, int iEndCol, int iBorder)
        {
            xlCell1 = sheet.Cells[iStartRow, iStartCol];
            xlCell2 = sheet.Cells[iEndRow, iEndCol];

            xlRange = sheet.get_Range(xlCell1, xlCell2);

            xlRange.Borders.LineStyle = iBorder;
        }

        public void Show()
        {
            xlApp.Visible = true;
        }

        public void Dispose()
        {

            xlApp = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

   
    }

    class CStudent
    {
       
    }
}