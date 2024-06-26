﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGoal.Backend.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class ChangeDecisionHelperDecimalToDouble : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<double>(
            name: "Weight",
            table: "DecisionHelperCriteria",
            type: "double precision",
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "numeric");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<decimal>(
            name: "Weight",
            table: "DecisionHelperCriteria",
            type: "numeric",
            nullable: false,
            oldClrType: typeof(double),
            oldType: "double precision");
    }
}
