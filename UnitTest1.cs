using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Foo;
using Squadron;
using Xunit;

namespace MongoExtensionsWithRecods {
    public class Tests : IClassFixture<MongoResource> {

        private readonly MongoResource _mongoResource;

        public Tests(
            MongoResource mongoResource) {
            _mongoResource = mongoResource;
        }

        [Fact]
        public async Task Test1() {
            // arrange

            var context = new BlogDbContext(new MongoDB.Extensions.Context.MongoOptions {
                DatabaseName = "foo",
                    ConnectionString = _mongoResource.ConnectionString
            });

            var repository = new BlogRepository(context);
            // var blog = new Blog("tim", "foo", DateTime.UtcNow, Guid.NewGuid()) { };
            var blog = new Blog() {
                Author = "foo",
                Content = "bar",
                CreatedAt = DateTime.UtcNow,
                Id = Guid.NewGuid()
            };

            // act
            await repository.AddBlogAsync(blog, CancellationToken.None);
            var result = await repository.GetBlogsAsync();

            // assert
            Console.WriteLine(result.ToList().Count);
        }
    }
}