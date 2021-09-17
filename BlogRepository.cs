using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Foo {
    public class BlogRepository {
        private InsertOneOptions _insertOneOptions;
        private IMongoCollection<Blog> _mongoCollection;

        public BlogRepository(BlogDbContext blogDbContext) {
            if (blogDbContext == null)
                throw new ArgumentNullException(nameof(blogDbContext));

            _mongoCollection = blogDbContext.CreateCollection<Blog>();

            _insertOneOptions = new InsertOneOptions() {
                BypassDocumentValidation = false
            };
        }

        public async Task AddBlogAsync(
            Blog blog, CancellationToken cancellationToken) {
            await _mongoCollection
                .InsertOneAsync(blog, _insertOneOptions, cancellationToken);
        }

        public async Task<IEnumerable<Blog>> GetBlogsAsync(
            CancellationToken cancellationToken = default) {
            var findOptions = new FindOptions<Blog>();

            IAsyncCursor<Blog> result = await _mongoCollection.FindAsync<Blog>(
                Builders<Blog>.Filter.Empty, findOptions, cancellationToken);

            return await result.ToListAsync();
        }
    }

}