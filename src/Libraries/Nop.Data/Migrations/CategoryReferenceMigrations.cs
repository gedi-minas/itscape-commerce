using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Migrations;
[NopSchemaMigration("2024-12-12 21:55:00", "Category. Adding few reference properties")]
public class CategoryReferenceMigrations : ForwardOnlyMigration
{
    /// <summary>
    /// Collect the UP migration expressions
    /// </summary>
    public override void Up()
    {
        var categoryTableName = nameof(Category);
        if (!Schema.Table(categoryTableName).Column(nameof(Category.ReferenceId)).Exists())
            Alter.Table(categoryTableName)
                .AddColumn(nameof(Category.ReferenceId)).AsInt32().Nullable().Indexed("IX_ReferenceId");

        if (!Schema.Table(categoryTableName).Column(nameof(Category.ReferenceCode)).Exists())
            Alter.Table(categoryTableName)
                .AddColumn(nameof(Category.ReferenceCode)).AsString(10).Nullable().Indexed("IX_ReferenceCode");

        if (!Schema.Table(categoryTableName).Column(nameof(Category.ReferenceName)).Exists())
            Alter.Table(categoryTableName)
                .AddColumn(nameof(Category.ReferenceName)).AsString(255).Nullable();
    }
}
