using System;
using MongoDB.Driver;
using MongoDB.Extensions.Context;

namespace Foo {
    internal class BlogCollectionConfiguration : IMongoCollectionConfiguration<Blog> {
        public void OnConfiguring(IMongoCollectionBuilder<Blog> mongoCollectionBuilder) {
            mongoCollectionBuilder
                .WithCollectionName("blogs")
                .AddBsonClassMap<Blog>(cm => {
                    cm.AutoMap();
                    cm.MapIdMember<Guid>(c => c.Id);
                })
                .WithCollectionSettings(settings => settings.ReadConcern = ReadConcern.Majority)
                .WithCollectionSettings(settings => settings.ReadPreference = ReadPreference.Nearest);

        }
    }
}