using Segfy.Youtube.Core.Repository.MongoDb;
using Segfy.Youtube.Tests.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Segfy.Youtube.Tests
{
    [Collection("MongoDatabase")]
    public class MongoDatabaseTest
    {

        [Fact]
        public void ValidConnectionMustNotThrowExceptionOnInit()
        {
            Exception exception = null;

            try
            {
                var repository = new MongoDbYoutubeRepository(Resources.MongoDbConnection);
            }
            catch (Exception e)
            {
                exception = e;
            }

            Assert.Null(exception);
        }

        [Fact]
        public void InvalidConnectionMustThrowExceptionOnInit()
        {
            Exception exception = null;

            try
            {
                var repository = new MongoDbYoutubeRepository("");
            }
            catch (Exception e)
            {
                exception = e;
            }

            Assert.NotNull(exception);
        }


    }
}
