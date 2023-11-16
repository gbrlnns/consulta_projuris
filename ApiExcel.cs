using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace API_Tarefas;

public static class ApiExcel
{
    public static List<string> ReadExcel(string fileName)
    {
        var xlDocument = SpreadsheetDocument.Open(fileName, false);
        var xlWorkbook = xlDocument.WorkbookPart;
        var xlWorksheet = xlWorkbook?.WorksheetParts.First();
        var xlStringTable = xlWorkbook?.SharedStringTablePart;
        var xlSheetdata = xlWorksheet?.Worksheet.Elements<SheetData>().First();
        var listaProcessos = new List<string>();
        
        foreach (Row r in xlSheetdata.Elements<Row>())
        {
            if (r.RowIndex == 1)
            {
                continue;
            }
            foreach (Cell c in r.Elements<Cell>())
            {
                string value = c.CellValue.InnerXml;
                if (c.DataType != null && c.DataType.Value == CellValues.SharedString)
                {
                    string processo = xlStringTable.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
                    listaProcessos.Add(processo);
                }
                else
                {
                    string processo = value;
                    listaProcessos.Add(processo);
                }
            }
        }

        return listaProcessos;
    }

    public static void WriteExcel(string path, Dictionary<string, string> tarefasDict)
    {
        using (var xlFinal = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook))
        {
            var xlWorkbook = xlFinal.AddWorkbookPart();
            xlWorkbook.Workbook = new Workbook();

            var xlWorksheet = xlWorkbook.AddNewPart<WorksheetPart>();
            xlWorksheet.Worksheet = new Worksheet(new SheetData());

            var xlSheets = xlFinal.WorkbookPart.Workbook.AppendChild(new Sheets());
            var xlSheet = new Sheet()
            {
                Id = xlFinal.WorkbookPart.GetIdOfPart(xlWorksheet),
                SheetId = 1,
                Name = "Processo"
            };
            xlSheets.Append(xlSheet);

            var xlSheetData = xlWorksheet.Worksheet.GetFirstChild<SheetData>();

            var linhaCabecalho = new Row();
            linhaCabecalho.AppendChild(new Cell()
            {
                DataType = CellValues.String,
                CellValue = new CellValue("Número do processo")
            });
            
            linhaCabecalho.AppendChild(new Cell()
            {
                DataType = CellValues.String,
                CellValue = new CellValue("Tarefas pendentes")
            });

            xlSheetData.AppendChild(linhaCabecalho);

            foreach (var kvp in tarefasDict)
            {
                var linhaDados = new Row();
                linhaDados.AppendChild(new Cell()
                {
                    DataType = CellValues.String,
                    CellValue = new CellValue(kvp.Key)
                });
                linhaDados.AppendChild(new Cell()
                {
                    DataType = CellValues.String,
                    CellValue = new CellValue(kvp.Value)
                });
                xlSheetData.AppendChild(linhaDados);
            }
        }
    }
}