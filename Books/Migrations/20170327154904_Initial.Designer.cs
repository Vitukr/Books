using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Books.Models;

namespace Books.Migrations
{
    [DbContext(typeof(BooksContext))]
    [Migration("20170327154904_Initial")]
    partial class Initial
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

                    b.Property<int?>("BookID");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("BookID");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("Books.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Passage");

                    b.HasKey("ID");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Books.Models.Author", b =>
                {
                    b.HasOne("Books.Models.Book")
                        .WithMany("Authors")
                        .HasForeignKey("BookID");
                });
        }
    }
}
