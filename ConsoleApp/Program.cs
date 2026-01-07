namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataExportJSON originalJSONExport = new DataExportJSON(
                data: "{ 'name': 'UserName1' }",
                filePath: "data.json",
                encoding: "UTF-8",
                indented: true);

            // Clone our class DataExportJSON
            DataExportJSON clonedJSONExport = (DataExportJSON)originalJSONExport.MyClone();

            // Change Data in original class, but cloned class will not change
            originalJSONExport.Data = "{ 'name': 'UserName2' }";

            Console.WriteLine($"OriginalJSON: {originalJSONExport.Data}\n");

            Console.WriteLine($"ClonedJSON: {clonedJSONExport.Data}\n");



            // ICloneableClone возвращает самый верхний уровень класса в иерархии
            // то есть object.
            var ICloneableClone = ((ICloneable)originalJSONExport).Clone();
            

            Console.WriteLine("\nProgram Complite.");
        }
    }
}
