using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Books.Models;

namespace Books.Migrations
{
    [DbContext(typeof(BooksContext))]
    [Migration("20170327170518_Initial3")]
    partial class Initial3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Books.Models.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("Books.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorRefId");

                    b.Property<string>("Name");

                    b.Property<string>("Passage");

                    b.HasKey("ID");

                    b.HasIndex("AuthorRefId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Books.Models.Book", b =>
                {
                    b.HasOne("Books.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorRefId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
