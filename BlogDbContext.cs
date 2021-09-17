using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using MongoDB.Extensions.Context;

namespace Foo {
    public class BlogDbContext : MongoDbContext {
        public BlogDbContext(MongoOptions mongoOptions) : base(mongoOptions) {

        }
        protected override void OnConfiguring(IMongoDatabaseBuilder mongoDatabaseBuilder) {
            mongoDatabaseBuilder
                .RegisterDefaultConventionPack()
                .ConfigureConnection(con => con.ReadConcern = ReadConcern.Majority)
                .ConfigureConnection(con => con.WriteConcern = WriteConcern.WMajority)
                .ConfigureConnection(con => con.ReadPreference = ReadPreference.Primary)
                .ConfigureCollection(new BlogCollectionConfiguration());
        }
    }
}