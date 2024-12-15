using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Migrations;
[NopSchemaMigration("2024-12-13 08:40:00", "Product. Adding few reference properties")]
public class ProductReferenceMigrations : ForwardOnlyMigration
{
    /// <summary>
    /// Collect the UP migration expressions
    /// </summary>
    public override void Up()
    {
        var productTableName = nameof(Product);
        if (!Schema.Table(productTableName).Column(nameof(Product.ReferenceId)).Exists())
            Alter.Table(productTableName)
                .AddColumn(nameof(Product.ReferenceId)).AsInt32().Nullable().Indexed("IX_ReferenceId");

        if (!Schema.Table(productTableName).Column(nameof(Product.ReferenceCode)).Exists())
            Alter.Table(productTableName)
                .AddColumn(nameof(Product.ReferenceCode)).AsString(10).Nullable().Indexed("IX_ReferenceCode");

        if (!Schema.Table(productTableName).Column(nameof(Product.ReferenceName)).Exists())
            Alter.Table(productTableName)
                .AddColumn(nameof(Product.ReferenceName)).AsString(255).Nullable();
    }
}
