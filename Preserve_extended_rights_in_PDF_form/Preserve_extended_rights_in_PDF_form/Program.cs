// See https://aka.ms/new-console-template for more information

//Get the loaded form
using Syncfusion.Pdf.Parsing;

//Load an existing PDF.
FileStream docStream = new FileStream("../../../ExtendedFeaturedForm.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
//Load the form from the loaded document.
PdfLoadedForm loadedForm = loadedDocument.Form;
loadedForm.SetDefaultAppearance(false);

//Load the form field collections from the form.
PdfLoadedFormFieldCollection fieldCollection = loadedForm.Fields as PdfLoadedFormFieldCollection;
PdfLoadedField loadedField = null;

//Get the field using TryGetField Method.
if (fieldCollection.TryGetField("First Name", out loadedField))
{
    (loadedField as PdfLoadedTextBoxField).Text = "Simons";
}
if (fieldCollection.TryGetField("Last Name", out loadedField))
{
    (loadedField as PdfLoadedTextBoxField).Text = "Bistro";
}
if (fieldCollection.TryGetField("Email Address", out loadedField))
{
    (loadedField as PdfLoadedTextBoxField).Text = "simonsbistro@outlook.com";
}

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
