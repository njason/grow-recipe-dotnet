using System;
using Xunit;

namespace GrowRecipe.Tests
{
    public class ClientTests
    {
        public static Stream ToStream(this string str)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        [Fact]
        public void TestBasic()
        {
            xml = @"<recipe>
                        <germination duration='1'></germination>
                    </recipe>";

            using (var stringStream = xml.ToStream())
            {
                client = Client();
                client.Valid(stringStream);
            }
        }
    }
}
