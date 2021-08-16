﻿using NUnit.Framework;
using Spare;
using Mu = Analys.Mutable;
using Veho;
using static Palett.Presets;

namespace Analys.Test {
  [TestFixture]
  public class MutableTableTest {
    [Test]
    public void TableDecoTest() {
      var table = Mu::Table<object>.Build(
        Li.From("foo", "bar", "zen"),
        Li.From(
          Li.From<object>(1, "Tesla", 10),
          Li.From<object>(2, "Faraday", 120),
          Li.From<object>(3, "BYD", 1250)
        )
      );
      table.MutableTableToTable().Deco(presets: (Planet, Fresh)).Logger();
    }

    [Test]
    public void CrostabDecoTest() {
      var table = Crostab<object>.Build(
        new[] {"foo", "bar", "zen"},
        new[] {"foo", "bar", "zen"},
        new object[,] {
          {1, "Tesla", 10},
          {2, "Faraday", 120},
          {3, "BYD", 1250}
        });
      table.Deco(tab: 2, presets: (Planet, Fresh)).Logger();
    }
  }
}