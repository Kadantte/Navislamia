﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Navislamia.Game.Contexts;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Navislamia.Game.Migrations.Telecaster
{
    [DbContext(typeof(TelecasterContext))]
    partial class TelecasterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.AllianceEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("LeadGuildId")
                        .HasColumnType("bigint");

                    b.Property<int>("MaxAllianceCount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("NameChanged")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Alliances", (string)null);
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.AuctionEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long[]>("BiddersIds")
                        .HasColumnType("bigint[]");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("HighestBidderId")
                        .HasColumnType("bigint");

                    b.Property<string>("HighestBidderName")
                        .HasColumnType("text");

                    b.Property<long>("HighestBiddingPrice")
                        .HasColumnType("bigint");

                    b.Property<long>("InstantPurchasePrice")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsHiddenVillageOnly")
                        .HasColumnType("boolean");

                    b.Property<long>("ItemId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("RegistrationTax")
                        .HasColumnType("bigint");

                    b.Property<long>("SellerId")
                        .HasColumnType("bigint");

                    b.Property<string>("SellerName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HighestBidderId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.HasIndex("SellerId");

                    b.ToTable("Auctions", (string)null);
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.CharacterEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<string>("AccountName")
                        .HasColumnType("text");

                    b.Property<int>("AdvChatCount")
                        .HasColumnType("integer");

                    b.Property<bool>("AutoUsed")
                        .HasColumnType("boolean");

                    b.Property<long[]>("BeltItemIds")
                        .HasMaxLength(6)
                        .HasColumnType("bigint[]");

                    b.Property<int>("Chaos")
                        .HasColumnType("integer");

                    b.Property<string>("CharacterName")
                        .HasColumnType("text");

                    b.Property<int>("Charisma")
                        .HasColumnType("integer");

                    b.Property<int>("ChatBlockTime")
                        .HasColumnType("integer");

                    b.Property<string[]>("ClientInfo")
                        .HasColumnType("text[]");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CurrentJob")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DkCount")
                        .HasColumnType("integer");

                    b.Property<int>("EtherealStoneDurability")
                        .HasColumnType("integer");

                    b.Property<long>("Exp")
                        .HasColumnType("bigint");

                    b.Property<string[]>("FlagList")
                        .HasColumnType("text[]");

                    b.Property<long>("Gold")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("GuildBlockTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("GuildId")
                        .HasColumnType("bigint");

                    b.Property<int>("HairColorIndex")
                        .HasColumnType("integer");

                    b.Property<int>("HairColorRgb")
                        .HasColumnType("integer");

                    b.Property<int>("Havoc")
                        .HasColumnType("integer");

                    b.Property<int>("HideEquipFlag")
                        .HasColumnType("integer");

                    b.Property<int>("Hp")
                        .HasColumnType("integer");

                    b.Property<int>("HuntaholicEnterCount")
                        .HasColumnType("integer");

                    b.Property<int>("HuntaholicPoint")
                        .HasColumnType("integer");

                    b.Property<decimal>("ImmoralPoint")
                        .HasColumnType("numeric");

                    b.Property<int>("Jlv")
                        .HasColumnType("integer");

                    b.Property<short>("JobDepth")
                        .HasColumnType("smallint");

                    b.Property<int[]>("JobLvs")
                        .HasMaxLength(3)
                        .HasColumnType("integer[]");

                    b.Property<long>("Jp")
                        .HasColumnType("bigint");

                    b.Property<long>("LastDecreasedExp")
                        .HasColumnType("bigint");

                    b.Property<int>("Layer")
                        .HasColumnType("integer");

                    b.Property<int>("LoginCount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("LoginTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("LogoutTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Lv")
                        .HasColumnType("integer");

                    b.Property<long?>("MainSummonId")
                        .HasColumnType("bigint");

                    b.Property<int>("MaxReachedLv")
                        .HasColumnType("integer");

                    b.Property<int[]>("Models")
                        .HasMaxLength(5)
                        .HasColumnType("integer[]");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Mp")
                        .HasColumnType("integer");

                    b.Property<int>("OtpValue")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("OtpVerifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("PartyId")
                        .HasColumnType("bigint");

                    b.Property<int>("Permission")
                        .HasColumnType("integer");

                    b.Property<long?>("PetId")
                        .HasColumnType("bigint");

                    b.Property<int>("PkCount")
                        .HasColumnType("integer");

                    b.Property<bool>("PkMode")
                        .HasColumnType("boolean");

                    b.Property<int>("PlayTime")
                        .HasColumnType("integer");

                    b.Property<int[]>("Position")
                        .HasMaxLength(3)
                        .HasColumnType("integer[]");

                    b.Property<long?>("PreviousGuildId")
                        .HasColumnType("bigint");

                    b.Property<int[]>("PreviousJobs")
                        .HasMaxLength(3)
                        .HasColumnType("integer[]");

                    b.Property<int>("Race")
                        .HasColumnType("integer");

                    b.Property<int>("RemainSummonTime")
                        .HasColumnType("integer");

                    b.Property<int>("Sex")
                        .HasColumnType("integer");

                    b.Property<int>("SkinColor")
                        .HasColumnType("integer");

                    b.Property<int>("Slot")
                        .HasColumnType("integer");

                    b.Property<int>("Stamina")
                        .HasColumnType("integer");

                    b.Property<long?>("SubSummonId")
                        .HasColumnType("bigint");

                    b.Property<long[]>("SummonSlotItemIds")
                        .HasMaxLength(6)
                        .HasColumnType("bigint[]");

                    b.Property<int>("TalentPoint")
                        .HasColumnType("integer");

                    b.Property<int>("TextureId")
                        .HasColumnType("integer");

                    b.Property<long>("TotalJp")
                        .HasColumnType("bigint");

                    b.Property<bool>("WasNameChanged")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.HasIndex("MainSummonId")
                        .IsUnique();

                    b.HasIndex("PartyId");

                    b.HasIndex("PetId")
                        .IsUnique();

                    b.HasIndex("PreviousGuildId");

                    b.HasIndex("SubSummonId")
                        .IsUnique();

                    b.ToTable("Characters", (string)null);
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.DungeonEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("BestRaidTime")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LastDungeonRaidWrapUpTime")
                        .HasColumnType("integer");

                    b.Property<int>("LastDungeonSiegeFinishTime")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("OwnerGuildId")
                        .HasColumnType("bigint");

                    b.Property<long?>("RaidGuildId")
                        .HasColumnType("bigint");

                    b.Property<int>("TaxRate")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RaidGuildId");

                    b.ToTable("Dungeons", (string)null);
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.GuildEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("AdvertiseComment")
                        .HasColumnType("text");

                    b.Property<DateTime>("AdvertiseEndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("AdvertiseType")
                        .HasColumnType("integer");

                    b.Property<long>("AllianceBlockTime")
                        .HasColumnType("bigint");

                    b.Property<long>("AllianceId")
                        .HasColumnType("bigint");

                    b.Property<string>("Banner")
                        .HasColumnType("text");

                    b.Property<int>("BannerSize")
                        .HasColumnType("integer");

                    b.Property<int>("Chaos")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DonationPoint")
                        .HasColumnType("integer");

                    b.Property<long>("DungeonBlockTime")
                        .HasColumnType("bigint");

                    b.Property<long>("DungeonId")
                        .HasColumnType("bigint");

                    b.Property<long>("Gold")
                        .HasColumnType("bigint");

                    b.Property<string>("Icon")
                        .HasColumnType("text");

                    b.Property<int>("IconSize")
                        .HasColumnType("integer");

                    b.Property<short>("MaxRecruitLevel")
                        .HasColumnType("smallint");

                    b.Property<short>("MinRecruitLevel")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("NameChanged")
                        .HasColumnType("boolean");

                    b.Property<string>("Notice")
                        .HasColumnType("text");

                    b.Property<string[]>("PermissionNames")
                        .HasMaxLength(6)
                        .HasColumnType("text[]");

                    b.Property<int[]>("PermissionSets")
                        .HasMaxLength(6)
                        .HasColumnType("integer[]");

                    b.Property<bool>("Recruiting")
                        .HasColumnType("boolean");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AllianceId")
                        .IsUnique();

                    b.HasIndex("DungeonId")
                        .IsUnique();

                    b.ToTable("Guilds", (string)null);
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.ItemEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer");

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<int?>("AuctionId")
                        .HasColumnType("integer");

                    b.Property<long?>("CharacterId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ElementalEffectAttackPoint")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ElementalEffectExpireTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ElementalEffectMagicPoint")
                        .HasColumnType("integer");

                    b.Property<int>("ElementalEffectType")
                        .HasColumnType("integer");

                    b.Property<int>("Endurance")
                        .HasColumnType("integer");

                    b.Property<int>("Enhance")
                        .HasColumnType("integer");

                    b.Property<int?>("EquippedBySummonId")
                        .HasColumnType("integer");

                    b.Property<int>("EtherealDurability")
                        .HasColumnType("integer");

                    b.Property<int>("Flag")
                        .HasColumnType("integer");

                    b.Property<int>("GenerateBySource")
                        .HasColumnType("integer");

                    b.Property<int>("Idx")
                        .HasColumnType("integer");

                    b.Property<int>("ItemResourceId")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("RelatedAuctionId")
                        .HasColumnType("bigint");

                    b.Property<int>("RemainingTime")
                        .HasColumnType("integer");

                    b.Property<long[]>("SocketItemIds")
                        .HasMaxLength(4)
                        .HasColumnType("bigint[]");

                    b.Property<int?>("StorageId")
                        .HasColumnType("integer");

                    b.Property<int>("WearInfo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("RelatedAuctionId");

                    b.ToTable("Items", (string)null);
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.ItemStorageEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CharacterId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("ItemId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("RelatedAuctionId")
                        .HasColumnType("bigint");

                    b.Property<int>("RelatedItemEnhance")
                        .HasColumnType("integer");

                    b.Property<long>("RelatedItemId")
                        .HasColumnType("bigint");

                    b.Property<int>("RelatedItemLevel")
                        .HasColumnType("integer");

                    b.Property<int>("StorageType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.HasIndex("RelatedAuctionId")
                        .IsUnique();

                    b.HasIndex("RelatedItemId")
                        .IsUnique();

                    b.ToTable("ItemStorages", (string)null);
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.PartyEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("LeadPartyId")
                        .HasColumnType("bigint");

                    b.Property<long>("LeaderId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("PartyType")
                        .HasColumnType("integer");

                    b.Property<int>("ShareMode")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LeadPartyId");

                    b.HasIndex("LeaderId")
                        .IsUnique();

                    b.ToTable("Parties", (string)null);
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.PetEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<long>("CharacterId")
                        .HasColumnType("bigint");

                    b.Property<int>("CoolTime")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("ItemId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("PetResourceId")
                        .HasColumnType("integer");

                    b.Property<bool>("WasNameChanged")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("Pets", (string)null);
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.SummonEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<long>("CardItemId")
                        .HasColumnType("bigint");

                    b.Property<long>("CharacterId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Exp")
                        .HasColumnType("bigint");

                    b.Property<int>("Fp")
                        .HasColumnType("integer");

                    b.Property<int>("Hp")
                        .HasColumnType("integer");

                    b.Property<int>("Jlv")
                        .HasColumnType("integer");

                    b.Property<int>("Jp")
                        .HasColumnType("integer");

                    b.Property<long>("LastDecreasedExp")
                        .HasColumnType("bigint");

                    b.Property<int>("Lv")
                        .HasColumnType("integer");

                    b.Property<int>("MaxLevel")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Mp")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int[]>("PreviousLevel")
                        .HasMaxLength(2)
                        .HasColumnType("integer[]");

                    b.Property<long[]>("PreviousSummonResourceIds")
                        .HasMaxLength(2)
                        .HasColumnType("bigint[]");

                    b.Property<int>("Sp")
                        .HasColumnType("integer");

                    b.Property<int>("SummonResourceId")
                        .HasColumnType("integer");

                    b.Property<int>("Transform")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CardItemId")
                        .IsUnique();

                    b.ToTable("Summons", (string)null);
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.AuctionEntity", b =>
                {
                    b.HasOne("Navislamia.Game.Models.Telecaster.CharacterEntity", "HighestBidder")
                        .WithMany("HighestBidders")
                        .HasForeignKey("HighestBidderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Navislamia.Game.Models.Telecaster.ItemEntity", "Item")
                        .WithOne("Auction")
                        .HasForeignKey("Navislamia.Game.Models.Telecaster.AuctionEntity", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Navislamia.Game.Models.Telecaster.CharacterEntity", "Seller")
                        .WithMany("Sellers")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HighestBidder");

                    b.Navigation("Item");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.CharacterEntity", b =>
                {
                    b.HasOne("Navislamia.Game.Models.Telecaster.GuildEntity", "Guild")
                        .WithMany("Members")
                        .HasForeignKey("GuildId");

                    b.HasOne("Navislamia.Game.Models.Telecaster.SummonEntity", "MainSummon")
                        .WithOne("MainSummonsMaster")
                        .HasForeignKey("Navislamia.Game.Models.Telecaster.CharacterEntity", "MainSummonId");

                    b.HasOne("Navislamia.Game.Models.Telecaster.PartyEntity", "Party")
                        .WithMany("PartyMembers")
                        .HasForeignKey("PartyId");

                    b.HasOne("Navislamia.Game.Models.Telecaster.PetEntity", "Pet")
                        .WithOne("Character")
                        .HasForeignKey("Navislamia.Game.Models.Telecaster.CharacterEntity", "PetId");

                    b.HasOne("Navislamia.Game.Models.Telecaster.GuildEntity", "PreviousGuild")
                        .WithMany("PreviousMembers")
                        .HasForeignKey("PreviousGuildId");

                    b.HasOne("Navislamia.Game.Models.Telecaster.SummonEntity", "SubSummon")
                        .WithOne("SubSummonsMaster")
                        .HasForeignKey("Navislamia.Game.Models.Telecaster.CharacterEntity", "SubSummonId");

                    b.Navigation("Guild");

                    b.Navigation("MainSummon");

                    b.Navigation("Party");

                    b.Navigation("Pet");

                    b.Navigation("PreviousGuild");

                    b.Navigation("SubSummon");
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.DungeonEntity", b =>
                {
                    b.HasOne("Navislamia.Game.Models.Telecaster.GuildEntity", "RaidGuild")
                        .WithMany()
                        .HasForeignKey("RaidGuildId");

                    b.Navigation("RaidGuild");
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.GuildEntity", b =>
                {
                    b.HasOne("Navislamia.Game.Models.Telecaster.AllianceEntity", "Alliance")
                        .WithOne("LeadGuild")
                        .HasForeignKey("Navislamia.Game.Models.Telecaster.GuildEntity", "AllianceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Navislamia.Game.Models.Telecaster.DungeonEntity", "Dungeon")
                        .WithOne("OwnerGuild")
                        .HasForeignKey("Navislamia.Game.Models.Telecaster.GuildEntity", "DungeonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alliance");

                    b.Navigation("Dungeon");
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.ItemEntity", b =>
                {
                    b.HasOne("Navislamia.Game.Models.Telecaster.CharacterEntity", "Character")
                        .WithMany("Items")
                        .HasForeignKey("CharacterId");

                    b.HasOne("Navislamia.Game.Models.Telecaster.AuctionEntity", "RelatedAuction")
                        .WithMany()
                        .HasForeignKey("RelatedAuctionId");

                    b.Navigation("Character");

                    b.Navigation("RelatedAuction");
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.ItemStorageEntity", b =>
                {
                    b.HasOne("Navislamia.Game.Models.Telecaster.CharacterEntity", "Character")
                        .WithOne("ItemStorage")
                        .HasForeignKey("Navislamia.Game.Models.Telecaster.ItemStorageEntity", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Navislamia.Game.Models.Telecaster.ItemEntity", "Item")
                        .WithOne("ItemStorage")
                        .HasForeignKey("Navislamia.Game.Models.Telecaster.ItemStorageEntity", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Navislamia.Game.Models.Telecaster.AuctionEntity", "RelatedAuction")
                        .WithOne("ItemStorage")
                        .HasForeignKey("Navislamia.Game.Models.Telecaster.ItemStorageEntity", "RelatedAuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Navislamia.Game.Models.Telecaster.ItemEntity", "RelatedItem")
                        .WithOne("RelatedItemStorage")
                        .HasForeignKey("Navislamia.Game.Models.Telecaster.ItemStorageEntity", "RelatedItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Item");

                    b.Navigation("RelatedAuction");

                    b.Navigation("RelatedItem");
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.PartyEntity", b =>
                {
                    b.HasOne("Navislamia.Game.Models.Telecaster.PartyEntity", "LeadParty")
                        .WithMany("RaidParties")
                        .HasForeignKey("LeadPartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Navislamia.Game.Models.Telecaster.CharacterEntity", "Leader")
                        .WithOne("LeadersParty")
                        .HasForeignKey("Navislamia.Game.Models.Telecaster.PartyEntity", "LeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LeadParty");

                    b.Navigation("Leader");
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.PetEntity", b =>
                {
                    b.HasOne("Navislamia.Game.Models.Telecaster.ItemEntity", "Item")
                        .WithOne("PetItem")
                        .HasForeignKey("Navislamia.Game.Models.Telecaster.PetEntity", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.SummonEntity", b =>
                {
                    b.HasOne("Navislamia.Game.Models.Telecaster.ItemEntity", "CardItem")
                        .WithOne("Summon")
                        .HasForeignKey("Navislamia.Game.Models.Telecaster.SummonEntity", "CardItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardItem");
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.AllianceEntity", b =>
                {
                    b.Navigation("LeadGuild");
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.AuctionEntity", b =>
                {
                    b.Navigation("ItemStorage");
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.CharacterEntity", b =>
                {
                    b.Navigation("HighestBidders");

                    b.Navigation("ItemStorage");

                    b.Navigation("Items");

                    b.Navigation("LeadersParty");

                    b.Navigation("Sellers");
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.DungeonEntity", b =>
                {
                    b.Navigation("OwnerGuild");
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.GuildEntity", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("PreviousMembers");
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.ItemEntity", b =>
                {
                    b.Navigation("Auction");

                    b.Navigation("ItemStorage");

                    b.Navigation("PetItem");

                    b.Navigation("RelatedItemStorage");

                    b.Navigation("Summon");
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.PartyEntity", b =>
                {
                    b.Navigation("PartyMembers");

                    b.Navigation("RaidParties");
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.PetEntity", b =>
                {
                    b.Navigation("Character");
                });

            modelBuilder.Entity("Navislamia.Game.Models.Telecaster.SummonEntity", b =>
                {
                    b.Navigation("MainSummonsMaster");

                    b.Navigation("SubSummonsMaster");
                });
#pragma warning restore 612, 618
        }
    }
}
