using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PackIT.Infrastructure.EF.Models;

namespace PackIT.Infrastructure.EF.Config;

internal sealed class ReadConfiguration
	: IEntityTypeConfiguration<PackingListReadModel>,
		IEntityTypeConfiguration<PackingItemReadModel>
{
	void IEntityTypeConfiguration<PackingListReadModel>.Configure(
		EntityTypeBuilder<PackingListReadModel> builder
	)
	{
		builder.ToTable("packingLists");
		builder.HasKey(pl => pl.Id);
		builder
			.Property(pl => pl.Localization)
			.HasConversion(l => l.ToString(), l => LocalizationReadModel.Create(l));
		builder.HasMany(pl => pl.Items).WithOne(pi => pi.PackingList);
	}

	void IEntityTypeConfiguration<PackingItemReadModel>.Configure(
		EntityTypeBuilder<PackingItemReadModel> builder
	)
	{
		builder.ToTable("packingItems");
	}
}
