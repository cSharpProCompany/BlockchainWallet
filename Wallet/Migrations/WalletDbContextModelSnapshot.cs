﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wallet.Models;

namespace Wallet.Migrations
{
    [DbContext(typeof(WalletDbContext))]
    partial class WalletDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Wallet.Models.BlockChainTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlockNumber");

                    b.Property<string>("ContractAddress");

                    b.Property<DateTime>("Date");

                    b.Property<double>("DecimalValue");

                    b.Property<string>("FromAddress");

                    b.Property<bool>("IsSuccess");

                    b.Property<string>("ToAddress");

                    b.Property<string>("TransactionHash");

                    b.Property<string>("What");

                    b.HasKey("Id");

                    b.ToTable("BlockChainTransactions");
                });

            modelBuilder.Entity("Wallet.Models.CustomEventLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountOfToken")
                        .HasColumnType("decimal(38, 5)");

                    b.Property<int>("BlockNumber");

                    b.Property<int>("ERC20TokenId");

                    b.Property<string>("From");

                    b.Property<string>("To");

                    b.Property<DateTime>("dateTime");

                    b.HasKey("Id");

                    b.HasIndex("ERC20TokenId");

                    b.ToTable("CustomEventLogs");
                });

            modelBuilder.Entity("Wallet.Models.ERC20Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int>("DecimalPlaces");

                    b.Property<bool>("IsSynchronized");

                    b.Property<int>("LastSynchronizedBlockNumber");

                    b.Property<string>("Name");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(38, 5)");

                    b.Property<string>("Symbol");

                    b.Property<int>("TransactionsCount");

                    b.Property<string>("Type");

                    b.Property<DateTime?>("UpdDate");

                    b.Property<int>("WalletsCount");

                    b.Property<string>("WebSiteLink");

                    b.HasKey("Id");

                    b.ToTable("Erc20Tokens");
                });

            modelBuilder.Entity("Wallet.Models.NotificationOptions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressThatReceivedNumberOfToken");

                    b.Property<bool>("IsWithoutNotifications");

                    b.Property<int>("NumberOfContractTokenWasSent");

                    b.Property<int>("NumberOfTokenOrEtherThatWasSentFrom");

                    b.Property<int>("NumberOfTokenOrEtherThatWasSentTo");

                    b.Property<int>("NumberOfTokenOrEtherWasReceived");

                    b.Property<string>("NumberOfTokenOrEtherWasSentName");

                    b.Property<int>("NumberOfTokenWasReceivedByAddress");

                    b.Property<string>("TokenOrEtherReceivedName");

                    b.Property<string>("TokenOrEtherSentName");

                    b.Property<string>("TokenOrEtherWasReceivedName");

                    b.Property<int>("TokenReceivedDecimalPlaces");

                    b.Property<int>("TokenSentDecimalPlaces");

                    b.Property<int>("UserWatchlistId");

                    b.Property<bool>("WhenAnythingWasSent");

                    b.Property<bool>("WhenNumberOfContractTokenWasSent");

                    b.Property<bool>("WhenNumberOfContractWasReceivedByAddress");

                    b.Property<bool>("WhenNumberOfTokenOrEtherWasReceived");

                    b.Property<bool>("WhenNumberOfTokenOrEtherWasSent");

                    b.Property<bool>("WhenTokenOrEtherIsReceived");

                    b.Property<bool>("WhenTokenOrEtherIsSent");

                    b.HasKey("Id");

                    b.HasIndex("UserWatchlistId")
                        .IsUnique();

                    b.ToTable("NotificationOptions");
                });

            modelBuilder.Entity("Wallet.Models.PageData", b =>
                {
                    b.Property<int>("PageDataId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ElementData");

                    b.Property<string>("ElementName");

                    b.Property<bool>("IsTransactionsSaved");

                    b.HasKey("PageDataId");

                    b.ToTable("PageData");
                });

            modelBuilder.Entity("Wallet.Models.TokenHolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("ERC20TokenId");

                    b.Property<int>("GeneralTransactionsNumber");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(38, 5)");

                    b.Property<int>("ReceivedTransactionsNumber");

                    b.Property<int>("SentTransactionsNumber");

                    b.Property<decimal>("TokensReceived")
                        .HasColumnType("decimal(38, 5)");

                    b.Property<decimal>("TokensSent")
                        .HasColumnType("decimal(38, 5)");

                    b.HasKey("Id");

                    b.HasIndex("ERC20TokenId");

                    b.ToTable("TokenHolders");
                });

            modelBuilder.Entity("Wallet.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Wallet.Models.UserWatchlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<bool>("IsContract");

                    b.Property<int>("TokenDecimalPlaces");

                    b.Property<string>("UserEmail")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("UserWatchlist");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Wallet.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Wallet.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Wallet.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Wallet.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wallet.Models.CustomEventLog", b =>
                {
                    b.HasOne("Wallet.Models.ERC20Token", "Token")
                        .WithMany("Logs")
                        .HasForeignKey("ERC20TokenId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wallet.Models.NotificationOptions", b =>
                {
                    b.HasOne("Wallet.Models.UserWatchlist", "UserWatchlist")
                        .WithOne("NotificationOptions")
                        .HasForeignKey("Wallet.Models.NotificationOptions", "UserWatchlistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wallet.Models.TokenHolder", b =>
                {
                    b.HasOne("Wallet.Models.ERC20Token", "Token")
                        .WithMany("Holders")
                        .HasForeignKey("ERC20TokenId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
