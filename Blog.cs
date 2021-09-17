using System;

namespace Foo {
    public class Blog {
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid Id { get; internal set; }
    }

    // public record Blog(string Author, string Content, DateTime CreatedAt, Guid id);
}