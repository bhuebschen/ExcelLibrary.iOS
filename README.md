ExcelLibrary.iOS
================

Port of https://code.google.com/p/excellibrary/ to run with MonoTouch

>>

excellibrary
============

Introduction
============

This library is built based on the following documents, thanks to their authors:

  * Compound Document file format
  * Excel file format
  * Microsoft Office 97 Drawing File Format

Record structures in BIFF8/BIFF8X format are considered.

Now this project is hosted on Google Code.
You can get the latest code, report issues and submit improvements from there. 

What It Can Do?
===============

  * It can read worksheets in a workbook and read cells in a worksheet.
  * It can read cell content (text, number, datetime, or error) and cell format (font, alignment, linestyle, background, etc.).
  * It can read pictures in the file, get information of image size, position, data, and format.
  * It can create a workbook and save to file.

Using the Code
==============

  1. Open file:
    Stream fileStream = File.OpenRead(file);
    Workbook book = new Workbook();
    book.Open(fileStream);
    Worksheet sheet = book.Worksheets[0];

  2. Read cell:
    int row = 1;
    int col = 0;
    string ID = sheet.Cells[row, col].StringValue;

    Picture pic = sheet.ExtractPicture(row, col);

  3.  Create workbook:
    string file = "C:\\newdoc.xls";
    Workbook workbook = new Workbook();
    Worksheet worksheet = new Worksheet("First Sheet");
    worksheet.Cells[0, 1] = new Cell(1);
    worksheet.Cells[2, 0] = new Cell(2.8);
    worksheet.Cells[3, 3] = new Cell((decimal)3.45);
    worksheet.Cells[2, 2] = new Cell("Text string");
    worksheet.Cells[2, 4] = new Cell("Second string");
    worksheet.Cells[4, 0] = new Cell(32764.5, "#,###.00");
    worksheet.Cells[5, 1] = new Cell(DateTime.Now, @"YYYY\-MM\-DD");
    worksheet.Cells.ColumnWidth[0, 1] = 3000;
    workbook.Worksheets.Add(worksheet);
    workbook.Save(file);

  4.    Traverse worksheet:
     // traverse cells
    foreach (Pair<Pair<int, int>, Cell> cell in sheet.Cells)
    {
	dgvCells[cell.Left.Right, cell.Left.Left].Value = cell.Right.Value;
    }

    // traverse rows by Index
    for (int rowIndex = sheet.Cells.FirstRowIndex; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
    {
	Row row = sheet.Cells.GetRow(rowIndex);
	for (int colIndex = row.FirstColIndex; colIndex <= row.LastColIndex; colIndex++)
	{
	    Cell cell = row.GetCell(colIndex);
	}
    }
