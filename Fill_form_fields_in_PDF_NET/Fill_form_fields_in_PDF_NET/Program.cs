// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2VFhhQlVEfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5Qd0FjUH5fdX1RR2ZZ");

//Get stream from an existing PDF document. 
FileStream docStream = new FileStream(Path.GetFullPath("../../../PDFForm.pdf"), FileMode.Open, FileAccess.Read);

//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Load the form from the loaded document.
PdfLoadedForm form = loadedDocument.Form;

//Load the form field collections from the form.
PdfLoadedFormFieldCollection fieldCollection = form.Fields as PdfLoadedFormFieldCollection;
PdfLoadedField loadedField = null;

//Get and fill the field using TryGetField Method.
if (fieldCollection.TryGetField("Name", out loadedField))
{
    (loadedField as PdfLoadedTextBoxField).Text = "Simons";
}
if (fieldCollection.TryGetField("Email address", out loadedField))
{
    (loadedField as PdfLoadedTextBoxField).Text = "simonsbistro@outlook.com";
}
if (fieldCollection.TryGetField("Phone", out loadedField))
{
    (loadedField as PdfLoadedTextBoxField).Text = "31 12 34 56";
}
if (fieldCollection.TryGetField("Gender", out loadedField))
{
    (loadedField as PdfLoadedRadioButtonListField).SelectedIndex = 0;
}

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
