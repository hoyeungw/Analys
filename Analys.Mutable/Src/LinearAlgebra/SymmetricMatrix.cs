﻿using System;
using System.Collections.Generic;
using System.Linq;
using Veho.Sequence;
using Veho.Mutable.LinearAlgebra;
using Mu = Veho.Mutable.LinearAlgebra;

namespace Analys.Mutable.LinearAlgebra {
  public static class SymmetricMatrix {
    public static Crostab<T> SelectBy<T>(Crostab<T> crostab, IReadOnlyList<int> indices) {
      return Crostab<T>.Build(
        crostab.Side.SelectBy(indices),
        crostab.Head.SelectBy(indices),
        Mu::SymmetricMatrix.SelectBy(crostab.Rows, indices)
      );
    }
    public static Crostab<T> UpperTriangular<T>(Crostab<T> crostab) {
      return Crostab<T>.Build(
        crostab.Side.Slice(),
        crostab.Head.Slice(),
        Mu::SymmetricMatrix.UpperTriangular(crostab.Rows)
      );
    }
    public static Crostab<T> LowerTriangular<T>(Crostab<T> crostab) {
      return Crostab<T>.Build(
        crostab.Side.Slice(),
        crostab.Head.Slice(),
        Mu::SymmetricMatrix.LowerTriangular(crostab.Rows)
      );
    }
    public static IEnumerable<Crostab<T>> IntersectionalBlocks<T>(this Crostab<T> crostab, T signal) where T : IEquatable<T> {
      var rowSkipper = Skipper<List<T>>.Build(crostab.Rows);
      foreach (var index in rowSkipper.IntoIndexIter()) {
        var intersectionalIndices = crostab.Rows.FindIntersectional(index, signal).ToList();
        rowSkipper.AcquireIndices(intersectionalIndices);
        if (intersectionalIndices.Count <= 1) continue;
        // common.Deco().Says(index.ToString());
        yield return SymmetricMatrix.SelectBy(crostab, intersectionalIndices);
      }
    }
  }
}