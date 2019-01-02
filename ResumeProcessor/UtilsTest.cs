using PictureServices.Core;
using Xunit;

namespace ResumeProcessor
{
    public class UtilsTest
    {
        [Fact]
        public void should_true()
        {
            string str = "hello world";
            Assert.Equal("worl", Utils.GetString(str,"wo","d"));
        }
        
    }
}