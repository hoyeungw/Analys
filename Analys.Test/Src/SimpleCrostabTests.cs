﻿using Analys.Types;
using NUnit.Framework;
using Spare.Deco;
using Spare.Logger;

namespace Analys.Test {
  [TestFixture]
  public class SimpleCrostabTests {
    [Test]
    public void SimpleTest() {
      var table = Table.Build(
        new[] {"day", "name", "served", "sold", "adt"},
        new object[,] {
          {1, "Joyce", 70, 7, ""},
          {1, "Joyce", 66, 15, ""},
          {2, "Joyce", 86, 10, ""},
          {2, "Joyce", double.NaN, double.NaN, ""},
          {3, "Joyce", 96, 2, ""},
          {1, "Lance", 98, 15, ""},
          {1, "Lance", 66, 15, ""},
          {2, "Lance", 85, 12, ""},
          {2, "Lance", 63, 12, ""},
          {3, "Lance", double.NaN, double.NaN, ""},
          {1, "Naomi", 90, 14, ""},
          {1, "Naomi", 66, 9, ""},
          {2, "Naomi", double.NaN, double.NaN, ""},
          {2, "Naomi", 93, 16, ""},
          {3, "Naomi", 78, 8, ""},
        }
      );
      // var (side, head, rows) = table.ToCrostab(PivotPreset.Average(), "name", "day", "sold");
      var crostab = table.ToCrostab<Average>(
        "name",
        "day",
        "sold",
        PivotMode.Average
      );
      // rows.Deco().Logger();
      // var crostab = Crostab<Average>.Build(side, head, rows).Map(x => x.Value);
      crostab.Side.Deco().Logger();
      crostab.Head.Deco().Logger();
      crostab.Rows.Deco().Logger();
    }
  }
}