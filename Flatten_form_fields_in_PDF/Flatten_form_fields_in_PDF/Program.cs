// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

//Load the PDF document.
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Get the loaded form.
PdfLoadedForm loadedForm = loadedDocument.Form;
PdfLoadedFormFieldCollection fields = loadedForm.Fields;
//Flatten the whole form.
loadedForm.Flatten = true;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}

//Close the document.
loadedDocument.Close(true);
