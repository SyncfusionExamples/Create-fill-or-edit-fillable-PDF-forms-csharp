// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document
PdfDocument document = new PdfDocument();
//Add a new page to the PDF document
PdfPage page = document.Pages.Add();
//Set the standard font
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
//Draw the string      
page.Graphics.DrawString("Job Application", font, PdfBrushes.Black, new PointF(250, 0));
font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
page.Graphics.DrawString("Name", font, PdfBrushes.Black, new PointF(10, 20));

//Create a text box field for name
PdfTextBoxField textBoxField1 = new PdfTextBoxField(page, "Name");
textBoxField1.Bounds = new RectangleF(10, 40, 200, 20);
textBoxField1.ToolTip = "Name";
document.Form.Fields.Add(textBoxField1);

page.Graphics.DrawString("Email address", font, PdfBrushes.Black, new PointF(10, 80));
//Create a text box field for email address
PdfTextBoxField textBoxField3 = new PdfTextBoxField(page, "Email address");
textBoxField3.Bounds = new RectangleF(10, 100, 200, 20);
textBoxField3.ToolTip = "Email address";
document.Form.Fields.Add(textBoxField3);

page.Graphics.DrawString("Phone", font, PdfBrushes.Black, new PointF(10, 140));
//Create a text box field for phone
PdfTextBoxField textBoxField4 = new PdfTextBoxField(page, "Phone");
textBoxField4.Bounds = new RectangleF(10, 160, 200, 20);
textBoxField4.ToolTip = "Phone";
document.Form.Fields.Add(textBoxField4);

page.Graphics.DrawString("Gender", font, PdfBrushes.Black, new PointF(10, 200));
//Create radio button for gender
PdfRadioButtonListField employeesRadioList = new PdfRadioButtonListField(page, "Gender");
document.Form.Fields.Add(employeesRadioList);
page.Graphics.DrawString("Male", font, PdfBrushes.Black, new PointF(40, 220));
PdfRadioButtonListItem radioButtonItem1 = new PdfRadioButtonListItem("Male");
radioButtonItem1.Bounds = new RectangleF(10, 220, 20, 20);
page.Graphics.DrawString("Female", font, PdfBrushes.Black, new PointF(140, 220));
PdfRadioButtonListItem radioButtonItem2 = new PdfRadioButtonListItem("Female");
radioButtonItem2.Bounds = new RectangleF(110, 220, 20, 20);
employeesRadioList.Items.Add(radioButtonItem1);
employeesRadioList.Items.Add(radioButtonItem2);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
