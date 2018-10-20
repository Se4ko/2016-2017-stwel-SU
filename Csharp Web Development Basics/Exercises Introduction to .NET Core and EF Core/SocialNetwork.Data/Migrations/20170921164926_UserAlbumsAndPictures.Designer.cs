﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SocialNetwork.Data;
using System;

namespace SocialNetwork.Data.Migrations
{
    [DbContext(typeof(SocialNetworkContext))]
    [Migration("20170921164926_UserAlbumsAndPictures")]
    partial class UserAlbumsAndPictures
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SocialNetwork.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BackgroundColour")
                        .IsRequired();

                    b.Property<bool>("IsPublic");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("SocialNetwork.Models.AlbumPicture", b =>
                {
                    b.Property<int>("AlbumId");

                    b.Property<int>("PictureId");

                    b.HasKey("AlbumId", "PictureId");

                    b.HasIndex("PictureId");

                    b.ToTable("AlbumPicture");
                });

            modelBuilder.Entity("SocialNetwork.Models.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caption")
                        .IsRequired();

                    b.Property<string>("FilePath")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("SocialNetwork.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastTimeLoggedIn");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte[]>("ProfilePicture");

                    b.Property<DateTime>("RegisteredOn");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SocialNetwork.Models.UserFriend", b =>
                {
                    b.Property<int>("FirstUserId");

                    b.Property<int>("SecondUserId");

                    b.HasKey("FirstUserId", "SecondUserId");

                    b.HasIndex("SecondUserId");

                    b.ToTable("UserFriend");
                });

            modelBuilder.Entity("SocialNetwork.Models.Album", b =>
                {
                    b.HasOne("SocialNetwork.Models.User", "Owner")
                        .WithMany("Albums")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SocialNetwork.Models.AlbumPicture", b =>
                {
                    b.HasOne("SocialNetwork.Models.Album", "Album")
                        .WithMany("Pictures")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SocialNetwork.Models.Picture", "Picture")
                        .WithMany("Albums")
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SocialNetwork.Models.UserFriend", b =>
                {
                    b.HasOne("SocialNetwork.Models.User", "FirstUser")
                        .WithMany("Followers")
                        .HasForeignKey("FirstUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SocialNetwork.Models.User", "SecondUser")
                        .WithMany("Following")
                        .HasForeignKey("SecondUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
