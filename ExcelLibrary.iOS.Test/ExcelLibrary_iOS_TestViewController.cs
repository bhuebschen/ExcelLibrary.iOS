using System;
using CoreGraphics;
using Foundation;
using UIKit;
using QiHe.CodeLib;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.BinaryDrawingFormat;
using ExcelLibrary.BinaryFileFormat;
using ExcelLibrary.SpreadSheet;

namespace ExcelLibrary.iOS.Test
{
	public partial class ExcelLibrary_iOS_TestViewController : UIViewController
	{
		public ExcelLibrary_iOS_TestViewController () : base ("ExcelLibrary_iOS_TestViewController", null)
		{
		}

		System.Collections.Generic.Dictionary<String, UILabel> Cells = new System.Collections.Generic.Dictionary<string, UILabel>();

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		partial void TestSave (NSObject sender)
		{
			System.Diagnostics.Debug.WriteLine (System.Environment.GetFolderPath (System.Environment.SpecialFolder.MyDocuments)  + "/newdoc.xls");
			string file = System.Environment.GetFolderPath (System.Environment.SpecialFolder.MyDocuments)  + "/newdoc.xls";
			Workbook workbook = new Workbook();
			Worksheet worksheet = new Worksheet("First Sheet");
			worksheet.Cells[0, 1] = new Cell(1);
			worksheet.Cells[2, 0] = new Cell(2.8);
			worksheet.Cells[3, 3] = new Cell((decimal)3.45);
			worksheet.Cells[2, 2] = new Cell("Text string");
			worksheet.Cells[2, 4] = new Cell("Second string");
			worksheet.Cells[4, 0] = new Cell(32764.5, "#,##0.00");
			worksheet.Cells[5, 1] = new Cell(DateTime.Now, @"YYYY\-MM\-DD");
			worksheet.Cells.ColumnWidth[0, 1] = 3000;
			workbook.Worksheets.Add(worksheet);
			workbook.Save(file);
		}

		partial void TestRead (NSObject sender)
		{
			CompoundDocument doc = CompoundDocument.Open (System.Environment.GetFolderPath (System.Environment.SpecialFolder.MyDocuments)  + "/newdoc.xls");
			byte[] bookdata = doc.GetStreamData("Workbook");
			if (bookdata == null) return;
			Workbook book = WorkbookDecoder.Decode(new System.IO.MemoryStream(bookdata));
			Worksheet ws = book.Worksheets[0];
			for(int Cols = 0; Cols < 6; Cols++) {
				for(int Rows = 0; Rows < 13; Rows++) {
					char R = (char)(((int)'A')+(Cols));
					int C = Rows;
					try {
						Cells[R.ToString() + C.ToString()].Text = ws.Cells[Rows, Cols].Value.ToString ();

					} catch (Exception ex) {
						
					}
				}


			}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			Cells.Add ("A1",  A1);     Cells.Add ("B1",  B1);     Cells.Add ("C1",  C1);    Cells.Add ("D1",  D1);   Cells.Add ("E1",  E1);    Cells.Add ("F1",  F1);
			Cells.Add ("A2",  A2);     Cells.Add ("B2",  B2);     Cells.Add ("C2",  C2);    Cells.Add ("D2",  D2);   Cells.Add ("E2",  E2);    Cells.Add ("F2",  F2);
			Cells.Add ("A3",  A3);     Cells.Add ("B3",  B3);     Cells.Add ("C3",  C3);    Cells.Add ("D3",  D3);   Cells.Add ("E3",  E3);    Cells.Add ("F3",  F3);
			Cells.Add ("A4",  A4);     Cells.Add ("B4",  B4);     Cells.Add ("C4",  C4);    Cells.Add ("D4",  D4);   Cells.Add ("E4",  E4);    Cells.Add ("F4",  F4);
			Cells.Add ("A5",  A5);     Cells.Add ("B5",  B5);     Cells.Add ("C5",  C5);    Cells.Add ("D5",  D5);   Cells.Add ("E5",  E5);    Cells.Add ("F5",  F5);
			Cells.Add ("A6",  A6);     Cells.Add ("B6",  B6);     Cells.Add ("C6",  C6);    Cells.Add ("D6",  D6);   Cells.Add ("E6",  E6);    Cells.Add ("F6",  F6);
			Cells.Add ("A7",  A7);     Cells.Add ("B7",  B7);     Cells.Add ("C7",  C7);    Cells.Add ("D7",  D7);   Cells.Add ("E7",  E7);    Cells.Add ("F7",  F7);
			Cells.Add ("A8",  A8);     Cells.Add ("B8",  B8);     Cells.Add ("C8",  C8);    Cells.Add ("D8",  D8);   Cells.Add ("E8",  E8);    Cells.Add ("F8",  F8);
			Cells.Add ("A9",  A9);     Cells.Add ("B9",  B9);     Cells.Add ("C9",  C9);    Cells.Add ("D9",  D9);   Cells.Add ("E9",  E9);    Cells.Add ("F9",  F9);
			Cells.Add ("A10", A10);    Cells.Add ("B10", B10);    Cells.Add ("C10", C10);   Cells.Add ("D10", D10);  Cells.Add ("E10", E10);   Cells.Add ("F10", F10);
			Cells.Add ("A11", A11);    Cells.Add ("B11", B11);    Cells.Add ("C11", C11);   Cells.Add ("D11", D11);  Cells.Add ("E11", E11);   Cells.Add ("F11", F11);
			Cells.Add ("A12", A12);    Cells.Add ("B12", B12);    Cells.Add ("C12", C12);   Cells.Add ("D12", D12);  Cells.Add ("E13", E12);   Cells.Add ("F14", F12);
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}
