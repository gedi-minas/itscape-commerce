using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Migrations;

[NopSchemaMigration("2024-12-12 21:55:00", "Manufacturer. Adding few reference properties")]
public class ManufacturersReferenceMigrations: ForwardOnlyMigration
{
    /// <summary>
    /// Collect the UP migration expressions
    /// </summary>
    public override void Up()
    {
        var manufacturerTableName = nameof(Manufacturer);
        if (!Schema.Table(manufacturerTableName).Column(nameof(Manufacturer.ReferenceId)).Exists())
            Alter.Table(manufacturerTableName)
                .AddColumn(nameof(Manufacturer.ReferenceId)).AsInt32().Nullable().Indexed("IX_ReferenceId");

        if (!Schema.Table(manufacturerTableName).Column(nameof(Manufacturer.ReferenceCode)).Exists())
            Alter.Table(manufacturerTableName)
                .AddColumn(nameof(Manufacturer.ReferenceCode)).AsString(10).Nullable().Indexed("IX_ReferenceCode");

        if (!Schema.Table(manufacturerTableName).Column(nameof(Manufacturer.ReferenceName)).Exists())
            Alter.Table(manufacturerTableName)
                .AddColumn(nameof(Manufacturer.ReferenceName)).AsString(255).Nullable();
    }
}
