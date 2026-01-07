using ConsoleApp;
namespace Prototype_Pattern_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void DataExportJSON_DifferentIndexes_But_EqualFields()
        {
            // Arrange
            var original = new DataExportJSON("{ 'name': 'UserName2' }", "data.json", "UTF-8", true);

            // Act
            var clone = (DataExportJSON)original.MyClone();

            // Assert
            Assert.NotSame(original, clone); // Different index
            Assert.Equal(original.Data, clone.Data);
            Assert.Equal(original.FilePath, clone.FilePath);
            Assert.Equal(original.Encoding, clone.Encoding);
            Assert.Equal(original.Indented, clone.Indented); // Equal field data
        }

        [Fact]
        public void DataExportBinary_Independent_WhenOriginalChanges()
        {
            // Arrange
            var original = new DataExportBinary("binary_data", "file.bin", 4096);

            // Act
            var clone = (DataExportBinary)original.MyClone();

            // Change Data and buffer size
            original.BufferSize = 8192;
            original.Data = "new_binary_data";

            // Assert
            Assert.Equal(4096, clone.BufferSize); // Clone have 4096
            Assert.Equal("binary_data", clone.Data); // Clone have old Data

            // Original have new Data and new buffer size
            Assert.Equal(8192, original.BufferSize);
            Assert.NotEqual(original.BufferSize, clone.BufferSize);
        }

        [Fact]
        public void ICloneable_ReturnObject()
        {
            // Arrange
            var original = new DataExportJSON("{}", "data.json", "UTF-8", true);
            ICloneable standardInterface = original;

            // Act Call IClonable method Clone
            object result = standardInterface.Clone();

            // Assert Check Type
            Assert.IsType<DataExportJSON>(result);
            Assert.True(result.GetType() == typeof(DataExportJSON));

            var castedResult = result as DataExportJSON;
            
            Assert.NotNull(castedResult);
            Assert.Equal(original.FilePath, castedResult.FilePath);
        }
    }
}